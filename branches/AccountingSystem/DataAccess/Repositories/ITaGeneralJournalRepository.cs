using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ITaGeneralJournalRepository:ITaRepositoryBase<GeneralJournal>
    {
        bool IsValidBalanceAccountAmount(int prodeduce_id,int proceducetype_id);
    }
}
