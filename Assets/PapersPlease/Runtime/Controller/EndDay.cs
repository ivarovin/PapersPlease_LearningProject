using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class EndDay
    {
        readonly Economy economy;
        readonly Workday workday;
        readonly ExpensesReport view;
        
        public EndDay(Economy economy, Workday workday, ExpensesReport view)
        {
            this.economy = economy;
            this.workday = workday;
            this.view = view;
        }

        public async Task Run()
        {
            //TODO: sacar los cálculos del performance según el día real.
            var balance = economy.BalanceForDay(WorkdayPerformance.Zero);

            var bills = await view.OfDay(workday.DaysSinceBeginning, balance);
            economy.Apply(bills);
            await view.Close();
            
            workday.SpendDay();
        }
    }
}