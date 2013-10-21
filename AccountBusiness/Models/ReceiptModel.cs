using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace AccountBusiness.Models
{
    public class ReceiptModel
    {
        public Receipt Receipt { get; set; }
        public List<Invoice> Invoices { get; set; }
        public TradingPartner TradingPartner { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
        public List<AccountCompareModel> AccountCompareModels { get; set; }
        /// <summary>
        /// use to get reason write to GeneralJournal
        /// </summary>
        public AccountClause AccountClause { get; set; }
    }
}
