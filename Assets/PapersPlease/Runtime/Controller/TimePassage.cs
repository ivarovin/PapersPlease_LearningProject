using System;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class TimePassage
    {
        readonly Workday day;
        readonly Clock view;
        readonly EndDay endController;
        
        public TimePassage(Workday day, Clock view, EndDay endController)
        {
            this.day = day;
            this.view = view;
            this.endController = endController;
        }

        public void InjectTime(TimeSpan time)
        {
            day.Forward(time);
            view.Print(day.TimeOfDay);
            
            if(day.IsOver)
                endController.Execute(day);
        }
    }
}