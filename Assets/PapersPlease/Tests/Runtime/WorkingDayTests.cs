using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine;
using UnityEngine.TestTools;
using static PapersPlease.Tests.Runtime.Wait;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class WorkingDayTests : WalkingSkeletonFixture
    {
        static async Task WalkToWork()
        {
            await aSecond;
            ClickOn<WalkToWorkButton>();
            await aSecond;
            await aSecond;
        }

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

        [Test, Description("False negative")]
        public async Task Forwarding_IsNotPossible_BeforeWorkdayStarts()
        {
            await WalkToWork();
            ClickOn<ForwardingInput>();

            await aFrame;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:00");
        }
    }
}