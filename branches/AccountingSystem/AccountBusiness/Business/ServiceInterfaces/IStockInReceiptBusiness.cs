using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Models;
using AccountBusiness.Models;

namespace AccountBusiness.Business.ServiceInterfaces
{
    public interface IStockInReceiptBusiness
    {
        void addStockInProceduce(StockInReceiptModel model);
        StockInReceipt addStockInReceipt(StockInReceiptModel model);
        /// <summary>
        /// write stockindetail
        /// </summary>
        /// <param name="StockInReceipt">stockinreceipt contain detail</param>
        /// <param name="StockInReceipt">list stockindetail are exported inside stockinreceipt</param>
        /// <returns>amount fo receipt</returns>
        decimal writeStockInDetails(StockInReceipt stockInReceipt, List<StockInDetail> stockInDetails);
        void writeInvoices(StockInReceipt stockInReceipt, List<Invoice> invoices);
        void writeGeneralLedger(StockInReceipt stockInReceipt, List<BalanceAccountModel> accounts);
        void updateInventory(StockInDetail stockInDetail);
        decimal CalAmount(StockInDetail stockInDetail);
    }
}
