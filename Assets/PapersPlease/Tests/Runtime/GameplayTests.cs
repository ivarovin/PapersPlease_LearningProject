using System.Collections;
using FluentAssertions;
using NUnit.Framework;
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

        [UnityTest, Repeat(100)]
        public IEnumerator OpenExpensesReport_WhenDayEnds()
        {
            yield return Simulate.WholeDay();
            FindObjectOfType<EndDayScreen>(true).gameObject.activeInHierarchy.Should().BeTrue();
        }
    }
}