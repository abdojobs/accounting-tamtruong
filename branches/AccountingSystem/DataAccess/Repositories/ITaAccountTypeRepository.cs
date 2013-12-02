using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ITaAccountTypeRepository : ITaRepositoryBase<AccountType>
    {
        int GetAccountTypeId(AccountTypeEnum type);
    }
}
