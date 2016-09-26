using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskyBets.MicroService.BLL;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.Tests.BLL
{
    /// <summary>
    /// Summary description for SettledBetsRiskAnalyzeUnitTest
    /// </summary>
    [TestClass]
    public class SettledBetsRiskAnalyzeUnitTest
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
                Assert.IsInstanceOfType(ex, new ArgumentNullException().GetType());
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
                Assert.IsInstanceOfType(ex, new ArgumentOutOfRangeException().GetType());
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
}
