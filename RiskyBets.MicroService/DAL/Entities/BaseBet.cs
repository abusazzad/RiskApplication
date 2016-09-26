using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskyBets.MicroService.DAL.Entities
{
    public abstract class BaseBet: BaseEntity
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public int Stake { get; set; }
    }
}