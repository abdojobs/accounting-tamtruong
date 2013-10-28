using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Models;
using DataAccess.Entities;

namespace Business.Business.ServiceInterfaces
{
    public interface IStockOutReceiptBusiness
    {
        void addStockOutProceduce(StockOutReceiptModel model);
        StockOutReceipt addStockOutReceipt(StockOutReceiptModel model);
        /// <summary>
        /// write stockoutdetail
        /// </summary>
        /// <param name="stockOutReceipt">stockoutreceipt contain detail</param>
        /// <param name="stockOutDetails">list stockoutdetail are exported inside stockoutreceipt</param>
        /// <returns>amount fo receipt</returns>
        decimal writeStockOutDetails(StockOutReceipt stockOutReceipt, List<StockOutDetail> stockOutDetails);
        void writeInvoices(StockOutReceipt stockOutReceipt, List<Invoice> invoices);
        void writeGeneralLedger(StockOutReceipt stockOutReceipt, List<BalanceAccountModel> accounts);
        void updateInventory(StockOutDetail stockOutDetail);
        decimal CalAmount(StockOutDetail stockOutDetail);
    }
}
