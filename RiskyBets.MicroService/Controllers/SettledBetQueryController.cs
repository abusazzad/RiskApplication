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
    public class SettledBetQueryController : ApiController
    {
        private readonly IRepository<SettledBet> _repository;
        private readonly IRiskAnalyze<SettledBet> _riskAnalyze;

        public SettledBetQueryController(IRepository<SettledBet> repository, IRiskAnalyze<SettledBet> riskAnalyze)
        {
            _repository = repository;
            _riskAnalyze = riskAnalyze;
        }

        //GET api/SettledBetQuery
        public IHttpActionResult Get()
        {
            var sattledBets =  _repository.GetAll();
            return Ok(sattledBets);
        }

        //GET api/SettledBetQuery?CustomerId=1
        public IHttpActionResult Get(int customerId)
        {
            var sattledBets = _repository.GetAll();
            var customerBets = sattledBets.Where(q => q.CustomerId == customerId);
            var isRisky = _riskAnalyze.IsRiskyCustomer(customerBets.ToList());
            var response = new CustomerSattledBetsModel() {
                Bets = customerBets.ToList(),
                RiskType = isRisky? "Risky": "Safe"
            };
            
            return Ok(response);
        }

    }
}
