using System.Collections;
using System.Threading.Tasks;
using FluentAssertions.Extensions;
using PapersPlease.Runtime.View;
using TMPro;
using UnityEngine;
using static RGV.TestApi.Runtime.TestApi.Fake;

namespace PapersPlease.Tests.Runtime
{
    public static class Wait
    {
        public static Task aSecond => Task.Delay(1000.Milliseconds());
        public static Task aSecondOdd => Task.Delay(1100.Milliseconds());

        public static async Task ToChange(this TextMeshProUGUI label)
        {
            var tcs = new TaskCompletionSource<bool>();

            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(Listen);
            await tcs.Task;
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(Listen);

            void Listen(Object o)
            {
                if(o == label)
                    tcs.SetResult(true);
            }
        }

        public static async Task WalkToWorkAsync()
        {
            await aSecond;
            ClickOn<WalkToWorkButton>();
            await aSecond;
            await aSecond;
        }

        public static IEnumerator WalkToWork()
        {
            yield return TheNewspaperToBeShown();
            ClickOn<WalkToWorkButton>();
            yield return TheNewspaperToBeClosed();
            yield return NewDayTypewriter();
        }

        public static IEnumerator TheNewspaperToBeShown()
        {
            yield return new WaitForSeconds(2);
        }

        public static IEnumerator TheNewspaperToBeClosed()
        {
            yield return new WaitForSeconds(0.5f);
        }

        public static IEnumerator NewDayTypewriter()
        {
            yield return new WaitUntil(Is.TypewritterHidden);
            yield return null;
        }

        public static IEnumerator TheDayToStart()
        {
            ClickOn<SpeakerButton>();
            yield return new WaitForSeconds(1f);
        }

        public static IEnumerator TheDayToEnd()
        {
            Object.FindObjectOfType<EntryPoint>().EndDayAtOnce();
            yield return new WaitForSeconds(1);
            ClickOn<SpeakerButton>();
            yield return null;
        }
    }
}