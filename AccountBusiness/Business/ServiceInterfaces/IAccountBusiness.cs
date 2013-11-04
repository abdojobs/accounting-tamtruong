using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using System.Data;

namespace Business.Business.ServiceInterfaces
{
    public interface IAccountBusiness
    {
        void addAccountLevel1(Account account);
        void updateAccountLevel1(Account account);
        void addAccountLevel2(Account accountParent,Account account);
        void updateAccountLevel2(Account accountParent, Account account);
        void addAccountLevel3(Account accountParent, Account account);
        void updateAccountLevel3(Account accountParent, Account account);
        IEnumerable<Account> GetByFirstLetter(string code);
        IEnumerable<Account> GetChildrenByParentId(int id);
        IEnumerable<Account> GetAll();
        Account Get(int id);
        DataTable GetToDataTable();
    }
}
