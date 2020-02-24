﻿using System;
using UnityEngine;

namespace Timeline.SpecificGO
{
    public class EvtGOCubeSpown : ATLEventGO
    {
        [SerializeField] private GameObject cube;

        protected void Awake()
        {
            base.Awake();
        
            if (cube == null)
                throw new Exception("[" + GetType().Name + "] in Awake -> Cube prefab is not set");
        }

        public override void OnEventStart()
        {
            Debug.Log("[" + GetType().Name + "] Create cube ! Time: " + TimelineManager.Instance.Chrono);
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
}
