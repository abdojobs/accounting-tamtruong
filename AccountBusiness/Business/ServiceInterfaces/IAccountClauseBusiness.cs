using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using AccountBusiness.Models;

namespace Business.Business.ServiceInterfaces
{
    public interface IAccountClauseBusiness
    {
        void addAccountClauseProceduce(AccountClause accountClause, List<AccountClauseDetail> balanceAccounts);
        AccountClause addAccountClause(AccountClause accountClause,int proceduceTypeId);
        void addBalanceAccounts(AccountClause accountClause, List<AccountClauseDetail> balanceAccount);
        IEnumerable<AccountClauseModel> GetAllWithAccountClauseModel();
        IEnumerable<ProceduceType> GetProceduceTypes();
        IEnumerable<AccountClause> GetAll();
        AccountClause addAccountClause(AccountClauseModel accountClause);
        ProceduceType GetProceduceType(int id);
        void updateAccountClause(AccountClause accountClause);
        void addBalanceAccount(AccountClauseDetail balanceAccount);
        IEnumerable<AccountClauseDetail> GetAccountDetailsByClauseId(int id);
        void DeleteDetail(int accountId, int clauseId, int accountTypeId);
        AccountType GetAccountType(string code);
        AccountClause Get(int id);
        IEnumerable<AccountClauseDetail> GetDetailWithType(int id,string code);
        void UpdateAccountDetail(int accountId, int clauseId, string typeCode, string description);
    }
}
