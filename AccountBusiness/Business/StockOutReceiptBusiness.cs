using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountBusiness.Business.ServiceInterfaces;
using System.Transactions;
using DataAccess.Entities;
using Common.Logs;
using Common.Exceptions;
using Common.Messages;
using DataAccess.Repositories;
using Common.Maths;
using AccountBusiness.Validations;

namespace AccountBusiness.Business
{
    public class StockOutReceiptBusiness:BaseConnector,IStockOutReceiptBusiness
    {
        ITaStockOutReceiptRepository stockOutReceiptRepository;
        ITaStockOutDetailRepository stockOutDetailtRepository;
        ITaInvoiceStockOutReceiptRepository invoiceStockOutReceiptRepository;
        ITaInvoiceRepository invoiceRepository;
        InvoiceValidate _invoiceValidate;
        StockOutDetailValidate _stockOutDetailValidate;
        #region properties
        InvoiceValidate invoiceValidate {
            get {
                if (_invoiceValidate == null)
                    _invoiceValidate = new InvoiceValidate();
                return _invoiceValidate;
            }
        }
        StockOutDetailValidate stockOutDetailValidate {
            get {
                if (_stockOutDetailValidate == null)
                    _stockOutDetailValidate = new StockOutDetailValidate();
                return _stockOutDetailValidate;
            }
        }
        #endregion
        
        public void addStockInProceduce(Models.StockOutReceiptModel model)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    // add stockoutreceipt
                    StockOutReceipt stockOutReceipt = addStockOutReceipt(model);

                    // write invoices for stockoutreceipt
                    writeInvoices(stockOutReceipt, model.Invoices);

                    // write general ledger for stockoutreceipt
                    writeGeneralLedger(stockOutReceipt, model.BalanceAccounts);

                    Context.SaveChanges();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ErrorsManager.Error0000);
                }
            }
        }

        public DataAccess.Entities.StockOutReceipt addStockOutReceipt(Models.StockOutReceiptModel model)
        {
            StockOutReceipt stockOutReceipt = model.StoctOutReceipt;
            stockOutReceipt.Receiver = model.Receiver;
            stockOutReceipt.TradingPartner = model.TradingPartner;
            stockOutReceipt.VatType = model.VatType;
            stockOutReceipt.WareHouse = model.WareHouse;
            stockOutReceipt.CreateDate = stockOutReceipt.CreateDate == DateTime.MinValue ? DateTime.Now : stockOutReceipt.CreateDate;
            decimal amount = 0;
            amount = writeStockOutDetails(stockOutReceipt,model.StockOutDetails);
            stockOutReceipt.Amount = amount;
            
            //validate

            // add
            Context.StockOutReceipts.AddSubmit(stockOutReceipt);

            return stockOutReceipt;
        }

        public decimal writeStockOutDetails(DataAccess.Entities.StockOutReceipt stockOutReceipt, List<DataAccess.Entities.StockOutDetail> stockOutDetails)
        {
            decimal amount = 0;
            foreach (var s in stockOutDetails) {
                //validate
                s.StockOutReceipt = stockOutReceipt;
                updateInventory(s);
                amount += CalAmount(s);
            }
            Context.StockOutDetails.AddList(stockOutDetails);
            return amount;
        }

        public void writeInvoices(DataAccess.Entities.StockOutReceipt stockOutReceipt, List<DataAccess.Entities.Invoice> invoices)
        {
            List<Invoice_StockOutReceipt> invrecs = new List<Invoice_StockOutReceipt>();
            foreach (Invoice i in invoices)
            {
                //validate invoice
                invoiceValidate.validate(i);
                //save
                invoiceRepository.Add(i);
                //save detail invoice
                Invoice_StockOutReceipt invrec = new Invoice_StockOutReceipt()
                {
                    Invoice = i,
                    StockOutReceipt = stockOutReceipt
                };
                invrecs.Add(invrec);
            }
            Context.InvoiceStockOutReceipts.AddList(invrecs);
        }

        public void writeGeneralLedger(DataAccess.Entities.StockOutReceipt stockOutReceipt, List<DataAccess.Models.BalanceAccountModel> accounts)
        {
            List<GeneralJournal> list = new List<GeneralJournal>();
            foreach (var a in accounts)
            {
                GeneralJournal gj = new GeneralJournal();
                gj.Account = a.Account;
                gj.DebtAmount = a.DedtAmount;
                gj.ReceiveAmount = a.ReceiveAmount;
                gj.Description = a.Description;
                gj.Proceduce_Id = stockOutReceipt.Id;
                list.Add(gj);
            }
            Context.GeneralJournals.AddList(list);
        }

        public void updateInventory(StockOutDetail stockOutDetail)
        {
            stockOutDetail.Stock.Inventory -= stockOutDetail.Quantity;
        }

        public decimal CalAmount(StockOutDetail stockOutDetail)
        {
            return stockOutDetail.IncludeFee + AccountMath.MultiDouAndDecimal(stockOutDetail.Price, stockOutDetail.Quantity);
        }
    }
}
