using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.View;
using UnityEngine;
using static RGV.TestApi.Runtime.TestApi.Find;

namespace PapersPlease.Tests.Runtime
{
    public class GameplayTests : WalkingSkeletonFixture
    {
        [Test]
        public async Task ShowNewspaper_WhenLoadGame()
        {
            TextOnLabelOf<Newspaper>().Should().Be($"{23.November(1982):dd/MM/yyyy}");
            Object.FindObjectOfType<Newspaper>().isActiveAndEnabled.Should().BeTrue();
        }
    }
}