using System;

namespace 贪吃蛇
{
    struct Pos
    {
        public int x;
        public int y;

        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class GameUnit : IDraw
    {
        public Pos pos = new Pos();

        private E_UnitType _type;

        private ConsoleColor color;
        private string tag;

        public GameUnit(E_UnitType unitType)
        {
            type = unitType;
        }

        public GameUnit(E_UnitType unitType, int x, int y) : this(unitType)
        {
            pos.x = x;
            pos.y = y;
        }

        #region 位置判断
        public bool OnLeft(GameUnit unit)
        {
            if (pos.y != unit.pos.y)
            {
                return false;
            }

            return pos.x + 2 == unit.pos.x;
        }

        public bool OnRight(GameUnit unit)
        {
            if (pos.y != unit.pos.y)
            {
                return false;
            }

            return pos.x - 2 == unit.pos.x;
        }

        public bool OnTop(GameUnit unit)
        {
            if (pos.x != unit.pos.x)
            {
                return false;
            }

            return pos.y + 2 == unit.pos.y;
        }

        public bool Under(GameUnit unit)
        {
            if (pos.x != unit.pos.x)
            {
                return false;
            }

            return pos.y - 2 == unit.pos.y;
        }

        #endregion

        #region 设置单位类别
        public E_UnitType type
        {
            get => _type;

            set
            {
                _type = value;

                switch (value)
                {
                    case E_UnitType.Wall:
                        color = ConsoleColor.Red;
                        tag = "■";
                        break;
                    case E_UnitType.Food:
                        color = ConsoleColor.Blue;
                        tag = "¤";
                        break;
                    case E_UnitType.SnakeHead:
                        color = ConsoleColor.Yellow;
                        tag = "●";
                        break;
                    case E_UnitType.SnakeTrunk:
                        color = ConsoleColor.Green;
                        tag = "◎";
                        break;
                    default:
                        color = ConsoleColor.White;
                        tag = "  ";
                        break;
                }
            }
        }
        #endregion

        public void SetPos(int x, int y)
        {
            pos.x = x;
            pos.y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = color;
            Console.Write(tag);
        }
    }
}
