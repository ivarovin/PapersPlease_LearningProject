using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FluentAssertions.Extensions;
using TMPro;
using UnityEngine;

namespace PapersPlease.Tests.Runtime
{
    public static class Wait
    {
        public static Task aSecond => Task.Delay(1000.Milliseconds());
        public static Task aSecondOdd => Task.Delay(1100.Milliseconds());
        public static YieldAwaitable aFrame => Task.Yield();

        public static string TextOnChildLabelOf<T>() where T : MonoBehaviour
        {
            return Object.FindObjectOfType<T>().GetComponentsInChildren<TMP_Text>().Single().text;
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
    }
}