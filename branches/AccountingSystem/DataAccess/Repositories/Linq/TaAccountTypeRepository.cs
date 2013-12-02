using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaAccountTypeRepository : TaDataContextEntity<AccountType>, ITaAccountTypeRepository
    {

        public int GetAccountTypeId(AccountTypeEnum type)
        {
            using (var Context = new TaDalContext())
            {

                try
                {
                    string code = type.ToString().ToLower();
                    var rs = Context.AccountTypes.Where(t => t.Code.ToLower() == code).FirstOrDefault();
                    return rs != null ? rs.Id : 0;
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return 0;
            }
        }
    }
}
