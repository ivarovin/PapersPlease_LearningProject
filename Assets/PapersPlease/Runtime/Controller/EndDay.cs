using System;
using System.Threading.Tasks;

namespace PapersPlease.Runtime.Controller
{
    public class EndDay
    {
        readonly DayView view;
        
        public EndDay(DayView view)
        {
            this.view = view;
        }

        public Task ExecuteAsync()
        {
            var task = view.PrintAtEnd(new DateTime(1982, 11, 23));
            return task;
        }
    }
}