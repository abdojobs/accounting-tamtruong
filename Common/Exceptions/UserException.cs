using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Exceptions
{
    public class UserException:Exception
    {
        public UserException(string message) : base(message) { }
    }
}
