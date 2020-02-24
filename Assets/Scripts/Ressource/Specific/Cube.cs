using System;
using System.Collections;
using System.Collections.Generic;
using Ressource;
using Timeline;
using Timeline.Specific;
using UnityEngine;

public class Cube : AResource
{
    private static int m_Number = 0;
    private EvtLog evt;

    public override int Number
    {
        get { return m_Number;}
        protected set { m_Number = value; }
    }
    public override void Add(int number)
    {
        Number++;
    }

    private void Awake()
    {
        base.Awake();
        evt = new EvtLog(2, 20, true, 2, 3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            TimelineManager.Instance.RemoveEvent(evt);
    }

    protected override void OnPick()
    {
        base.OnPick();
        Debug.Log("[" + GetType().Name + "] Cube picked !");
        
        TimelineManager.Instance.AddEvent(evt);
    }
}
