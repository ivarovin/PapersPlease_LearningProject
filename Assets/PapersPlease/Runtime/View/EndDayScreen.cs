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
        Task ExpensesReport.OfDay(int day, EconomicBalance balance)
        {
            gameObject.SetActive(true);
            FindObjectOfType<EndDayLabel>().GetComponent<TextMeshProUGUI>().text = $"End of day {day}";
            FindObjectOfType<Billing>().Print(balance);
            return Task.CompletedTask;
        }

        public async Task Listen()
        {
            var tcs = new TaskCompletionSource<bool>();
            FindObjectOfType<StartNewDayButton>(true).GetComponent<Button>().onClick.AddListener(() => tcs.SetResult(true));
            await tcs.Task;
        }
        
        public Task Close()
        {
            gameObject.SetActive(false);
            return Task.CompletedTask;
        }
    }
}