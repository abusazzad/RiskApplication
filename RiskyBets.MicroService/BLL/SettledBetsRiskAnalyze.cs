using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.BLL
{
    public class SettledBetsRiskAnalyze: IRiskAnalyze<SettledBet>
    {
        public bool IsRiskyCustomer(IList<SettledBet> customerBets, int riskPercentage)
        {
            throw new NotImplementedException();
        }
    }
}