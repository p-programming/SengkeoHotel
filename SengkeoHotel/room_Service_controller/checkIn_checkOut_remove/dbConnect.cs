using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SengkeoHotel.dbconnection
{
    class dbConnect
    {
        protected static String strcn = "Data Source=DESKTOP-MQQPSHU\\SQLEXPRESS;Initial Catalog=ProjectSengKeo;Integrated Security=True";
        protected static SqlConnection cn = new SqlConnection(strcn);
        protected static SqlCommand cmd = new SqlCommand("", cn);
        protected SqlDataAdapter da = new SqlDataAdapter(cmd);
        protected DataSet ds = new DataSet();
        protected DataTable dt = new DataTable();
        protected static String sql = "";

        protected static void connectdb()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        protected static void disconnectdb()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        protected DataSet cmd_dataset(String query)
        {
            connectdb();
            da = new SqlDataAdapter(sql, cn);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        protected DataTable cmd_datatable(String query)
        {
            connectdb();
            da = new SqlDataAdapter(sql,cn);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
