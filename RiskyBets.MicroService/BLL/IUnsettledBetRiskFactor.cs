using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskyBets.MicroService.BLL
{
    public interface IUnsettledBetRiskFactor
    {
        int UnusualBetTimes { get; }
        int HighlyUnusualBetTimes { get;}
    }
}
