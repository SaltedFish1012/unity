using System;
using System.Collections.Generic;
using Res.Scripts.Modul.UIFrame.BaseUI;
using UIFrame.Base;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Res.Scripts.Modul.UIFrame
{
    /// <summary>
    ///  对uimgr 的接口实现
    /// </summary>
    public class UIMgr:IUIManager
    {
        private Func<string,Object, bool> UIInitAction;
        private Func<string,bool, bool> UIActiveAction;
        private Stack<UIHandler> uiStack;
        private Dictionary<string,Transform> prefabPool;
        
        public UIMgr()
        {
            uiStack = new Stack<UIHandler>();
            prefabPool = new Dictionary<string, Transform>();
        }
        public  void AddUIInitListener(Func<string, Object, bool> action)
        {
            UIInitAction = action;
        }

        public void AddUIActiveListener(Func<string, bool, bool> action)
        {
            UIActiveAction = action;
        }

        /// <summary>
        /// 根据UI的ID显示UI
        /// </summary>
        /// <param name="id"></param>
        public void ShowUI<T>(T id)
        {
            Transform uiTrans = SpawnUI(id.ToString());
            IUIBase ui = uiTrans.GetComponent<IUIBase>();
            if (ui == null)
                throw new Exception("Can't find UIBase component");

            if (ui.GetLayer() == UILayer.View)
            {
                UIHandler newHandler = new UIHandler(ui);
                if (uiStack.Count > 0)
                {
                    uiStack.Peek().Hide(ui.GetLayer());
                }
                AddListener(ui,id.ToString(), newHandler);
                newHandler.Show(ui);
                uiStack.Push(newHandler);
            }
            else
            {
                AddListener(ui,id.ToString(), uiStack.Peek());
                uiStack.Peek().Show(ui);
            }
        }

        /// <summary>
        /// 返回上一界面
        /// </summary>
        public void Back()
        {
            if (!uiStack.Peek().Back() && uiStack.Count > 1)
            {
                uiStack.Pop().Hide(UILayer.View);
                UIHandler handler = uiStack.Peek();
                handler.BackToShow();
            }
        }
        //************* 函数 ************//
        private Transform SpawnUI(string id)
        {
            //LoadMgr.Single.LoadPrefab(path);
            
            string path = IUIPathManager.GetPath(id);
            if (!string.IsNullOrEmpty(path))
            {
                if (!prefabPool.ContainsKey(id) || prefabPool[id] == null)
                {
                    prefabPool[id] = UITool.ProduceUI(path);
                }
                return prefabPool[id];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过UIHandler统一添加UI对UIInitAction及UIActiveAction的监听
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        private void AddListener(IUIBase ui, string id,UIHandler handler)
        {
            handler.AddListener(ui, obj=>UIInitAction(id.ToString(),obj), isActive => UIActiveAction(id.ToString(), isActive));  
            
        }
        
       
    }
}
