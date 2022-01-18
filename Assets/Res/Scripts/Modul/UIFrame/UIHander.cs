using System;
using System.Collections.Generic;
using Res.Scripts.Modul.UIFrame.BaseUI;
using UIFrame.Base;
using Object = UnityEngine.Object;
namespace Res.Scripts.Modul.UIFrame
{
    public class UIHandler
    {
        private UIData data;
        public View View
        {
            get
            {
                return data.View;
            }
        }

        public UIHandler(IUIBase View)
        {
            if (View != null)
            {
                data = new UIData((View)View);
            }
            else
            {
                throw new Exception("View is null");
            }
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        /// <param name="ui"></param>
        public void Show(IUIBase ui)
        {
            switch (ui.GetLayer())
            {
                case UILayer.View:
                    ShowUI<View>(ui);
                    break;
                case UILayer.Dialog:
                    ShowUI(ui, data.OverlayUIStack);
                    break;
                case UILayer.FixedUI:
                    ShowUI(ui, data.TopUIStack);
                    break;
            }
        }
        /// <summary>
        /// 返回方法中UI的显示
        /// </summary>
        public void BackToShow()
        {
            ShowUI<View>(data.View);
            if (data.OverlayUIStack.Count > 0)
            {
                data.OverlayUIStack.Peek().UIState = UIStateEnum.SHOW;
            }
            if (data.TopUIStack.Count > 0)
            {
                data.TopUIStack.Peek().UIState = UIStateEnum.SHOW;
            }
        }
        /// <summary>
        /// 隐藏UI
        /// </summary>
        /// <param name="showLayer">当前即将显示的UI的层级</param>
        public void Hide(UILayer showLayer)
        {
            HideUI<View>(showLayer, UILayer.View);
            HideUI(showLayer, UILayer.Dialog, data.OverlayUIStack);
            HideUI(showLayer, UILayer.FixedUI, data.TopUIStack);
        }
        /// <summary>
        /// 返回上一界面
        /// </summary>
        /// <returns>
        ///     true代表Overlay或Top层有界面返回成功，
        ///     若为false，代表需要返回的是当前数据类的View
        /// </returns>
        public bool Back()
        {
            if (CloseUI(data.TopUIStack))
            {
                return true;
            }
            else
            {
                if (CloseUI(data.OverlayUIStack))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 添加对UI的监听
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="initAction"></param>
        /// <param name="activeAction"></param>
        public void AddListener(IUIBase ui,Func<Object, bool> initAction,Func<bool, bool> activeAction)
        {
            if (ui.UIState == UIStateEnum.NOTINIT)
            {
                ui.AddInitListener(initAction);
                ui.AddActiveListener(activeAction);
            }
        }
        /// <summary>
        /// 显示UI的处理方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ui"></param>
        /// <param name="stack"></param>
        private void ShowUI<T>(IUIBase ui, Stack<T> stack = null) where T : IUIBase
        {
            if (stack != null)
            {
                if (stack.Count > 0)
                {
                    stack.Peek().UIState = UIStateEnum.HIDE;
                }
                stack.Push((T)ui);
            }
            ui.UIState = UIStateEnum.SHOW;
        }
        /// <summary>
        /// 隐藏UI的处理方法
        /// 当其他高于此层级UI显示时，隐藏UI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="showLayer"></param>
        /// <param name="targetLayer"></param>
        /// <param name="stack"></param>
        private void HideUI<T>(UILayer showLayer, UILayer targetLayer, Stack<T> stack = null) where T : IUIBase
        {
            if (showLayer <= targetLayer)
            {
                if (stack != null)
                {
                    if (stack.Count > 0)
                    {
                        stack.Peek().UIState = UIStateEnum.HIDE;
                    }
                }
                else
                {
                    data.View.UIState = UIStateEnum.HIDE;
                }
            }
        }
        /// <summary>
        /// 关闭UI界面
        /// 当从此界面返回，请处栈内数据并隐藏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool CloseUI<T>(Stack<T> stack) where T : IUIBase
        {
            if (stack.Count > 0)
            {
                stack.Pop().UIState = UIStateEnum.HIDE;
                return true;
            }

            return false;
        }
    }
    
}