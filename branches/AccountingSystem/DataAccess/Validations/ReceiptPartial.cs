using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Exceptions;
using Common.Messages;
using DataAccess.Models;

namespace DataAccess.Entities
{
    /// <summary>
    /// using for validation
    /// </summary>
    partial class Receipt
    {
        public void validate() {
            Receipt receipt = this;
            if (receipt.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0001);
            if (receipt.TradingPartner == null)
                throw new UserException(ErrorsManager.Error0002);
            if (receipt.DeliveryPerson == null)
                throw new UserException(ErrorsManager.Error0003);
        }
        public void validate(List<AccountCompareModel> accounts) { 
            if(accounts==null || accounts.Count==0)
                throw new UserException(ErrorsManager.Error0004);
        }
    }
}
