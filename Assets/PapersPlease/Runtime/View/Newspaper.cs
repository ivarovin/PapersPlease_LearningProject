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

            transform.DOLocalRotate(Vector3.back * 360 * 9, .9f, RotateMode.LocalAxisAdd).SetEase(OutQuad);
            await transform.DOScale(0, .9f).From().SetEase(InQuad).AsyncWaitForCompletion();
        }

        public Task PrintAtEnd(DateTime dateTime)
        {
            return FindObjectOfType<LabelDayView>().PrintAtEnd(dateTime);
        }
    }
}