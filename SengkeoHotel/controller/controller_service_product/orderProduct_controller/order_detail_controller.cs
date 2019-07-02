using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SengkeoHotel.dbconnection;
using System.Windows.Forms;
namespace SengkeoHotel.controller.orderProduct_controller
{
    class order_detail_controller : dbConnect
    {
        public DataTable dtr = new DataTable();
        public DataTable check_ProductInstock(String qty)
        {
            
            connectdb();
            sql = "Select * from check_ProductInStock where Qty <= '"+qty+"'";
            cmd.CommandText = sql;
            da = new System.Data.SqlClient.SqlDataAdapter(sql,cn);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;
           
        }
        public DataTable getProduct_instock()
        {

            connectdb();
            sql = "Select *from check_ProductInStock";
            cmd.CommandText = sql;
            da = new System.Data.SqlClient.SqlDataAdapter(sql, cn);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;

        }
        public DataTable get_supplier()
        {
            connectdb();
            sql = "Select *from Supplier";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, cn);
            DataTable sup = new DataTable();
            da.Fill(sup);
            return sup;

        }
        public double create_id()
        {
            connectdb();
            sql = "Select max(SupplierID) from Supplier";
            cmd.CommandText = sql;
            Object id = cmd.ExecuteScalar();
            if (id.ToString() != "")
            {
                disconnectdb();
                return double.Parse(id.ToString()) + 1;
            }
            return 000001;
        }
        public bool insert_supplier(String id, String name, String address, String tel)
        {
            connectdb();
            sql = "Insert into Supplier values (@id,@name,@add,@tel)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@add",address);
            cmd.Parameters.AddWithValue("@tel",tel);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool insert_OrderProduct(String id, String Date,String status, String Empid, String Supplier)
        {
            connectdb();
            sql = "Insert into Orders(OrderID,OrderDate,OrderStatus,EmpID,SupplierID) values (@id,@date,@st,@user,@sup)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@date",Date);
            cmd.Parameters.AddWithValue("@st", status);
            cmd.Parameters.AddWithValue("@user", Empid);
            cmd.Parameters.AddWithValue("@sup",Supplier);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool insert_OrderDetail( String Product, String qty, String bill)
        {
            connectdb();
            sql = "Insert into OrderDetail(ProductID,OrderQty,OrderID) values (@proid,@proqty,@bill)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@proid", Product);
            cmd.Parameters.AddWithValue("@proqty",qty);
            cmd.Parameters.AddWithValue("@bill", bill);
            cmd.ExecuteNonQuery();
            return false;
        }
        public DataTable check_supp(String id)
        {
            connectdb();
            sql = "Select *from Supplier where SupplierName =@name";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name",id);
            DataTable get = new DataTable();
            da.Fill(get);
            return get;

        }
        public double billNo()
        {
            connectdb();
            sql = "Select max(OrderID) from Orders";
            cmd.CommandText = sql;
            Object id = cmd.ExecuteScalar();
            if (id.ToString() != "")
            {
                return double.Parse(id.ToString()) + 1;
            }
            return 100001;
        }
        public double OrderdetailNo()
        {
            connectdb();
            sql = "Select max(OrderDetailID) from OrderDetail";
            cmd.CommandText = sql;
            Object id = cmd.ExecuteScalar();
            if (id.ToString() != "")
            {
                return double.Parse(id.ToString()) + 1;
            }
            return 1;
        }
        public void  OrderBllNo(String OrderBill)
        {
            connectdb();
            sql = "Select *from OrderBillno where OrderID='"+OrderBill+"'";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@id",OrderBill);
            DataTable bill = new DataTable();
            da.Fill(bill);
            dtr = bill;
        }
    }

}
