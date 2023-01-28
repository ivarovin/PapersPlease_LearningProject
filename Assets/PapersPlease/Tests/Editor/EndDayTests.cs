using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using PapersPlease.Runtime.Controller;
using PapersPlease.Runtime.Model;

namespace PapersPlease.Tests.Editor
{
    public class EndDayTests
    {
        [Test]
        public async Task SecondTime_ReportsAs_Day2()
        {
            //Arrange
            var dummy = Workday.FirstOne;
            dummy.Start();

            var mock = Substitute.For<ExpensesReport>();
            mock.OfDay(default, default).ReturnsForAnyArgs(Task.CompletedTask);

            var sut = new EndDay(new Economy(), dummy, mock);

            await sut.Run();
            mock.ClearReceivedCalls();
            dummy.Start();

            //Act
            await sut.Run();

            //Assert
            await mock.Received(1).OfDay(2, Arg.Any<EconomicBalance>());
        }
    }
}