using System.Collections;
using System.Collections.Generic;
using UIFrame.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Res.Scripts.Modul.UIFrame
{
    public class UITool
    {
        /// <summary>
        /// 添加button的监听
        /// </summary>
        /// <param name="parent">开始查找Button组件的父物体</param>
        /// <param name="action">点击事件</param>
        /// <param name="buttonName">带有button组件的物体名称，若未空，即为父物体挂载了Button组件</param>
        public static void AddBtnListener(Transform parent, UnityAction action, string buttonName = "")
        {
            if (parent == null || action == null)
            {
                Debug.LogError("The parameter 'parent' or 'action' of the UITool.AddBtnListener method cannot be null");
                return;
            }
            if (!string.IsNullOrEmpty(buttonName))
            {
                Transform buttonObj = parent.Find(buttonName);
                if (buttonObj != null)
                {
                    if (buttonObj.GetComponent<Button>() != null)
                    {
                        buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                        {
                            action();
                        });
                    }
                    else
                    {
                        Debug.LogError("on the " + buttonObj.name + " cannot find Button Component");
                    }

                }
                else
                {
                    Debug.LogError(buttonName + " path is null");
                    return;
                }
            }
            else
            {
                if (parent.GetComponent<Button>() != null)
                {
                    parent.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        action();
                    });
                }
                else
                {
                    Debug.LogError("on the " + parent.name + " cannot find Button Component");
                }

            }
        }

        /// <summary>
        /// 对象生成在UI自定义层级的父物体下
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parentLayer"></param>
        /// <returns></returns>
        public static Transform ProduceObject(string path, UILayer parentLayer)
        {
            Transform parent = UILayerMgr.Single.UILayerObjDic[parentLayer].transform;
            return ProduceObject(path, parent);
        }

        public static Transform ProduceObject(string path, Transform parent)
        {
            Transform source = Resources.Load<Transform>(path);
            if (source != null)
            {
                return Object.Instantiate(source, parent);
            }
            else
            {
                Debug.LogError("source is null");
                return null;
            }
        }

        public static Transform ProduceObject(Transform source, Transform parent)
        {
            if (source != null)
            {
                return Object.Instantiate(source, parent);
            }
            else
            {
                Debug.LogError("source is null");
                return null;
            }
        }
        /// <summary>
        /// 生成UI对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Transform ProduceUI(string path)
        {
            //Debug.Log(UILayerMgr.Single.UILayerObjDic);
            Transform source = Resources.Load<Transform>(path);
            UILayer layer = source.GetComponent<IUIBase>().GetLayer();
            Transform parent = UILayerMgr.Single.UILayerObjDic[layer].transform;
            return ProduceObject(source, parent);
        }

    }
}
