using Res.Scripts.Modul.UIFrame.BaseUI;
using UnityEngine.UI;

namespace demo.script
{
    public class InfoDialog : Dialog
    {
        public Button mBackBtn;
        public override void Init()
        {
            base.Init();
            mBackBtn.onClick.AddListener(() =>
            {
                MainRoot.UIManager.Back();
            });
        }

        protected override void UpdateShow()
        {
            base.UpdateShow();
        }
    }
}