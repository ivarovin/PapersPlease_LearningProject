using System.Collections;
using FluentAssertions;
using PapersPlease.Runtime.View;
using UnityEngine;
using UnityEngine.TestTools;

namespace PapersPlease.Tests.Runtime
{
    public class TestApiTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator WalkToWorkTest()
        {
            yield return Wait.WalkToWork();
            Is.TypewritterHidden().Should().BeTrue();
        }

        [UnityTest]
        public IEnumerator StartDay()
        {
            yield return Wait.WalkToWork();
            yield return Wait.TheDayToStart();

            yield return new WaitForSeconds(1);

            Find.TextOnChildLabelOf<DigitalClock>().Should().NotBe("06:00:00");
        }
        
        [UnityTest]
        public IEnumerator EndDay()
        {
            yield return Wait.WalkToWork();
            yield return Wait.TheDayToStart();
            yield return Wait.TheDayToEnd();

            Object.FindObjectOfType<EndDayScreen>().gameObject.activeInHierarchy.Should().BeTrue();
        }
    }
}