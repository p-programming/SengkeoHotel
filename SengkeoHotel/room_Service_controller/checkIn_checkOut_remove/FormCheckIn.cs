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
    public partial class FormCheckIn : Form
    {
        public FormCheckIn()
        {
            InitializeComponent();
        }
        ClassConnection SQL = new ClassConnection();

        private void btn_RoomNo_Click(object sender, EventArgs e)
        {
            //FormSelectRoom jj = new FormSelectRoom();
            //jj.StartPosition = FormStartPosition.CenterScreen;
            //jj.Show();
        }
        internal string SendRoomID
        {
            set
            {
                txtRoomID.Text = value;


            }
        }
        internal string SendBookingID
        {
            set
            {

                txtBookingID.Text = value;
            }

        }
        internal string SendCustomerID
        {
            set
            {

                txtCustomerID.Text = value;
            }

        }



        public void UpdateRoom()
        {
            SQL.str = "Update Room set RoomStatus='2' where RoomID='" + txtRoomID.Text + "'";
            SQL.RunManger(SQL.str);
        }
        public void UpdateBooking()
        {
            SQL.str = "Update Booking set BookingStatus='2' where BookingID='" + txtBookingID.Text + "'";
            SQL.RunManger(SQL.str);
        }


        private void txt_PriseDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCheckIn_Load(object sender, EventArgs e)
        {
            ShowBooking();
        }
        public void ShowBooking()
        {
            SQL.str = "Select * from ViewRommCheckIn where  where BookingStatus='1' and  BookingID='" + txtBookingID.Text +"'";
            SQL.RunQuery(SQL.str);
            DGV.DataSource = SQL.ds.Tables[0];
            DGV.Refresh();

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
                txtBookingID.Text = DGV.Rows[e.RowIndex].Cells["BookingID"].Value.ToString();
                txtCustomerID.Text = DGV.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();
                txtCustomerName.Text = DGV.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
                 txtTel.Text = DGV.Rows[e.RowIndex].Cells["Tel"].Value.ToString();
                txtRoomID.Text = DGV.Rows[e.RowIndex].Cells["RoomID"].Value.ToString();

            }





            }

        private void btn_PrintCheck_Click(object sender, EventArgs e)
        {
            if (txtRoomID.Text == "" && txtBookingID.Text == "" && txtCustomerID.Text == "")
            {
                MessageBox.Show("");
                return;

            }
                if (chCheckIn.Checked == true)
                {

                UpdateBooking();
                UpdateRoom();
                }

            
            ShowBooking();

            }

        private void btn_CloseCheck_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSharech_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBookingID_Click(object sender, EventArgs e)
        {
            ShowBooking();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        }

    
}
