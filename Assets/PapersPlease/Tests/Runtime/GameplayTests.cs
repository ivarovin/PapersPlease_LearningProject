using System.Collections;
using FluentAssertions;
using UnityEngine.TestTools;

namespace PapersPlease.Tests.Runtime
{
    public class GameplayTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator ShowNewspaper_WhenLoadGame()
        {
            yield return Wait.TheNewspaperToBeShown();
            Is.NewspaperVisible().Should().BeTrue();
        }

        [UnityTest]
        public IEnumerator OpenExpensesReport_WhenDayEnds()
        {
            yield return Simulate.WholeDay();
            Is.ExpensesReportVisible().Should().BeTrue();
        }

        [UnityTest]
        public IEnumerator OpenExpensesReport_ShowsEconomicBalance()
        {
            yield return Simulate.WholeDay();
            Find.EconomicValues().Should().OnlyContain(e => e.Value != -1);
        }

        [UnityTest]
        public IEnumerator CloseExpensesReport_WhenNewDayStarts()
        {
            yield return Simulate.WholeDay();
            yield return Simulate.PassToNextDay();
            Is.ExpensesReportVisible().Should().BeFalse();
        }

        [UnityTest]
        public IEnumerator NewDay_DoesNotStarts_Automatically()
        {
            yield return Simulate.WholeDay();
            Is.NewspaperHidden().Should().BeTrue();
        }
    }
}