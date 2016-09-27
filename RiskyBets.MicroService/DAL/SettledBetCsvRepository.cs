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
            //var bets = new List<SettledBet>()
            //{
            //    new SettledBet(){Id = 1, CustomerId = 1, EventId = 1, ParticipantId = 6, Stake = 50, WinAmount = 250},
            //    new SettledBet(){Id = 2, CustomerId = 2, EventId = 1, ParticipantId = 3, Stake = 5, WinAmount = 0},
            //};
            //return bets;
            //throw new NotImplementedException();
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
                    //var intField = csv.GetField<int>(0);
                    //var stringField = csv.GetField<string>(1);
                    //var boolField = csv.GetField<bool>("HeaderName");
                    bets.Add(bet);
                }

                //var records = csv.GetRecords<SettledBet>();
                //return records.ToList();
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