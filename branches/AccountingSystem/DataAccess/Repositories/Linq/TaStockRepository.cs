using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaStockRepository:TaDataContextEntity<Stock>,ITaStockRepository
    {

        public TaStockRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
