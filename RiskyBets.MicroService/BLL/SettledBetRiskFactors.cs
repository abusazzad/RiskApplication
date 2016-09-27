using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskyBets.MicroService.BLL
{
    public class SettledBetRiskFactors: ISettledBetRiskFactor
    {
        public int RiskPercentage { get { return 60;} }
    }
}