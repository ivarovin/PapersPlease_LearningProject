namespace PapersPlease.Runtime.Model
{
    public class Economy
    {
        int savings;

        internal Commodities Commodities()
        {
            return Model.Commodities.Default;
        }

        public int Savings()
        {
            return savings;
        }

        public void Apply(Bills bills)
        {
            savings += bills.Balance;
        }

        public EconomicBalance BalanceForDay(WorkdayPerformance performance)
        {
            return new EconomicBalance
            {
                Salary = performance.Hits * 5,
                Savings = savings,
                Rent = 20,
                Penalties = performance.Faults * 5,
                Food = 20,
                Heat = 10
            };
        }
    }
}