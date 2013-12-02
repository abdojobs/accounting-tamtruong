using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ITaAccountClauseDetailRepository : ITaRepositoryBase<AccountClauseDetail>
    {
        IEnumerable<AccountClauseDetail> GetAccountReceivableDetail(int accountclause_id);
        IEnumerable<AccountClauseDetail> GetAccountDebtDetail(int accountclause_id);
    }
}
