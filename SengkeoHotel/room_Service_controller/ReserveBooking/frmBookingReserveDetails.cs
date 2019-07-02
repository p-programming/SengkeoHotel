using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.controller.controller_service_room.duplexreserve_controller;
using SengkeoHotel.controller;
using SengkeoHotel.controller.Login_Controller;
namespace SengkeoHotel.room_Service_controller.ReserveBooking
{
    public partial class frmBookingReserveDetails : Form
    {
        public static string cusname, custmeraddress, customertel, cusemail = null;
        ReservBookingController cntrl_booking = new ReservBookingController();
        AnymessageBox ms = new AnymessageBox();
        ChangeColumns_Controller cnl = new ChangeColumns_Controller();
        String St1 = "ຈອງ", St2 ="ວ່າງ", St3="ບໍລິການ",St4 = "ອະນາໄມ";

        public frmBookingReserveDetails()
        {
            InitializeComponent();
        }

        private void frmBookingReserveDetails_Load(object sender, EventArgs e)
        {
            //txtEmp.Text = LoginController.employeelogined.Rows[0]["EmployeeName"].ToString();
            //txtUserAuther.Text = LoginController.userlogined.Rows[0]["UserAuther"].ToString();
            cntrl_booking.CreateReserveBookingAutoID(txtBillno);
            cbRoomType.DataSource = cntrl_booking.Get_RoomType();
            cbRoomType.DisplayMember = "RoomTypeName";
            cbRoomType.ValueMember = "RoomTypeID";
            cbRoomType.Text = "....ເລືອກປະເພດຫ້ອງ...";
            dgvRoom.Visible = false;

            cbCus.DataSource = cntrl_booking.Get_Customer();
            cbCus.DisplayMember = "CustomerName";
            cbCus.ValueMember = "CustomerID";
            cbCus.Text = "....ເລືອກສະມາຊິກລູກຄ້າ...";
            txtcusemail.Text = "";
            txtcusaddr.Text = "";
            txtcustel.Text = "";
        }

        private void bookingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void cbRoomType_TextChanged(object sender, EventArgs e)
        {
            DataTable getcurrent = new DataTable();
            getcurrent = cntrl_booking.Set_RoomType(cbRoomType.Text);
            dgvRoom.DataSource = getcurrent;
            dgvRoom.Visible = true;
            String[] h = { "ລະຫັດຫ້ອງ", "ເບີຫ້ອງ", "ປະເພດຫ້ອງ", "ລາຄາຫ້ອງ" };
            cnl.change_columnsname(dgvRoom, h);
        }

