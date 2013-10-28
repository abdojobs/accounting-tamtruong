using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;

namespace Business.Validations
{
    public class AccountClauseValidate
    {
        public void validate(AccountClause accountClause) { 
            // code is not empty
            if (accountClause.Code == string.Empty)
                throw new UserException(ErrorsManager.Error0020);
            // description is not empty
            if(accountClause.Description==string.Empty)
                throw new UserException(ErrorsManager.Error0014);
            // proceducetype is not null
            //if(accountClause.ProceduceType==null || accountClause.ProceduceType.Id==0)
            //    throw new UserException(ErrorsManager.Error0019);
        }
        public void validateBalanceAccount(AccountClauseDetail accountdetail) { 
            // accountclause is not null
            if (accountdetail.AccountClause == null || accountdetail.AccountClause.Id == 0)
                throw new UserException(ErrorsManager.Error0021);
            // account is not null
            if(accountdetail.Account==null || accountdetail.Account.Id==0)
                throw new UserException(ErrorsManager.Error0022);
            // description is not null
            if(accountdetail.Description==string.Empty)
                throw new UserException(ErrorsManager.Error0014);
        }
    }
}
