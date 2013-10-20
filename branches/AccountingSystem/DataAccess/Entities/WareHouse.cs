using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class WareHouse
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Address { get; set; }
    }
}
