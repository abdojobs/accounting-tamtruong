using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repositories.Linq;
using DataAccess.Repositories.ADO;
using DataAccess.Repositories.Harsh;
using System.Data;
using System.Data.SqlClient;
using Common.Logs;
using Common.Exceptions;
using Common.Messages;
using System.Configuration;

namespace DataAccess.Repositories
{
    public class BaseConnector
    {
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
        public DataTable Execute(string sql) {
            try {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[GlobalConstant.DBConnecstring].ConnectionString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        using (var da = new SqlDataAdapter(cmd)) {
                            cmd.CommandText = sql;
                            DataTable tb = new DataTable();
                            da.Fill(tb);
                            return tb;
                        }
                    }
                }
            }
            catch (Exception ex) {
                WriteLog.Error(this.GetType(), ex);
                throw new UserException(ErrorsManager.Error0000);
            }
        }
    }
    public enum ConnectType { 
        EF,
        ADO,
        Harsh
    }
}
