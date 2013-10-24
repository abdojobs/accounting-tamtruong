using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class PayBill
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Receiver Receiver { get; set; }
        public virtual AccountClause AccountClause { get; set; }
    }
}
