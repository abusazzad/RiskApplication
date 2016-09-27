using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using RiskyBets.MicroService.DAL.Entities;
using CsvHelper;

namespace RiskyBets.MicroService.DAL
{
    public class SettledBetCsvRepository: IRepository<SettledBet>
    {
        public IList<SettledBet> GetAll()
        {
            var bets = new List<SettledBet>();
            try
            {
                var textReader = File.OpenText(HostingEnvironment.MapPath(@"~/App_Data/Settled.csv"));
                var csv = new CsvReader(textReader);
                var id = 0;
                while (csv.Read())
                {
                    ++id;
                    var bet = new SettledBet()
                    {
                        Id = id,
                        CustomerId = csv.GetField<int>(0),
                        EventId = csv.GetField<int>(1),
                        ParticipantId = csv.GetField<int>(2),
                        Stake = csv.GetField<int>(3),
                        WinAmount = csv.GetField<int>(4)
                    };
                    bets.Add(bet);
                }
                return bets;
            }
            catch 
            {
                return new List<SettledBet>();
            }
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