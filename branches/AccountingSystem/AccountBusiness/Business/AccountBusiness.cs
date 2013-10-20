using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace AccountBusiness.Business
{
    public class AccountBusiness
    {

        private ITaAccountRepository _Accounts;

        public AccountBusiness(ITaAccountRepository accounts)
        {
            _Accounts = accounts;
        }
        public void addAccount() {
            Account acc = new Account();
            _Accounts.Add(acc);
        }
    }
}
