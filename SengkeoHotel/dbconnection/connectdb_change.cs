using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SengkeoHotel.dbconnection
{
    class connectdb_change
    {
        public SqlConnection cn = new SqlConnection("Data Source=DESKTOP-MQQPSHU\\SQLEXPRESS;Initial Catalog=ProjectSengKeo;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlDataReader dr;
        public DataSet ds;
        public DataTable dt;
        public string sql = "";
        //Connect database 
        public void Connection_Database()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        //Close database when don't use database
        public void Disconnect_Database()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
}
