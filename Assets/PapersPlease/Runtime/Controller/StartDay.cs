using System;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public class StartDay
    {
        readonly DayView view;
        
        public StartDay(DayView view)
        {
            this.view = view;
        }

        public Task ExecuteAsync()
        {
            return view.Print(new DateTime(1982, 11, 23));
        }
    }
}