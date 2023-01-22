namespace PapersPlease.Runtime.Model
{
    public class EconomicBalance
    {
        public float Salary { get; init; }
        public float Savings { get; init; }
        public float Rent { get; init; }
        public float Penalties { get; init; }

        public virtual float TotalExpenses => Rent + Penalties;
        public float TotalIncome => Salary + Savings;
        public float Balance => TotalIncome - TotalExpenses;
        public bool IsInDebt => Balance < 0;
    }
}