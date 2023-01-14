using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class EndDay
    {
        readonly Workday model;
        readonly ExpensesReport view;

        public EndDay(Workday model, ExpensesReport view)
        {
            this.model = model;
            this.view = view;
        }

        public async Task Run()
        {
            await view.OfDay(model.DaysSinceBeginning, new EconomicBalance());
            model.SpendDay();
        }
    }
}