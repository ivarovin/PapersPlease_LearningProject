using System;
using System.Collections;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace PapersPlease.Tests.Runtime
{
    public class WalkingSkeletonTests
    {
        const float aWhile = 0.5f;
        
        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
        }
        
        [UnityTest]
        public IEnumerator StartDay()
        {
            FindObjectOfType<StartDayInput>().GetComponent<Button>().onClick.Invoke();

            yield return new WaitForSeconds(aWhile);
            
            var dayLabel = FindObjectOfType<LabelDayView>().GetComponent<TextMeshProUGUI>();
            dayLabel.text.Should().Be($"Day started: {23.November(1982):dd/MM/yyyy}");
        }
        
        [UnityTest]
        public IEnumerator EndDay()
        {
            FindObjectOfType<StartDayInput>().GetComponent<Button>().onClick.Invoke();
            yield return new WaitForSeconds(aWhile);
            
            FindObjectOfType<EndDayInput>().GetComponent<Button>().onClick.Invoke();
            yield return new WaitForSeconds(aWhile);

            var dayLabel = FindObjectOfType<LabelDayView>().GetComponent<TextMeshProUGUI>();
            dayLabel.text.Should().Be($"Day ended: {23.November(1982):dd/MM/yyyy}");
        }
    }
}