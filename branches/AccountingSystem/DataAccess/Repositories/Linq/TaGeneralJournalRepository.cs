using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaGeneralJournalRepository : TaDataContextEntity<GeneralJournal>,ITaGeneralJournalRepository
    {

        public bool IsValidBalanceAccountAmount(int prodeduce_id, int proceducetype_id)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    decimal amount = (from g in Context.GeneralJournals
                                     where g.Proceducetype_Id == proceducetype_id
                                     && g.Proceduce_Id == prodeduce_id
                                     group g by new
                                     {
                                         g.Proceduce_Id,
                                         g.Proceducetype_Id,
                                     } into gs
                                     select new
                                     {
                                         amount = gs.Sum(g => g.DebtAmount) - gs.Sum(g => g.ReceiveAmount)
                                     }).FirstOrDefault().amount;
                    return amount == 0 ? true : false;
                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return false;
            }
        }
    }
}
