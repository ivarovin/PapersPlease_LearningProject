using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using static PapersPlease.Tests.Runtime.Wait;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static UnityEngine.Object;


namespace PapersPlease.Tests.Runtime
{
    public class GameplayTests : WalkingSkeletonFixture
    {
        [Test]
        public async Task ShowNewspaper_WhenLoadGame()
        {
            await aSecond;
            FindObjectOfType<CanvasNewspaper>().isActiveAndEnabled.Should().BeTrue();
        }

        [Test]
        public async Task OpenExpensesReport_WhenDayEnds()
        {
            await WalkToWork();
            await aSecond;
            await aSecond;
            await aSecond;
            await aSecond;
            

            ClickOn<SpeakerButton>();
            await aSecondOdd;

            FindObjectOfType<EntryPoint>().EndDayAtOnce();
            await aSecondOdd;
            ClickOn<SpeakerButton>();
            await aSecondOdd;
            await aSecondOdd;
            await aSecondOdd;
            await aSecondOdd;
            

            FindObjectOfType<EndDayScreen>(true).isActiveAndEnabled.Should().BeTrue();
        }
    }
}