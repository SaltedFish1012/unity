using UIFrame.Base;

namespace demo.script
{
    public class MUIPathMgr : IUIPathManager
    {
        /// <summary>
        /// 预制位置需加入到字典中
        /// </summary>
        protected override void InitPathDic()
        {
            UIPathDic[MUIEnum.MAIN_VIEW.ToString()] = "Prefabs/MainView";
            UIPathDic[MUIEnum.Test_View.ToString()] = "Prefabs/TestView";
            UIPathDic[MUIEnum.Info_Dialog.ToString()] = "Prefabs/InforDialog";
        }
    }
}