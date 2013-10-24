using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;

namespace AccountBusiness.Validations
{
    public class StockOutReceiptValidate
    {
        public void validate(StockOutReceipt stockOutReceipt) { 
            //code is not empty
            if (stockOutReceipt.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0012);
            //receiver is not null
            if(stockOutReceipt.Receiver==null || stockOutReceipt.Receiver.Id==0)
                throw new UserException(ErrorsManager.Error0007);
            //tradingpartner is not null
            if(stockOutReceipt.TradingPartner==null || stockOutReceipt.TradingPartner.Id==0)
                throw new UserException(ErrorsManager.Error0002);
            //warehouse is not null
            if(stockOutReceipt.WareHouse==null || stockOutReceipt.WareHouse.Id==0)
                throw new UserException(ErrorsManager.Error0013);
            //amount is not less than or equal 0
            if(stockOutReceipt.Amount==0)
                throw new UserException(ErrorsManager.Error0006);
            //Description is not empty
            if(stockOutReceipt.Description==string.Empty)
                throw new UserException(ErrorsManager.Error0014);
        }
    }
}
