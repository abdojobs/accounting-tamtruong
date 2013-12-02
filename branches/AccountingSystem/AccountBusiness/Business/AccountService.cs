using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Repositories;
using Business.Business.ServiceInterfaces;
using Business.Validations;
using Common.Utils;
using System.Data.SqlClient;
using Common.Logs;
using Common.Exceptions;
using Common.Messages;

namespace Business.Business
{
    public class AccountService:BaseConnector,IAccountBusiness
    {
        private const int level1Limit = 3;
        private const int level2Limit = 4;
        private const int level3Limit = 5;
        AccountValidate _accountValidate;
        AccountValidate accountValidate {
            get {
                if (_accountValidate == null)
                    _accountValidate = new AccountValidate();
                return _accountValidate;
            }
        }
        public void addAccount(Account account)
        {
            accountValidate.validate(account);
            Context.Accounts.AddSubmit(account);
        }

        public IEnumerable<Account> GetByFirstLetter(string code)
        {
            return Context.Accounts.GetAll().Where(a => a.Id.ToString().StartsWith(code));
        }

        public IEnumerable<Account> GetChildrenByParentId(int id)
        {
            return Context.Accounts.GetAll().Where(a => a.Parent!=null && a.Parent.Id==id);
        }


        public void updateAccount(Account account)
        {
            accountValidate.validate(account);
            Context.Accounts.UpdateSubmit(account);
        }


        public IEnumerable<Account> GetAll()
        {
            return Context.Accounts.GetAll();
        }

        public void addAccountLevel1(Account account)
        {
            accountValidate.validate(account);
            String zero = new String('0', level1Limit);
            account.Code = string.Format("{0:" + zero + "}", Convert.ToInt32(account.Code.Sub(0, level1Limit)));
            Context.Accounts.AddSubmit(account);
        }

        public void updateAccountLevel1(Account account)
        {
            accountValidate.validate(account);
            String zero = new String('0', level1Limit);
            account.Code = string.Format("{0:" + zero + "}", Convert.ToInt32(account.Code.Sub(0, level1Limit)));
            Context.Accounts.UpdateSubmit(account);
        }




        public void addAccountLevel2(Account accountParent, Account account)
        {
            accountValidate.validate(account);
            account.Code = accountParent.Code + account.Code;
            String zero = new String('0', level2Limit);
            account.Code = string.Format("{0:" + zero + "}", Convert.ToInt32(account.Code.Sub(0, level2Limit)));
            account.Parent = accountParent;
            Context.Accounts.AddSubmit(account);
        }

        public void updateAccountLevel2(Account accountParent, Account account)
        {
            accountValidate.validate(account);
            account.Code = accountParent.Code + account.Code;
            String zero = new String('0', level2Limit);
            account.Code = string.Format("{0:" + zero + "}", Convert.ToInt32(account.Code.Sub(0, level2Limit)));
            Context.Accounts.UpdateSubmit(account);
        }

        public void addAccountLevel3(Account accountParent, Account account)
        {
            accountValidate.validate(account);
            account.Code = accountParent.Code + account.Code;
            String zero = new String('0', level3Limit);
            account.Code = string.Format("{0:" + zero + "}", Convert.ToInt32(account.Code.Sub(0, level3Limit)));
            account.Parent = accountParent;
            Context.Accounts.AddSubmit(account);
        }

        public void updateAccountLevel3(Account accountParent, Account account)
        {
            accountValidate.validate(account);
            account.Code = accountParent.Code + account.Code;
            String zero = new String('0', level3Limit);
            account.Code = string.Format("{0:" + zero + "}", Convert.ToInt32(account.Code.Sub(0, level3Limit)));
            Context.Accounts.UpdateSubmit(account);
        }


        public Account Get(int id)
        {
            return Context.Accounts.Get(id);
        }


        public System.Data.DataTable GetToDataTable()
        {
            try
            {
                string sql = "select Id,Code,Description from Account";
                return Execute(sql);
            }
            catch (Exception ex) {
                WriteLog.Error(this.GetType(), ex);
                throw new UserException(ErrorsManager.Error0000);
            }
        }
    }
}
