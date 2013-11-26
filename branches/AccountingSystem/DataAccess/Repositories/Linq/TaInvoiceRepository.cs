using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaInvoiceRepository : TaDataContextEntity<Invoice>,ITaInvoiceRepository
    {

        public void AddInvoice(int customer_id, int vattype_id, Invoice invoice)
        {
            using(var Context=new TaDalContext()){
                try
                {
                    Customer cus = Context.Customers.Find(customer_id);
                    VatType vat = Context.VatTypes.Find(vattype_id);
                    invoice.Customer = cus;
                    invoice.VatType = vat;

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
