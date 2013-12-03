using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Models.Views;

namespace DataAccess.Repositories
{
    public interface ITaPayBillRepository:ITaRepositoryBase<PayBill>
    {
        List<PayBillView> Search(DateTime to, DateTime fro, string code);
        PayBill AddPayBill(PayBill paybill,int receiver_id,int supplier_id,int accountclause_id);
        void AddInvoicePayBills(List<Invoice_PayBill> invoices);
        void UpdateAmount(int paybill_id, decimal amount);
        void WriteGeneralJournal(int paybill_id, int proceducetype_id, List<GeneralJournal> gens);
    }
}
