using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_MGR_TimeLine : MonoBehaviour
{
    public ATLEvent[] Events;
    void Awake()
    {
        MGR_TimeLine.Instance.SetUp(Events);
        
        Destroy(this);
    }
}
