using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.DAL
{
    public class UnsettledBetCsvRepository: IRepository<UnSettledBet>
    {
        public IList<UnSettledBet> GetAll()
        {
            var bets = new List<UnSettledBet>()
            {
                new UnSettledBet(){Id = 1, CustomerId = 1, EventId = 11, ParticipantId = 4, Stake = 50, ToWinAmount = 500},
                new UnSettledBet(){Id = 2, CustomerId = 3, EventId = 11, ParticipantId = 6, Stake = 50, ToWinAmount = 400},
            };
            return bets;
        }

        public UnSettledBet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(UnSettledBet entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UnSettledBet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UnSettledBet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}