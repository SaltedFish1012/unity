
public interface IMsg
    {
        /// <summary>
        ///  处理消息虚接口
        /// </summary>
        /// <param name="_params">
        /// 需是1维数组
        /// </param>
        /// <typeparam name="T"></typeparam>
        void ProcessMsg<T>(params T[] _params);
    }
