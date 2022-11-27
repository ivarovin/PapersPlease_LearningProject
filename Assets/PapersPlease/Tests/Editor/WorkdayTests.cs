using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Tests.Editor
{
    public class WorkdayTests
    {
        [Test]
        public void Duration_of_aWorktime()
        {
            var sut = new Worktime
            {
                Start = 05.Hours(),
                End = 19.Hours()
            };
            
            sut.Duration.Should().Be(14.Hours());
        }

        [Test]
        public void Workday_DoesNotStart_Automatically()
        {
            var doc = new Worktime
            {
                Start = 12.Hours(),
                End = 22.Hours()
            };
            var sut = new Workday(21.June(1944), doc);
            
            sut.Forward(4.Hours());

            sut.TimeToOver.Should().Be(doc.Duration);
            sut.TimeOfDay.Should().Be(doc.Start);
        }
        
        
        [Test]
        public void IsOver_WhenIsAboutToEnd()
        {
            var doc = new Worktime
            {
                Start = 9.Hours(),
                End = 17.Hours()
            };
            var sut = new Workday(1.January(2000), doc);
            sut.Start();
            
            sut.Forward(8.Hours() - 900.Milliseconds());
            
            sut.IsOver.Should().BeTrue();
        }

        [Test]
        public void RemaningTimeOfWorkday_IsSameThanWorktimeDuration_AtTheBeginningOfDay()
        {
            var doc = new Worktime
            {
                Start = 15.Hours(),
                End = 21.Hours()
            };
            var sut = new Workday(1.January(2077), doc);
            sut.Start();
            
            sut.TimeToOver.Should().Be(doc.Duration);
        }

        [Test]
        public void Spend_aWholeDay_FastForward_toBeginOfNextDay()
        {
            var doc = new Worktime
            {
                Start = 9.Hours(),
                End = 17.Hours()
            };
            var sut = new Workday(1.January(2000), doc);
            sut.Start();
            sut.Forward(doc.Duration - 1.Minutes());
            
            sut.SpendDay();
            
            sut.TimeOfDay.Should().Be(doc.Start);
            ((DateTime)sut).Should().BeSameDateAs(2.January(2000));
        }

        [Test]
        public void DaysFrom_TheFirstWorkday_StartsAtOne()
        {
            var sut = new Workday(Workday.FirstOne);
            
            sut.DaysSinceBeginning.Should().Be(1);
        }
    }
}