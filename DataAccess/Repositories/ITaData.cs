using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ITaData
    {
        ITaAccountRepository Accounts { get; }
    }
}
