using System;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DigitalClock : MonoBehaviour, Clock
    {
        public void Print(TimeSpan theHour)
        {
            GetComponent<TextMeshProUGUI>().text = theHour.ToString("hh\\:mm\\:ss");
        }
    }
}