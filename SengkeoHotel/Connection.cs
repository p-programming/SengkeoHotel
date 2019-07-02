using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SengkeoHotel
{
    class Connection
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MQQPSHU\\SQLEXPRESS;Initial Catalog=ProjectSengKeo;Integrated Security=True");

        public SqlConnection ActiveCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }

}
