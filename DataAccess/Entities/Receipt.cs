using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Receipt
    {
        #region properties
        public int Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public virtual TradingPartner TradingPartner { get; set; }
        public virtual DeliveryPerson DeliveryPerson { get; set; }
        
        public virtual AccountClause AccountClause { get; set; }
        #endregion

    }

}
