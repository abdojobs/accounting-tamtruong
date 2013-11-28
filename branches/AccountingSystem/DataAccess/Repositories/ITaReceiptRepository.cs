using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using AccountBusiness.Models.Views;

namespace DataAccess.Repositories
{
    public interface ITaReceiptRepository:ITaRepositoryBase<Receipt>
    {
        Receipt AddReceipt(Receipt receipt, int tradingpartner_id, int deliveryperson_id, int accountclause_id);
        void AddInvoiceReceipts(List<Invoice_Receipt> invoices);
        void WriteGeneralJournal(int receipt_id, int proceducetype_id, List<GeneralJournal> gens);
        void UpdateAmount(int id, decimal amount);
        List<ReceiptView> Search(DateTime to, DateTime fro, string code);
    }
}
