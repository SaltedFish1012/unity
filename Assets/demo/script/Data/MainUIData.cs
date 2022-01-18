using UIFrame.Base;

namespace demo.script
{
    public class MainUIData:IData
    {
        public int coin
        {
            get;
            set;
        }

        public MainUIData(int _coin)
        {
            coin = _coin;
        }
    }
}