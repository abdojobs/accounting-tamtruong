using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ITaStockInReceiptRepository:ITaRepositoryBase<StockInReceipt>
    {
        StockInReceipt AddStockInReceipt(StockInReceipt stockIn);
    }
}
