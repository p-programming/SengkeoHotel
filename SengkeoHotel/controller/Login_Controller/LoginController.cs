using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SengkeoHotel.dbconnection;
namespace SengkeoHotel.controller.Login_Controller
{
    class LoginController : dbConnect
    {
        public static DataTable userlogined = new DataTable();
        public static DataTable employeelogined = new DataTable();


        public DataTable getEmployeename(String id)
        {
            connectdb();
            sql = "Select *from Employee where EmployeeID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            DataTable get_emp = new DataTable();
            da.Fill(get_emp);
            return get_emp;
        }
        public DataTable getUsersAuther(String id)
        {
            connectdb();
            sql = "Select *from Users where Empid =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            DataTable get_emp = new DataTable();
            da.Fill(get_emp);
            return get_emp;
        }

        public DataTable check_emp() {
            connectdb();
            sql= "Select EmpID,EmployeeName,PositionName from useremp";
            cmd.CommandText = sql;
            DataTable gt = new DataTable();
            da.Fill(gt);
            return gt;
        }
        public DataTable get_emp(String id)
        {
            connectdb();
            sql = "Select *from useremp_login where EmpID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            DataTable gt = new DataTable();
            da.Fill(gt);
            return gt;
        }
        public DataTable Check_CurrentUsers(String id)
        {
            connectdb();
            sql = "Select *from Users where EmpID =@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            DataTable gt = new DataTable();
            da.Fill(gt);
            return gt;
        }
        public bool insert_users(String id, String usernane ,String pass ,String grant) {
            connectdb();
            sql = "Insert into Users values (@id,@name,@pas,@gr)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name", usernane);
            cmd.Parameters.AddWithValue("@pas", pass);
            cmd.Parameters.AddWithValue("@gr", grant);
            cmd.ExecuteNonQuery();
            return false;
        }
        public bool Update_users( String usernane, String pass, String id)
        {
            connectdb();
            sql = "Update Users set Username = @u, UserPassword=@pas where EmpID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", usernane);
            cmd.Parameters.AddWithValue("@pas", pass);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            return false;
        }
        public double create_id()
        {
            connectdb();
            sql = "Select max(EmpID) from Users";
            cmd.CommandText = sql;
            object id = cmd.ExecuteScalar();
            if (id.ToString() != "")
            {
                return double.Parse(id.ToString()) + 1;
            }
            return 1001;
        }
        public DataSet Login(String us,String pas)
        {
            connectdb();
            sql = "Select Username,UserPassword from Users Where Username =@name and UserPassword =@pas";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name",us);
            cmd.Parameters.AddWithValue("@pas",pas);
            DataSet login = new DataSet();
            da.Fill(login);
            return login;
        }
        public bool create_newUsers(String id, String username, String userpassowrd, String UserAuther)
        {
            connectdb();
            sql = "Insert into Users(EmpID, Username, UserPassword, UserAuther) values (@id,@us,@pas,@au)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@us",username);
            cmd.Parameters.AddWithValue("@pas",userpassowrd);
            cmd.Parameters.AddWithValue("@au",UserAuther);
            cmd.ExecuteNonQuery();
            return false;
        }
        public DataTable check_userAuther(String id)
        {
            connectdb();
            sql = "select *from Users where EmpID=@id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id",id);
            DataTable get_current = new DataTable();
            da.Fill(get_current);
            return get_current;
        }
        public DataTable check_userAutherCurrent(String id)
        {
            connectdb();
            sql = "select *from Users where Username=@id";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            DataTable get_current = new DataTable();
            da.Fill(get_current);
            return get_current;
        }
        public DataTable check_UserCount_InSystem() {
            connectdb();
            sql = "Select EmpID from Users ";
            cmd.CommandText = sql;
            DataTable current = new DataTable();
            da.Fill(current);
            return current;
        }
        public bool createUser_Emp(String id, String employeename, String position)
        {
            sql = "Insert into Employee (EmployeeID,EmployeeName,PositionID) values (@id,@name,@posit)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name", employeename);
            cmd.Parameters.AddWithValue("@posit", position);
            cmd.ExecuteNonQuery();
            return false; 
        }
        public bool Create_Position_users(String PositionID, String Positionname)
        {
            connectdb();
            sql = "Insert into Position (PositionID, PositionName) values (@id,@name)";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",PositionID);
            cmd.Parameters.AddWithValue("@name",Positionname);
            cmd.ExecuteNonQuery();
            return false;
        }
    }
}
