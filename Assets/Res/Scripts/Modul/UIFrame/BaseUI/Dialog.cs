using System;

namespace Res.Scripts.Modul.UIFrame.BaseUI
{
    public class Dialog : UIBase
    {
        public override UILayer GetLayer()
        {
           // throw new Exception();
           return UILayer.Dialog;
        }
    }
}