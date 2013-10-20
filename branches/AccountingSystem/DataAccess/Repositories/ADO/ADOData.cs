using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.ADO
{
    public class ADOData:ITaData
    {
        public ITaAccountRepository Accounts
        {
            get { throw new NotImplementedException(); }
        }
    }
}
