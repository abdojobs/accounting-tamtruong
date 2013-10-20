using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
namespace DataAccess.Repositories.Linq {
	public class TaStockInDetailRepository : TaDataContextEntity<StockInDetail>, ITaStockInDetailRepository {

        public TaStockInDetailRepository(TaDalContext Context)
        {
            this.Context = Context;
        }

	}

}