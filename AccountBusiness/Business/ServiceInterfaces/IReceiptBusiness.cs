using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Models;
using DataAccess.Entities;
using AccountBusiness.Models.Views;
using System.Data;

namespace Business.Business.ServiceInterfaces
{
    public interface IReceiptBusiness
    {
        void addReceiptProceduce(ReceiptModel receiptmodel);
        Receipt addReceipt(ReceiptModel receiptmodel);
        void writeGeneralLedger(Receipt receipt, List<BalanceAccountModel> balanceaccounts);
        void writeInvoices(Receipt receipt, List<Invoice> invoices);
        IList<ReceiptView> Search(DateTime to, DateTime from, string code);
        IList<TradingPartner> GetTradingPartners();
        IList<DeliveryPerson> GetDeliveryPersons();
    }
}
