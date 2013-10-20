using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [UniqueKey]
        [StringLength(100)]
        public string TaxCode { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Address { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string DirectorName { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string BankAccountNo { get; set; }
    }
}
