using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_TimeLine : MonoBehaviour
{
    private enum ETLEventType
    {
        Start,
        Stop,
    }
    
    private struct STLEvent
    {
        public float ActionTime;
        public ETLEventType TLEventType;
        public ATLEvent Event;

        public STLEvent(float actionTime, ETLEventType tlEventType, ATLEvent evt)
        {
            ActionTime = actionTime;
            TLEventType = tlEventType;
            Event = evt;
        }
    }

    private List<STLEvent> m_events;
    private List<ATLEvent> m_runningEvents;
    
    public float Chrono { get; private set; }
    public bool IsChronoStarted { get; private set; }
    public bool IsChronoPaused { get; private set; }

    private float _maxGameDuration = 15 * 60;
    public float MaxGameDuration
    {
        get { return _maxGameDuration; } 
        private set
        {
            if (!IsSetUp)
                _maxGameDuration = value;
            else
                throw new SystemException("[MGR_TimeLine] You can't define MaxGameDuration during game's execution");
        }
    }

    public bool IsSetUp { get; private set; } = false;
        
    public void SetUp()
    {
        IsSetUp = true;
    }

    public void ChronoStart()
    {
        foreach (ATLEvent evt in m_runningEvents)
        {
            evt.NotifyChronoStart();
        }
    }

    public void ChronoPause()
    {
        foreach (ATLEvent evt in m_runningEvents)
        {
            evt.NotifyChronoPause();
        }
    }

    public void ChronoResume()
    {
        foreach (ATLEvent evt in m_runningEvents)
        {
            evt.NotifyChronoResume();
        }
    }

    public void ChronoStop()
    {
        foreach (ATLEvent evt in m_runningEvents)
        {
            evt.NotifyChronoStop();
        }
    }

    private void BuildTimeLine(ATLEvent[] events)
    {
        foreach (ATLEvent evt in events)
        {
            if (evt.IsPeriodic)
            {
                float startTime = evt.StartTime;
                float endTime = evt.StartTime + evt.Duration;

                while (endTime < evt.EndTime)
                {
                    buildTLEventPair(startTime, endTime, evt);

                    startTime = endTime + evt.Period;
                    endTime = startTime + evt.Duration;
                }
            }
            else
                buildTLEventPair(evt.StartTime, evt.EndTime, evt);
        }
    }

    private void buildTLEventPair(float startTime, float endTimen, ATLEvent evt)
    {
        m_events.Add(new STLEvent(evt.StartTime, ETLEventType.Start, evt));
        m_events.Add(new STLEvent(evt.EndTime, ETLEventType.Stop, evt));   
    }

    private bool testChronoEnd()
    {
        return Chrono >= MaxGameDuration;
    }
}
