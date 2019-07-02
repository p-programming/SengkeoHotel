using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SengkeoHotel
{
    public class ClassConnection
    {

        string strconn = "Data Source=DESKTOP-MQQPSHU\\SQLEXPRESS;Initial Catalog=ProjectSengKeo;Integrated Security=True";
        public SqlConnection conn = new SqlConnection();
        public SqlCommand cm;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataSet ds = new DataSet();
        public StringBuilder sb = new StringBuilder();
        public string str = "";
        public DataTable dt;
        public Boolean CheckUser;
        public static string EmployeeID;

        public void RunManger(string str)
        {
            conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            cm = new SqlCommand(str, conn);
            cm.ExecuteNonQuery();
        }

        public void RunQuery(string str)
        {
            conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                
            }

            cm = new SqlCommand(str, conn);
            da = new SqlDataAdapter(cm);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

        }

        public void RunStringBuilder(string str)
        {
            conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            cm = new SqlCommand(str, conn);
            da = new SqlDataAdapter(cm);
            ds = new DataSet();
            da.Fill(ds);

        }

        public void RunReader(string str)
        {
            conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            cm = new SqlCommand(str, conn);
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                CheckUser = true;
            }
            else
            {
                CheckUser = false;
            }
            dr.Close();
        }



        public void ShowDataAll(string str)
        {
            conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            sb.Append(str);
            string a = sb.ToString();
            cm = new SqlCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = str;
            cm.Connection = conn;
            dr = cm.ExecuteReader();

        }

        public void RunQuerytoReport(string str)
        {
            conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            cm = new SqlCommand(str, conn);
            da = new SqlDataAdapter(cm);


        }


    }
}
