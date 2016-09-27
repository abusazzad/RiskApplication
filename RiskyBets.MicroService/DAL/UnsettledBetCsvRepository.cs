using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using CsvHelper;
using RiskyBets.MicroService.DAL.Entities;

namespace RiskyBets.MicroService.DAL
{
    public class UnsettledBetCsvRepository: IRepository<UnSettledBet>
    {
        public IList<UnSettledBet> GetAll()
        {
            var bets = new List<UnSettledBet>();
            try
            {
                var textReader = File.OpenText(HostingEnvironment.MapPath(@"~/App_Data/Unsettled.csv"));
                var csv = new CsvReader(textReader);
                var id = 0;
                while (csv.Read())
                {
                    ++id;
                    var bet = new UnSettledBet()
                    {
                        Id = id,
                        CustomerId = csv.GetField<int>(0),
                        EventId = csv.GetField<int>(1),
                        ParticipantId = csv.GetField<int>(2),
                        Stake = csv.GetField<int>(3),
                        ToWinAmount = csv.GetField<int>(4)
                    };
                    bets.Add(bet);
                }
                return bets;
            }
            catch
            {
                return new List<UnSettledBet>();
            }
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