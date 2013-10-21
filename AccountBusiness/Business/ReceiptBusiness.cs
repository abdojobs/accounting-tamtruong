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

namespace AccountBusiness.Business
{
    public class ReceiptBusiness : IReceiptBusiness
    {
        private ITaReceiptRepository receiptRepository;
        private ITaInvoiceRepository invoiceRepository;
        private ITaGeneralJournalRepository generalJournalRepository;
        private ITaInvoiceReceiptRepository generalJournalRepository;
       
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
            receipt.validate(receiptmodel.AccountCompareModels);

            //save
            receiptRepository.Add(receipt);
            #endregion

            #region invoices
            foreach (Invoice i in receiptmodel.Invoices) { 
                //validate invoice
                i.validate();
                //save
                invoiceRepository.Add(i);
                //save detail invoice

            }
            #endregion
        }
            
    }
}
