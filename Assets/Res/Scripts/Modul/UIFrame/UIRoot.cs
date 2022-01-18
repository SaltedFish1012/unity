using System;
using UIFrame.Base;

namespace Res.Scripts.Modul.UIFrame
{
    /// <summary>
    ///  uiroot实现
    /// </summary>
    public class UIRoot : IUIRoot
    {
        public virtual void Start()
        {
            InitUISystem();
            //throw new NotImplementedException();
        }

        protected override void InitUISystem()
        {
            UIManager = new UIMgr();
            if (LayerManager == null)
            {
                LayerManager = gameObject.AddComponent<UILayerMgr>();
                LayerManager.Init();
            }
            
            UIManager.AddUIInitListener(UILayerMgr.Single.InitFun);
            UIManager.AddUIActiveListener(UILayerMgr.Single.ActiveFun);
        }
    }
}