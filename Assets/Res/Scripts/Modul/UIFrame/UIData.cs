using System.Collections.Generic;
using Res.Scripts.Modul.UIFrame.BaseUI;

namespace Res.Scripts.Modul.UIFrame
{
    public class UIData
    {
        public View View { get; private set; }
        public Stack<Dialog> OverlayUIStack { get; private set; }

        public Stack<FixedUI> TopUIStack { get; private set; }

        public UIData(View basic)
        {
            View = basic;
            OverlayUIStack = new Stack<Dialog>();
            TopUIStack = new Stack<FixedUI>();
        }
    }
}