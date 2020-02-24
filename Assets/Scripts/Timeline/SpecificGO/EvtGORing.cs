using System.Collections;
using System.Collections.Generic;
using Song;
using Timeline;
using UnityEngine;

public class EvtGORing : ATLEventGO
{
    public override void OnEventStart()
    {
        SongManager.Instance.PlaySound("ring");
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
