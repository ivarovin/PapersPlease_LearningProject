using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using RGV.TestApi.Runtime;
using UnityEngine.TestTools;
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

        [UnityTest]
        public IEnumerator OpenExpensesReport_WhenDayEnds()
        {
            yield return Simulate.WholeDay();
            FindObjectOfType<EndDayScreen>(true).gameObject.activeInHierarchy.Should().BeTrue();
        }

        [UnityTest, Ignore("Not implemented yet")]
        public IEnumerator CloseExpensesReport_WhenNewDayStarts()
        {
            yield return Simulate.WholeDay();
            TestApi.Fake.ClickOn<CloseEndDayScreenButton>();
            FindObjectOfType<EndDayScreen>(false).gameObject.activeInHierarchy.Should().BeTrue();
        }

        [UnityTest]
        public IEnumerator NewDay_DoesNotStarts_Automatically()
        {
            yield return Simulate.WholeDay();
            Is.NewspaperHidden().Should().BeTrue();
        }
    }
}