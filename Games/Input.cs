using System;

namespace 贪吃蛇
{
    enum E_Key
    {
        None,
        Up,
        Down,
        Left,
        Right,
        Enter,
    }

    enum E_Dir
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    class Input
    {

        public static E_Key Key
        {
            get
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        return E_Key.Up;
                    case ConsoleKey.S:
                        return E_Key.Down;
                    case ConsoleKey.A:
                        return E_Key.Left;
                    case ConsoleKey.D:
                        return E_Key.Right;
                    case ConsoleKey.J:
                        return E_Key.Enter;
                    default:
                        return E_Key.None;
                }
            }
        }

        public static E_Dir Dir
        {
            get
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        return E_Dir.Up;
                    case ConsoleKey.S:
                        return E_Dir.Down;
                    case ConsoleKey.A:
                        return E_Dir.Left;
                    case ConsoleKey.D:
                        return E_Dir.Right;
                    default:
                        return E_Dir.None;
                }
            }
        }
    }
}
