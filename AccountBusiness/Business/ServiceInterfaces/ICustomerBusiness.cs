using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface ICustomerBusiness
    {
        IEnumerable<Customer> GetAll();
    }
}
