using System;
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
    [TestClass]
    public class IsRiskyCustomerUnitTest
    {
        [TestMethod]
        public void Should_Pass_When_Passing_Valid_Param()
        {
            var riskyCustomer = new SettledBetsRiskAnalyze();
            var response = riskyCustomer.IsRiskyCustomer(new List<SettledBet>() { new SettledBet() { CustomerId =1, WinAmount = 10 } }, 60);

            response.Should().BeTrue();
        }

        [TestMethod]
        public void Should_throw_ArgumentNullException_When_Try_With_Null_Bets()
        {
            var riskyCustomer = new SettledBetsRiskAnalyze();
            try
            {
                var response = riskyCustomer.IsRiskyCustomer(null, 60);

            }
            catch (Exception ex)
            {
                Xunit.Assert.IsType< ArgumentNullException>(ex);
            }


        }

        [TestMethod]
        public void Should_throw_ArgumentOutOfRangeException_When_Try_With_Invalid_RiskPercentage()
        {
            var riskyCustomer = new SettledBetsRiskAnalyze();
            try
            {
                var response = riskyCustomer.IsRiskyCustomer(new List<SettledBet>(), -0);

            }
            catch (Exception ex)
            {
                Xunit.Assert.IsType< ArgumentOutOfRangeException>(ex);
            }


        }

        [TestMethod]
        public void Should_Pass_When_Try_With_NoBet_And_Valid_RiskPercentage()
        {
            var riskyCustomer = new SettledBetsRiskAnalyze();
            var response = riskyCustomer.IsRiskyCustomer(new List<SettledBet>(), 1);

            response.Should().BeFalse();
        }
    }

    [TestClass]
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
            var bets = _fixture.Create<List<SettledBet>>();
            var riskyCustomer = new SettledBetsRiskAnalyze();

            //Act
            var response = riskyCustomer.IsHighlyUnusualBetCustomer(bets, (int)bets.Average(q=>q.Stake)*35);

            //Assert
            response.Should().BeTrue();
        }
    }
}
