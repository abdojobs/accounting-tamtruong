using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Business.ServiceInterfaces;
using DataAccess.Repositories;
using Business.Validations;
using System.Transactions;
using DataAccess.Entities;
using Common.Logs;
using Common.Messages;
using Common.Exceptions;
using Business.Models;
using Common.Utils;

namespace Business.Business
{
    public class PayBillService :BaseConnector ,IPayBillBusiness
    {
        #region fields
       
        private PayBillValidate _payBillValidate;
        private InvoiceValidate _invoiceValidate;
        private BalanceAccountValidate _balanceAccountValidate;
        #endregion

        #region properties
        private PayBillValidate payBillValidate
        {
            get
            {
                if (_payBillValidate == null)
                    _payBillValidate = new PayBillValidate();
                return _payBillValidate;
            }
        }
        private InvoiceValidate invoiceValidate
        {
            get
            {
                if (_invoiceValidate == null)
                    _invoiceValidate = new InvoiceValidate();
                return _invoiceValidate;
            }
        }
        private BalanceAccountValidate balanceAccountValidate {
            get {
                if (_balanceAccountValidate == null)
                    _balanceAccountValidate = new BalanceAccountValidate();
                return _balanceAccountValidate;
            }
        }
        #endregion

        public void addPayBillProceduce(PayBillModel payBillModel)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    // validate paybill
                    payBillValidate.validate(payBillModel.PayBill, payBillModel.BalanceAccounts, payBillModel.Invoices);
                    // validate balanceaccounts
                    balanceAccountValidate.validate(payBillModel.BalanceAccounts);

                    // add paybill
                    PayBill payBill = addPayBill(payBillModel);

                    // write invoices
                    writeInvoices(payBill, payBillModel.Invoices);

                    // write General Ledger
                    writeGeneralLedger(payBill, payBillModel.BalanceAccounts);

                    Context.SaveChanges();
                    transaction.Complete();
                }
                catch (UserException ex) {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ex.Message);
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ErrorsManager.Error0000);
                }
            }
        }

        public DataAccess.Entities.PayBill addPayBill(PayBillModel payBillModel)
        {
            PayBill payBill = payBillModel.PayBill;
            // set receiver for paybill
            payBill.Receiver = payBillModel.Receiver;
            // set createdate for paybill
            payBill.CreateDate = payBill.CreateDate == DateTime.MinValue ? DateTime.Now : payBill.CreateDate;
            // set supplier for paybill
            payBill.Supplier = payBillModel.Supplier;
            // save
            Context.PayBills.AddPayBill(payBill, payBillModel.Receiver.Id, payBillModel.Supplier.Id, payBillModel.AccountClause.Id);
            return payBill;
        }

        public void writeGeneralLedger(PayBill payBill, List<BalanceAccountModel> balanceaccounts)
        {
            List<GeneralJournal> list = new List<GeneralJournal>();
            int proceducetype_id = Context.ProceduceTypes.GetPayBillProceduceType();
            decimal Amount = 0;
            foreach (var a in balanceaccounts)
            {
                GeneralJournal gj = new GeneralJournal();
                gj.DebtAmount = a.DedtAmount;
                gj.ReceiveAmount = a.ReceiveAmount;
                gj.Description = a.Description;
                gj.Account_Id = a.Account.Id;
                list.Add(gj);

                Amount += a.ReceiveAmount;
            }
            Context.PayBills.UpdateAmount(payBill.Id, Amount);
            Context.PayBills.WriteGeneralJournal(payBill.Id, proceducetype_id, list);
        }

        public void writeInvoices(DataAccess.Entities.PayBill payBill, List<DataAccess.Entities.Invoice> invoices)
        {
            List<Invoice_PayBill> invrecs = new List<Invoice_PayBill>();
            foreach (Invoice i in invoices)
            {
                //validate invoice
                invoiceValidate.validate(i);
                //save
                Context.Invoices.AddInvoice(i.Customer.Id, i.VatType.Id, i);
                //save detail invoice
                Invoice_PayBill invpay = new Invoice_PayBill()
                {
                    Invoice = i,
                    PayBill = payBill
                };
                invrecs.Add(invpay);
            }
            Context.PayBills.AddInvoicePayBills(invrecs);
            
        }


        public IList<DataAccess.Models.Views.PayBillView> Search(DateTime from, DateTime to, string code)
        {
            try
            {
                from = from.BeginOfDate();
                to = to.EndOfDate();

                var list = Context.PayBills.Search(to, from, code);

                return list;
            }
            catch (Exception ex)
            {
                WriteLog.ErrorDbCommon(this.GetType(), ex);
            }
            return null;
        }
    }
}
