using System;
using System.Collections;
using DG.Tweening;
using PapersPlease.Runtime.Model;
using PapersPlease.Runtime.View;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace PapersPlease.Tests.Runtime
{
    public abstract class WalkingSkeletonFixture
    {
        TimeSpan originalRealtimeWorkday;
        
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            Time.timeScale *= 10; 
            
            originalRealtimeWorkday = EntryPoint.RealtimeWorkday;
            EntryPoint.RealtimeWorkday = Worktime.Default.Duration;
            
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
        }
        
        [UnityTearDown]
        public IEnumerator TearDown()
        {
            Time.timeScale /= 10;
            
            EntryPoint.RealtimeWorkday = originalRealtimeWorkday;
            DOTween.KillAll(); //Si fuera Complete, las cosas destruidas darían MissingReferenceException.
            yield return null;
        }
    }
}