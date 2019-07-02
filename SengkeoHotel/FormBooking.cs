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
    public partial class FormBooking : Form
    {
        public FormBooking()
        {
            InitializeComponent();
        }
        //ClassConnection SQL = new ClassConnection();
        //        DateTime BookingDate = DateTime.Now;
        private void FormBooking_Load(object sender, EventArgs e)
        {
            //LVshow();
            //ShowDatacb();
            //ShowCustomer();
            //SelectBooking();
        }
        public void ShowDatacb()
        {
            //SQL.sb = new StringBuilder();
            //SQL.sb.Remove(0, SQL.sb.Length);
            //SQL.sb.Append("SELECT * from RoomType;");

            //SQL.str = SQL.sb.ToString();
            //SQL.ShowDataAll(SQL.str);
            //if (SQL.dr.HasRows)
            //{
            //    SQL.dt = new DataTable();
            //    SQL.dt.Load(SQL.dr);
            //    cmbRoomType.BeginUpdate();
            //    cmbRoomType.DisplayMember = "RoomTypeName";
            //    cmbRoomType.ValueMember = "RoomTypeID";
            //    cmbRoomType.DataSource = SQL.dt;
            //    cmbRoomType.EndUpdate();

            //}
            //SQL.dr.Close();

        }
        public void ShowRoom()
        {
            //SQL.str = "Select * from ViewRoomBooking where RoomStatus='0' and RoomTypeID='" + cmbRoomType.SelectedValue + "'";
            //SQL.RunQuery(SQL.str);
            //DGVRoom.DataSource = SQL.ds.Tables[0];
            //DGVRoom.Refresh();

        }
        public void ShowCustomer()
        {
            //SQL.str = "Select * from Customer";
            //SQL.RunQuery(SQL.str);
            //DGVCustomer.DataSource = SQL.ds.Tables[0];
            //DGVCustomer.Refresh();
        }
        public void SelectBooking()
        {
            //SQL.str = "select MAX(BookingID)+1 AS BookingID from Booking";
            //SQL.RunQuery(SQL.str);
            //if (SQL.ds.Tables[0].Rows.Count  > 0)
            //{
            //    lblBookingID.Text = SQL.ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //}
        }
        //public void InserBooking()
        //{
        //    SQL.str = "Insert into Booking values ('"+ lblBookingID.Text+ "','"+ dtpStart.Value.ToString("yyyy/MM/dd") +"','0','" + BookingDate.ToString("yyyy/MM/dd") + "','"+ dtpStart.Value.AddDays(+Convert.ToInt16(txtQyDay.Text)) +"','1','1')";
        //    SQL.RunManger(SQL.str);
            
        //}
        public void InserBookingDetail()
        {
            //int i = 0;
            //for (i = 0; i <= LV.Items.Count -1; i++)
            //{
            //SQL.str = "Insert into BookingDetail values ('" + LV.Items[i].SubItems[0].Text  +
            //    "','" + LV.Items[i].SubItems[1].Text +
            //    "','" + LV.Items[i].SubItems[2].Text +
            //    "','" + LV.Items[i].SubItems[3].Text +
            //    "','" + lblBookingID.Text + 
            //    "')";
            //SQL.RunManger(SQL.str);

            //}
           


        }
        //public void UpdateRoomAdd()
        //{
        //    SQL.str = "Update Room set RoomStatus='1' where RoomID ='" + lblRoomID.Text + "'";
        //    SQL.RunManger(SQL.str);

        //}        
        //public void LVshow()
        //{
        //    LV.View = View.Details;
        //    LV.LabelEdit = true;
        //    LV.AllowColumnReorder = true;
        //    LV.FullRowSelect =true;
        //    LV.Sorting =SortOrder.Ascending;
        //    LV.Columns.Add("RoomID",100,HorizontalAlignment.Left);
        //    LV.Columns.Add("RoomNO", 100, HorizontalAlignment.Left);
        //    LV.Columns.Add("RoomPrice", 100, HorizontalAlignment.Left);
        //    LV.Columns.Add("DayQty", 100, HorizontalAlignment.Left);
        //    LV.Columns.Add("Amount", 100, HorizontalAlignment.Left);

        //}
        public void AddData()  {
        //ListViewItem lvi = new ListViewItem();

        //   lblAmount.Text=(double.Parse(lblRoomPrice.Text)*double.Parse(txtQyDay.Text)).ToString("#,##");
        //   lblTotal.Text =(double.Parse(lblTotal.Text) +double.Parse(lblAmount.Text)).ToString("#,###");

        // string[] row ={lblRoomID.Text,lblRoomNO.Text,lblRoomPrice.Text,txtQyDay.Text,lblAmount.Text};
        //    ListViewItem item = new ListViewItem(row);

        //    LV.Items.Add(item);
        }

        //public void UpdateRoomCancel()
        //{
        //    SQL.str = "Update Room set RoomStatus='0' where RoomID ='" + lblRoomID.Text + "'";
        //    SQL.RunManger(SQL.str);
        //}

        private void DGVRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    return;
            //}
            //int i = 0;
            //for (i = 0; i <= DGVRoom.SelectedRows.Count - 1; i++)
            //{
            //    lblRoomID.Text = DGVRoom.Rows[e.RowIndex].Cells["RoomID"].Value.ToString();
            //    lblRoomNO.Text = DGVRoom.Rows[e.RowIndex].Cells["RoomNO"].Value.ToString();
            //    lblRoomPrice.Text = DGVRoom.Rows[e.RowIndex].Cells["RoomPrice"].Value.ToString();
            //}


        }

        private void DGVCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    return;
            //}
            //int i = 0;
            //for (i = 0; i <= DGVCustomer.SelectedRows.Count - 1; i++)
            //{
            //    lblCustomerID.Text = DGVCustomer.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();
            //    lblCustomerName.Text = DGVCustomer.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
            //    lblCustomerSurename.Text = DGVCustomer.Rows[e.RowIndex].Cells["CustomerSurename"].Value.ToString();

            //}


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                //InserBooking();
                //InserBookingDetail();
                //btnSave.Enabled = false;
                //LV.Clear();
    }
     
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (txtQyDay.Text == "")
            //{
            //    MessageBox.Show("");
            //    txtQyDay.Focus();
            //    return;
            //}

            //AddData();
            //UpdateRoomAdd();
            //ShowRoom();
            //btnSave.Enabled = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
    //        if (lblRoomID.Text == "")
    //        {
    //            MessageBox.Show("");
    //            return;
    //        }

    //if(MessageBox.Show("","Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK){
    //    lblTotal.Text = (double.Parse(lblTotal.Text) - double.Parse(lblAmount.Text)).ToString("#,###") ;
    //UpdateRoomCancel();
    //ShowRoom();
    //LV.Items.RemoveAt(0);

}
        
        }

        //private void LV_MouseClick(object sender, MouseEventArgs e)
        //{
        //        //lblRoomID.Text = LV.SelectedItems[0].SubItems[0].Text;
        //        //lblRoomNO.Text = LV.SelectedItems[0].SubItems[1].Text;
        //        //lblRoomPrice.Text = LV.SelectedItems[0].SubItems[2].Text;
        //        //lblAmount.Text = LV.SelectedItems[0].SubItems[4].Text;
        //}

        //private void label18_Click(object sender, EventArgs e)
        //{

        //}

        //private void txtQyDay_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbRoomType_ChangeUICues(object sender, UICuesEventArgs e)
        //{

        //}

        //private void cmbRoomType_Click_1(object sender, EventArgs e)
        //{
        //    //ShowRoom();
        //}

        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}
    }

