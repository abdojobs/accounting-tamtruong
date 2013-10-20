using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Invoice_Receipt
    {
        [Key, ForeignKey("Invoice"), Column(Order = 1)]
        public int Invoice_Id { get; set; }
        [Key, ForeignKey("Receipt"), Column(Order = 2)]
        public int Receipt_Id { get; set; }
       
        public virtual Invoice Invoice { get; set; }
        
        public virtual Receipt Receipt { get; set; }
    }
}
