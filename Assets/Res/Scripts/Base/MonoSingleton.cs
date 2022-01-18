using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mono单例
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _single;

    public static T Single
    {
        get
        {
             T t = FindObjectOfType<T>();
                if (_single == null)
                {
                    if (t != null)
                    {
                        _single = t;
                    }
                    else
                    {
                        Debug.LogError("类" + typeof(T).Name + "单例对象为空");
                    }
                }
                return _single;
        }
    }
}
