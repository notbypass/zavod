using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Zavod
{
    internal class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "89.108.115.218";
            int port = 3306;
            string database = "zavod";
            string user = "appuser";
            string password = "pass";

            return DBMySQLUtils.GetDBConnection(host, port, database, user, password);
        }
    }
}
