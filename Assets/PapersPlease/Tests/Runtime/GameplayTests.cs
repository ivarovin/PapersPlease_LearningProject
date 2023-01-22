using System.Collections;
using FluentAssertions;
using PapersPlease.Runtime.View;
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

        [UnityTest]
        public IEnumerator CloseExpensesReport_WhenNewDayStarts()
        {
            yield return Simulate.WholeDay();
            yield return Simulate.PassToNextDay();
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