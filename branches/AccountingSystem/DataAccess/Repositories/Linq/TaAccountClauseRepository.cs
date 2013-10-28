using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaAccountClauseRepository : TaDataContextEntity<AccountClause>, ITaAccountClauseRepository
    {
        public TaAccountClauseRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
