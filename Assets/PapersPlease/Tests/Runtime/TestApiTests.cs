using System.Collections;
using FluentAssertions;
using PapersPlease.Runtime.View;
using UnityEngine;
using UnityEngine.TestTools;

namespace PapersPlease.Tests.Runtime
{
    /// <summary>
    /// ESTOS TESTS DEBERÍAN ACABAR EN PRODUCCIÓN DE ALGUNA MANERA.
    /// </summary>
    public class TestApiTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator WalkToWorkTest()
        {
            yield return Simulate.WalkToWork();
            Is.TypewritterHidden().Should().BeTrue();
        }

        [UnityTest]
        public IEnumerator StartDay()
        {
            yield return Simulate.WalkToWork();
            yield return Wait.TheWorkdayToStart();

            yield return new WaitForSeconds(1);

            Find.TextOnChildLabelOf<DigitalClock>().Should().NotBe("06:00:00");
        }
    }
}