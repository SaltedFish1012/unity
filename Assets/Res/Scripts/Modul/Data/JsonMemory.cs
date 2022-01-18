using System;
using System.IO;

//TODO 用于游戏内使用的表 先搁置 一般的项目用不到
public class JsonMemory : IDataMemory
{
    public T Get<T>(string key)
    {
        throw new NotImplementedException();
    }

    public void Set<T>(string key, T value)
    {
        throw new NotImplementedException();
    }

    public void Clear(string key)
    {
        throw new NotImplementedException();
    }

    public void ClearAll()
    {
        throw new NotImplementedException();
    }

    public bool Contains(string key)
    {
        throw new NotImplementedException();
    }

    public void SetObject(string key, object value)
    {
        throw new NotImplementedException();
    }

    public object GetObject(string key)
    {
        throw new NotImplementedException();
    }
}