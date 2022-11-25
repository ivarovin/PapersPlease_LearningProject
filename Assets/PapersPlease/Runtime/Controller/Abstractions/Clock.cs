using System;

namespace PapersPlease.Runtime.Controller
{
    public interface Clock
    {
        void Print(TimeSpan theHour);
    }
}