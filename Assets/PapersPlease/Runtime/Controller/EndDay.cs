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
            //TODO: sacar los cálculos del performance según el día real.
            //TODO: la economía tendrá que compartirse entre diferentes controladores, es modelo.
            var balance = new Economy().BalanceForDay(WorkdayPerformance.Zero);

            await view.OfDay(model.DaysSinceBeginning, balance);
            await view.Listen();
            await view.Close();
            
            model.SpendDay();
        }
    }
}