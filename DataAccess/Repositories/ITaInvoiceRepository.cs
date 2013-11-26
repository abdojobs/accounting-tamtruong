using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ITaInvoiceRepository:ITaRepositoryBase<Invoice>
    {
        void AddInvoice(int customer_id, int vattype_id, Invoice invoice);
    }
}
