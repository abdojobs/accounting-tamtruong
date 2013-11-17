using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountBusiness.Business.ServiceInterfaces;
using DataAccess.Repositories;

namespace AccountBusiness.Business
{
    public class CustomerService : BaseConnector, ICustomerBusiness
    {
        public IEnumerable<DataAccess.Entities.Customer> GetAll()
        {
            return Context.Customers.GetAll();
        }
    }
}
