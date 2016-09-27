using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.Models
{
    public class UnsettledBetsModel: UnSettledBet
    {
        public string RiskType { get; set; }
    }
}