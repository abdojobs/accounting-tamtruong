using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;

namespace AccountBusiness.Validations
{
    public class StockInReceiptValidate
    {
        public void validate(StockInReceipt stockInReceipt) { 
            // code is not empty
            if (stockInReceipt.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0015);
            // supplier is not null
            if(stockInReceipt.Supplier==null || stockInReceipt.Supplier.Id==0)
                throw new UserException(ErrorsManager.Error0016);
            // DeliveryPerson is not null
            if(stockInReceipt.DeliveryPerson==null || stockInReceipt.DeliveryPerson.Id==0)
                throw new UserException(ErrorsManager.Error0003);
            // warehouse is not null
            if(stockInReceipt.WareHouse==null || stockInReceipt.WareHouse.Id==0)
                throw new UserException(ErrorsManager.Error0013);
            // desription is not null
            if(stockInReceipt.Description==string.Empty)
                throw new UserException(ErrorsManager.Error0014);
            // amount is not less than or equal 0
            if(stockInReceipt.Amount==0)
                throw new UserException(ErrorsManager.Error0006);
        }
    }
}
