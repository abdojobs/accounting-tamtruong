using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccess.Repositories
{
    public class GlobalConstant
    {
        public readonly static string ConnectType = ConfigurationSettings.AppSettings["ConnectType"];
        public readonly static string DBConnecstring = "dbconnecstring";
        public const int MaxLengthDefault = 255; 
    }
}
