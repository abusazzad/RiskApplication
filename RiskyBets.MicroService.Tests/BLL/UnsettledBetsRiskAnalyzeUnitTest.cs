using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskyBets.MicroService.BLL;
using RiskyBets.MicroService.DAL.Entities;

using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;
namespace RiskyBets.MicroService.Tests.BLL
{

    public class IsHighlyUnusualBetCustomerUnitTest
    {
        private readonly IFixture _fixture;
        public IsHighlyUnusualBetCustomerUnitTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }
        [Fact]
        [Trait("BLL", "IsHighlyUnusualBetCustomer")]
        public void Should_Pass_When_Passing_Valid_Params()
        {
            //Arrange
            var mockRiskFactor = new Mock<IUnsettledBetRiskFactor>();
            mockRiskFactor.Setup(m => m.HighlyUnusualBetTimes).Returns(30);

            var bets = _fixture.Create<List<UnSettledBet>>();
            var riskyCustomer = new UnsettledBetsRiskAnalyze(mockRiskFactor.Object);

            //Act
            var response = riskyCustomer.IsHighlyUnusualBetCustomer(bets, (int)bets.Average(q=>q.Stake)*35);

            //Assert
            response.Should().BeTrue();
        }
    }
}
