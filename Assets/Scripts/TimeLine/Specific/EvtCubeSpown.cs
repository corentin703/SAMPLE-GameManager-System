using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtCubeSpown : ATLEvent
{
    [SerializeField] private GameObject cube;

    protected void Awake()
    {
        base.Awake();
        
        if (cube == null)
            throw new Exception("Cube prefab is not set");
    }

    public override void OnEventStart()
    {
        Debug.Log("Create cube ! Time: " + MGR_TimeLine.Instance.Chrono);
        Instantiate(cube);
    }

    public override void OnEventPause()
    {
        return;
    }

    public override void OnEventResume()
    {
        return;
    }

    public override void OnEventStop()
    {
        return;
    }
}
