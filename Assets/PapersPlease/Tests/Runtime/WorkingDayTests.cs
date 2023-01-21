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

        [Test]
        public async Task WorkingDay_StartsAtSixAM()
        {
            await WalkToWork();
            ClickOn<SpeakerButton>();

            await aFrame;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:00");
        }

        [Test]
        public async Task Forwarding_IsNotPossible_BeforeWorkdayStarts()
        {
            await WalkToWork();
            ClickOn<ForwardingInput>();

            await aFrame;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:00");
        }

        [Test]
        public async Task Forwarding_DuringWorkday()
        {
            await WalkToWork();

            ClickOn<SpeakerButton>();
            await aSecond;

            ClickOn<ForwardingInput>();
            await aSecond;

            TextOnLabelOf<DigitalClock>().Should().Be("07:00:01");
        }
    }
}