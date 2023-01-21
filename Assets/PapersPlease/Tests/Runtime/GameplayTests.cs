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
        [UnityTest]
        public IEnumerator ShowNewspaper_WhenLoadGame()
        {
            yield return Wait.TheNewspaperToBeShown();
            FindObjectOfType<CanvasNewspaper>().isActiveAndEnabled.Should().BeTrue();
        }

        [Test]
        public async Task OpenExpensesReport_WhenDayEnds()
        {
            // await WalkToWorkAsync();
            // await aSecond;
            // await aSecond;
            // await aSecond;
            // await aSecond;
            //

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
        public IEnumerator OpenExpensesReport_WhenDayEnds_Unity()
        {
            yield return Wait.WalkToWork();
            yield return Wait.TheDayToStart();
            yield return Wait.TheDayToEnd();
            
            FindObjectOfType<EndDayScreen>(true).isActiveAndEnabled.Should().BeTrue();
        }
    }
}