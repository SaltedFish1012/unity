using Res.Scripts.Modul.UIFrame.BaseUI;
using UIFrame.Base;
using UnityEngine;
using UnityEngine.UI;

namespace demo.script
{
    public class TextView : View
    {
        public Button mBackBtn;
        public Button mAddBtn;
        public Button mDialogBtn;
        public override void Init()
        {
            base.Init();
            Debug.Log(" testciew init");
            InitUI(MUIEnum.Test_View,MainUIHandler.Name);
            mAddBtn.onClick.AddListener(() =>
            {
                // MainUIData a = (MainUIData)dataHandler.GetData();
                // a.coin -= 1;
                IDataHandler data =  GetDataHandlerManager().GetHandler(MainUIHandler.Name);
                MainUIData a = (MainUIData) data.GetData();
                a.coin -= 1;
                data.UpdataData(a);
                
                EventMgr.Single.EventTrigger(EventConfig.TEST_NOTICE,"wdnmd");
            } );
            mBackBtn.onClick.AddListener(()=>{ MainRoot.UIManager.Back(); });
            mDialogBtn.onClick.AddListener((() => {MainRoot.UIManager.ShowUI(MUIEnum.Info_Dialog);}));
            
            MainUIData mdata =  (MainUIData)dataHandler.GetData();
            transform.Find("coin").GetComponent<Text>().text = mdata.coin.ToString();
        }

        protected override void UpdateShow()
        {
            
            base.UpdateShow();
            MainUIData data =  (MainUIData)dataHandler.GetData();
            transform.Find("coin").GetComponent<Text>().text = data.coin.ToString();
        }
    }
}