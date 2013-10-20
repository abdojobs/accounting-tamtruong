using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaGeneralJournalRepository : TaDataContextEntity<GeneralJournal>,ITaGeneralJournalRepository
    {
        public TaGeneralJournalRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
