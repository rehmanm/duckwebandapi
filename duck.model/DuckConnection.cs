using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck.model
{
    public class DuckConnection
    {
        public static string Connection {
            get {
                return ConfigurationManager.ConnectionStrings["DuckDB"].ToString();
                    
                   // "Server=.\\SQLEXPRESS;Database=Duck;Trusted_Connection=Yes";
            }
        }
    }
}
