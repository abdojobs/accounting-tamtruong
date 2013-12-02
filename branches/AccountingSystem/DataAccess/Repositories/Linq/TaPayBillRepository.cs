using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Models.Views;
using Common.Logs;
using System.Data.Entity;

namespace DataAccess.Repositories.Linq
{
    public class TaPayBillRepository:TaDataContextEntity<PayBill>,ITaPayBillRepository
    {

        public List<PayBillView> Search(DateTime to, DateTime fro, string code)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    var query = Context.PayBills
                        .Where(r => r.CreateDate >= fro && r.CreateDate <= to && (r.Code.Contains(code) || string.IsNullOrEmpty(code)))
                        .AsNoTracking().Select(
                            r => new PayBillView()
                            {
                                Id = r.Id,
                                Code = r.Code,
                                CreateDate = r.CreateDate,
                                Amount = r.Amount,
                                Receiver=r.Receiver.Name,
                                Supplier=r.Supplier.Name
                            }); ;
                    return query.ToList();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }

                return null;
            }
        }

    }
}
