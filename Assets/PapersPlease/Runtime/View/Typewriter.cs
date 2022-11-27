using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class Typewriter : MonoBehaviour, ExpensesReport, NewDay
    {
        public async Task StartAt(DateTime day)
        {
            await Task.Delay(458);
            GetComponent<TextMeshProUGUI>().text = $"{day:dd/MM/yyyy}";
        }

        public async Task OfDay(int day)
        {
            GetComponent<TextMeshProUGUI>().text = $"End of day {day}";
            await Task.Delay(458);
        }
    }
}