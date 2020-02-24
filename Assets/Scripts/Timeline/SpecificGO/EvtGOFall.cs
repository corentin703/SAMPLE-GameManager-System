﻿using UnityEngine;

namespace Timeline.SpecificGO
{
    public class EvtGOFall : ATLEventGO
    {
        public override void OnEventStart()
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.name = "Sphere";
        
            Debug.Log("[" + GetType().Name + "] Created");
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
            Destroy(GameObject.Find("Sphere"));
            Debug.Log("[" + GetType().Name + "] Destroyed");
        }
    }
}
