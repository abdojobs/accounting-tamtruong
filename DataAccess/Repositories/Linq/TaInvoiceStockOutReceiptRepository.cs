using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaInvoiceStockOutReceiptRepository:TaDataContextEntity<Invoice_StockOutReceipt>,ITaInvoiceStockOutReceiptRepository
    {
        public TaInvoiceStockOutReceiptRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
