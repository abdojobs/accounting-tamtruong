using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace Business.Models
{
    public class PayBillModel
    {
        public PayBill PayBill { get; set; }
        public List<Invoice> Invoices { get; set; }
        public Receiver Receiver { get; set; }
        public List<BalanceAccountModel> BalanceAccounts { get; set; }
        /// <summary>
        /// use to get reason write to GeneralJournal
        /// </summary>
        public AccountClause AccountClause { get; set; }
    }
}