        private void cbCus_TextChanged(object sender, EventArgs e)
        {
            DataTable get = new DataTable();
            get = cntrl_booking.Set_Customer(cbCus.Text);
            if (get.Rows.Count > 0)
            {
                txtcusaddr.Text = get.Rows[0].ItemArray[1].ToString();
                txtcustel.Text = get.Rows[0].ItemArray[2].ToString();
                txtcusemail.Text = get.Rows[0].ItemArray[3].ToString();
                cbCus.Enabled = false;
               
            }
            else
            {
                txtcusemail.Text = "";
                txtcusaddr.Text = "";
                txtcustel.Text = "";
                cbCus.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbCus.Enabled = true;
            txtcusaddr.Text = "";
            txtcusemail.Text = "";
            txtcustel.Text = "";
            cbCus.Text = "....ເລືອກສະມາຊິກລູກຄ້າ...";
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            cbCus.Enabled = true;
            txtcusaddr.Text = "";
            txtcusemail.Text = "";
            txtcustel.Text = "";
            cbCus.Text = "....ເລືອກສະມາຊິກລູກຄ້າ...";
            dgvList.Rows.Clear();
            cbRoomType.Text = "....ເລືອກປະເພດຫ້ອງ...";
            dgvRoom.Visible = false;
            dgvRoom.DataSource = new DataTable();
            txtTotalCount.Text = "0";
            txtTotalPrice.Text = "0.000";
        }

        private void txtSearchRoom_TextChanged(object sender, EventArgs e)
        {
            dgvRoom.DataSource = cntrl_booking.Get_SelectedSearchRoom(txtSearchRoom.Text);
            dgvRoom.Visible = true;
            String[] h = { "ລະຫັດຫ້ອງ", "ເບີຫ້ອງ", "ປະເພດຫ້ອງ", "ລາຄາຫ້ອງ" };
            cnl.change_columnsname(dgvRoom, h);
        }

        private void dgvRoom_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            try
            {
                int row = e.RowIndex;
                    String roomid = dgvRoom.Rows[row].Cells[0].Value.ToString();
                    String No = dgvRoom.Rows[row].Cells[1].Value.ToString();
                    String rtname = dgvRoom.Rows[row].Cells[2].Value.ToString();
                    double price = Convert.ToDouble( dgvRoom.Rows[row].Cells[3].Value.ToString());
                    for (int r = 0; r < dgvList.Rows.Count; r++)
                    {
                        String listroomid = dgvList.Rows[r].Cells[0].Value.ToString();
                        if (listroomid == roomid)
                        {
                        //dgvRoom.Rows[row].Cells[2].Value = int.Parse(dgvRoom.Rows[row].Cells[2].Value.ToString()) + 1;
                            MessageBox.Show("ຫ້ອງຖືກເພີ່ມໄປແລ້ວ ກະລຸນາເລືອກຫ້ອງໃໝ່");

                            return;
                        }
                    }
                    dgvList.Rows.Add(roomid, No, rtname, price, "1", "", "");
                    txtTotalCount.Text = dgvList.Rows.Count.ToString();
                double Price = 0, Result = 0;
                foreach (DataGridViewRow r in dgvList.Rows)
                {
                    for (int n = r.Index; n < dgvList.Rows.Count; n++)
                    {
                        dgvList.Rows[n].Cells[5].Value = (double.Parse(dgvList.Rows[n].Cells[3].Value.ToString()) * double.Parse(dgvList.Rows[n].Cells[4].Value.ToString()));
                    }
                    //double Price = 0, Result = 0;
                    //foreach (DataGridViewRow cr in dgvList.Rows)
                    //{
                        Price = Convert.ToDouble(r.Cells[5].Value);
                        Result = Result + Price;
                        txtTotalPrice.Text = Result.ToString("#,###");
                    //}
                }
            }
            catch { }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (cbRoomType.Text == "....ເລືອກປະເພດຫ້ອງ...") {
                MessageBox.Show("ເລືອກປະເພດຫ້ອງ");
                cbRoomType.Focus();
                return;
            }
            else if (cbCus.Text == "....ເລືອກສະມາຊິກລູກຄ້າ...")
            {
                MessageBox.Show("ເລືອກສະມາຊິກລູກຄ້າ");
                cbCus.Focus();
                return;
            }
            if (dgvList.Rows.Count < 1)
            {
                MessageBox.Show("ຍັງບໍ່ມີຂໍ້ມູນລາຍລະອຽດການຈອງຫ້ອງ");
                return;
            }
                cntrl_booking.Inserted_Booking(txtBillno.Text.ToUpper().Trim(),dtpDate.Value.ToString("yyyy/MM/dd"),St1.ToString(),LoginController.userlogined.Rows[0]["EmpID"].ToString(),cbCus.SelectedValue.ToString());
                for (int insert = 0; insert < dgvList.Rows.Count; insert++)
                {
                    String listoomid = dgvList.Rows[insert].Cells[0].Value.ToString();
                    Decimal Price = Convert.ToDecimal(dgvList.Rows[insert].Cells[3].Value.ToString());
                    int AmountDay = Convert.ToInt32(dgvList.Rows[insert].Cells[4].Value.ToString());
                    double TotalPrice = Convert.ToDouble(dgvList.Rows[insert].Cells[5].Value.ToString());
                    cntrl_booking.Inserted_BookingDetail(listoomid.ToString(),Price.ToString().Trim(),AmountDay.ToString(),TotalPrice.ToString().Trim(),txtBillno.Text.ToUpper().Trim());

                }
                ms.INSERT_Or_SAVE_Successfull();
                cntrl_booking.CreateReserveBookingAutoID(txtBillno);
            cbRoomType.Text = "....ເລືອກປະເພດຫ້ອງ...";
            cbCus.Text = "....ເລືອກສະມາຊິກລູກຄ້າ...";
            dgvRoom.Visible = false;
            dgvRoom.DataSource = new DataTable();
            dgvList.Rows.Clear();
            txtTotalCount.Text = "0";
            txtTotalPrice.Text = "0.000";
            cbCus.Enabled = true;
            txtcusaddr.Text = "";
            txtcusemail.Text = "";
            txtcustel.Text = "";
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                if (e.ColumnIndex == 4)
                {
                    dgvList.Rows[row].Cells[5].Value = double.Parse(dgvList.Rows[row].Cells[3].Value.ToString()) * double.Parse(dgvList.Rows[row].Cells[4].Value.ToString());
                    double Price = 0, Result = 0;
                    foreach (DataGridViewRow cr in dgvList.Rows)
                    {
                        Price = Convert.ToDouble(cr.Cells[5].Value);
                        Result = Result + Price;
                        txtTotalPrice.Text = Result.ToString("#,###");
                    }
                }
            }
            catch { }
        }

        private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    dgvList.Rows.Remove(dgvList.CurrentRow);
                    txtTotalCount.Text = dgvList.Rows.Count.ToString();
                    double sumprice = 0, Result = 0;
                    foreach (DataGridViewRow r in dgvList.Rows)
                    {
                        sumprice = Convert.ToDouble(r.Cells[5].Value);
                        Result = Result + sumprice;
                        txtTotalPrice.Text = Result.ToString("#,###");
                    }
                   if (dgvList.Rows.Count < 1)
                    {
                        txtTotalPrice.Text = "0.000";
                    }
                }
            }
            catch { }
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            SengkeoHotel.room_Service_controller.ReserveBooking.frmCustomerReservBooking f = new frmCustomerReservBooking();
            
            f.ShowDialog();
            cbCus.Text = cusname;
            txtcusaddr.Text = custmeraddress;
            txtcustel.Text = customertel;
            txtcusemail.Text = cusemail;
            cbCus.DataSource = cntrl_booking.Get_Customer();
        }
    }
}
