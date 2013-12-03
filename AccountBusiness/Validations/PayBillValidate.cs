using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;
using Business.Models;

namespace Business.Validations
{
    public class PayBillValidate
    {
        public void validate(PayBill payBill) { 
            // code not empty
            if (payBill.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0005);
            // receiver not null
            if(payBill.Receiver==null || payBill.Receiver.Id==0)
                throw new UserException(ErrorsManager.Error0007);
            // supplier is not null
            if (payBill.Supplier == null || payBill.Supplier.Id == 0)
                throw new UserException(ErrorsManager.Error0016);
        }
        public void validate(PayBill paybill, List<BalanceAccountModel> accounts, List<Invoice> invoices)
        {
            validate(paybill);
            if (accounts != null && accounts.Count > 0 && invoices != null && invoices.Count > 0)
            {
                decimal accountAmount = 0;
                decimal invoiceAmount = 0;
                accountAmount = accounts.Sum(a => a.ReceiveAmount);
                invoiceAmount = invoices.Sum(i => i.Amount);
                if (accountAmount != invoiceAmount)
                    throw new UserException(ErrorsManager.Error0026);
            }
        }
    }
}
