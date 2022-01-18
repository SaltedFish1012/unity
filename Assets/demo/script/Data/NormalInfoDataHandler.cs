using System;
using UIFrame.Base;
using demo.script;

namespace demo.script
{


    public class NormalInfoDataHandler : IDataHandler
    {
        public const string NAME = "NormalInfoProxy";
        private NormalInfoData data;

        public Action UpdateShow { get; set; }

        public NormalInfoDataHandler()
        {
            InitData();
        }

        public void InitData()
        {
            //data = new NormalInfoData("BlueMonk", 28, 1);
            data = new NormalInfoData("dd", 11, 2);
        }

        public IData GetData()
        {
            return data;
        }

        public void UpdataData(IData newData)
        {
            data = (NormalInfoData) newData;
            if (UpdateShow != null)
            {
                UpdateShow();
            }
        }

        public string GetName()
        {
            return NAME;
        }
    }
}