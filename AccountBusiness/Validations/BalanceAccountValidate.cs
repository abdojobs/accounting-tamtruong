using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Models;
using Common.Exceptions;
using Common.Messages;

namespace Business.Validations
{
    public class BalanceAccountValidate
    {
        public void validate(List<BalanceAccountModel> accounts)
        {
            if (accounts == null || accounts.Count == 0)
                throw new UserException(ErrorsManager.Error0004);
        }
    }
}
