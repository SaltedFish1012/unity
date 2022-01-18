using System;
using UIFrame.Base;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

    /// <summary>
    ///  UIbase具体实现 11/30
    /// </summary>
    public class UIBase : IUIBase
    {
        private UIStateEnum uiState;
        protected IDataHandler dataHandler;
        private Func<Object, bool> callBackAction;
        /// <summary>
        /// 初始化的回调
        /// </summary>
        private Func<Object,bool> InitAction;
        /// <summary>
        /// 对象显示或隐藏状态的回调
        /// </summary>
        private Func<bool, bool> ObjectActiveAction;
        public override void AddInitListener(Func<Object, bool> action)
        {
            InitAction = action;
        }
        
        public override void AddActiveListener(Func<bool,bool> action)
        {
            ObjectActiveAction = action;
        }

        public override UILayer GetLayer()
        {
            throw new System.NotImplementedException();
        }

        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            return IUIRoot.DataHandlerManager;
        }

        protected override void SetActive(bool value)
        {
            try
            {
                if (ObjectActiveAction == null)
                {
                    gameObject.SetActive(value);
                }
                else
                {
                    if (!ObjectActiveAction(value))
                    {
                        gameObject.SetActive(value);
                    }
                }
            }
            catch (Exception)
            {
                Debug.LogError(gameObject.name+ " ObjectActiveAction has ERROR");
                gameObject.SetActive(value);
            }
        }

        protected override void SetUIState(UIStateEnum state)
        {
            HandleState(uiState, state);
            uiState = state;
        }

        protected override UIStateEnum GetUIState()
        {
            return uiState;
        }

        protected override void HandleState(UIStateEnum state1, UIStateEnum state2)
        {
            switch (state2)
            {
                case UIStateEnum.HIDE:
                    Hide();
                    break;
                case UIStateEnum.INIT:
                    Init();
                    break;
                case UIStateEnum.SHOW:
                    if (state1 == UIStateEnum.NOTINIT)
                    {
                        Init();
                        Show();
                    }
                    else
                    {
                        Show();
                    }
                    break;
                case UIStateEnum.CLOSE:
                    break;
                case UIStateEnum.NOTINIT:
                    break;
                default:
                    break;
            }
        }
        
        //**************  UIbase 虚方法  *******************//

        /// <summary>
        ///  ui打开
        /// </summary>
        public virtual void Show()
        {
            UpdateShow();
            SetActive(true);
        }

        /// <summary>
        ///  ui 关闭
        /// </summary>
        public virtual void Hide()
        {
            SetActive(false);
        }

        public virtual void Init()
        {
            if (InitAction != null)
            {
                InitAction(gameObject);
            }
        }
        
        /// <summary>
        /// 初始化UI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataHandlerName"></param>
        protected void InitUI<T>(T id, string dataHandlerName = null)
        {
            ID = id.ToString();
            uiState = UIStateEnum.NOTINIT;
            if (!string.IsNullOrEmpty(dataHandlerName))
            {
                dataHandler = GetDataHandlerManager().GetHandler(dataHandlerName);
                dataHandler.UpdateShow += UpdateShow;
            }
        }
        
        /// <summary>
        /// 刷新UI显示
        /// </summary>
        protected virtual void UpdateShow()
        {
            
        }
        
        /// <summary>
        /// 获取当前UI的数据类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual T GetData<T>() where T : IData
        {
            if (dataHandler == null)
            {
                throw new Exception("This dataHandler is null." +
                                    "Please call the InitUI method in the Init method" +
                                    " to initialize the dataHandler");
            }
            return (T)dataHandler.GetData();
        }
        
        public virtual void HandleNotification(INotification notification)
        {
        }
    }
