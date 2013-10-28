using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using System.Data;
using DataAccess.Repositories;
using System.Data.Entity;

namespace DataAccess.Repositories.Linq
{
    public class TaAccountRepository :TaDataContextEntity<Account>,  ITaAccountRepository
    {
        
    }
}
