using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;
using DataAccess.Entities;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface IPayBillBusiness
    {
        void addPayBillProceduce(PayBillModel payBillModel);
        PayBill addPayBill(PayBillModel payBillModel);
        void writeGeneralLedger(PayBill payBill, List<BalanceAccountModel> balanceaccounts);
        void writeInvoices(PayBill payBill, List<Invoice> invoices);
    }
}
