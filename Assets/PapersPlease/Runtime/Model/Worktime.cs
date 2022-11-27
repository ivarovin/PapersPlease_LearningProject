using System;

namespace PapersPlease.Runtime.Model
{
    public readonly struct Worktime
    {
        public TimeSpan Start { get; private init; }
        public TimeSpan End { get; private init; }
        public TimeSpan Duration => End - Start;
        
        public static Worktime Default { get; } =  new Worktime
        {
            Start = TimeSpan.FromHours(6),
            End = TimeSpan.FromHours(6) + TimeSpan.FromSeconds(15)
        };
    }
}