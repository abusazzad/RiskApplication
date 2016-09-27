using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskyBets.MicroService.BLL
{
    public class UnsettledBetRiskFactors : IUnsettledBetRiskFactor
    {
        public int UnusualBetTimes { get { return 10; } }
        public int HighlyUnusualBetTimes { get { return 30; } }
    }
}