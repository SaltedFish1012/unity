using System;
using UIFrame.Base;

namespace demo.script
{
    public class MainUIHandler:IDataHandler
    {
        public const string Name = "MainUIProxy";
        private MainUIData data;
        public MainUIHandler()
        {
            InitData();
        }
        
        public IData GetData()
        {
            return data;
        }

        public void InitData()
        {
            data = new MainUIData(1000);
        }

        public string GetName()
        {
            return Name;
        }

        public void UpdataData(IData newData)
        {
            data = (MainUIData) newData;
            if (UpdateShow != null)
            {
                UpdateShow();
            }
        }

        public Action UpdateShow { get; set; }
    }
}