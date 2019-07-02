using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SengkeoHotel.dbconnection;
namespace SengkeoHotel.controller.orderProduct_controller
{
    class check_order_controller : dbConnect
    {
        public DataTable resutl_orderProduct()
        {
            connectdb();
            sql = "";
            return cmd_datatable(sql);
        }
        public DataSet check_ProductStock(String name)
        {
            connectdb();
            sql = "select  count(*) ProductID from checkProduct_Show_Onring where ProductTypeName =@name";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name",name);
            DataSet current = new DataSet();
            da.Fill(current);
            return current;
        }
        public DataTable result_check()
        {
            connectdb();
            sql = "Select *from check_stock";
            DataTable c = new DataTable();
            da.Fill(c);
            return c;
        }
        public DataTable get_productType_showRing()
        {
            connectdb();
            sql = "select ProductTypeID,ProductTypeName from ProductType";
            //DataSet get = new DataSet();
            //da.Fill(get);
            //return get;
            return cmd_datatable(sql);
        }
       
    }
}
