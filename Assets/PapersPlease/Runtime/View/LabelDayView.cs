using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class LabelDayView : MonoBehaviour, DayView
    {
        public async Task PrintAtStart(DateTime dateTime)
        {
            await Task.Yield();
            PrintDate(dateTime);
        }

        public async Task PrintAtEnd(DateTime dateTime)
        {
            GetComponent<TextMeshProUGUI>().text = $"Day {dateTime:dd/MM/yyyy} ended";
        }

        private void PrintDate(DateTime dateTime)
        {
            GetComponent<TextMeshProUGUI>().text = $"Day {dateTime:dd/MM/yyyy} started";
        }
    }
}