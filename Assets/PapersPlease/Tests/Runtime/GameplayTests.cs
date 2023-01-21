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
            yield return Wait.WalkToWork();
            yield return Wait.TheDayToStart();
            yield return Wait.TheDayToEnd();
            
            FindObjectOfType<EndDayScreen>(true).gameObject.activeInHierarchy.Should().BeTrue();
        }
    }
}