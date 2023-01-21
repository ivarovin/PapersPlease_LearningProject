using System.Collections;
using UnityEngine.TestTools;

namespace PapersPlease.Tests.Runtime
{
    public class TestApiTests : WalkingSkeletonFixture
    {
        [UnityTest]
        public IEnumerator WalkToWorkTest()
        {
            yield return Wait.WalkToWork();
        }
    }
}