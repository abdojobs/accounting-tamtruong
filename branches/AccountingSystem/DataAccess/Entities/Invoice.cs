using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(50)]
        public string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime PerformDate { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal Total { get; set; }
        public virtual VatType VatType { get; set; }
        public virtual Stock Stock { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
    }
}
