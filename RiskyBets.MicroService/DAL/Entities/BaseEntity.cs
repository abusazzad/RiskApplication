using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskyBets.MicroService.DAL.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}