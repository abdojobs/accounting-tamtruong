using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
namespace DataAccess.Repositories {
	public interface ITaProceduceTypeRepository : ITaRepositoryBase<ProceduceType> {
        int GetReceiptProceduceType();
	}

}