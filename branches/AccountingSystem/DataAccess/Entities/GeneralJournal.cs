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
        public int Id { get; set; }
        public int Proceduce_Id { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
        public virtual Account Account { get; set; }
        public decimal DebtMoney { get; set; }
        public decimal RecieveMoney { get; set; }
        public virtual ProceduceType Proceducetype { get; set; }
    }
}
