namespace 贪吃蛇
{
    class EndScene : UIScene
    {

        protected override void Init()
        {
            base.Init();
            title = "游戏结束";
            optionName1 = "返回主菜单";
            optionName2 = "退出游戏";
        }

        protected override void DoOption1()
        {
            Game.scene = E_Scene.Start;
        }

        protected override void DoOption2()
        {
            Game.scene = E_Scene.None;
        }
    }
}
