namespace 贪吃蛇
{
    class StartScene : UIScene
    {

        protected override void Init()
        {
            base.Init();
            title = "贪吃蛇";
            optionName1 = "开始游戏";
            optionName2 = "退出游戏";
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
