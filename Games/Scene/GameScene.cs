using System;
using System.Collections.Generic;

namespace 贪吃蛇
{
    class GameScene : IScene
    {
        public static GameScene instance { get; private set; }

        private bool _gameover;

        private GameUnit _food;
        private Map _map = new Map();
        private Snake _snake = new Snake();

        private Random _rand = new Random();
        private Dictionary<Pos, E_UnitType> _dict = new Dictionary<Pos, E_UnitType>();

        private void Init()
        {
            Console.Clear();

            _dict.Clear();
            _gameover = false;
            _lastTickTime = (DateTime.Now.Millisecond - TickInterval + 1000) % 1000;
            instance = this;

            _map.Init();
            _snake.Init();
            GenerateFood();
        }

        public void Show()
        {
            Init();

            while (!_gameover)
            {
                UpdateScene();
                UpdateInput();
            }
        }

        private int _lastTickTime;
        private const int TickInterval = 350;

        #region 视图/输入更新
        private void UpdateScene()
        {
            if (((DateTime.Now.Millisecond - _lastTickTime + 1000) % 1000) < TickInterval)
            {
                return;
            }
            _lastTickTime = (_lastTickTime + TickInterval) % 1000;

            _snake.Update();
        }

        private void UpdateInput()
        {
            if (Console.KeyAvailable)
            {
                _snake.UpdateDir();
            }
        }
        #endregion

        public E_UnitType GetUnitType(Pos pos)
        {
            if (_dict.TryGetValue(pos, out E_UnitType unitType))
            {
                return unitType;
            }

            return E_UnitType.None;
        }

        #region 添加单位
        public GameUnit AddUnit(E_UnitType unitType)
        {
            GameUnit unit = new GameUnit(unitType);

            do
            {
                // 生成地图范围内的偶数x（不含边界）
                unit.pos.x = _rand.Next(2, Game.Window_Width - 2);
                if ((unit.pos.x & 1) != 0)
                {
                    unit.pos.x ^= 1;
                }

                // 生成地图内范围的整数y（不含边界）
                unit.pos.y = _rand.Next(1, Game.Window_Height - 1);
            } while (_dict.ContainsKey(unit.pos));

            _dict.Add(unit.pos, unitType);
            unit.Draw();

            return unit;
        }

        public bool AddUnit(E_UnitType unitType, Pos pos, out GameUnit gameUnit)
        {
            if (_dict.ContainsKey(pos))
            {
                gameUnit = null;
                return false;
            }

            gameUnit = new GameUnit(unitType, pos.x, pos.y);
            _dict.Add(pos, unitType);
            gameUnit.Draw();

            return true;
        }

        public bool AddUnit(E_UnitType unitType, int x, int y, out GameUnit gameUnit)
        {
            if (_dict.ContainsKey(new Pos(x, y)))
            {
                gameUnit = null;
                return false;
            }

            gameUnit = new GameUnit(unitType, x, y);
            _dict.Add(gameUnit.pos, unitType);
            gameUnit.Draw();

            return true;
        }

        #endregion

        #region 移除单位
        public void RemoveUnit(Pos pos)
        {
            _dict.Remove(pos);
            ClearUnitView(pos);
        }

        public void RemoveUnit(GameUnit unit)
        {
            RemoveUnit(unit.pos);
        }

        private void ClearUnitView(Pos pos)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("  ");
        }
        #endregion

        public void GameOver()
        {
            _gameover = true;

            Game.scene = E_Scene.End;
        }

        public void GenerateFood()
        {
            _food = AddUnit(E_UnitType.Food);
        }
    }
}
