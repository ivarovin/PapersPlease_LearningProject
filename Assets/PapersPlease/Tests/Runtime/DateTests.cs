using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine.TestTools;
using static PapersPlease.Tests.Runtime.Wait;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;
using static UnityEngine.Object;

namespace PapersPlease.Tests.Runtime
{
    public class DateTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator GoToWork_ShowsTheDay()
        {
            yield return WalkToWork();

            TextOnChildLabelOf<Typewriter>().Should().Be($"{23.November(1982):dd MM yyyy}");
        }

        [Test]
        public async Task FinishWorkday_ShowsDayEnded()
        {
            await WalkToWorkAsync();

            ClickOn<SpeakerButton>();
            await aSecondOdd;

            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;

            ClickOn<SpeakerButton>();
            await aSecond;
            
            TextOnLabelOf<Typewriter>().Should().Be("End of day 1");
        }

        [Test]
        public async Task EndDay_ThenStartDay_PassesToNextDay()
        {
            await WalkToWorkAsync();

            ClickOn<SpeakerButton>();
            await aSecondOdd;

            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;
            
            ClickOn<SpeakerButton>();
            await aSecond;

            await WalkToWorkAsync();
            await aSecond;
            await aSecond;

            TextOnChildLabelOf<Typewriter>().Should().Be($"{24.November(1982):dd MM yyyy}");
        }
    }
}