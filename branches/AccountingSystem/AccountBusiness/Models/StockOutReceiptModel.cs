using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace Business.Models
{
    public class StockOutReceiptModel
    {
        public StockOutReceipt StoctOutReceipt { get; set; }
        public Receiver Receiver { get; set; }
        public TradingPartner TradingPartner { get; set; }
        public List<StockOutDetail> StockOutDetails { get; set; }
        public List<BalanceAccountModel> BalanceAccounts { get; set; }
        public List<Invoice> Invoices { get; set; }
        public VatType VatType { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
