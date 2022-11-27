using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine;
using static PapersPlease.Tests.Runtime.Wait;

namespace PapersPlease.Tests.Runtime
{
    public class GameplayTests : WalkingSkeletonFixture
    {
        [Test]
        public async Task ShowNewspaper_WhenLoadGame()
        {
            await aSecond;
            Object.FindObjectOfType<CanvasNewspaper>().isActiveAndEnabled.Should().BeTrue();
        }
    }
}