using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repositories.Linq;
using DataAccess.Repositories.ADO;
using DataAccess.Repositories.Harsh;

namespace DataAccess.Repositories
{
    public class BaseConnector
    {
        private ConnectType ConnectType;
        private ITaData Connector;
        public BaseConnector() {
            string type = GlobalConstant.ConnectType;
            switch (type.ToLower()) {
                case "harsh":
                    Connector = new HarshData();
                    break;
                case "ado":
                    Connector = new ADOData();
                    break;
                default:
                    Connector = new EFData();
                    break;
            }
        }
        public ITaData Context {
            get {
                return Connector;
            }
        }
    }
    public enum ConnectType { 
        EF,
        ADO,
        Harsh
    }
}
