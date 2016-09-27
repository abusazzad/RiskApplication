using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskyBets.MicroService.BLL
{
    public interface IUnsettledBetRiskAnalyze<T> where T : class
    {
        bool IsUnusualBetCustomer(IList<T> customerBets, int stake);
        bool IsHighlyUnusualBetCustomer(IList<T> customerBets, int stake);
        bool IsWinOver1K(T customerBet);
    }
}
