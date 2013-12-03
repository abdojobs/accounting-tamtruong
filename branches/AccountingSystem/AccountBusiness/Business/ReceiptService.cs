using System;
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
using DataAccess.Models.Views;
using System.Data;
using Common.Utils;

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
                    //validate
                    receiptValidate.validate(receiptmodel.Receipt, receiptmodel.BalanceAccounts, receiptmodel.Invoices);
                    // add receipt
                    Receipt receipt = addReceipt(receiptmodel);

                    // write invoices for receipt
                    writeInvoices(receipt, receiptmodel.Invoices);

                    // write general ledger for receipt
                    writeGeneralLedger(receipt, receiptmodel.BalanceAccounts);

                    Context.SaveChanges();
                    transactionScope.Complete();
                }
                catch (UserException ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ex.Message);
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
            decimal receiptAmount = 0;
            foreach (var a in balanceaccounts)
            {
                GeneralJournal gj = new GeneralJournal();
                gj.DebtAmount = a.DedtAmount;
                gj.ReceiveAmount = a.ReceiveAmount;
                gj.Description = a.Description;
                gj.Account_Id=a.Account.Id;
                list.Add(gj);

                receiptAmount += a.ReceiveAmount;
            }
            Context.Receipts.UpdateAmount(receipt.Id, receiptAmount);
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


        public IList<ReceiptView> Search(DateTime fro,DateTime to,string code)
        {
            try
            {
                fro = fro.BeginOfDate();
                to = to.EndOfDate();

                var list = Context.Receipts.Search(to, fro, code);

                return list;
            }
            catch (Exception ex)
            {
                WriteLog.ErrorDbCommon(this.GetType(), ex);
            }
            return null;
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

        public bool IsValidBalanceAccountAmount(int proceduce_id, int proceducetype_id) {
            return Context.GeneralJournals.IsValidBalanceAccountAmount(proceduce_id, proceducetype_id);
        }
        public int GetReceiptProceduceType()
        {
            return Context.ProceduceTypes.GetReceiptProceduceType();
        }
    }
}
