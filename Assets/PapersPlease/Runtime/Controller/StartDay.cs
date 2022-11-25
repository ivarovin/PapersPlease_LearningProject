using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class StartDay
    {
        readonly DayView view;
        readonly Workday model;
        
        public StartDay(Workday model, DayView view)
        {
            this.model = model;
            this.view = view;
        }

        public Task Execute()
        {
            return view.PrintAtStart(model);
        }
    }
}