using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [UniqueKey]
        [StringLength(50)]
        public string IC { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string FixedAddress { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string UnFixedAddress { get; set; }

    }
}
