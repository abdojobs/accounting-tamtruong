using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Invoice_StockOutReceipt
    {
        [Key, ForeignKey("Invoice"), Column(Order = 1)]
        public int Invoice_Id { get; set; }
        [Key, ForeignKey("StockOutReceipt"), Column(Order = 2)]
        public int StockOutReceipt_Id { get; set; }

        public virtual Invoice Invoice { get; set; }
       
        public virtual StockOutReceipt StockOutReceipt { get; set; }
    }
}
