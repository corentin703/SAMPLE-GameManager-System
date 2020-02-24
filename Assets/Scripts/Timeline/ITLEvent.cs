﻿namespace Timeline
{
    public interface ITLEvent
    {
        float StartTime { get; }
        float EndTime { get; }
        bool IsPeriodic { get; }
        float Period { get; }
        float Duration { get; }
    
        void OnEventStart();
    
        void OnEventPause();
    
        void OnEventResume();
    
        void OnEventStop();
    }
}
