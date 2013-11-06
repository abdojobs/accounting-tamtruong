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
using DataAccess.Repositories.Linq;

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
                    addAccountClause(accountClause,accountClause.ProceduceType.Id);
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

        public AccountClause addAccountClause(AccountClause accountClause,int proceduceTypeId)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    accountClauseValidate.validate(accountClause);
                    ProceduceType type = Context.ProceduceTypes.Find(proceduceTypeId);
                    accountClause.ProceduceType = type;
                    Context.AccountClauses.Add(accountClause);
                    Context.SaveChanges();
                    return accountClause;
                }
                catch (Exception ex)
                {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ErrorsManager.Error0000);
                }
                
            }
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
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.ProceduceTypes.Find(id);
                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public void updateAccountClause(AccountClause accountClause)
        {
            accountClauseValidate.validate(accountClause);
            Context.AccountClauses.UpdateSubmit(accountClause);
        }


        public void addBalanceAccount(AccountClauseDetail balanceAccount)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    var account = Context.Accounts.Find(balanceAccount.Account_Id);
                    var accountType = Context.AccountTypes.Find(balanceAccount.AccountType.Id);
                    var clause = Context.AccountClauses.Find(balanceAccount.AccountClause_Id);
                    balanceAccount.Account = account;
                    balanceAccount.AccountClause = clause;
                    balanceAccount.AccountType = accountType;
                    Context.AccountClauseDetails.Add(balanceAccount);
                    Context.SaveChanges();
                    
                }
                catch(Exception ex) {
                    WriteLog.Error(this.GetType(), ex);
                    throw new UserException(ErrorsManager.Error0000);
                }
                finally
                {
                    Context.Dispose();
                }
            }
        }


        public IEnumerable<AccountClauseDetail> GetAccountDetailsByClauseId(int id)
        {
            return Context.AccountClauseDetails.GetAll().Where(c =>c.AccountClause!=null && c.AccountClause.Id == id);
        }


        public void DeleteDetail(int accountId, int clauseId)
        {
            AccountClauseDetail detail = Context.AccountClauseDetails.GetAll().Where(d => d.Account_Id == accountId && d.AccountClause_Id == clauseId).FirstOrDefault();
            if(detail!=null)
                Context.AccountClauseDetails.DeleteSubmit(detail);
        }


        public AccountType GetAccountType(string code)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.AccountTypes.Where(a => a.Code == code).FirstOrDefault();
                }
                catch { }
                finally {
                    Context.Dispose();
                }
                return null;
            }
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
