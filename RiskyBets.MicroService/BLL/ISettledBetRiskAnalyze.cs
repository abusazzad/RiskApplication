using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskyBets.MicroService.BLL
{
    public interface ISettledBetRiskAnalyze<T> where T : class
    {
        bool IsRiskyCustomer(IList<T> customerBets);
    }
}
