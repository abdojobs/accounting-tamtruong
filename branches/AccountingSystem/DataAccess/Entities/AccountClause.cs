using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class AccountClause
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual ProceduceType ProceduceType { get; set; }
    }
}
