using System;

namespace 贪吃蛇
{
    class Game
    {
        public const int Window_Width = 80;
        public const int Window_Height = 40;

        private static IScene _curScene;

        public static E_Scene scene
        {
            set
            {
                switch (value)
                {
                    case E_Scene.Start:
                        _curScene = new StartScene();
                        break;
                    case E_Scene.Game:
                        _curScene = new GameScene();
                        break;
                    case E_Scene.End:
                        _curScene = new EndScene();
                        break;
                    default:
                        _curScene = null;
                        break;
                }
            }
        }

        private void Init()
        {
            scene = E_Scene.Start;

            Console.CursorVisible = false;

            Console.SetWindowSize(Window_Width, Window_Height + 1);
            Console.SetBufferSize(Window_Width, Window_Height + 1);
        }

        public void Start()
        {
            Init();

            while (_curScene != null)
            {
                _curScene.Show();
            }

            Exit();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
