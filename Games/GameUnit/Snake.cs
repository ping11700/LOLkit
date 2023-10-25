using System;
using System.Collections.Generic;
using System.Linq;

namespace 贪吃蛇
{
    class Snake : IDraw
    {
        private GameUnit _head;
        private Queue<GameUnit> _trunks = new Queue<GameUnit>();

        private E_Dir _dir;

        private Pos _nextPos = new Pos();

        public void Init()
        {
            if (GameScene.instance.AddUnit(E_UnitType.SnakeHead, Game.Window_Width / 3, Game.Window_Height / 2, out _head))
            {
                _dir = E_Dir.Right;
                return;
            }

            Console.Error.Write("初始化蛇头失败");
        }

        public void Draw()
        {
            _head.Draw();

            foreach (GameUnit trunk in _trunks)
            {
                trunk.Draw();
            }
        }

        public void Update()
        {
            GetNextPos();
            Move();
        }

        private void GetNextPos()
        {
            _nextPos = _head.pos;

            switch (_dir)
            {
                case E_Dir.Left:
                    _nextPos.x -= 2;
                    break;
                case E_Dir.Right:
                    _nextPos.x += 2;
                    break;
                case E_Dir.Up:
                    --_nextPos.y;
                    break;
                case E_Dir.Down:
                    ++_nextPos.y;
                    break;
            }
        }

        private void Move()
        {
            switch (GameScene.instance.GetUnitType(_nextPos))
            {
                case E_UnitType.Food:
                    GameScene.instance.RemoveUnit(_head);
                    GameScene.instance.RemoveUnit(_nextPos);

                    if (GameScene.instance.AddUnit(E_UnitType.SnakeTrunk, _head.pos, out GameUnit unit))
                    {
                        _trunks.Enqueue(unit);
                    }
                    else
                    {
                        Console.Error.Write("系统出错");
                    }

                    if (!GameScene.instance.AddUnit(E_UnitType.SnakeHead, _nextPos, out _head))
                    {
                        Console.Error.Write("系统出错");
                    }
                    GameScene.instance.GenerateFood();
                    break;

                case E_UnitType.Wall:
                case E_UnitType.SnakeTrunk:
                    GameScene.instance.GameOver();
                    break;

                case E_UnitType.SnakeHead:
                    Console.Error.Write("系统出错");
                    break;

                default:
                    bool hasTrunk = _trunks.Count > 0;

                    if (hasTrunk)
                    {
                        GameScene.instance.RemoveUnit(_trunks.Dequeue());
                    }
                    GameScene.instance.RemoveUnit(_head);

                    if (hasTrunk)
                    {
                        if (GameScene.instance.AddUnit(E_UnitType.SnakeTrunk, _head.pos, out GameUnit gameUnit))
                        {
                            _trunks.Enqueue(gameUnit);
                        }
                        else
                        {
                            Console.Error.Write("系统出错");
                        }
                    }

                    if (!GameScene.instance.AddUnit(E_UnitType.SnakeHead, _nextPos, out _head))
                    {
                        Console.Error.Write("系统出错");
                    }
                    break;
            }
        }

        public void UpdateDir()
        {
            E_Dir dir = Input.Dir;

            // 输入无效
            if (dir == E_Dir.None)
            {
                return;
            }

            // 只有蛇头无转向限制
            if (_trunks.Count == 0)
            {
                _dir = dir;
                return;
            }

            if ((dir == E_Dir.Left && _head.OnRight(_trunks.First()))
                || (dir == E_Dir.Right && _head.OnLeft(_trunks.First()))
                || (dir == E_Dir.Up && _head.Under(_trunks.First()))
                || (dir == E_Dir.Down && _head.OnTop(_trunks.First())))
            {
                return;
            }

            _dir = dir;
        }
    }
}
