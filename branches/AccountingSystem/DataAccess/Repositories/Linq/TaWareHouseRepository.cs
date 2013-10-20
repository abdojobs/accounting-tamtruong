using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
namespace DataAccess.Repositories.Linq {
	public class TaWareHouseRepository : TaDataContextEntity<WareHouse>, ITaWareHouseRepository {

        public TaWareHouseRepository(TaDalContext Context)
        {
            this.Context = Context;
        }

		
	}

}