using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SengkeoHotel
{
    public partial class FormRoomCheck : Form
    {
        public FormRoomCheck()
        {
            InitializeComponent();
        }

 ClassConnection SQL = new ClassConnection();
 public static string BookingID;
 public static string RoomID;

 public static string CustomerID;
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void FormRoomCheck_Load(object sender, EventArgs e)
        {
        }
        public void ShowRoom()
        {
            string RoomStuts="";
            if (cmbStuts.SelectedIndex == 0)
            {
                RoomStuts = "0";

            }
            else if (cmbStuts.SelectedIndex == 1)
            {
                RoomStuts = "1";


            }
            else if (cmbStuts.SelectedIndex == 2)
            {

                RoomStuts = "2";

            }
            else if (cmbStuts.SelectedIndex == 3)
            {

                RoomStuts = "3";

            }
            SQL.str = "Select * from ViewCheckRoom where  RoomStatus='" + RoomStuts + "'";
            SQL.RunQuery(SQL.str);
            DGV.DataSource = SQL.ds.Tables[0];
            DGV.Refresh();

        }

        private void txt_RoomNo_TextChanged(object sender, EventArgs e)
        {

        }


        private void cmbStuts_Click(object sender, EventArgs e)
        {
            //ShowRoom();
        }

        private void btn_ImportProduct_Click(object sender, EventArgs e)
        {
            //FormRoom a = new FormRoom();
            ////a.Show();
            ////a.SendBookingID = BookingID;
            ////a.SendCustomerID = CustomerID;
            ////a.SendRoomID = RoomID;

        }
        private void btn_ChectOut_Click(object sender, EventArgs e)
        {
            FormCheckIn a = new FormCheckIn();
            a.Show();
            a.SendBookingID = BookingID;
            a.SendCustomerID = CustomerID;
            a.SendRoomID = RoomID;
        }
        private void btn_PrintCheck_Click(object sender, EventArgs e)
        {
            //FormMovesRoom a = new FormMovesRoom();
            //a.Show();
            //a.SendBookingID = BookingID;
            //a.SendCustomerID = CustomerID;
            //a.SendRoomID = RoomID;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            FormCheckOut a = new FormCheckOut();
            a.Show();
            a.SendBookingID = BookingID;
            a.SendCustomerID = CustomerID;
            a.SendRoomID = RoomID;
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            int i = 0;
            for (i = 0; i <= DGV.SelectedRows.Count - 1; i++)
            {
                BookingID = DGV.Rows[e.RowIndex].Cells["BookingID"].Value.ToString();
                RoomID = DGV.Rows[e.RowIndex].Cells["RoomID"].Value.ToString();
                CustomerID = DGV.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

            }
        }
        private void cmbStuts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
