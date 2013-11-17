using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountBusiness.Models.Views
{
    public class ReceiptView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public string TradingPartner { get; set; }
        public string DeliveryPerson { get; set; }
    }
}
