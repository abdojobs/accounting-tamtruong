using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using Common.Logs;

namespace DataAccess.Repositories.Linq
{
    public class TaStockInReceiptRepository:TaDataContextEntity<StockInReceipt>,ITaStockInReceiptRepository
    {

        public StockInReceipt AddStockInReceipt(StockInReceipt stockIn)
        {
            using (var Context = new TaDalContext())
            {
                try
                {

                    // set Supplier for stockIn
                    stockIn.Supplier = Context.Suppliers.Find(stockIn.Supplier.Id);
                    // set DeliveryPerson for stockIn
                    stockIn.DeliveryPerson = Context.DeliveryPersons.Find(stockIn.DeliveryPerson.Id);
                    // set WareHouse for stockIn
                    stockIn.WareHouse = Context.WareHouses.Find(stockIn.WareHouse.Id);
                    // set VatType for stockIn
                    stockIn.VatType = Context.VatTypes.Find(stockIn.VatType.Id);
                    //receipt.AccountClause_Id = receiptmodel.AccountClause.Id;

                    //save
                    Context.StockInReceipts.Add(stockIn);
                    Context.SaveChanges();

                    return stockIn;
                }
                catch (Exception ex)
                {
                    WriteLog.ErrorDbCommon(this.GetType(), ex);
                }
                finally
                {
                    Context.Dispose();
                }
                return null;
            }
        }
    }
}
