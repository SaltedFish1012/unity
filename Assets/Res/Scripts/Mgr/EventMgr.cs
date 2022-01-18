using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件模块
/// </summary>
public class EventMgr : NormalSingleton<EventMgr>
{
    private Dictionary<string, IEventInfo> eventDir = new Dictionary<string, IEventInfo>();

    // 添加事件监听，一个参数的
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDir.ContainsKey(name))
            (eventDir[name] as EventInfo<T>).actions += action;
        else
            eventDir.Add(name, new EventInfo<T>(action));
    }

    // 添加事件监听，无参数的
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDir.ContainsKey(name))
            (eventDir[name] as EventInfo).actions += action;
        else
            eventDir.Add(name, new EventInfo(action));
    }

    // 事件触发，无参的
    public void EventTrigger(string name)
    {
        if (eventDir.ContainsKey(name))
            (eventDir[name] as EventInfo).actions?.Invoke();
    }

    //事件触发，一个参数的
    public void EventTrigger<T>(string name, T info)
    {
        if (eventDir.ContainsKey(name))
            (eventDir[name] as EventInfo<T>).actions?.Invoke(info);
    }

    //移除监听，无参的
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDir.ContainsKey(name))
            (eventDir[name] as EventInfo).actions -= action;
    }

    //移除监听，一个参数的
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDir.ContainsKey(name))
            (eventDir[name] as EventInfo<T>).actions -= action;
    }
    
    //清理 一般在scene切换使用
    public void Clear()
    {
        eventDir.Clear();
    }
}

