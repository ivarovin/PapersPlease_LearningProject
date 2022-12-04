using System;
using System.Threading.Tasks;
using DG.Tweening;
using Febucci.UI;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class Typewriter : MonoBehaviour, ExpensesReport, NewDay
    {
        public async Task StartAt(DateTime day)
        {
            GetComponentInParent<CanvasGroup>().alpha = 1;
            await Task.Delay(TimeSpan.FromSeconds(.5f));
            
            await WriteCharByChar(day);
            await Task.Delay(TimeSpan.FromSeconds(.5f));

            await GetComponentInParent<CanvasGroup>().DOFade(0, .5f).AsyncWaitForCompletion();
        }

        Task WriteCharByChar(DateTime day)
        {
            var text = $"{day:dd MM yyyy}";
            GetComponent<TextAnimator>().SetText(text, true);
            GetComponent<TextAnimatorPlayer>().StartShowingText();
            
            var animTime = GetComponent<TextAnimatorPlayer>().TypingTimeOf(text);
            return Task.Delay(animTime);
        }

        async Task ExpensesReport.OfDay(int day)
        {
            GetComponentInParent<CanvasGroup>().alpha = 1;
            GetComponent<TextMeshProUGUI>().text = $"End of day {day}";
            await Task.Delay(300);
            await GetComponentInParent<CanvasGroup>().DOFade(0, .5f).AsyncWaitForCompletion();
        }
    }
}