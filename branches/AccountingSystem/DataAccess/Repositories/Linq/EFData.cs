using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Linq
{
    public class EFData:ITaData
    {
        private TaDalContext _Context;
        private TaDalContext Context {
            get {
                if (_Context == null)
                    _Context = new TaDalContext(GlobalConstant.DBConnecstring);
                return _Context;
            }
        }
        public ITaAccountRepository Accounts
        {
            get { return new TaAccountRepository(Context); }
        }
    }
}
