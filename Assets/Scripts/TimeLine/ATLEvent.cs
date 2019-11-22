﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATLEvent : MonoBehaviour
{
    [SerializeField] private float m_startTime;
    public float StartTime
    {
        get { return m_startTime; }
        private set { m_startTime = value; }
    }
    
    [SerializeField] private float m_endTime;
    public float EndTime
    {
        get { return m_endTime; }
        private set { m_endTime = value; }
    }

    [SerializeField] private bool m_isPeriodic;
    public bool IsPeriodic { 
        get { return m_isPeriodic; }
        private set { m_isPeriodic = value; } 
    }
    
    [ConditionalHide("m_isPeriodic", true)]
    [Tooltip("If set to 0, period will be random")]
    [SerializeField] private float m_period;
    public float Period
    {
        get { return m_period; }
        private set { m_period = value; }
    }
    
    [ConditionalHide("m_isPeriodic", true)]
    [Tooltip("Define the duration between each period")]
    [SerializeField] private float m_duration;
    public float Duration
    {
        get { return m_duration; }
        private set { m_duration = value; }
    }

    [SerializeField] private bool m_isPausable;
    public bool IsPausable
    {
        get { return m_isPausable; }
        private set { m_isPausable = value; }
    }

    public void Fire()
    {
        OnEventStart();
    }
    
    public void NotifyChronoPause()
    {
        OnEventPause();
    }

    public void NotifyChronoResume()
    {
        OnEventResume();
    }

    public void Stop()
    {
        OnEventStop();
    }

    protected abstract void OnEventStart();
    
    protected abstract void OnEventPause();
    
    protected abstract void OnEventResume();
    
    protected abstract void OnEventStop();

}
