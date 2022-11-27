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
        [Test]
        public async Task GoToWork_ShowsTheDay()
        {
            ClickOn<WalkToWorkButton>();

            await aSecond;

            TextOnChildLabelOf<Typewriter>().Should().Be($"Day started: {23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task FinishWorkday_ShowsDayEnded()
        {
            ClickOn<WalkToWorkButton>();
            ClickOn<SpeakerButton>();
            await aSecondOdd;

            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;

            TextOnLabelOf<Typewriter>().Should().Be($"Day ended: {23.November(1982):dd/MM/yyyy}");
        }

        [Test]
        public async Task EndDay_ThenStartDay_PassesToNextDay()
        {
            ClickOn<WalkToWorkButton>();
            ClickOn<SpeakerButton>();
            await aSecondOdd;
            
            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;
            
            ClickOn<WalkToWorkButton>();
            await aSecondOdd;

            TextOnChildLabelOf<Typewriter>().Should().Be($"Day ended: {24.November(1982):dd/MM/yyyy}");
        }
    }
}