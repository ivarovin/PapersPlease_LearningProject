using System;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class LabelDayView : MonoBehaviour, DayView
    {
        public void PrintDate(DateTime dateTime)
        {
            GetComponent<TextMeshProUGUI>().text = $"Day {dateTime:dd/MM/yyyy} started";
        }
    }
}