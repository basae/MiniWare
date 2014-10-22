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
        public SqlConnection Conexion=new SqlConnection(ConfigurationSettings.AppSettings["MiniWareBD"]);        
    }
}
