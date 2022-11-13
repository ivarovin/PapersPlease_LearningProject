using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class LabelDayView : MonoBehaviour, DayView
    {
        public async Task Print(DateTime dateTime)
        {
            await Task.Yield();
            PrintDate(dateTime);
        }
        
        private void PrintDate(DateTime dateTime)
        {
            GetComponent<TextMeshProUGUI>().text = $"Day {dateTime:dd/MM/yyyy} started";
        }
    }
}