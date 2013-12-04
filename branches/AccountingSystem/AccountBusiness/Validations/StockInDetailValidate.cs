﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;

namespace Business.Validations
{
    public class StockInDetailValidate
    {
        public void validate(StockInDetail stockInDetail) { 
            // stockinreceipt is not null
            if (stockInDetail.StockInReceipt == null || stockInDetail.StockInReceipt.Id == 0)
                throw new UserException(ErrorsManager.Error0017);
            // stock is not null
            if(stockInDetail.Stock==null)
                throw new UserException(ErrorsManager.Error0008);

        }
    }
}
