using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_Gameplay : Singleton<MGR_Gameplay>
{
    [System.Serializable]
    public struct SBonus
    {
        public string name;
        public int bonus;
    }

    public bool IsSettingUp { get; private set; } = false;

    private Dictionary<string, int> m_dictBonus;


    public void SetUp(Object player)
    {
        IsSettingUp = true;
    }
    

}
