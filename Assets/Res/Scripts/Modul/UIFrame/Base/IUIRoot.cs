using UnityEngine;
using System.Collections;


namespace UIFrame.Base
{
    /// <summary>
    /// 负责所有系统的初始化，并保存所有系统的引用
    /// </summary>
    public abstract class IUIRoot : MonoBehaviour
    {
        public static IUIManager UIManager { get; protected set; }
        public static IUIDataHandlerManager DataHandlerManager { get; protected set; }
        public static IUILayerManager LayerManager { get; protected set; }
       // public static IUIEffectManager UIEffectManager { get; protected set; }
        protected abstract void InitUISystem();
    }
}
