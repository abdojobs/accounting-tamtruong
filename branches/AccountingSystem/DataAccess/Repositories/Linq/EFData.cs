using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Linq
{
    public class EFData : ITaData
    {
        private TaDalContext _Context;
        private TaDalContext Context
        {
            get
            {
                if (_Context == null)
                    _Context = new TaDalContext(GlobalConstant.DBConnecstring);
                return _Context;
            }
        }
        private ITaAccountRepository _Accounts;
        public ITaAccountRepository Accounts
        {
            get
            {
                if (_Accounts == null)
                {
                    _Accounts = new TaAccountRepository();
                    
                }
                return _Accounts;
            }
        }
        ITaDeliveryPersonRepository _DeliveryPersons;
        public ITaDeliveryPersonRepository DeliveryPersons
        {
            get
            {
                if (_DeliveryPersons == null)
                {
                    _DeliveryPersons = new TaDeliveryPersonRepository();
                    
                }
                return _DeliveryPersons;
            }
        }
        ITaGeneralJournalRepository _GeneralJournals;
        public ITaGeneralJournalRepository GeneralJournals
        {
            get {
                if (_GeneralJournals == null)
                {
                    _GeneralJournals = new TaGeneralJournalRepository();

                }
                return _GeneralJournals;
            }
        }
        ITaInvoicePayBillRepository _InvoicePayBills;
        public ITaInvoicePayBillRepository InvoicePayBills
        {
            get
            {
                if (_InvoicePayBills == null)
                {
                    _InvoicePayBills = new TaInvoicePayBillRepository();

                }
                return _InvoicePayBills;
            }
        }
        ITaInvoiceReceiptRepository _InvoiceReceipts;
        public ITaInvoiceReceiptRepository InvoiceReceipts
        {
            get
            {
                if (_InvoiceReceipts == null)
                {
                    _InvoiceReceipts = new TaInvoiceReceiptRepository();

                }
                return _InvoiceReceipts;
            }
        }
        ITaInvoiceRepository _Invoices;
        public ITaInvoiceRepository Invoices
        {
            get
            {
                if (_Invoices == null)
                {
                    _Invoices = new TaInvoiceRepository();

                }
                return _Invoices;
            }
        }
        ITaInvoiceStockInReceiptRepository _InvoiceStockInReceipts;
        public ITaInvoiceStockInReceiptRepository InvoiceStockInReceipts
        {
            get
            {
                if (_InvoiceStockInReceipts == null)
                {
                    _InvoiceStockInReceipts = new TaInvoiceStockInReceiptRepository();

                }
                return _InvoiceStockInReceipts;
            }
        }
        ITaInvoiceStockOutReceiptRepository _InvoiceStockOutReceipts;
        public ITaInvoiceStockOutReceiptRepository InvoiceStockOutReceipts
        {
            get
            {
                if (_InvoiceStockOutReceipts == null)
                {
                    _InvoiceStockOutReceipts = new TaInvoiceStockOutReceiptRepository();

                }
                return _InvoiceStockOutReceipts;
            }
        }
        ITaPayBillRepository _PayBills;
        public ITaPayBillRepository PayBills
        {
            get
            {
                if (_PayBills == null)
                {
                    _PayBills = new TaPayBillRepository();

                }
                return _PayBills;
            }
        }
        ITaReceiptRepository _Receipts;
        public ITaReceiptRepository Receipts
        {
            get
            {
                if (_Receipts == null)
                {
                    _Receipts = new TaReceiptRepository();

                }
                return _Receipts;
            }
        }
        ITaReceiverRepository _Receivers;
        public ITaReceiverRepository Receivers
        {
            get
            {
                if (_Receivers == null)
                {
                    _Receivers = new TaReceiverRepository();

                }
                return _Receivers;
            }
        }
        ITaStockInDetailRepository _StockInDetails;
        public ITaStockInDetailRepository StockInDetails
        {
            get
            {
                if (_StockInDetails == null)
                {
                    _StockInDetails = new TaStockInDetailRepository();

                }
                return _StockInDetails;
            }
        }
        ITaStockInReceiptRepository _StockInReceipts;
        public ITaStockInReceiptRepository StockInReceipts
        {
            get
            {
                if (_StockInReceipts == null)
                {
                    _StockInReceipts = new TaStockInReceiptRepository();

                }
                return _StockInReceipts;
            }
        }
        ITaStockOutDetailRepository _StockOutDetails;
        public ITaStockOutDetailRepository StockOutDetails
        {
            get
            {
                if (_StockOutDetails == null)
                {
                    _StockOutDetails = new TaStockOutDetailRepository();

                }
                return _StockOutDetails;
            }
        }
        ITaStockOutReceiptRepository _StockOutReceipts;
        public ITaStockOutReceiptRepository StockOutReceipts
        {
            get
            {
                if (_StockOutReceipts == null)
                {
                    _StockOutReceipts = new TaStockOutReceiptRepository();

                }
                return _StockOutReceipts;
            }
        }
        ITaStockRepository _Stocks;
        public ITaStockRepository Stocks
        {
            get
            {
                if (_Stocks == null)
                {
                    _Stocks = new TaStockRepository();

                }
                return _Stocks;
            }
        }
        ITaSupplierRepository _Suppliers;
        public ITaSupplierRepository Suppliers
        {
            get
            {
                if (_Suppliers == null)
                {
                    _Suppliers = new TaSupplierRepository();

                }
                return _Suppliers;
            }
        }
        ITaTradingPartnerRepository _TradingPartners;
        public ITaTradingPartnerRepository TradingPartners
        {
            get
            {
                if (_TradingPartners == null)
                {
                    _TradingPartners = new TaTradingPartnerRepository();

                }
                return _TradingPartners;
            }
        }
        ITaWareHouseRepository _WareHouses;
        public ITaWareHouseRepository WareHouses
        {
            get
            {
                if (_WareHouses == null)
                {
                    _WareHouses = new TaWareHouseRepository();

                }
                return _WareHouses;
            }
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        ITaAccountClauseRepository _AccountClauses;
        public ITaAccountClauseRepository AccountClauses
        {
            get
            {
                if (_AccountClauses == null)
                {
                    _AccountClauses = new TaAccountClauseRepository();

                }
                return _AccountClauses;
            }
        }
        ITaAccountClauseDetailRepository _AccountClauseDetails;
        public ITaAccountClauseDetailRepository AccountClauseDetails
        {
            get
            {
                if (_AccountClauseDetails == null)
                {
                    _AccountClauseDetails = new TaAccountClauseDetailRepository();

                }
                return _AccountClauseDetails;
            }
        }

        ITaAccountTypeRepository _AccountTypes;
        public ITaAccountTypeRepository AccountTypes
        {
            get
            {
                if (_AccountTypes == null)
                {
                    _AccountTypes = new TaAccountTypeRepository();

                }
                return _AccountTypes;
            }
        }

        ITaProceduceTypeRepository _ProceduceTypes;
        public ITaProceduceTypeRepository ProceduceTypes
        {
            get
            {
                if (_ProceduceTypes == null)
                {
                    _ProceduceTypes = new TaProceduceTypeRepository();

                }
                return _ProceduceTypes;
            }
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        ITaCustomerRepository _Customers;
        public ITaCustomerRepository Customers
        {
            get
            {
                if (_Customers == null)
                {
                    _Customers = new TaCustomerRepository();

                }
                return _Customers;
            }
        }
    }
}
