using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;

namespace Business.Validations
{
    public class StockOutDetailValidate
    {
        public void validate(StockOutDetail stockOutDetail) { 
            // stockoutreceipt is not null
            if (stockOutDetail.StockOutReceipt == null || stockOutDetail.StockOutReceipt.Id == 0)
                throw new UserException(ErrorsManager.Error0008);
            // stock is not null
            if(stockOutDetail.Stock==null)
                throw new UserException(ErrorsManager.Error0009);
            // quantity is not less than or equal 0
            if(stockOutDetail.Quantity==0)
                throw new UserException(ErrorsManager.Error0010);
            // price is not 0
            if(stockOutDetail.Price==0)
                throw new UserException(ErrorsManager.Error0011);
        }
    }
}
