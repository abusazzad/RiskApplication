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
            throw new NotImplementedException();
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