using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverMgr : NormalSingleton<SaverMgr>, ISaver
{
    private ISaver _saver;

    //仅实现json存储
    public SaverMgr()
    {
        _saver = new JsonSaver();
    }

    public void LoadData(string path, Action<GameDataModel> complete)
    {
        _saver.LoadData(path, complete);
    }
  
    public void SaveData(string path, GameDataModel model)
    {
       _saver.SaveData(path, model);
    }
}
