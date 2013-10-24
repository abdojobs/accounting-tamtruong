using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaInvoiceReceiptRepository:TaDataContextEntity<Invoice_Receipt>,ITaInvoiceReceiptRepository
    {
        public TaInvoiceReceiptRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
