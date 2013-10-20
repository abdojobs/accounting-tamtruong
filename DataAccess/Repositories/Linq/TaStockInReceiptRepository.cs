using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaStockInReceiptRepository:TaDataContextEntity<StockInReceipt>,ITaStockInReceiptRepository
    {
        public TaStockInReceiptRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
