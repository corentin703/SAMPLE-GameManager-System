using UnityEngine;

namespace Timeline
{
    public class InitTimelineManager : MonoBehaviour
    {
        public ATLEventGO[] Events;
        void Awake()
        {
            if (TimelineManager.Instance)
                TimelineManager.Instance.SetUp(Events);
        
            Destroy(this);
        }
    }
}
