using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class EndDay
    {
        readonly DayView view;

        public EndDay(DayView view)
        {
           this.view = view;
        }

        public Task Execute(Workday day)
        {
            var task = view.PrintAtEnd(day);
            day.SpendDay();
            return task;
        }
    }
}