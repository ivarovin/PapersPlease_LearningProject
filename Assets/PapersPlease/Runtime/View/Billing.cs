using PapersPlease.Runtime.Model;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class Billing : MonoBehaviour
    {
        public void Print(EconomicBalance balance)
        {
            transform.Find("Salary").GetComponent<EconomicValue>().Print(balance.Salary);
            transform.Find("Savings").GetComponent<EconomicValue>().Print(balance.Savings);
            
            transform.Find("Rent").GetComponent<EconomicValue>().Print(balance.Rent);
            transform.Find("Penalties").GetComponent<EconomicValue>().Print(balance.Penalties);
            
            
            transform.Find("Food").GetComponent<EconomicValue>().Print(balance.Food);
            transform.Find("Heat").GetComponent<EconomicValue>().Print(balance.Heat);
            
            transform.Find("Balance").GetComponent<EconomicValue>().Print(balance.Balance);
        }
    }
}