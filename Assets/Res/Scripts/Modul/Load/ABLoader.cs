using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
//TODO ab方式加载 先搁置
/// <summary>
/// ab加载
/// </summary>
public class ABLoader : ILoader {
	
	public GameObject LoadPrefab(string path, Transform parent = null)
	{
		throw new System.NotImplementedException();
	}

	public void LoadConfig(string path, Action<object> complete)
	{
		throw new NotImplementedException();
	}

	public T[] LoadAll<T>(string path) where T : Object
	{
		throw new NotImplementedException();
	}

    public void Load<T>(string path, Action<Object> complete) where T : Object
    {
        throw new NotImplementedException();
    }
}
