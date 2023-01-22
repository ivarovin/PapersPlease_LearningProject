namespace PapersPlease.Runtime.Model
{
    public class Bills : EconomicBalance
    {
        public float Heat { get; init; }
        public float Food { get; init; }
        public bool ExpensesInHeat { get; init; }
        public bool ExpensesInFood { get; init; }

        public override float TotalExpenses => base.TotalExpenses + (ExpensesInHeat ? Heat : 0) + (ExpensesInFood ? Food : 0);
    }
}