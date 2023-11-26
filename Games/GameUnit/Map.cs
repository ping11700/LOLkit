using System.Collections.Generic;

namespace 贪吃蛇
{
    class Map : IDraw
    {
        private List<GameUnit> wallList = new List<GameUnit>();

        public void Init()
        {
            wallList.Clear();

            int x, x2, y, y2;

            y = 0;
            y2 = Game.Window_Height - 1;
            for (x = 0; x < Game.Window_Width; x += 2)
            {
                TryAddUnit(x, y);
                TryAddUnit(x, y2);
            }

            x = 0;
            x2 = Game.Window_Width - 2;
            for (y = 1; y < y2; ++y)
            {
                TryAddUnit(x, y);
                TryAddUnit(x2, y);
            }
        }

        private void TryAddUnit(int x, int y)
        {
            if (GameScene.instance.AddUnit(E_UnitType.Wall, x, y, out GameUnit unit))
            {
                wallList.Add(unit);
            }
        }

        public void Draw()
        {
            wallList.ForEach((wall) =>
            {
                wall.Draw();
            });
        }
    }
}
