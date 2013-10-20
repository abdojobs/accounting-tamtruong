using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Attributes
{
    ///<summary> 
    ///A unique attribute 
    ///</summary> 
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueKeyAttribute : Attribute
    {
    } 
}
