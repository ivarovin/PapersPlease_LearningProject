using System.Collections;
using System.Linq;
using FluentAssertions;
using PapersPlease.Runtime.View;
using TMPro;
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
        public IEnumerator OpenExpensesReport_ShowsEconomicBalance()
        {
            yield return Simulate.WholeDay();

            var values = FindObjectsOfType<EconomicValue>().SelectMany(e => e.GetComponentsInChildren<TMP_Text>());
            values.Should().HaveCount(14);
            foreach(var v in values)
                v.text.Should().NotBe("Value");
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