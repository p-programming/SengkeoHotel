using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SengkeoHotel.dbconnection;
using System.Data;
namespace SengkeoHotel.controller.sellProduct_controller
{
    class SellController : dbConnect
    {
        public DataTable dtr = new DataTable();
        public double SellBill()
        {
            connectdb();
            sql = " Select Max (SellID) from Sell";
            cmd.CommandText = sql;
            object bill = cmd.ExecuteScalar();
            if (bill.ToString() != "")
            {
                return double.Parse(bill.ToString()) + 1;
            }
            return 100001;
        }
        public DataTable check_room(String roomid)
        {
            connectdb();
            sql = "Select RoomID, RoomNo from Room where RoomID LIKE '%'+@id+'%' Or RoomNo LIKE '%'+@no+'%'";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", roomid);
            cmd.Parameters.AddWithValue("@no", roomid);
            DataTable get_room = new DataTable();
            da.Fill(get_room);
            return get_room;
        }
        public DataTable check_customerInroom(String roomid)
        {
            connectdb();
            sql = "Select CustomerName from check_roomSale where RoomID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", roomid);
            DataTable get_room = new DataTable();
            da.Fill(get_room);
            return get_room;
        }
        public DataTable get_room()
        {
            connectdb();
            sql = "Select RoomID, RoomNo from Room";
            cmd.CommandText = sql;
            DataTable get_room = new DataTable();
            da.Fill(get_room);
            return get_room;
        }
        public DataTable getProductType()
        {
            connectdb();
            sql = "Select *from ProductType";
            cmd.CommandText = sql;
            DataTable get_pd = new DataTable();
            da.Fill(get_pd);
            return get_pd;
        }
        public DataSet check_Barcode(String barcode)
        {
            connectdb();
            sql = "Select *from sell_check_Product where Barcode=@barcode";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@barcode", barcode);
            DataSet get_barcoed = new DataSet();
            da.Fill(get_barcoed);
            return get_barcoed;
        }
        public DataTable check_ProductInStock(String search)
        {
            connectdb();
            sql = "Select ProductID,ProductTypeName,Sell,Qty,UnitName from sell_check_Product where Barcode LIKE '%'+@barcode+'%' OR ProductID LIKE '%'+@id+'%' OR ProductName LIKE N'%'+@proname+'%' OR ProductTypeName LiKE N'%'+@cate+'%' OR Sell LIKE '%'+@sell+'%' OR Qty LIKE '%'+@qty+'%' OR UnitName LIKE N'%'+@un+'%' ";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@barcode", search);
            cmd.Parameters.AddWithValue("@id", search);
            cmd.Parameters.AddWithValue("@proname", search);
            cmd.Parameters.AddWithValue("@cate", search);
            cmd.Parameters.AddWithValue("@sell", search);
            cmd.Parameters.AddWithValue("@qty", search);
            cmd.Parameters.AddWithValue("@un", search);
            DataTable get_prod = new DataTable();
            da.Fill(get_prod);
            return get_prod;
        }
        public DataTable check_ProductInStock_OnProductType(String search)
        {
            connectdb();
            sql = "Select ProductID,ProductName,ProductTypeName,Sell,Qty, UnitName from sell_check_Product where ProductTypeName =@ptype";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ptype", search);
            DataTable get_prod = new DataTable();
            da.Fill(get_prod);
            return get_prod;
        }
        public DataTable Load_ProductInStock()
        {
            connectdb();
            sql = "Select ProductID,ProductName,ProductTypeName,Sell,Qty, UnitName from sell_check_Product";
            cmd.CommandText = sql;
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public bool save_sellProduct(String id, String date, String roomid,String emp)
        {
            connectdb();
            sql = "Insert into Sell(SellID, SellDate, RoomID,EmpID) values (@id,@date,@rid,@ep )";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@date",date);
            cmd.Parameters.AddWithValue("@rid",roomid);
            cmd.Parameters.AddWithValue("@ep", emp);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool save_SellProductNoRoom(String id, String date,String emp)
        {
            connectdb();
            sql = "Insert into Sell(SellID, SellDate,EmpID) values (@id,@date,@eid )";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@eid", emp);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool save_sellProduct_Detail( String Proid, String Price,String Qty, String Total, String bill)
        {
            connectdb();
            sql = "Insert into SellDetail (ProductID, Sell, SellQty, Selltotal,SellID) values (@pid,@sell,@sellqty,@seltotal,@bill )";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pid", Proid);
            cmd.Parameters.AddWithValue("@sell", Price);
            cmd.Parameters.AddWithValue("@sellqty", Qty);
            cmd.Parameters.AddWithValue("@seltotal", Total);
            cmd.Parameters.AddWithValue("@bill", bill);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Update_instock(String qty, String id)
        {
            connectdb();
            sql = "update Product set Qty =@qty where ProductID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public DataTable get_SellProductLast(String toprow, bool all)
        {
            connectdb();
            if (all) sql = "Select from ";
            else sql = "";
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public DataTable get_roomComb()
        {
            connectdb();
            sql = "Select *from Room";
            cmd.CommandText = sql;
            DataTable r = new DataTable();
            da.Fill(r);
            return r;
        }
        public DataTable get_CustomerOnRoom(String room)
        {
            connectdb();
            sql = "select *from get_CustomerOnRoom where RoomNo=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",room);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public void Get_SaleBillNo(String selbill)
        {
            connectdb();
            sql = "Select *from SellBillNo where SellID='"+selbill+"'" ;
            cmd.CommandText = sql;
            DataTable bill = new DataTable();
            da.Fill(bill);
            dtr = bill;
        }
    }
}
