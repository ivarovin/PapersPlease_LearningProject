using System;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class TimePassage
    {
        readonly Workday day;
        readonly Clock view;
        
        public TimePassage(Workday day, Clock view)
        {
            this.day = day;
            this.view = view;
        }

        public void InjectTime(TimeSpan time)
        {
            day.Forward(time);
            view.Print(day.TimeOfDay);
        }
    }
}