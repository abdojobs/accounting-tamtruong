﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Business.ServiceInterfaces;
using Common.Exceptions;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Repositories;
using Business.Models;
using Business.Validations;
using System.Transactions;
using Common.Logs;
using DataAccess.Repositories.Linq;
using AccountBusiness.Models.Views;
using System.Data;

namespace Business.Business
{
    public class ReceiptService : BaseConnector, IReceiptBusiness
    {
        
        private ReceiptValidate _receiptValidate;
        private InvoiceValidate _invoiceValidate;

        ReceiptValidate receiptValidate {
            get {
                if (_receiptValidate == null)
                    _receiptValidate = new ReceiptValidate();
                return _receiptValidate;
            }
        }
        InvoiceValidate invoiceValidate {
            get {
                if (_invoiceValidate==null)
                    _invoiceValidate = new InvoiceValidate();
                return _invoiceValidate;
            }
        }
       
        public void addReceiptProceduce(ReceiptModel receiptmodel)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    // add receipt
                    Receipt receipt = addReceipt(receiptmodel);

                    // write invoices for receipt
                    writeInvoices(receipt, receiptmodel.Invoices);

                    // write general ledger for receipt
                    writeGeneralLedger(receipt, receiptmodel.BalanceAccounts);

                    Context.SaveChanges();
                    transactionScope.Complete();
                }
                catch (Exception ex) {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ErrorsManager.Error0000);
                }
            }
            
        }

        public void writeGeneralLedger(Receipt receipt, List<BalanceAccountModel> balanceaccounts)
        {
            List<GeneralJournal> list = new List<GeneralJournal>();
            int proceducetype_id=Context.ProceduceTypes.GetReceiptProceduceType();
            foreach (var a in balanceaccounts)
            {
                GeneralJournal gj = new GeneralJournal();
                gj.DebtAmount = a.DedtAmount;
                gj.ReceiveAmount = a.ReceiveAmount;
                gj.Description = a.Description;
                gj.Account_Id=a.Account.Id;
                list.Add(gj);
            }
            Context.Receipts.WriteGeneralJournal(receipt.Id, proceducetype_id, list);
        }


        public Receipt addReceipt(ReceiptModel receiptmodel)
        {
            #region receipt
            // set createdate for receipt
            Receipt receipt = receiptmodel.Receipt;
            receipt.CreateDate = receipt.CreateDate == DateTime.MinValue ? DateTime.Now : receipt.CreateDate;
            return Context.Receipts.AddReceipt(receipt, receiptmodel.TradingPartner.Id, receiptmodel.DeliveryPerson.Id, receiptmodel.AccountClause.Id);
            #endregion
            
        }

        public void writeInvoices(Receipt receipt, List<Invoice> invoices)
        {
            #region invoices
            List<Invoice_Receipt> invrecs = new List<Invoice_Receipt>();
            foreach (Invoice i in invoices)
            {
                //validate invoice
                invoiceValidate.validate(i);

                Context.Invoices.AddInvoice(i.Customer.Id,i.VatType.Id,i);

                //save detail invoice
                Invoice_Receipt invrec = new Invoice_Receipt()
                {
                    Invoice = i,
                    Receipt = receipt
                };
                invrecs.Add(invrec);
            }
            Context.Receipts.AddInvoiceReceipts(invrecs);
            #endregion
        }


        public IList<ReceiptView> Search(DateTime to, DateTime fro, string code)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    to = new DateTime(to.Year, to.Month, to.Day);
                    fro = new DateTime(fro.Year, fro.Month, fro.Day);


                    var query = from r in Context.Receipts
                                where r.CreateDate <= to
                                && r.CreateDate >= fro
                                && (r.Code.Contains(code) || string.IsNullOrEmpty(code))
                                select new ReceiptView() { 
                                    Id=r.Id,
                                    Code=r.Code,
                                    CreateDate=r.CreateDate,
                                    TradingPartner=r.TradingPartner.Name,
                                    Amount=r.Amount,
                                    DeliveryPerson=r.DeliveryPerson.Name,
                                };
                    return query.ToList();
                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public IList<TradingPartner> GetTradingPartners()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.TradingPartners.ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public IList<DeliveryPerson> GetDeliveryPersons()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.DeliveryPersons.ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }

    }
}
