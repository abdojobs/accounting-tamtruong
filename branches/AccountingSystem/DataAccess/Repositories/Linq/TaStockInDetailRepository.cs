using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;
namespace DataAccess.Repositories.Linq {
	public class TaStockInDetailRepository : TaDataContextEntity<StockInDetail>, ITaStockInDetailRepository {


        public void AddDetails(List<StockInDetail> details)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    foreach (var item in details) {
                        Context.StockInDetails.Add(item);
                    }
                    Context.SaveChanges();
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