using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏数据
public class GameDataModel : NormalSingleton<GameDataModel>
{ 
    public int Life { get; set; }
    public int Score { get; set; }
}
