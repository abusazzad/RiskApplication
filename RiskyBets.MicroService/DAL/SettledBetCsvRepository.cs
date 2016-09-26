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
            throw new NotImplementedException();
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