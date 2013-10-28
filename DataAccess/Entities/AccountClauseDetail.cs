using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class AccountClauseDetail
    {
        [Key, ForeignKey("Account"), Column(Order = 1)]
        public int Account_Id { get; set; }
        [Key, ForeignKey("AccountClause"), Column(Order = 2)]
        public int AccountClause_Id { get; set; }
        public virtual AccountClause AccountClause { get; set; }
        public virtual Account Account { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
