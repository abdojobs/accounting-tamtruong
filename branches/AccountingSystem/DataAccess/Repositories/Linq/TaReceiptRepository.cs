using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaReceiptRepository : TaDataContextEntity<Receipt>,ITaReceiptRepository
    {
        public TaReceiptRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
