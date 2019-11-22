using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtFall : ATLEvent
{
    protected override void OnEventStart()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.name = "Sphere";
        
        Debug.Log("Created");
    }

    protected override void OnEventPause()
    {
        return;
    }

    protected override void OnEventResume()
    {
        return;
    }

    protected override void OnEventStop()
    {
        Destroy(GameObject.Find("Sphere"));
        Debug.Log("Destroyed");
    }
}
