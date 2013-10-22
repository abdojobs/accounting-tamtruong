using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountBusiness.Business.ServiceInterfaces;
using Common.Exceptions;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Models;
using AccountBusiness.Validations;

namespace AccountBusiness.Business
{
    public class ReceiptBusiness : IReceiptBusiness
    {
        private ITaReceiptRepository receiptRepository;
        private ITaInvoiceRepository invoiceRepository;
        private ITaGeneralJournalRepository generalJournalRepository;
        private ReceiptValidate receiptValidate;
        private InvoiceValidate invoiceValidate;
        private ITaInvoiceReceiptRepository invoiceReceiptRepository;
       
        public ReceiptBusiness(ITaReceiptRepository ReceiptRepository) {
            this.receiptRepository = ReceiptRepository;
        }

        public void CreateNewReceipt(ReceiptModel receiptmodel)
        {
            #region receipt
            
            Receipt receipt=receiptmodel.Receipt;
            // set tradingpartner for receipt
            receipt.TradingPartner = receiptmodel.TradingPartner;
            // set DeliveryPerson for receipt
            receipt.DeliveryPerson = receiptmodel.DeliveryPerson;
            // set createdate for receipt
            receipt.CreateDate = receipt.CreateDate == DateTime.MinValue ? DateTime.Now : receipt.CreateDate;

            // validate
            receiptValidate.validate(receipt, receiptmodel.AccountCompareModels);

            //save
            receiptRepository.Add(receipt);
            #endregion

            #region invoices
            List<Invoice_Receipt> invrecs=new List<Invoice_Receipt>();
            foreach (Invoice i in receiptmodel.Invoices) { 
                //validate invoice
                invoiceValidate.validate(i);
                //save
                invoiceRepository.Add(i);
                //save detail invoice
                Invoice_Receipt invrec = new Invoice_Receipt()
                {
                    Invoice = i,
                    Receipt = receipt
                };
                invrecs.Add(invrec);
            }
            invoiceReceiptRepository.AddList(invrecs);
            #endregion
        }
            
    }
}
