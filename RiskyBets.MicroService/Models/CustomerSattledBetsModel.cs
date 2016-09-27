using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.Models
{
    public class CustomerSattledBetsModel
    {
        public List<SettledBet> Bets { get; set; }
        public string RiskType { get; set; }
    }
}