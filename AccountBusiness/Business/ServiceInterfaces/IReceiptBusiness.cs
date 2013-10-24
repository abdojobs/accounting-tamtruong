using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;
using DataAccess.Entities;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface IReceiptBusiness
    {
        void addReceiptProceduce(ReceiptModel receiptmodel);
        Receipt addReceipt(ReceiptModel receiptmodel);
        void writeGeneralLedger(Receipt receipt, List<BalanceAccountModel> balanceaccounts);
        void writeInvoices(Receipt receipt, List<Invoice> invoices);
    }
}
