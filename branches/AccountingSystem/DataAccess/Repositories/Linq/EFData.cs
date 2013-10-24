using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Linq
{
    public class EFData:ITaData
    {
        private TaDalContext _Context;
        private TaDalContext Context {
            get {
                if (_Context == null)
                    _Context = new TaDalContext(GlobalConstant.DBConnecstring);
                return _Context;
            }
        }
        
        public ITaAccountRepository Accounts
        {
            get { return new TaAccountRepository(Context); }
        }
        public ITaDeliveryPersonRepository DeliveryPersons
        {
            get { return new TaDeliveryPersonRepository(Context); }
        }
        public ITaGeneralJournalRepository GeneralJournals
        {
            get { return new TaGeneralJournalRepository(Context); }
        }
        public ITaInvoicePayBillRepository InvoicePayBills
        {
            get { return new TaInvoicePayBillRepository(Context); }
        }
        public ITaInvoiceReceiptRepository InvoiceReceipts
        {
            get { return new TaInvoiceReceiptRepository(Context); }
        }
        public ITaInvoiceRepository Invoices
        {
            get { return new TaInvoiceRepository(Context); }
        }
        public ITaInvoiceStockInReceiptRepository InvoiceStockInReceipts
        {
            get { return new TaInvoiceStockInReceiptRepository(Context); }
        }
        public ITaInvoiceStockOutReceiptRepository InvoiceStockOutReceipts
        {
            get { return new TaInvoiceStockOutReceiptRepository(Context); }
        }
        public ITaPayBillRepository PayBills
        {
            get { return new TaPayBillRepository(Context); }
        }
        public ITaReceiptRepository Receipts
        {
            get { return new TaReceiptRepository(Context); }
        }
        public ITaReceiverRepository Receivers
        {
            get { return new TaReceiverRepository(Context); }
        }
        public ITaStockInDetailRepository StockInDetails
        {
            get { return new TaStockInDetailRepository(Context); }
        }
        public ITaStockInReceiptRepository StockInReceipts
        {
            get { return new TaStockInReceiptRepository(Context); }
        }
        public ITaStockOutDetailRepository StockOutDetails
        {
            get { return new TaStockOutDetailRepository(Context); }
        }
        public ITaStockOutReceiptRepository StockOutReceipts
        {
            get { return new TaStockOutReceiptRepository(Context); }
        }
        public ITaStockRepository Stocks
        {
            get { return new TaStockRepository(Context); }
        }
        public ITaSupplierRepository Suppliers
        {
            get { return new TaSupplierRepository(Context); }
        }
        public ITaTradingPartnerRepository TradingPartners
        {
            get { return new TaTradingPartnerRepository(Context); }
        }
        public ITaWareHouseRepository WareHouses
        {
            get { return new TaWareHouseRepository(Context); }
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
