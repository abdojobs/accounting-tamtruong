using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaDeliveryPersonRepository:TaDataContextEntity<DeliveryPerson>,ITaDeliveryPersonRepository
    {
        public TaDeliveryPersonRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
