using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public class RepositorioBase
    {
        public SqlConnection Conexion;
        public RepositorioBase()
        {
            string test = ConfigurationManager.AppSettings["MiniWareBD"];
            Conexion = new SqlConnection(ConfigurationManager.AppSettings["MiniWareBD"]);
        }
    }
}
