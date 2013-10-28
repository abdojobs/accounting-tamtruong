using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace Business.Models
{
    public class BalanceAccountModel
    {
        public Account Account { get; set; }
        public decimal DedtAmount { get; set; }
        public decimal ReceiveAmount { get; set; }
        public string Description { get; set; }
    }
}
