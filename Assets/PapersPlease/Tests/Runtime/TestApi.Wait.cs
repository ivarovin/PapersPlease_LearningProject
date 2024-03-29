﻿using System;
using System.Collections;
using System.Threading.Tasks;
using FluentAssertions.Extensions;
using PapersPlease.Runtime.View;
using TMPro;
using UnityEngine;
using static RGV.TestApi.Runtime.TestApi.Fake;
using Object = UnityEngine.Object;

namespace PapersPlease.Tests.Runtime
{
    public static class Wait
    {
        [Obsolete("Tiene que desaparecer.")]
        public static Task aSecond => Task.Delay(1000.Milliseconds());

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

        public static IEnumerator TheWorkdayToStart()
        {
            ClickOn<SpeakerButton>();
            yield return new WaitForSeconds(1f);
        }

        public static IEnumerator TheWorkdayToEnd()
        {
            Object.FindObjectOfType<EntryPoint>().EndDayAtOnce();
            yield return new WaitForSeconds(1);
            ClickOn<SpeakerButton>();
            yield return new WaitForSeconds(1);
        }
    }
}