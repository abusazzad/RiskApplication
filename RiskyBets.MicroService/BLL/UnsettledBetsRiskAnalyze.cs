using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.BLL
{
    public class UnsettledBetsRiskAnalyze: IUnsettledBetRiskAnalyze<UnSettledBet>
    {
        private readonly IUnsettledBetRiskFactor _riskFactors;
        public UnsettledBetsRiskAnalyze(IUnsettledBetRiskFactor riskFactors)
        {
            _riskFactors = riskFactors;
        }
        public bool IsHighlyUnusualBetCustomer(IList<UnSettledBet> customerBets, int stake)
        {
            if (customerBets == null)
            {
                throw new ArgumentNullException("customerBets");
            }
            if (stake < 0)
            {
                throw new ArgumentOutOfRangeException("stake", "riskPercentage must be greater than 0");
            }

            var customerBetsCount = customerBets.Count();

            if (customerBetsCount == 0)
            {
                return false;
            }

            var avgAmt = customerBets.Average(q => q.Stake);
            return stake > (avgAmt * _riskFactors.HighlyUnusualBetTimes);
        }


        public bool IsUnusualBetCustomer(IList<UnSettledBet> customerBets, int stake)
        {
            if (customerBets == null)
            {
                throw new ArgumentNullException("customerBets");
            }
            if (stake < 0)
            {
                throw new ArgumentOutOfRangeException("stake", "riskPercentage must be greater than 0");
            }

            var customerBetsCount = customerBets.Count();

            if (customerBetsCount == 0)
            {
                return false;
            }

            var avgAmt = customerBets.Average(q => q.Stake);
            return stake > (avgAmt * _riskFactors.UnusualBetTimes);
        }
    }
}