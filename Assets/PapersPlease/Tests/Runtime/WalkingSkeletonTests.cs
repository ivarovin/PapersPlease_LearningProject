using System;
using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using RGV.TestApi.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using static RGV.TestApi.Runtime.TestApi.Fake;
using static RGV.TestApi.Runtime.TestApi.Find;
using static UnityEngine.Object;

namespace PapersPlease.Tests.Runtime
{
    public class WalkingSkeletonTests
    {
        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
        }

        [Test]
        public async Task StartDayAsync()
        {
            ClickOn<StartDayInput>();

            await Task.Delay(1.Seconds());
            
            TextOnLabelOf<LabelDayView>().Should().Be($"Day started: {23.November(1982):dd/MM/yyyy}");
        }
        
        [Test]
        public async Task EndDayAsync()
        {
            ClickOn<StartDayInput>();
            await Task.Delay(1.Seconds());
            
            ClickOn<EndDayInput>();
            await Task.Delay(1.Seconds());

            TextOnLabelOf<LabelDayView>().Should().Be($"Day ended: {23.November(1982):dd/MM/yyyy}");
        }
        
        [Test]
        public async Task EndDay_ThenStartDay_PassesToNextDay()
        {
            ClickOn<StartDayInput>();
            await Task.Delay(1.Seconds());
            
            ClickOn<EndDayInput>();
            await Task.Delay(1.Seconds());
            
            ClickOn<StartDayInput>();
            await Task.Delay(1.Seconds());

            TextOnLabelOf<LabelDayView>().Should().Be($"Day started: {24.November(1982):dd/MM/yyyy}");
        }
    }
}