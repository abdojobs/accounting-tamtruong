using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountBusiness.Models
{
    public class AccountClauseModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ProceduceType_Id { get; set; }
        public string ProceduceType_Des { get; set; }
    }
}
