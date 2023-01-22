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
            //Crear según reglas de negocio.
            var balance = new EconomicBalance
            {
                Salary = 654,
                Savings = 6878,
                Rent = 5,
                Penalties = 5,
                Food = 5,
                Heat = 5
            };

            await view.OfDay(model.DaysSinceBeginning, balance);
            await view.Listen();
            await view.Close();
            
            model.SpendDay();
        }
    }
}