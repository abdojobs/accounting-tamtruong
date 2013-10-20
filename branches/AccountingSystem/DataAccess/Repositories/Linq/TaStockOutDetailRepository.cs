using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
namespace DataAccess.Repositories.Linq {
	public class TaStockOutDetailRepository : TaDataContextEntity<StockOutDetail>, ITaStockOutDetailRepository {

        public TaStockOutDetailRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
	}

}