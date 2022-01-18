using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
/// <summary>
/// 加载模块 
/// </summary>
public class LoadMgr : NormalSingleton<LoadMgr>,ILoader
{
	[SerializeField]
	private ILoader _loader;
	public enum LoaderType
	{
		resource = 1,
		addr = 2,
		assertbundle = 3,
	};
	// resource & address & ab
	public LoadMgr()
	{
		_loader  = new ResourceLoader();
		//_loader  = new AddrLoader();
	}
	
	/// <summary>
	/// 切换loader方式
	/// </summary>
	/// <param name="t">
	/// loadertype 方式类型
	/// </param>
	public void LoadMgrType(LoaderType t)
	{
		if (t == LoaderType.resource)
		{
			_loader  = new ResourceLoader();
		}
		else
		{
			_loader  = new AddrLoader();
		}
		
		//_loader = new ABLoader();
	}

	/// <summary>
	/// 加载预制
	/// </summary>
	/// <param name="path">位置</param>
	/// <param name="parent">父节点</param>
	/// <returns></returns>
	public GameObject LoadPrefab(string path, Transform parent = null)
	{
		return _loader.LoadPrefab(path, parent);
	}

	public void LoadConfig(string path, Action<object> complete)
	{
		_loader.LoadConfig(path,complete);
	}

	public void Load<T>(string path, Action<Object> complete) where T : Object
	{
		_loader.Load<T>(path, complete);
	}

	public T[] LoadAll<T>(string path) where T : Object
	{
		return _loader.LoadAll<T>(path);
	}
}
	