using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Models;

namespace AccountBusiness.Models
{
    public class StockInReceiptModel
    {
        public StockInReceipt StockInReceipt { get; set; }
        public List<StockInDetail> StockInDetails { get; set; }
        public List<BalanceAccountModel> BalanceAccounts { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
