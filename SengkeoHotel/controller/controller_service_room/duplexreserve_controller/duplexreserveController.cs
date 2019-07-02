using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SengkeoHotel.dbconnection;
using System.Data;
using System.Windows.Forms;

namespace SengkeoHotel.controller.controller_service_room.duplexreserve_controller
{
    class duplexreserveController : dbConnect
    {
        //public double create_reserveID()
        //{
        //    connectdb();
        //    sql = "SELECT MAX (DResID) from DuplexReserve";
        //    cmd.CommandText = sql;
        //    object id = cmd.ExecuteScalar();
        //    if (id.ToString()!= "")
        //    {
        //        return double.Parse(id.ToString()) + 1;
        //    }
        //    return 101;
        //}
        public void create_AutoID(TextBox id)
        {
            connectdb();
            sql = "create_DuplexReserverID";
            cmd.CommandText = sql;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable d = new DataTable();
            da.Fill(d);
            id.Text = d.Rows[0].ItemArray[0].ToString();
        }
        public DataTable get_customerReserve()
        {
            connectdb();
            sql = "Select *from Customer";
            cmd.CommandText = sql;
            DataTable cus = new DataTable();
            da.Fill(cus);
            return cus;
        }
        public DataSet set_customerReserv(String customer)
        {
            connectdb();
            sql = "SELECT CustomerName,CustomerAddress,Tel,Email from getCustmer_DuplexReserve WHERE CustomerName=@id ";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",customer);
            DataSet cs = new DataSet();
            da.Fill(cs);
            return cs;
        }
        public DataTable get_Reserve(String TopRow, bool All)
        {
            connectdb();
            if(All) sql = "SELECT DResID,CustomerName,Tel,ReserveDate,EventDate,TotalPayment,Deposit,Balance FROM v_DuplexReserv ORDER BY DResID DESC";
            else sql ="SELECT TOP "+TopRow+ "DResID,CustomerName,Tel,ReserveDate,EventDate,TotalPayment,Deposit,Balance FROM v_DuplexReserv ORDER BY DResID DESC";
            cmd.CommandText = sql;
            DataTable rs = new DataTable();
            da.Fill(rs);
            return rs;
        }
        public DataTable get_ReserveShowOnfrm(String Drsid)
        {
            connectdb();
            sql = "SELECT DResID,CustomerName,Tel,ReserveDate,EventDate,TotalPayment,Deposit,Balance FROM v_DuplexReserv where DResID ='"+Drsid+"'";
            cmd.CommandText = sql;
            DataTable rs = new DataTable();
            da.Fill(rs);
            return rs;
        }
        public DataTable Search_Reserve(String search)
        {
            connectdb();
            sql = "SELECT DResID,CustomerName,Tel,TotalPayment,Deposit,Balance from v_DuplexReserv where DResID LIKE '%'+@id+'%' OR CustomerName LIKE N'%'+@cus+'%' OR Tel LIKE '%'+@tel+'%' OR TotalPayment LIKE '%'+@ttp+'%' OR Deposit LIKE '%'+@ds+'%' OR Balance LIKE '%'+@bl+'%'";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",search);
            cmd.Parameters.AddWithValue("@cus", search);
            cmd.Parameters.AddWithValue("@tel", search);
            cmd.Parameters.AddWithValue("@ttp", search);
            cmd.Parameters.AddWithValue("@ds", search);
            cmd.Parameters.AddWithValue("@bl", search);
            DataTable rs = new DataTable();
            da.Fill(rs);
            return rs;
        }
        public bool Inser_DuplexReserve(String id,String cus,String bdate,String edate, String total, String deposit,String blance)
        {
            connectdb();
            sql = "INSERT INTO DuplexReserve(DResID,CustomerID, ReserveDate,EventDate,TotalPayment,Deposit,Balance) VALUES (@id,@cus,@bdate,@edate,@total,@depo,@balance)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cus", cus);
            cmd.Parameters.AddWithValue("@bdate",bdate);
            cmd.Parameters.AddWithValue("@edate",edate);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@depo", deposit);
            cmd.Parameters.AddWithValue("@balance", blance); 
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Update_DuplexReserve( String bdate, String edate, String total, String deposit, String blance, String id)
        {
            connectdb();
            sql = "Update DuplexReserve Set ReserveDate=@bdate,EventDate=@edate,TotalPayment=@total,Deposit=@depo,Balance=@balance where DResID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@bdate", bdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@depo", deposit);
            cmd.Parameters.AddWithValue("@balance", blance);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Delete_DuplexReserve(string id)
        {
            connectdb();
            sql = "Delete from DuplexReserve where DResID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return false;
        }
    }
}
