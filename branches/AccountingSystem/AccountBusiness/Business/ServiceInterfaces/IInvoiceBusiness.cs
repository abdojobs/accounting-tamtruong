using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Entities;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface IInvoiceBusiness
    {
        DataTable GetVatTypeToTable();
        IList<Invoice> GetInvoices();
    }
}
