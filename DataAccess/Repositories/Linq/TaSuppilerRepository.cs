using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
namespace DataAccess.Repositories.Linq {
	public class TaSupplierRepository : TaDataContextEntity<Supplier>, ITaSupplierRepository {

        public TaSupplierRepository(TaDalContext Context)
        {
            this.Context = Context;
        }

	}

}