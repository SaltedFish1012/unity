using System.Collections;
using System.Collections.Generic;
using demo.script;
using Res.Scripts.Modul.UIFrame.BaseUI;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View
{
    public override void Init()
    {
        base.Init();
        InitUI(MUIEnum.MAIN_VIEW, MainUIHandler.Name);
        Debug.Log("MainView Init");
        transform.Find("GoText1").GetComponent<Button>().onClick.AddListener(()=>
        {
            MainRoot.UIManager.ShowUI(MUIEnum.Test_View);
        });
        
        MainUIData data =  (MainUIData)dataHandler.GetData();
        transform.Find("coin").GetComponent<Text>().text = data.coin.ToString();

        EventMgr.Single.AddEventListener<string>(EventConfig.TEST_NOTICE,UpdateName);
    }

    public override void Show()
    {
        base.Show();
        
    }

    protected override void UpdateShow()
    {
        MainUIData data =  (MainUIData)dataHandler.GetData();
        transform.Find("coin").GetComponent<Text>().text = data.coin.ToString();
    }

    private void UpdateName(string name)
    {
        transform.Find("name").GetComponent<Text>().text = name;
    }
}
