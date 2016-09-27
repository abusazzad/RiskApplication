using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.BLL
{
    public class SettledBetsRiskAnalyze: IRiskAnalyze<SettledBet>
    {        
        public bool IsHighlyUnusualBetCustomer(IList<SettledBet> customerBets, int stake)
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
            return stake > (avgAmt * 30);
        }

        public bool IsRiskyCustomer(IList<SettledBet> customerBets, int riskPercentage)
        {
            if (customerBets == null)
            {
                throw new ArgumentNullException("customerBets");
            }
            if (riskPercentage < 0)
            {
                throw new ArgumentOutOfRangeException("riskPercentage", "riskPercentage must be greater than 0");
            }

            var customerBetsCount = customerBets.Count();

            if (customerBetsCount == 0)
            {
                return false;
            }
            var customerWinningBets = customerBets.Count(q => q.WinAmount > 0);

            var winningBetPercentage = (customerWinningBets * 100) / customerBetsCount;

            return winningBetPercentage > riskPercentage;
        }

        public bool IsUnusualBetCustomer(IList<SettledBet> customerBets, int stake)
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
            return stake > (avgAmt * 10);
        }
    }
}