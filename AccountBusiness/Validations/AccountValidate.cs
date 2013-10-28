using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Exceptions;
using Common.Messages;
using Common.Utils;

namespace Business.Validations
{
    public class AccountValidate
    {
        public void validate(Account account) {
            // code is not less than or equal 0
            if (account.Code.IsEmpty())
                throw new UserException(ErrorsManager.Error0018);
            // code must numeric type
            if(!account.Code.IsNumber())
                throw new UserException(ErrorsManager.Error0023);
            // description is not null
            if (account.Description.IsEmpty())
                throw new UserException(ErrorsManager.Error0014);
        }
    }
}
