using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace AccountingSystem.Reports.Models
{
    public class ReceiptModelReport:Receipt
    {
        public string DecreeName { get; set; }
    }
}
