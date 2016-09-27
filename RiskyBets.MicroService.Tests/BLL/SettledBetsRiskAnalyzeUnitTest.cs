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
    public class IsRiskyCustomerUnitTest
    {

        private readonly IFixture _fixture;

        public IsRiskyCustomerUnitTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Fact]
        [Trait("BLL", "IsRiskyCustomer")]
        public void Should_Pass_When_Passing_Valid_Param()
        {
            //Arrange
            var mockRiskFactor = new Mock<ISettledBetRiskFactor>();
            mockRiskFactor.Setup(m => m.RiskPercentage).Returns(0);
            var riskyCustomer = new SettledBetsRiskAnalyze(mockRiskFactor.Object);

            var bets = _fixture.Create<List<SettledBet>>();

            //Act
            var response = riskyCustomer.IsRiskyCustomer(bets);

            //Assert
            response.Should().BeTrue();
        }

        [Fact]
        [Trait("BLL", "IsRiskyCustomer")]
        public void Should_throw_ArgumentNullException_When_Try_With_Null_Bets()
        {
            //Arrange
            var mockRiskFactor = new Mock<ISettledBetRiskFactor>();
            mockRiskFactor.Setup(m => m.RiskPercentage).Returns(60);
            var riskyCustomer = new SettledBetsRiskAnalyze(mockRiskFactor.Object);
            try
            {
                //Act
                var response = riskyCustomer.IsRiskyCustomer(null);
            }
            catch (Exception ex)
            {
                //Assert
                Xunit.Assert.IsType<ArgumentNullException>(ex);
            }


        }

        [Fact]
        [Trait("BLL", "IsRiskyCustomer")]
        public void Should_throw_ArgumentOutOfRangeException_When_Try_With_Invalid_RiskPercentage()
        {
            //Arrange
            var mockRiskFactor = new Mock<ISettledBetRiskFactor>();
            mockRiskFactor.Setup(m => m.RiskPercentage).Returns(-60);
            var riskyCustomer = new SettledBetsRiskAnalyze(mockRiskFactor.Object);

            var bets = _fixture.Create<List<SettledBet>>();

            try
            {   //Act
                var response = riskyCustomer.IsRiskyCustomer(bets);

            }
            catch (Exception ex)
            {
                Xunit.Assert.IsType<InvalidDataException>(ex);
            }


        }

    }
}
