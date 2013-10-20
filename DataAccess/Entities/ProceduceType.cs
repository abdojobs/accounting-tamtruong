using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Attributes;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories;

namespace DataAccess.Entities
{
    public class ProceduceType
    {
        public int Id { get; set; }
        [UniqueKey]
        [StringLength(1)]
        public string Code { get; set; }
        [StringLength(GlobalConstant.MaxLengthDefault)]
        public string Description { get; set; }
    }
    public enum EProceduceType { 
        I,//Import,
        E,//Export,
        R,//Recieve,
        P//Pay
    }
}
