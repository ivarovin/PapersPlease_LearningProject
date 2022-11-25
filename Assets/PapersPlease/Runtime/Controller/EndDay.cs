using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class EndDay
    {
        readonly DayView view;
        readonly Workday model;

        public EndDay(Workday model, DayView view)
        {
            this.model = model;
            this.view = view;
        }

        public Task ExecuteAsync()
        {
            var task = view.PrintAtEnd(model);
            model.SpendDay();
            return task;
        }
    }
}