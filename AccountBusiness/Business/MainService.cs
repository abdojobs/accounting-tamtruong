using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountBusiness.Business.ServiceInterfaces;
using DataAccess.Repositories.Linq;

namespace AccountBusiness.Business
{
    public class MainService:IMainBusiness
    {
        public List<DataAccess.Entities.Supplier> GetSuppliers()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.Suppliers.ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }

        public List<DataAccess.Entities.Receiver> GetRecievers()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.Receivers.ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public List<DataAccess.Entities.Stock> GetStocks()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.Stocks.Include("MensuralUnit").ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public List<DataAccess.Entities.WareHouse> GetWareHouse()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.WareHouses.ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }


        public List<DataAccess.Entities.TradingPartner> GetTradingPartner()
        {
            using (var Context = new TaDalContext())
            {
                try
                {
                    return Context.TradingPartners.ToList();

                }
                catch { }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }
    }
}
