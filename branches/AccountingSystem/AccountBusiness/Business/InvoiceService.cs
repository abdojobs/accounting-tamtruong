using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountBusiness.Business.ServiceInterfaces;
using DataAccess.Repositories.Linq;
using System.Data;

namespace AccountBusiness.Business
{
    public class InvoiceService:IInvoiceBusiness
    {
        public System.Data.DataTable GetVatTypeToTable()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    DataTable tb = new DataTable();
                    tb.Columns.Add("Id");
                    tb.Columns.Add("Code");
                    tb.Columns.Add("Tax");
                    var query= Context.VatTypes;
                    foreach (var item in query) {
                        tb.Rows.Add(new object[] { item.Id, item.Code, item.Tax });
                    }
                    return tb;
                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }

        public IList<DataAccess.Entities.Invoice> GetInvoices()
        {
            throw new NotImplementedException();
        }
    }
}
