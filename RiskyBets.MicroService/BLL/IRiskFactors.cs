using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskyBets.MicroService.BLL
{
    public interface IRiskFactors
    {
        int RiskPercentage { get; }
        int UnusualBetTimes { get; }
        int HighlyUnusualBetTimes { get;}
    }
}
