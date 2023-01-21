using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine.TestTools;
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
            await WalkToWorkAsync();
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

        [UnityTest]
        public IEnumerator WalkToWorkTest()
        {
            yield return WalkToWork();
        }
    }
}