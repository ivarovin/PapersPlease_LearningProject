using System.Threading.Tasks;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Runtime.Controller
{
    public class EndDay
    {
        readonly Economy economy;
        readonly Workday workday;
        readonly WorkdayPerformance performance;
        readonly ExpensesReport view;
        
        public EndDay(Economy economy, Workday workday, WorkdayPerformance performance, ExpensesReport view)
        {
            this.economy = economy;
            this.workday = workday;
            this.performance = performance;
            this.view = view;
        }

        public async Task Run()
        {
            var balance = economy.BalanceForDay(performance);

            var bills = await view.OfDay(workday.DaysSinceBeginning, balance);
            economy.Apply(bills);
            await view.Close();
            
            workday.SpendDay();
        }
    }
}