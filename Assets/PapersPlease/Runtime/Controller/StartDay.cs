using System;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public class StartDay
    {
        readonly DayView view; 
        DateTime date;
        
        public StartDay(DayView view)
        {
            this.view = view;
            this.date = new DateTime(1982, 11, 23) - TimeSpan.FromDays(1);
        }

        public Task Execute()
        {
            date = date.AddDays(1);
            return view.PrintAtStart(date);
        }
    }
}