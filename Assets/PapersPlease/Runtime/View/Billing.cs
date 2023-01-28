using PapersPlease.Runtime.Model;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class Billing : MonoBehaviour
    {
        public void Print(EconomicBalance balance)
        {
            transform.Find("Salary").GetComponent<EconomicMagnitude>().Print(balance.Salary);
            transform.Find("Savings").GetComponent<EconomicMagnitude>().Print(balance.Savings);
            
            transform.Find("Rent").GetComponent<EconomicMagnitude>().Print(balance.Rent);
            transform.Find("Penalties").GetComponent<EconomicMagnitude>().Print(balance.Penalties);

            transform.Find("Food").GetComponent<EconomicMagnitude>().Print(balance.Food);
            transform.Find("Heat").GetComponent<EconomicMagnitude>().Print(balance.Heat);
            
            transform.Find("Balance").GetComponent<EconomicMagnitude>().Print(balance.Balance);
        }
    }
}