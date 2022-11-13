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
            PrintHeader("started");
            await Task.Delay(458);
            GetComponent<TextMeshProUGUI>().text += $"{dateTime:dd/MM/yyyy}";
        }

        public async Task PrintAtEnd(DateTime dateTime)
        {
            PrintHeader("ended");
            await Task.Delay(257);
            GetComponent<TextMeshProUGUI>().text += $"{dateTime:dd/MM/yyyy}";
        }
        
        void PrintHeader(string header)
        {
            GetComponent<TextMeshProUGUI>().text = $"Day {header}: ";
        }
    }
}