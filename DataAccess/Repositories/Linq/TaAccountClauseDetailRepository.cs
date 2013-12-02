using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaAccountClauseDetailRepository : TaDataContextEntity<AccountClauseDetail>, ITaAccountClauseDetailRepository
    {

        public IEnumerable<AccountClauseDetail> GetAccountReceivableDetail(int accountclause_id)
        {
            using (var Context = new TaDalContext()) {
                try {
                    string code = AccountTypeEnum.C.ToString();
                    return Context.AccountClauseDetails.Include("Account").Include("AccountType").Include("AccountClause").Where(a => a.AccountType.Code == code && a.AccountClause_Id == accountclause_id).ToList();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public IEnumerable<AccountClauseDetail> GetAccountDebtDetail(int accountclause_id)
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    string code = AccountTypeEnum.N.ToString();
                    return Context.AccountClauseDetails.Include("Account").Include("AccountType").Include("AccountClause").Where(a => a.AccountType.Code == code && a.AccountClause_Id == accountclause_id).ToList();
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }
    }
}
