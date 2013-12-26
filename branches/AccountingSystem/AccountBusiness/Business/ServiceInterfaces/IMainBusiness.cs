using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface IMainBusiness
    {
        List<Supplier> GetSuppliers();
        List<Receiver> GetRecievers();
        List<Stock> GetStocks();
        List<WareHouse> GetWareHouse();
        List<TradingPartner> GetTradingPartner();
    }
}
