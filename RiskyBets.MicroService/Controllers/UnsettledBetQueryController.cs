using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using RiskyBets.MicroService.BLL;
using RiskyBets.MicroService.DAL;
using RiskyBets.MicroService.DAL.Entities;
using WebApi.Infrastructure.ActionFilters;
using RiskyBets.MicroService.Models;

namespace RiskyBets.MicroService.Controllers
{
    [ModelValidationFilter]
    [CustomExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UnsettledBetQueryController : ApiController
    {
        private readonly IRepository<UnSettledBet> _unsettledBetRepository;
        private readonly IRepository<SettledBet> _settledBetRepository;
        private readonly IUnsettledBetRiskAnalyze<UnSettledBet> _unsettledBetRiskAnalyze;
        private readonly ISettledBetRiskAnalyze<SettledBet> _settledBetRiskAnalyze;

        public UnsettledBetQueryController(IRepository<UnSettledBet> unsettledBetRepository, IRepository<SettledBet> settledBetRepository, IUnsettledBetRiskAnalyze<UnSettledBet> unsettledBetRiskAnalyze, ISettledBetRiskAnalyze<SettledBet> settledBetRiskAnalyze)
        {
            _unsettledBetRepository = unsettledBetRepository;
            _settledBetRepository = settledBetRepository;
            _unsettledBetRiskAnalyze = unsettledBetRiskAnalyze;
            _settledBetRiskAnalyze = settledBetRiskAnalyze;
        }

        //GET api/UnsettledBetQuery
        public IHttpActionResult Get()
        {
            var unsettledBets = _unsettledBetRepository.GetAll();
            var settledBets = _settledBetRepository.GetAll();
            var response = new List<UnsettledBetsModel>();
            foreach (var bet in unsettledBets)
            {
                var model = new UnsettledBetsModel();
                model.Id = bet.Id;
                model.CustomerId = bet.CustomerId;
                model.EventId = bet.EventId;
                model.ParticipantId = bet.ParticipantId;
                model.Stake = bet.Stake;
                model.ToWinAmount = bet.ToWinAmount;

                if (_unsettledBetRiskAnalyze.IsWinOver1K(bet))
                {
                    model.RiskType = "WIN 1K+";
                }else if (_unsettledBetRiskAnalyze.IsHighlyUnusualBetCustomer(
                    unsettledBets.Where(q => q.CustomerId == bet.CustomerId).ToList(), bet.Stake))
                {
                    model.RiskType = "HighlyUnusual";
                }
                else if (_unsettledBetRiskAnalyze.IsUnusualBetCustomer(
                   unsettledBets.Where(q => q.CustomerId == bet.CustomerId).ToList(), bet.Stake))
                {
                    model.RiskType = "Unusual";
                }
                else if (_settledBetRiskAnalyze.IsRiskyCustomer(
                    settledBets.Where(q => q.CustomerId == bet.CustomerId).ToList()))
                {
                    model.RiskType = "Risky";
                }
                else
                {
                    model.RiskType = "None";
                }

                response.Add(model);
            }

            return Ok(response);
        }

    }
}
