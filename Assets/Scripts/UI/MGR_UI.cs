using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_UI : Singleton<MGR_UI>
{
    public bool IsSetUp { get; private set; } = false;
    
    public void SetUp()
    {
        IsSetUp = true;
    }
    
    public void NotifySceneChanged()
    {
        IsSetUp = false;
    }
    
    // TODO: Define your UI's fonctions here 
}
