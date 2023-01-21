using System.Collections;
using FluentAssertions;
using FluentAssertions.Extensions;
using PapersPlease.Runtime.View;
using UnityEngine.TestTools;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class DateTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator GoToWork_ShowsTheDay()
        {
            yield return Simulate.WalkToWork();

            Find.TextOnChildLabelOf<Typewriter>().Should().Be($"{23.November(1982):dd MM yyyy}");
        }

        [UnityTest]
        public IEnumerator FinishWorkday_ShowsDayEnded_Unity()
        {
            yield return Simulate.WholeDay();

            TextOnLabelOf<Typewriter>().Should().Be("End of day 1");
        }

        [UnityTest]
        public IEnumerator EndDay_ThenStartDay_PassesToNextDay()
        {
            yield return Simulate.WholeDay();
            yield return Simulate.WalkToWork();

            Find.TextOnChildLabelOf<Typewriter>().Should().Be($"{24.November(1982):dd MM yyyy}");
        }
    }
}