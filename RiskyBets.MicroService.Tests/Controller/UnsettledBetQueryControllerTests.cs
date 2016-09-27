using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;
using RiskyBets.MicroService.DAL;
using RiskyBets.MicroService.DAL.Entities;
using RiskyBets.MicroService.BLL;
using RiskyBets.MicroService.Controllers;

namespace RiskyBets.MicroService.Tests.Controller
{
    public class UnsettledBetQueryControllerTests
    {
        public class GetUnitTest
        {
            private readonly IFixture _fixture;
            public GetUnitTest()
            {
                _fixture = new Fixture().Customize(new AutoMoqCustomization());
            }

            [Fact]
            [Trait("Api", "Controller")]
            public void Should_Return_All_Bets()
            {
                //Arrange
                var unsettledBets = _fixture.Create<List<UnSettledBet>>();
                var settledBets = _fixture.Create<List<SettledBet>>();
                var mockUnsettledRepository = _fixture.Freeze<Mock<IRepository<UnSettledBet>>>();
                var mockUnsettledRiskAnalyze = _fixture.Freeze<Mock<IUnsettledBetRiskAnalyze<UnSettledBet>>>();
                var mockSettledRepository = _fixture.Freeze<Mock<IRepository<SettledBet>>>();
                var mockSettledRiskAnalyze = _fixture.Freeze<Mock<ISettledBetRiskAnalyze<SettledBet>>>();

                mockUnsettledRepository.Setup(m => m.GetAll()).Returns(unsettledBets);
                mockSettledRepository.Setup(m => m.GetAll()).Returns(settledBets);
                var controller = new UnsettledBetQueryController(mockUnsettledRepository.Object, mockSettledRepository.Object, mockUnsettledRiskAnalyze.Object, mockSettledRiskAnalyze.Object);

                //Act
                var response = controller.Get();

                //Assert
                Assert.NotNull(response);
            }
        }
    }
}
