﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskyBets.MicroService.DAL.Entities
{
    public class Customer: BaseEntity
    {
        public string FullName { get; set; }
    }
}