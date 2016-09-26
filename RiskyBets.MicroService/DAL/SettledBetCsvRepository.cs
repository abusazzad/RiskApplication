using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.DAL
{
    public class SettledBetCsvRepository: IRepository<SettledBet>
    {
        public IList<SettledBet> GetAll()
        {
            var bets = new List<SettledBet>()
            {
                new SettledBet(){Id = 1, CustomerId = 1, EventId = 1, ParticipantId = 6, Stake = 50, WinAmount = 250},
                new SettledBet(){Id = 2, CustomerId = 2, EventId = 1, ParticipantId = 3, Stake = 5, WinAmount = 0},
            };
            return bets;
            //throw new NotImplementedException();
        }

        public SettledBet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(SettledBet entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SettledBet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SettledBet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}