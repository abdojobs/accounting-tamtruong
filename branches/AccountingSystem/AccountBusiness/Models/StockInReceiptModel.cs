using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace Business.Models
{
    public class StockInReceiptModel
    {
        public StockInReceipt StockInReceipt { get; set; }
        public List<StockInDetail> StockInDetails { get; set; }
        public List<Invoice> Invoices { get; set; }
        public int AccountClause_Id { get; set; }
        public double Tax { get; set; }
    }
}
