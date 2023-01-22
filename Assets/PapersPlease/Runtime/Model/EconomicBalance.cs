namespace PapersPlease.Runtime.Model
{
    public class EconomicBalance
    {
        public int Salary { get; init; }
        public int Savings { get; init; }
        public int Rent { get; init; }
        public int Penalties { get; init; }
        
        Commodities Commodities { get; init; }
        public int Food => Commodities.Food;
        public int Heat => Commodities.Heat;


        public virtual int TotalExpenses => Rent + Penalties;
        public int TotalIncome => Salary + Savings;
        public int Balance => TotalIncome - TotalExpenses;
        public bool IsInDebt => Balance < 0;
    }
}