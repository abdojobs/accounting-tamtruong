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
                    // add paybill
                    PayBill payBill = addPayBill(payBillModel);

                    // write invoices
                    writeInvoices(payBill, payBillModel.Invoices);

                    // write General Ledger
                    writeGeneralLedger(payBill, payBillModel.BalanceAccounts);

                    Context.SaveChanges();
                    transaction.Complete();
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
            // validate paybill
            payBillValidate.validate(payBill);
            // validate balanceaccounts
            balanceAccountValidate.validate(payBillModel.BalanceAccounts);
            // save
            Context.PayBills.AddSubmit(payBill);
            return payBill;
        }

        public void writeGeneralLedger(PayBill payBill, List<BalanceAccountModel> balanceaccounts)
        {
            List<GeneralJournal> list = new List<GeneralJournal>();
            foreach (var a in balanceaccounts)
            {
                GeneralJournal gj = new GeneralJournal();
                gj.Account = a.Account;
                gj.DebtAmount = a.DedtAmount;
                gj.ReceiveAmount = a.ReceiveAmount;
                gj.Description = a.Description;
                gj.Proceduce_Id = payBill.Id;
                list.Add(gj);
            }
            Context.GeneralJournals.AddList(list);
        }

        public void writeInvoices(DataAccess.Entities.PayBill payBill, List<DataAccess.Entities.Invoice> invoices)
        {
            List<Invoice_PayBill> invrecs = new List<Invoice_PayBill>();
            foreach (Invoice i in invoices)
            {
                //validate invoice
                invoiceValidate.validate(i);
                //save
                Context.Invoices.Add(i);
                //save detail invoice
                Invoice_PayBill invpay = new Invoice_PayBill()
                {
                    Invoice = i,
                    PayBill = payBill
                };
                invrecs.Add(invpay);
            }
            Context.InvoicePayBills.AddList(invrecs);
        }
    }
}
