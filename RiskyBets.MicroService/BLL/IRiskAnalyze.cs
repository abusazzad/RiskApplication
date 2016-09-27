﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskyBets.MicroService.BLL
{
    public interface IRiskAnalyze<T> where T : class
    {
        bool IsRiskyCustomer(IList<T> customerBets);
        bool IsUnusualBetCustomer(IList<T> customerBets, int stake);
        bool IsHighlyUnusualBetCustomer(IList<T> customerBets, int stake);
    }
}
