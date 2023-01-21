using System.Collections;
using FluentAssertions;
using PapersPlease.Runtime.View;
using UnityEngine;
using UnityEngine.TestTools;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class WorkingDayTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator WorkingDayStartsWithFirstEntrant()
        {
            yield return Wait.WalkToWork();
            ClickOn<SpeakerButton>();
            yield return new WaitForSeconds(2);

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:01");
        }

        [UnityTest]
        public IEnumerator WorkingDay_StartsAtSixAM()
        {
            yield return Wait.WalkToWork();
            TextOnLabelOf<DigitalClock>().Should().Be("06:00:00");
        }
    }
}