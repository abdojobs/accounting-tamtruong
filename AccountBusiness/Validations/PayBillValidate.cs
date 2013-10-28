using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;

namespace Business.Validations
{
    public class PayBillValidate
    {
        public void validate(PayBill payBill) { 
            // code not empty
            if (payBill.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0005);
            // amount is not less than or equal 0
            if(payBill.Amount<=0)
                throw new UserException(ErrorsManager.Error0006);
            // receiver not null
            if(payBill.Receiver==null || payBill.Receiver.Id==0)
                throw new UserException(ErrorsManager.Error0007);
        }
    }
}
