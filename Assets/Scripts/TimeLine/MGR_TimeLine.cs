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

    private List<ITLEvent> m_events;
    
    public float Chrono { get; private set; }
    public bool IsChronoStarted { get; private set; }
    public bool IsChronoPaused { get; private set; }

    public float MaxGameDuration = 15 * 60;

    public bool IsSettingUp { get; private set; } = false;
        
    public void SetUp()
    {
        IsSettingUp = true;
    }

    public void ChronoStart()
    {
        
    }

    public void ChronoPause()
    {
        
    }

    public void ChronoStop()
    {
        
    }

    public void ChronoEnd()
    {
        
    }

    private void BuildTimeLine()
    {
        
    }

    private void testChronoEnd()
    {
        
    }
}
