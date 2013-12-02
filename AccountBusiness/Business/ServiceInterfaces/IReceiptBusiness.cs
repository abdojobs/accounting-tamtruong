using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Models;
using DataAccess.Entities;
using System.Data;
using DataAccess.Models.Views;

namespace Business.Business.ServiceInterfaces
{
    public interface IReceiptBusiness
    {
        void addReceiptProceduce(ReceiptModel receiptmodel);
        Receipt addReceipt(ReceiptModel receiptmodel);
        void writeGeneralLedger(Receipt receipt, List<BalanceAccountModel> balanceaccounts);
        void writeInvoices(Receipt receipt, List<Invoice> invoices);
        IList<ReceiptView> Search(DateTime from,DateTime to, string code);
        IList<TradingPartner> GetTradingPartners();
        IList<DeliveryPerson> GetDeliveryPersons();
        bool IsValidBalanceAccountAmount(int proceduce_id, int proceducetype_id);
        int GetReceiptProceduceType();
    }
}
