namespace demo.script
{
    public class MUIDataHandlerMgr:Res.Scripts.Modul.UIFrame.UIDataHandlerMgr
    {
        
            protected override void RegisterHandler()
            {
                 handlerDic.Add(NormalInfoDataHandler.NAME, new NormalInfoDataHandler());
                 handlerDic.Add(MainUIHandler.Name, new MainUIHandler());
            }
        
    }
}