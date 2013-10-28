using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ITaData
    {
        ITaAccountRepository Accounts { get; }
        ITaAccountClauseRepository AccountClauses { get; }
        ITaAccountClauseDetailRepository AccountClauseDetails { get; }
        ITaAccountTypeRepository AccountTypes { get; }
        ITaDeliveryPersonRepository DeliveryPersons { get; }
        ITaGeneralJournalRepository GeneralJournals { get; }
        ITaInvoicePayBillRepository InvoicePayBills { get; }
        ITaInvoiceReceiptRepository InvoiceReceipts { get; }
        ITaInvoiceRepository Invoices { get; }
        ITaInvoiceStockInReceiptRepository InvoiceStockInReceipts { get; }
        ITaInvoiceStockOutReceiptRepository InvoiceStockOutReceipts { get; }
        ITaPayBillRepository PayBills { get; }
        ITaReceiptRepository Receipts { get; }
        ITaReceiverRepository Receivers { get; }
        ITaStockInDetailRepository StockInDetails { get; }
        ITaStockInReceiptRepository StockInReceipts { get; }
        ITaStockOutDetailRepository StockOutDetails { get; }
        ITaStockOutReceiptRepository StockOutReceipts { get; }
        ITaStockRepository Stocks { get; }
        ITaSupplierRepository Suppliers { get; }
        ITaTradingPartnerRepository TradingPartners { get; }
        ITaWareHouseRepository WareHouses { get; }
        ITaProceduceTypeRepository ProceduceTypes { get; }
        void SaveChanges();
    }
}
