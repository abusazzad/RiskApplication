using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskyBets.MicroService.DAL.Entities
{
    public class SettledBet: BaseBet
    {
        public int WinAmount { get; set; }
    }
}