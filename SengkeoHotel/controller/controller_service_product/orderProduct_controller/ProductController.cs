using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SengkeoHotel.dbconnection;
using System.Data;

namespace SengkeoHotel.controller.orderProduct_controller
{
    class ProductController : dbConnect
    {
        public double createID()
        {
            connectdb();
            sql = "SELECT MAX (UnitID) from Unit";
            cmd.CommandText = sql;
            object id = cmd.ExecuteScalar();
            if (id.ToString() != "")
            {
                return double.Parse(id.ToString()) + 1;

            }
            return 1;
        }
        public bool insert_unit(String id, String name)
        {
            connectdb();
            sql = "insert into Unit values (@id,@name)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Update_unit(String name, String id)
        {
            connectdb();
            sql = "Update Unit set UnitName =@name where UnitID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool delete_unit(String id)
        {
            connectdb();
            sql = "delete from Unit where UnitID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public DataTable search(String search)
        {
            connectdb();
            sql = "Select *from Unit where UnitID Like '%'+@id+'%' Or UnitName Like '%'+@name+'%'";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", search);
            cmd.Parameters.AddWithValue("@name", search);
            DataTable dg = new DataTable();
            da.Fill(dg);
            return dg;
        }
        public DataTable get_unit()
        {
            connectdb();
            sql = "Select *from Unit";
            cmd.CommandText = sql;
            DataTable dg = new DataTable();
            da.Fill(dg);
            return dg;
        }
    }

}
