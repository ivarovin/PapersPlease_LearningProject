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

        /// Ahora como mucho te pasa el mismo día de una vez, nunca más de uno.
        public void Inject(TimeSpan time)
        {
            day.Forward(time < day.TimeToOver ? time : day.TimeToOver);
            view.Print(day.TimeOfDay);
        }
    }
}