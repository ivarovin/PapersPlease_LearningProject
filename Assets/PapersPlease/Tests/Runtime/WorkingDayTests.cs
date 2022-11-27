using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using static PapersPlease.Tests.Runtime.Wait;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class WorkingDayTests : WalkingSkeletonFixture
    {
        [Test]
        public async Task WorkingDayStartsWithFirstImmigrant()
        {
            ClickOn<SpeakerButton>();

            await aSecond;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:01");
        }
        
        [Test]
        public async Task WorkingDay_StartsAtSixAM()
        {
            ClickOn<SpeakerButton>();

            await aFrame;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:00");
        }
        
        [Test]
        public async Task Forwarding_IsNotPossible_BeforeWorkdayStarts()
        {
            ClickOn<ForwardingInput>();

            await aFrame;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:00");
        }
        
        [Test]
        public async Task Forwarding_DuringWorkday()
        {
            ClickOn<SpeakerButton>();
            ClickOn<ForwardingInput>();

            await aSecond;

            TextOnLabelOf<DigitalClock>().Should().Be("07:00:01");
        }
    }
}