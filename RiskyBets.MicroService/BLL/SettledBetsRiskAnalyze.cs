using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.BLL
{
    public class SettledBetsRiskAnalyze: ISettledBetRiskAnalyze<SettledBet>
    {
        private readonly ISettledBetRiskFactor _riskFactors;
        public SettledBetsRiskAnalyze(ISettledBetRiskFactor riskFactors)
        {
            _riskFactors = riskFactors;
        }

        public bool IsRiskyCustomer(IList<SettledBet> customerBets)
        {
            if (customerBets == null)
            {
                throw new ArgumentNullException("customerBets");
            }
            if (_riskFactors.RiskPercentage < 0)
            {
                throw new InvalidDataException( "riskPercentage must be greater than 0");
            }

            var customerBetsCount = customerBets.Count();

            if (customerBetsCount == 0)
            {
                return false;
            }
            var customerWinningBets = customerBets.Count(q => q.WinAmount > 0);

            var winningBetPercentage = (customerWinningBets * 100) / customerBetsCount;

            return winningBetPercentage > _riskFactors.RiskPercentage;
        }

    }
}