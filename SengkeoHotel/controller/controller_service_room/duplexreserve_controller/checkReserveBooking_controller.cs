using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SengkeoHotel.dbconnection;
namespace SengkeoHotel.controller.controller_service_room.duplexreserve_controller
{
    class checkReserveBooking_controller : dbConnect
    {
        public DataTable GetCheckRoomByStatus(String status) {
            connectdb();
            sql = "";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("",status);
            DataTable getch = new DataTable();
            da.Fill(getch);
            return getch;
        }
    }
}
