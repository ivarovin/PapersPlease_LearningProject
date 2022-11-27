using System;
using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class Newspaper : MonoBehaviour, DayView
    {
        [SerializeField] TextMeshProUGUI date;
        
        public async Task PrintAtStart(DateTime dateTime)
        {
            gameObject.SetActive(true);
            date.text = $"{dateTime:dd/MM/yyyy}";
            await Task.Delay(1000);
        }

        public Task PrintAtEnd(DateTime dateTime)
        {
            return FindObjectOfType<LabelDayView>().PrintAtEnd(dateTime);
        }
    }
}