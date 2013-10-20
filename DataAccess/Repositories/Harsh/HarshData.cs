using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Harsh
{
    public class HarshData:ITaData
    {
        public ITaAccountRepository Accounts
        {
            get { return new TaAccountEntity(); }
        }
    }
}
