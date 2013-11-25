using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class GeneralJournal
    {
        [Key,Column(Order = 1)]
        public int Proceduce_Id { get; set; }
        [Key, ForeignKey("Account"), Column(Order = 2)]
        public int Account_Id { get; set; }
        [Key, ForeignKey("Proceducetype"), Column(Order = 3)]
        public int Proceducetype_Id { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
        public virtual Account Account { get; set; }
        public decimal DebtAmount { get; set; }
        public decimal ReceiveAmount { get; set; }
        public virtual ProceduceType Proceducetype { get; set; }
    }
}
