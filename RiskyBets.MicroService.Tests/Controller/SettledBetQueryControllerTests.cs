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
    public class SettledBetQueryControllerTests
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
                var bets = _fixture.Create<List<SettledBet>>();
                var mockRepository = _fixture.Freeze<Mock<IRepository<SettledBet>>>();
                var mockRiskAnalyze = _fixture.Freeze<Mock<ISettledBetRiskAnalyze<SettledBet>>>();
                mockRepository.Setup(m=>m.GetAll()).Returns(bets);
                var controller = new SettledBetQueryController(mockRepository.Object, mockRiskAnalyze.Object);

                //Act
                var response = controller.Get();

                //Assert
                Assert.NotNull(response);
            }
        }
    }
}
