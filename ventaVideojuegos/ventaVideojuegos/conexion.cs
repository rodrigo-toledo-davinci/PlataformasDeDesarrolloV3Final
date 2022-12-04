using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ventaVideojuegos
{
    class conexion
    {

        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-4QE2QT2;" + "Initial Catalog=TEST;" + "Integrated Security=SSPI;");

            cn.Open();

            return cn;

        }

    }
}
