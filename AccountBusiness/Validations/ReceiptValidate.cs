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
    public class ReceiptValidate
    {
        public void validate(Receipt receipt) {
            if (receipt.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0001);
            if (receipt.TradingPartner == null)
                throw new UserException(ErrorsManager.Error0002);
            if (receipt.DeliveryPerson == null)
                throw new UserException(ErrorsManager.Error0003);
            // amount is not less than or equal 0
            if(receipt.Amount<=0)
                throw new UserException(ErrorsManager.Error0006);
        }
        public void validate(Receipt receipt,List<BalanceAccountModel> accounts) {
            validate(receipt);
            if (accounts == null || accounts.Count == 0)
                throw new UserException(ErrorsManager.Error0004);
        }
    }
}
