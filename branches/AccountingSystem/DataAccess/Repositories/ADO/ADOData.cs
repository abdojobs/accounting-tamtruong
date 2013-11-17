﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.ADO
{
    public class ADOData:ITaData
    {
        public ITaAccountRepository Accounts
        {
            get { throw new NotImplementedException(); }
        }


        public ITaDeliveryPersonRepository DeliveryPersons
        {
            get { throw new NotImplementedException(); }
        }

        public ITaGeneralJournalRepository GeneralJournals
        {
            get { throw new NotImplementedException(); }
        }

        public ITaInvoicePayBillRepository InvoicePayBills
        {
            get { throw new NotImplementedException(); }
        }

        public ITaInvoiceReceiptRepository InvoiceReceipts
        {
            get { throw new NotImplementedException(); }
        }

        public ITaInvoiceRepository Invoices
        {
            get { throw new NotImplementedException(); }
        }

        public ITaInvoiceStockInReceiptRepository InvoiceStockInReceipts
        {
            get { throw new NotImplementedException(); }
        }

        public ITaInvoiceStockOutReceiptRepository InvoiceStockOutReceipts
        {
            get { throw new NotImplementedException(); }
        }

        public ITaPayBillRepository PayBills
        {
            get { throw new NotImplementedException(); }
        }

        public ITaReceiptRepository Receipts
        {
            get { throw new NotImplementedException(); }
        }

        public ITaReceiverRepository Receivers
        {
            get { throw new NotImplementedException(); }
        }

        public ITaStockInDetailRepository StockInDetails
        {
            get { throw new NotImplementedException(); }
        }

        public ITaStockInReceiptRepository StockInReceipts
        {
            get { throw new NotImplementedException(); }
        }

        public ITaStockOutDetailRepository StockOutDetails
        {
            get { throw new NotImplementedException(); }
        }

        public ITaStockOutReceiptRepository StockOutReceipts
        {
            get { throw new NotImplementedException(); }
        }

        public ITaStockRepository Stocks
        {
            get { throw new NotImplementedException(); }
        }

        public ITaSupplierRepository Suppliers
        {
            get { throw new NotImplementedException(); }
        }

        public ITaTradingPartnerRepository TradingPartners
        {
            get { throw new NotImplementedException(); }
        }

        public ITaWareHouseRepository WareHouses
        {
            get { throw new NotImplementedException(); }
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }


        public ITaAccountClauseRepository AccountClauses
        {
            get { throw new NotImplementedException(); }
        }

        public ITaAccountClauseDetailRepository AccountClauseDetails
        {
            get { throw new NotImplementedException(); }
        }

        public ITaAccountTypeRepository AccountTypes
        {
            get { throw new NotImplementedException(); }
        }


        public ITaProceduceTypeRepository ProceduceTypes
        {
            get { throw new NotImplementedException(); }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public ITaCustomerRepository Customers
        {
            get { throw new NotImplementedException(); }
        }
    }
}
