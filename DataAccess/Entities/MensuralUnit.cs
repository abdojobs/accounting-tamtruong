using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class MensuralUnit
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual MensuralUnit UnitConverted { get; set; }
        public float ConvertRate { get; set; }
    }
}
