using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using RiskyBets.MicroService.DAL;
using RiskyBets.MicroService.DAL.Entities;
using WebApi.Infrastructure.ActionFilters;

namespace RiskyBets.MicroService.Controllers
{
    [ModelValidationFilter]
    [CustomExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SettledBetQueryController : ApiController
    {
        private readonly IRepository<SettledBet> _repository;

        public SettledBetQueryController(IRepository<SettledBet> repository)
        {
            _repository = repository;
        }

        //GET api/SettledBetQuery
        public IHttpActionResult Get()
        {
            var sattledBets =  _repository.GetAll();
            return Ok(sattledBets);
        }
    }
}
