using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repositories;
using Business.Business.ServiceInterfaces;
using DataAccess.Entities;
using Business.Models;
using Common.Logs;
using Common.Exceptions;
using Common.Messages;
using System.Transactions;
using Common.Utils;
using Business.Validations;
using Common.Maths;

namespace Business.Business
{
    public class StockInReceiptService : BaseConnector, IStockInReceiptBusiness
    {
        InvoiceValidate _invoiceValidate;
        StockInDetailValidate _stockInDetailValidate;
        StockInReceiptValidate _stockInReceiptValidate;

        
        #region properties
        InvoiceValidate invoiceValidate
        {
            get
            {
                if (_invoiceValidate == null)
                    _invoiceValidate = new InvoiceValidate();
                return _invoiceValidate;
            }
        }
        StockInDetailValidate stockInDetailValidate {
            get {
                if (_stockInDetailValidate == null)
                    _stockInDetailValidate = new StockInDetailValidate();
                return _stockInDetailValidate;
            }
        }
        public StockInReceiptValidate stockInReceiptValidate
        {
            get {
                if (_stockInReceiptValidate == null)
                    _stockInReceiptValidate = new StockInReceiptValidate();
                return _stockInReceiptValidate;
            }
            
        }
        #endregion
        public void addStockInProceduce(StockInReceiptModel model)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    // add stockinreceipt
                    StockInReceipt stockInReceipt = addStockInReceipt(model);
                    // write invoice
                    writeInvoices(stockInReceipt, model.Invoices);
                    // write general ledger
                    writeGeneralLedger(stockInReceipt, model.BalanceAccounts);


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

        public StockInReceipt addStockInReceipt(StockInReceiptModel model)
        {
            StockInReceipt stockInReceipt = model.StockInReceipt;
            stockInReceipt.CreateDate = stockInReceipt.CreateDate.NowOrOwner();
            // add and submit stockinreceipt
            Context.StockInReceipts.AddStockInReceipt(stockInReceipt);

            stockInReceipt.Amount = writeStockInDetails(stockInReceipt, model.StockInDetails);
            // validate
            stockInReceiptValidate.validate(stockInReceipt);
            return stockInReceipt;
        }

        public decimal writeStockInDetails(StockInReceipt stockInReceipt, List<StockInDetail> stockInDetails)
        {
            decimal amount = 0;
            foreach (var s in stockInDetails)
            {
                //validate
                stockInDetailValidate.validate(s);

                s.StockInReceipt = stockInReceipt;
                updateInventory(s);
                amount += CalAmount(s);
            }
            Context.StockInDetails.AddList(stockInDetails);
            return amount;
        }

        public void writeInvoices(StockInReceipt stockInReceipt, List<Invoice> invoices)
        {
            List<Invoice_StockInReceipt> invrecs = new List<Invoice_StockInReceipt>();
            foreach (Invoice i in invoices)
            {
                //validate invoice
                invoiceValidate.validate(i);
                //save
                Context.Invoices.Add(i);
                //save detail invoice
                Invoice_StockInReceipt invrec = new Invoice_StockInReceipt()
                {
                    Invoice = i,
                    StockInReceipt = stockInReceipt
                };
                invrecs.Add(invrec);
            }
            Context.InvoiceStockInReceipts.AddList(invrecs);
        }

        public void writeGeneralLedger(StockInReceipt stockInReceipt, List<BalanceAccountModel> accounts)
        {
            List<GeneralJournal> list = new List<GeneralJournal>();
            foreach (var a in accounts)
            {
                GeneralJournal gj = new GeneralJournal();
                gj.Account = a.Account;
                gj.DebtAmount = a.DedtAmount;
                gj.ReceiveAmount = a.ReceiveAmount;
                gj.Description = a.Description;
                gj.Proceduce_Id = stockInReceipt.Id;
                list.Add(gj);
            }
            Context.GeneralJournals.AddList(list);
        }

        public void updateInventory(StockInDetail stockInDetail)
        {
            Context.Stocks.UpdateInventory(stockInDetail.Stock.Id, stockInDetail.Quantity);
        }

        public decimal CalAmount(StockInDetail stockInDetail)
        {
            return stockInDetail.IncludeFee + AccountMath.MultiDouAndDecimal(stockInDetail.Price, stockInDetail.Quantity);
        }
    }
}
