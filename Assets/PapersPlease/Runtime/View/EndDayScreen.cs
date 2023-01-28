using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using PapersPlease.Runtime.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PapersPlease.Runtime.View
{
    public class EndDayScreen : MonoBehaviour, ExpensesReport
    {
        Task<Bills> ExpensesReport.OfDay(int day, EconomicBalance balance)
        {
            gameObject.SetActive(true);
            FindObjectOfType<EndDayLabel>().GetComponent<TextMeshProUGUI>().text = $"End of day {day}";
            FindObjectOfType<Billing>().Print(balance);
            
            return Listen();
            
            async Task<Bills> Listen()
            {
                var tcs = new TaskCompletionSource<bool>();
                FindObjectOfType<StartNewDayButton>(true).GetComponent<Button>().onClick.AddListener(() => tcs.SetResult(true));
                await tcs.Task;

                //TODO: cambiar en función de si elige el jugador gastar en calor y/o comida.
                return new Bills(balance);
            }
        }

        public Task Close()
        {
            gameObject.SetActive(false);
            return Task.CompletedTask;
        }
    }
}