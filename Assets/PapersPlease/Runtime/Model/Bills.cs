namespace PapersPlease.Runtime.Model
{
    public class Bills : EconomicBalance
    {
        public bool ExpensesInHeat { get; init; }
        public bool ExpensesInFood { get; init; }

        public override int TotalExpenses => base.TotalExpenses + (ExpensesInHeat ? Heat : 0) + (ExpensesInFood ? Food : 0);
    }
}