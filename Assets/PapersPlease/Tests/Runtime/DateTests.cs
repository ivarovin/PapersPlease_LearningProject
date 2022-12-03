using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using static PapersPlease.Tests.Runtime.Wait;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;
using static UnityEngine.Object;

namespace PapersPlease.Tests.Runtime
{
    public class DateTests : WalkingSkeletonFixture
    {
        static async Task WalkToWork()
        {
            await aSecond;
            ClickOn<WalkToWorkButton>();
            await aSecond;
            await aFrame;
        }

        [Test]
        public async Task GoToWork_ShowsTheDay()
        {
            await WalkToWork();

            TextOnChildLabelOf<Typewriter>().Should().Be($"{23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task FinishWorkday_ShowsDayEnded()
        {
            await WalkToWork();

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
            await WalkToWork();

            ClickOn<SpeakerButton>();
            await aSecondOdd;

            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;
            
            ClickOn<SpeakerButton>();
            await aSecond;

            await WalkToWork();
            await aSecond;

            TextOnChildLabelOf<Typewriter>().Should().Be($"{24.November(1982):dd/MM/yyyy}");
        }
    }
}