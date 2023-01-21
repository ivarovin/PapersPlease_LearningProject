using System.Collections;
using System.Runtime.CompilerServices;
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
        public static YieldAwaitable aFrame => Task.Yield();

        public static string TextOnChildLabelOf<T>() where T : MonoBehaviour
        {
            return Object.FindObjectOfType<T>().GetComponentInChildren<TMP_Text>().text;
        }
        
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

        static IEnumerator TheNewspaperToBeShown()
        {
            yield return new WaitForSeconds(2);
        }
        
        static IEnumerator TheNewspaperToBeClosed()
        {
            yield return new WaitForSeconds(0.5f);
        }

        static IEnumerator NewDayTypewriter()
        {
            var typewritter = UnityEngine.Object.FindObjectOfType<Typewriter>().GetComponentInParent<CanvasGroup>();
            yield return new WaitUntil(() => typewritter.alpha == 0);
            yield return null;
        }
    }
}