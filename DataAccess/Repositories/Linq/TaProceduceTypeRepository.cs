using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories.Linq
{
    public class TaProceduceTypeRepository : TaDataContextEntity<ProceduceType>, ITaProceduceTypeRepository
    {
        public TaProceduceTypeRepository(TaDalContext Context)
        {
            this.Context = Context;
        }
    }
}
