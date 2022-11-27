using System;

namespace PapersPlease.Runtime.Model
{
    public readonly struct Worktime
    {
        public TimeSpan Start { get; init; }
        public TimeSpan End { get; init; }
        public TimeSpan Duration => End - Start;
        
        public static Worktime Default { get; } =  new()
        {
            Start = TimeSpan.FromHours(6),
            End = TimeSpan.FromHours(6) + TimeSpan.FromHours(12)
        };
    }
}