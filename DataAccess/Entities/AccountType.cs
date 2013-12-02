using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(1)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
    public enum AccountTypeEnum { 
        N,// nợ
        C // có
    }
}
