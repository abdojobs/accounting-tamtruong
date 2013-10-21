using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Models
{
    public class AccountCompareModel
    {
        public Account Account { get; set; }
        public decimal DedtMoney { get; set; }
        public decimal ReceiveMoney { get; set; }
    }
}
