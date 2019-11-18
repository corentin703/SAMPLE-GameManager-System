using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_MGR_Ressource : MonoBehaviour
{
    public MGR_Ressource.SRessourceInfo[] RessourceInfos;
    private void Awake()
    {
        MGR_Ressource.Instance.SetUp(RessourceInfos);
        
        Destroy(this);
    }
}
