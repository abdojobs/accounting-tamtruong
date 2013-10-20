using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public decimal LastInPrice { get; set; }
        public decimal SellPrice { get; set; }
        public float PromotionPercent { get; set; }
        public double Inventory { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual MensuralUnit MensuralUnit { get; set; }
    }
}
