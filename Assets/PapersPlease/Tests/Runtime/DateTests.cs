using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static PapersPlease.Tests.Runtime.Wait;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;
using static UnityEngine.Object;

namespace PapersPlease.Tests.Runtime
{
    public class DateTests
    {
        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return null;
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
            yield return null;
        }

        [Test]
        public async Task GoToWork_ShowsTheDay()
        {
            ClickOn<WalkToWork>();

            await aSecond;

            TextOnLabelOf<LabelDayView>().Should().Be($"Day started: {23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task FinishWorkday_ShowsDayEnded()
        {
            ClickOn<WalkToWork>();
            ClickOn<Speaker>();
            await aSecondOdd;

            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;

            TextOnLabelOf<LabelDayView>().Should().Be($"Day ended: {23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task EndDay_ThenStartDay_PassesToNextDay()
        {
            ClickOn<WalkToWork>();
            ClickOn<Speaker>();
            await aSecondOdd;
            
            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;
            
            ClickOn<WalkToWork>();
            await aSecondOdd;

            TextOnLabelOf<LabelDayView>().Should().Be($"Day started: {24.November(1982):dd/MM/yyyy}");
        }
    }
}