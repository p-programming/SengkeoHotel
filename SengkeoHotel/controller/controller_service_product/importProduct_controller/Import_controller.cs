using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SengkeoHotel.dbconnection;
namespace SengkeoHotel.controller.importProduct_controller
{
    class Import_controller : dbConnect
    {
        public double create_id()
        {
            connectdb();
            sql = "select max(ImportID) from Import ";
            cmd.CommandText = sql;
            object id = cmd.ExecuteScalar();
            if (id.ToString() !=""){
                return double.Parse(id.ToString()) +1;
            }
            return 100001;
        }
        public DataTable chec_OrderBill(String Orderid)
        {
            connectdb();
            sql = "Select OrderDate, ProductID, ProductName, ProductTypeName, OrderQty,SupplierName,'','','' from show_check_OrderProduct where OrderID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", Orderid);
            DataTable getcheck = new DataTable();
            da.Fill(getcheck);
            return getcheck;
        }
        public DataTable get_OrderID()
        {
            connectdb();
            sql = "Select OrderID from Orders";
            cmd.CommandText = sql;
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public DataTable get_OrderDate()
        {
            connectdb();
            sql = "Select *from GroupBy_dateImport";
            cmd.CommandText = sql;
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public DataTable check_current(String id)
        {
            connectdb();
            sql = "Select ImportID from Import where ImportID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public DataSet  check_orderStatus(String id)
        {
            connectdb();
            sql = "Select OrderStatus from Orders where OrderID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            DataSet get_status = new DataSet();
            da.Fill(get_status);
            return get_status;
        }
        public bool Save_importProduct(String id, String date, String employee) {
            connectdb();
            sql = "Insert into Import(ImportID,Importdate,EmpID) values (@id,@date,@emp)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@date",date);
            cmd.Parameters.AddWithValue("@emp", employee);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Save_importDetail (String proid,String prosell,String prodqty,String orderbill, String total)
        {
            connectdb();
            sql = "Insert into ImportDetail(ProductID,ImportBuy,ImportQty,ImportID,Importtotal) values (@id,@buy,@qty,@bill,@total)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", proid);
            cmd.Parameters.AddWithValue("@buy", prosell);
            cmd.Parameters.AddWithValue("@qty", prodqty);
            cmd.Parameters.AddWithValue("@bill", orderbill);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.ExecuteNonQuery();
            return false;

        }
        public bool Update_Product(String qty, String id)
        {
            connectdb();
            sql = "Update Product Set Qty=@qty where ProductID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@qty",qty);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public DataTable plus_qty (string id)
        {
            connectdb();
            sql = "Select Qty from Product Where ProductID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
        }
        public bool Update_OrderProduct_Status(String Status, String id)
        {
            connectdb();
            sql = "Update Orders set OrderStatus=@status where OrderID=@orderid";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@status",Status);
            cmd.Parameters.AddWithValue("@orderid",id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public DataTable Show_ProductImport_InStock( String TopRow, bool All )
        {
            connectdb();
            if (All) sql = "Select ProductID,ProductName,ProductTypeName,ImportQty,Qty from Import_Product_Amount order by ProductID,Qty Desc";
            else sql = "Select Top " + TopRow + "ProductID,ProductName,ProductTypeName,ImportQty,Qty from Import_Product_Amount order by ProductID,Qty Desc ";
            cmd.CommandText = sql;
            DataTable pd = new DataTable();
            da.Fill(pd);
            return pd;
        }
    }
}
