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
            Find.EconomicMagnitudes().Should().OnlyContain(e => e.Value != -1);
        }

        [UnityTest]
        public IEnumerator SavingsChanges_asDaysPass()
        {
            yield return Simulate.WholeDay();
            
            var previousSavings = Find.EconomicMagnitudeValueOf("Savings");

            yield return Simulate.PassToNextDay();
            yield return Simulate.WholeDay();

            Find.EconomicMagnitudeValueOf("Savings").Should().NotBeEquivalentTo(previousSavings);
        }

        [UnityTest]
        public IEnumerator ApplyChoicesToExpenses()
        {
            yield return Simulate.WholeDay();

            var previousBalance = Find.EconomicMagnitudeValueOf("Balance");

            Fake.Toggle("Heat");

            Find.EconomicMagnitudeValueOf("Balance").Should().NotBeEquivalentTo(previousBalance);
        }

        [UnityTest]
        public IEnumerator ResetChoices_WhenOpenExpensesReport()
        {
            yield return Simulate.WholeDay();
            
            Fake.Toggle("Heat");

            yield return Simulate.PassToNextDay();
            yield return Simulate.WholeDay();
            
            Find.ToggleOf("Heat").isOn.Should().BeFalse();
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