using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SengkeoHotel.dbconnection;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SengkeoHotel.controller.controller_service_room.duplexreserve_controller
{
    class ReservBookingController : dbConnect
    {
        public void CreateReserveBookingAutoID(TextBox id) {

            connectdb();
            da= new SqlDataAdapter( "create_ReserveBookingID",cn);
            //cmd.CommandText = sql;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable getid = new DataTable();
            da.Fill(getid);
            id.Text = getid.Rows[0].ItemArray[0].ToString();
        }
        public void CreateCustomerID(TextBox get) {
            connectdb();
            da = new SqlDataAdapter( "New_Customer",cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable getnew = new DataTable();
            da.Fill(getnew);
            get.Text = getnew.Rows[0].ItemArray[0].ToString();
        }
        public DataTable Get_RoomType()
        {
            connectdb();
            da = new SqlDataAdapter("Select *from RoomType",cn);
            DataTable getr = new DataTable();
            da.Fill(getr);
            return getr;
        }
        public DataTable Set_RoomType(String name) {
            connectdb();
            sql = "select *from Selected_Room where RoomTypeName =N'"+name+"'";
            cmd.CommandText = sql;
            return cmd_datatable(sql);
        }
        public DataTable Get_SelectedSearchRoom(String Search)
        {
            connectdb();
            sql = "select *from Selected_Room where RoomID LIKE N'%'+@name+'%'";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@name", Search);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }

        public DataTable Get_Customer() {
            connectdb();
            sql = "Select *from Customer";
            cmd.CommandText = sql;
            return cmd_datatable(sql);
        }
        public DataTable Set_Customer(String ID)
        {
            connectdb();
            sql = "Select CustomerName,CustomerAddress,Tel,Email from Customer where CustomerName =N'"+ID+"'";
            cmd.CommandText = sql;
            return cmd_datatable(sql);
        }
        public bool AddNew_Customer(String id, String fname, String lname, String Address, String Tel,String Email)
        {
            sql = "Addnew_CustomerInBooking";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@tel", Tel);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Inserted_Booking(String id,String date,String status,String emp, String cus)
        {
            connectdb();
            sql = "Inserted_BookingReserve";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@bid",id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@empid", emp);
            cmd.Parameters.AddWithValue("@cusid", cus);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Inserted_BookingDetail (String roomid,String Price, String Amount, String Pricetotal, String bookid)
        {
            connectdb();
            sql = "Inserted_BookingDetail";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@roomid", roomid);
            cmd.Parameters.AddWithValue("@rprice", Price);
            cmd.Parameters.AddWithValue("@amount", Amount);
            cmd.Parameters.AddWithValue("@total", Pricetotal);
            cmd.Parameters.AddWithValue("@bid", bookid);
            cmd.ExecuteNonQuery();
            return false;
        }
    }
}
