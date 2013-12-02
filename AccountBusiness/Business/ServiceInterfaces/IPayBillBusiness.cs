using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Models;
using DataAccess.Entities;
using DataAccess.Models.Views;

namespace Business.Business.ServiceInterfaces
{
    public interface IPayBillBusiness
    {
        void addPayBillProceduce(PayBillModel payBillModel);
        PayBill addPayBill(PayBillModel payBillModel);
        void writeGeneralLedger(PayBill payBill, List<BalanceAccountModel> balanceaccounts);
        void writeInvoices(PayBill payBill, List<Invoice> invoices);
        IList<PayBillView> Search(DateTime from, DateTime to, string code);
    }
}
