﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ITaStockRepository:ITaRepositoryBase<Stock>
    {
        void UpdateInventory(int id, double quantity);
    }
}
