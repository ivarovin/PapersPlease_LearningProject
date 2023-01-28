using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Tests.Editor
{
    public class EconomyTests
    {
        [Test]
        public void Commodities_AreAlwaysTheSame()
        {
            var sut = new Economy();
            var commodities = sut.Commodities();

            commodities.Should().BeEquivalentTo(Commodities.Default);
        }

        [Test]
        public void Savings_StartsAt0()
        {
            var sut = new Economy();
            var savings = sut.Savings();

            savings.Should().Be(0);
        }

        [Test]
        public void Economy_AppliesPositiveBalance_ToSavings()
        {
            var sut = new Economy();
            sut.Apply(AnyPositiveBalance());

            sut.Savings().Should().BeGreaterThan(0);
        }
        
        [Test]
        public void Economy_AppliesNegativeBalance_ToSavings()
        {
            var sut = new Economy();
            sut.Apply(AnyNegativeBalance());

            sut.Savings().Should().BeLessThan(0);
        }

        [Test]
        public void CreatesDefaultBalance()
        {
            var sut = new Economy();

            using var _ = new AssertionScope();
            sut.BalanceForDay(WorkdayPerformance.Zero).Salary.Should().Be(0);
            sut.BalanceForDay(WorkdayPerformance.Zero).Penalties.Should().Be(0);
            sut.BalanceForDay(WorkdayPerformance.Zero).Heat.Should().Be(10);
            sut.BalanceForDay(WorkdayPerformance.Zero).Food.Should().Be(20);
            sut.BalanceForDay(WorkdayPerformance.Zero).Rent.Should().Be(20);
            sut.BalanceForDay(WorkdayPerformance.Zero).Savings.Should().Be(0);
        }

        [Test]
        public void SalaryAndPenaltiesVariesBalance()
        {
            var sut = new Economy();

            using var _ = new AssertionScope();
            sut.BalanceForDay(WorkdayPerformance.WithHits(2)).Salary.Should().Be(10);
            sut.BalanceForDay(WorkdayPerformance.WithFaults(3)).Penalties.Should().Be(15);
        }
        
        #region ObjectMother
        static Bills AnyPositiveBalance()
        {
            return new Bills
            {
                Salary = 0,
                Savings = int.MaxValue,
                Rent = 0,
                Penalties = 0,
                Food = 0,
                Heat = 0,
                ExpensesInHeat = false,
                ExpensesInFood = false
            };
        }
        
        static Bills AnyNegativeBalance()
        {
            return new Bills
            {
                Salary = 0,
                Savings = int.MinValue,
                Rent = 0,
                Penalties = 0,
                Food = 0,
                Heat = 0,
                ExpensesInHeat = false,
                ExpensesInFood = false
            };
        }
        #endregion
    }
}