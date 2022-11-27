using System;
using System.Threading.Tasks;
using DG.Tweening;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;
using static DG.Tweening.Ease;


namespace PapersPlease.Runtime.View
{
    public class Newspaper : MonoBehaviour, DayView
    {
        [SerializeField] TextMeshProUGUI date;
        
        public async Task PrintAtStart(DateTime dateTime)
        {
            gameObject.SetActive(true);
            date.text = $"{dateTime:dd/MM/yyyy}";
            await transform.DOScale(0, .5f).From().SetEase(OutElastic).AsyncWaitForCompletion();
        }

        public Task PrintAtEnd(DateTime dateTime)
        {
            return FindObjectOfType<LabelDayView>().PrintAtEnd(dateTime);
        }
    }
}