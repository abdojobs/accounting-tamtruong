using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaStockRepository:TaDataContextEntity<Stock>,ITaStockRepository
    {


        public void UpdateInventory(int id, double quantity)
        {
            using (var Context = new TaDalContext())
            {
                try
                {

                    Stock stock = Context.Stocks.Find(id);
                    stock.Inventory += quantity;
                    Context.Update<Stock>(stock);

                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }
    }
}
