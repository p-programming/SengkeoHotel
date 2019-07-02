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
    public partial class FormCheckOut : Form
    {
        public FormCheckOut()
        {
            InitializeComponent();
        }
        ClassConnection SQL = new ClassConnection();
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


        private void FormCheckOut_Load(object sender, EventArgs e)
        {

        }
        public void ShowDatacb()
        {
            SQL.sb = new StringBuilder();
            SQL.sb.Remove(0, SQL.sb.Length);
            SQL.sb.Append("SELECT * from RoomType;");

            SQL.str = SQL.sb.ToString();
            SQL.ShowDataAll(SQL.str);
            if (SQL.dr.HasRows)
            {
                SQL.dt = new DataTable();
                SQL.dt.Load(SQL.dr);
                cmbRate.BeginUpdate();
                cmbRate.DisplayMember = "CurrencyName";
                cmbRate.ValueMember = "CurrencyID";
                cmbRate.DataSource = SQL.dt;
                cmbRate.EndUpdate();
                txtTotalRate.Text = "RateAmount";
            }
            
            SQL.dr.Close();

        }
        public void UpdateBooking()
        {
            SQL.str = "Update Booking set BookingStatus='3' where BookingID='" + txtBookingID.Text + "'";
    SQL.RunManger(SQL.str);

        }
        public void UpdateRoom()
        {
            SQL.str = "Update Room set RoomStatus='3' where RoomID='" + txtRoomID.Text + "'";
            SQL.RunManger(SQL.str);

        }

        public void ShowBooking()
        {
            SQL.str = "Select * from ViewRoomCheckOut where CustomerID='" + txtCustomerID.Text + "' and  BookingID='" + txtBookingID.Text + "' and RoomID ='" + txtRoomID.Text + "'";
            SQL.RunQuery(SQL.str);
            DGVBooking.DataSource = SQL.ds.Tables[0];
            DGVBooking.Refresh();
            if (DGVBooking.RowCount > 0)
            {

                SumData1();
            }
        }

        public void ShowSell()
        {
            SQL.str = "Select * from ViewSellCheckOut where CustomerID='" + txtCustomerID.Text + "'and BookingID='" + txtBookingID.Text + "' and RoomID ='" + txtRoomID.Text + "'";
            SQL.RunQuery(SQL.str);
            DGVSell.DataSource = SQL.ds.Tables[0];
            DGVSell.Refresh();
            if (DGVBooking.RowCount > 0)
            {
                SumData2();
            }
        }
        public void SumData2()
        {
            int i;
            double TotalAmount = 0;

            if (DGVSell.Rows.Count > 0)
            {

                for (i = 0; i <= DGVSell.Rows.Count - 1; i++)
                {

                    TotalAmount += Convert.ToDouble(DGVSell.Rows[i].Cells[3].Value.ToString());

                }

                txtSellAmount.Text = TotalAmount.ToString("#,###");

            }
        }
        public void SumData1()
        {
            int i;
            double TotalAmount = 0;

            if (DGVBooking.Rows.Count > 0)
            {

                for (i = 0; i <= DGVBooking.Rows.Count - 1; i++)
                {

                    TotalAmount += Convert.ToDouble(DGVBooking.Rows[i].Cells[5].Value.ToString());

                }

                txtRoomAmount.Text = TotalAmount.ToString("#,###");

            }

        }

        private void txtBookingID_Click(object sender, EventArgs e)
        {
            ShowBooking();
            ShowSell();

        }

        private void txtRoomAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtRoomAmount.Text != "" && txtSellAmount.Text != "")
            {

                txtTotalAmount.Text = (double.Parse(txtRoomAmount.Text) + double.Parse(txtSellAmount.Text)).ToString("#,###");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBookingID.Text == "" & txtRoomID.Text == "" & txtCustomerID.Text == "" & txtTotalAmount.Text == "")
            {

                MessageBox.Show("");
                return;
            }

            UpdateBooking();
            UpdateRoom();
        }

        private void btn_CloseCheck_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}