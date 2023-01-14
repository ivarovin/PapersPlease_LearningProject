namespace PapersPlease.Runtime.Model
{
    public class EconomicBalance
    {
        public float Salary { get; init; }
        public float Savings { get; init; }
        public float Rent { get; init; }
        public float Penalties { get; init; }
        public float Heat { get; init; }
        public float Food { get; init; }
        public bool ExpensesInHeat { get; init; }
        public bool ExpensesInFood { get; init; }
        
        public float TotalExpenses => Rent + Penalties + (ExpensesInHeat ? Heat : 0) + (ExpensesInFood ? Food : 0);
        public float TotalIncome => Salary + Savings;
        public float Balance => TotalIncome - TotalExpenses;
        public bool IsInDebt => Balance < 0;
    }
}