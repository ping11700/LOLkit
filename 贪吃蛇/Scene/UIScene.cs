using System;

namespace 贪吃蛇
{
    class UIScene : IScene
    {
        protected string title;
        protected string optionName1;
        protected string optionName2;

        private int _curOption;

        protected virtual void Init()
        {
            _curOption = 0;
        }

        public void Show()
        {
            Init();

            while (true)
            {
                Draw();
                switch (Input.Key)
                {
                    case E_Key.Up:
                        _curOption = Math.Max(0, _curOption - 1);
                        break;
                    case E_Key.Down:
                        _curOption = Math.Min(1, _curOption + 1);
                        break;
                    case E_Key.Enter:
                        DoOption();
                        return;
                }
            }
        }

        private void Draw()
        {
            Console.Clear();

            // 标题
            Console.SetCursorPosition(Game.Window_Width / 2 - title.Length, Game.Window_Height / 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(title);

            // 选项一
            Console.SetCursorPosition(Game.Window_Width / 2 - optionName1.Length, Game.Window_Height / 2);
            Console.ForegroundColor = _curOption == 0? ConsoleColor.Red: ConsoleColor.White;
            Console.Write(optionName1);

            // 选项二
            Console.SetCursorPosition(Game.Window_Width / 2 - optionName2.Length, Game.Window_Height / 2 + 2);
            Console.ForegroundColor = _curOption == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(optionName2);
        }

        private void DoOption()
        {
            if (_curOption == 0)
            {
                DoOption1();
            }
            else
            {
                DoOption2();
            }

        }

        protected virtual void DoOption1()
        {

        }

        protected virtual void DoOption2()
        {

        }
    }
}
