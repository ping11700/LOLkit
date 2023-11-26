namespace 贪吃蛇
{
    class StartScene : UIScene
    {

        protected override void Init()
        {
            base.Init();
            title = "贪吃蛇(https://github.com/ping11700/LOLKit)";
            optionName1 = "开始游戏";
            optionName2 = "退出游戏";
            optionName3 = "J 开始"; 
        }

        protected override void DoOption1()
        {
            Game.scene = E_Scene.Game;
        }

        protected override void DoOption2()
        {
            Game.scene = E_Scene.None;
        }
    }
}
