using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Models.Views;

namespace DataAccess.Repositories
{
    public interface ITaPayBillRepository:ITaRepositoryBase<PayBill>
    {
        List<PayBillView> Search(DateTime to, DateTime fro, string code);
    }
}
