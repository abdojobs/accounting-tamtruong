using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAccess.Attributes;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class Account
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(6)]
        public string Code { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual Account Parent { get; set; }
    }
}
