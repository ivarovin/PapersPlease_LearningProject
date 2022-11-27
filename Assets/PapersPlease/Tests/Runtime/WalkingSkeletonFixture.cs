using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace PapersPlease.Tests.Runtime
{
    public abstract class WalkingSkeletonFixture
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return SceneManager.LoadSceneAsync("WalkingSkeleton");
        }
    }
}