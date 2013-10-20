using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Invoice_StockInReceipt
    {
        [Key, ForeignKey("Invoice"), Column(Order = 1)]
        public int Invoice_Id { get; set; }
        [Key, ForeignKey("StockInReceipt"), Column(Order = 2)]
        public int StockInReceipt_Id { get; set; }
        
        public virtual Invoice Invoice { get; set; }
        
        public virtual StockInReceipt StockInReceipt { get; set; }
    }
}
