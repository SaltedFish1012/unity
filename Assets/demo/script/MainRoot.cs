using System;
using System.Collections;
using System.Collections.Generic;
using demo.script;
using Res.Scripts.Modul.UIFrame;
using UnityEngine;

public class MainRoot : UIRoot
{
    public override void Start()
    {
        base.Start();
        UIManager.ShowUI(MUIEnum.MAIN_VIEW.ToString());
    }

    protected override void InitUISystem()
    {
        base.InitUISystem();
        new MUIPathMgr();
        DataHandlerManager = new MUIDataHandlerMgr();
    }
}
