using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class StockInReceipt
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual DeliveryPerson DeliveryPerson { get; set; }
        public virtual WareHouse WareHouse { get; set; }
        public virtual VatType VatType { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public float DiscountPercent { get; set; }
    }
}
