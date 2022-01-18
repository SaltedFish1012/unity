using System;
using System.Collections.Generic;
using UIFrame.Base;

namespace Res.Scripts.Modul.UIFrame
{
    public abstract class UIDataHandlerMgr :IUIDataHandlerManager
    {
        
            protected Dictionary<string,IDataHandler> handlerDic;

            public UIDataHandlerMgr()
            {
                handlerDic = new Dictionary<string, IDataHandler>();
                RegisterHandler();
            }
            /// <summary>
            /// 初始化所有自定义的数据处理器
            /// </summary>
            protected abstract void RegisterHandler();

            public void RemoveHandler(string handlerName)
            {
                handlerDic.Remove(handlerName);
            }

            public IDataHandler GetHandler(string handlerName)
            {
                if (handlerDic.ContainsKey(handlerName))
                {
                    return handlerDic[handlerName];
                }
                else
                {
                    throw new Exception("this proxy is not registered");
                }
            }
        }
    }
