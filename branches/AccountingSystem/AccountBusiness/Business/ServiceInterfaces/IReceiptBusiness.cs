using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface IReceiptBusiness
    {
        void CreateNewReceipt(ReceiptModel receiptmodel);
    }
}
