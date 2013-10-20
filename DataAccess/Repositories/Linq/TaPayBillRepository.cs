using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaPayBillRepository:TaDataContextEntity<PayBill>,ITaPaybillRepository
    {
        public TaPayBillRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
