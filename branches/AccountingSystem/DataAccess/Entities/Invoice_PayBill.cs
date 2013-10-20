using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Invoice_PayBill
    {
        [Key, ForeignKey("Invoice"), Column(Order = 1)]
        public int Invoice_Id { get; set; }
        [Key, ForeignKey("PayBill"), Column(Order = 2)]
        public int PayBill_Id { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual PayBill PayBill { get; set; }
    }
}
