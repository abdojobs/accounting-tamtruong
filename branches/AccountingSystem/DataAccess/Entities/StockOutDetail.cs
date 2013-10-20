using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Entities
{
    public class StockOutDetail
    {
        public int Id { get; set; }
        public virtual StockOutReceipt StockOutReceipt { get; set; }
        public virtual Stock Stock { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal IncludeFee { get; set; }
    }
}
