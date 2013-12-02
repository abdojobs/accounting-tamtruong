using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Models.Views
{
    public class PayBillView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public string Supplier { get; set; }
        public string Receiver { get; set; }
    }
}
