using System;
using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class DateTests
    {
        static Task aFew => Task.Delay(1000.Milliseconds());

        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return null;
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
            yield return null;
        }

        [Test]
        public async Task StartDay()
        {
            ClickOn<StartDayInput>();

            await aFew;

            TextOnLabelOf<LabelDayView>().Should().Be($"Day started: {23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task EndDay()
        {
            ClickOn<StartDayInput>();
            await aFew;

            ClickOn<EndDayInput>();
            await aFew;

            TextOnLabelOf<LabelDayView>().Should().Be($"Day ended: {23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task EndDay_ThenStartDay_PassesToNextDay()
        {
            ClickOn<StartDayInput>();
            await aFew;
            
            ClickOn<EndDayInput>();
            await aFew;
            
            ClickOn<StartDayInput>();
            await aFew;

            TextOnLabelOf<LabelDayView>().Should().Be($"Day started: {24.November(1982):dd/MM/yyyy}");
        }
    }
}