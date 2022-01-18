using UnityEngine;
using System.Collections;

namespace UIFrame.Base
{
    /// <summary>
    /// 数据处理器对象管理类接口
    /// </summary>
    public interface IUIDataHandlerManager
    {
        /// <summary>
        /// 根据名称移除数据处理器
        /// </summary>
        /// <param name="handlerName"></param>
        void RemoveHandler(string handlerName);
        /// <summary>
        /// 根据名称获取数据管理器
        /// </summary>
        /// <param name="handlerName"></param>
        /// <returns></returns>
        IDataHandler GetHandler(string handlerName);
    }
}
