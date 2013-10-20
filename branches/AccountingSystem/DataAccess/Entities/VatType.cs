using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class VatType
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(1)]
        public string Code { get; set; }
        public float Tax { get; set; }
    }
}
