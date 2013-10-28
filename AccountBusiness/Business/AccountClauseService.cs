using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repositories;
using Business.Business.ServiceInterfaces;
using Common.Logs;
using Common.Exceptions;
using Common.Messages;
using System.Transactions;
using Business.Validations;
using DataAccess.Entities;
using AccountBusiness.Models;
using System.Data.Objects;
using System.Data.Entity;

namespace Business.Business
{
    public class AccountClauseService:BaseConnector,IAccountClauseBusiness
    {
        AccountClauseValidate _accountClauseValidate;
        AccountClauseValidate accountClauseValidate {
            get {
                if (_accountClauseValidate == null)
                    _accountClauseValidate = new AccountClauseValidate();
                return _accountClauseValidate;
            }
        }
        public void addAccountClauseProceduce(DataAccess.Entities.AccountClause accountClause, List<DataAccess.Entities.AccountClauseDetail> balanceAccounts)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    addAccountClause(accountClause);
                    addBalanceAccounts(accountClause, balanceAccounts);

                    Context.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ErrorsManager.Error0000);
                }
            }
        }

        public AccountClause addAccountClause(AccountClause accountClause)
        {
            accountClauseValidate.validate(accountClause);
            Context.AccountClauses.AddSubmit(accountClause);
            return accountClause;
        }

        public void addBalanceAccounts(AccountClause accountClause, List<DataAccess.Entities.AccountClauseDetail> balanceAccounts)
        {
            foreach (var a in balanceAccounts) {
                a.AccountClause = accountClause;
            }
            Context.AccountClauseDetails.AddList(balanceAccounts);
        }


        public IEnumerable<AccountClause> GetAll()
        {
            return Context.AccountClauses.GetAll();
        }

        public IEnumerable<AccountClauseModel> GetAllWithAccountClauseModel()
        {
            var query = ((DbSet<AccountClause>)Context.AccountClauses.GetAll()).Include(x => x.ProceduceType).AsEnumerable();
            var result = query.Select(a=>new AccountClauseModel()
            {
                Code=a.Code,
                Description=a.Description,
                Id=a.Id,
                ProceduceType_Id=a.ProceduceType!=null?a.ProceduceType.Id:0,
                ProceduceType_Des=a.ProceduceType!=null?a.ProceduceType.Description:string.Empty
            });
            return result;
        }


        public IEnumerable<ProceduceType> GetProceduceTypes()
        {
            return Context.ProceduceTypes.GetAll();
        }


        public AccountClause addAccountClause(AccountClauseModel accountClause)
        {
            throw new NotImplementedException();
        }


        public ProceduceType GetProceduceType(int id)
        {
            return Context.ProceduceTypes.Get(id);
        }


        public void updateAccountClause(AccountClause accountClause)
        {
            accountClauseValidate.validate(accountClause);
            Context.AccountClauses.UpdateSubmit(accountClause);
        }


        public void addBalanceAccount(AccountClauseDetail balanceAccount)
        {
            Context.AccountClauseDetails.AddSubmit(balanceAccount);
        }


        public IEnumerable<AccountClauseDetail> GetAccountDetailsByClauseId(int id)
        {
            return Context.AccountClauseDetails.GetAll().Where(c =>c.AccountClause!=null && c.AccountClause.Id == id);
        }


        public void DeleteDetail(int accountId, int clauseId)
        {
            AccountClauseDetail detail = Context.AccountClauseDetails.GetAll().Where(d => d.Account_Id == accountId && d.AccountClause_Id == clauseId).FirstOrDefault();
            Context.AccountClauseDetails.DeleteSubmit(detail);
        }


        public AccountType GetAccountType(string code)
        {
            return Context.AccountTypes.GetAll().Where(a => a.Code == code).FirstOrDefault();
        }


        public AccountClause Get(int id)
        {
            return Context.AccountClauses.Get(id);
        }


        public IEnumerable<AccountClauseDetail> GetDetailWithType(int id, string code)
        {
            var query = ((DbSet<AccountClauseDetail>)Context.AccountClauseDetails.GetAll()).Include(x => x.AccountType).AsEnumerable();
            query = query.Where(a => a.AccountType.Code == code && a.AccountClause_Id == id);
            return query;
        }
    }
}
