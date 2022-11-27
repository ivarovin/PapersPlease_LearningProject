using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class ShowNewspaper
    {
        readonly DayView view;
        readonly Workday model;

        public ShowNewspaper(DayView view, Workday model)
        {
            this.view = view;
            this.model = model;
        }

        public async Task Run()
        {
            await view.PrintAtStart(model);
        }
    }
}