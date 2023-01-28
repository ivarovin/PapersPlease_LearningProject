namespace PapersPlease.Runtime.Model
{
    public class Bills : EconomicBalance
    {
        public bool ExpensesInHeat { get; init; }
        public bool ExpensesInFood { get; init; }

        public override int TotalExpenses => base.TotalExpenses + (ExpensesInHeat ? Heat : 0) + (ExpensesInFood ? Food : 0);

        public Bills()
        {
            
        }
        
        public Bills(EconomicBalance copied)
        {
            Salary = copied.Salary;
            Penalties = copied.Penalties;
            Savings = copied.Savings;
            Rent = copied.Rent;
            Food = copied.Food;
            Heat = copied.Heat;

            ExpensesInHeat = false;
            ExpensesInFood = false;
        }
    }
}