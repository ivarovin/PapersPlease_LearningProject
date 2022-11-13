using System;

namespace PapersPlease.Runtime.Controller
{
    public class StartDay
    {
        readonly DayView view;
        
        public StartDay(DayView view)
        {
            this.view = view;
        }

        public void Execute()
        {
            view.PrintDate(new DateTime(1982, 11, 23));
        }
    }
}