using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text title;
    
    // Start is called before the first frame update
    void Start()
    {
        //EventMgr.Single.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseSceneBall()
    {
        SceneManager.LoadScene("ComposeBall");
    }
    
    public void chooseSceneXiaoxiaole()
    {
        SceneManager.LoadScene("xiaoxiaole");
    }
    
    public void chooseSceneSdk()
    {
        //SceneManager.LoadScene("ComposeBall");
    }

    public void chooseSceneFrame()
    {
        SceneManager.LoadScene("demo");
    }
}
