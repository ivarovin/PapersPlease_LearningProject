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

        /// Ahora como mucho te pasa el mismo día de una vez, nunca más de uno.
        public void InjectTime(TimeSpan time)
        {
            if(time > day.TimeToOver)
            {
                endController.Execute(day);
                return;
            }
            
            day.Forward(time);
            view.Print(day.TimeOfDay);
            
            if(day.IsOver)
                endController.Execute(day);
        }
    }
}