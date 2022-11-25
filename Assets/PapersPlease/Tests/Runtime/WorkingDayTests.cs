using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using RGV.TestApi.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class WorkingDayTests
    {
        static Task kindaSecond => Task.Delay(1100.Milliseconds());
        static YieldAwaitable aFrame => Task.Yield();

        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
        }

        [Test]
        public async Task WorkingDayStartsWithFirstImmigrant()
        {
            ClickOn<Speaker>();

            await kindaSecond;

            TextOnLabelOf<DigitalClock>().Should().Be("06:00:01");
        }
        
        [Test]
        public async Task WorkingDay_StartsAtSixAM()
        {
            ClickOn<Speaker>();

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
            ClickOn<Speaker>();
            ClickOn<ForwardingInput>();

            await kindaSecond;

            TextOnLabelOf<DigitalClock>().Should().Be("07:00:01");
        }
    }
}