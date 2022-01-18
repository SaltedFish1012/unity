using UnityEngine;

public abstract class BaseDialog : MonoBehaviour,IMediator
{
    public abstract void OnCreat();

    public abstract void OnShow();

    public abstract void OnResume();

    public abstract void OnExit();

    
    public abstract void contact(string name);
}

