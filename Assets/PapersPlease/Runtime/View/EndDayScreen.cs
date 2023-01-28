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
            Open(day, balance);
            return Listen();
            
            async Task<Bills> Listen()
            {
                ResetChoices();
                ListenToBillingChoices();

                var tcs = new TaskCompletionSource<bool>();
                SubscribeToSleepButton(tcs);
                await tcs.Task;

                return CurrentBills(balance);
            }
            
            void ListenToBillingChoices()
            {
                ToggleOf(Magnitude.Heat).onValueChanged.AddListener(RefreshBillings);
                ToggleOf(Magnitude.Food).onValueChanged.AddListener(RefreshBillings);
            }

            void RefreshBillings(bool _)
            {
                FindObjectOfType<Billing>().Print(CurrentBills(balance));
            }
        }

        void ResetChoices()
        {
            ToggleOf(Model.Magnitude.Heat).isOn = false;
            ToggleOf(Model.Magnitude.Food).isOn = false;
        }

        void Open(int day, EconomicBalance balance)
        {
            gameObject.SetActive(true);
            FindObjectOfType<EndDayLabel>().GetComponent<TextMeshProUGUI>().text = $"End of day {day}";
            FindObjectOfType<Billing>().Print(balance);
        }

        Bills CurrentBills(EconomicBalance balance)
        {
            return new Bills(balance)
            {
                ExpensesInHeat = ToggleOf(Model.Magnitude.Heat).isOn,
                ExpensesInFood = ToggleOf(Model.Magnitude.Food).isOn
            };
        }

        static void SubscribeToSleepButton(TaskCompletionSource<bool> tcs)
        {
            FindObjectOfType<StartNewDayButton>(true)
                .GetComponent<Button>()
                .onClick.AddListener(() => tcs.SetResult(true));
        }

        public Task Close()
        {
            gameObject.SetActive(false);
            return Task.CompletedTask;
        }
        
        Toggle ToggleOf(Model.Magnitude magnitude)
        {
            return transform
                .Find($"Billing/{magnitude}")
                .GetComponentInChildren<Toggle>();
        }
    }
}