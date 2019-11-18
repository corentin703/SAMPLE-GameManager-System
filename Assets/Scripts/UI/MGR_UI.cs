using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_UI : Singleton<MGR_UI>
{
    public bool IsSettingUp { get; private set; } = false;
    
    public void SetUp()
    {
        IsSettingUp = true;
    }
    
    
    // TODO: Define your UI's fonctions here 
}
