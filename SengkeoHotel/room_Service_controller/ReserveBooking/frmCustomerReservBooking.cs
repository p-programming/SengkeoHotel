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
namespace SengkeoHotel.room_Service_controller.ReserveBooking
{
    public partial class frmCustomerReservBooking : Form
    {
        ReservBookingController cn = new ReservBookingController();
        AnymessageBox ms = new AnymessageBox();
        public frmCustomerReservBooking()
        {
            InitializeComponent();
        }
        private void frmCustomerReservBooking_Load(object sender, EventArgs e)
        {
            cn.CreateCustomerID(txtcusid);
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {

                if (txtname.Text == "") {
                    MessageBox.Show("ປ້ອນຊື່ລູກຄ້າ");
                    txtname.Focus();
                    return;
                }
                else if (txtlname.Text == "")
                {
                    MessageBox.Show("ປ້ອນນາມສະກຸນ");
                    txtlname.Focus();
                    return;
                } else if (txtaddress.Text == "") {
                    MessageBox.Show("ປ້ອນທີ່ຢູ່");
                    txtaddress.Focus();
                    return;
                }
                cn.AddNew_Customer(txtcusid.Text.Trim().ToUpper().Trim(), txtname.Text.Trim(), txtlname.Text.Trim(), txtaddress.Text.Trim(), txttel.Text.Trim(), txtemail.Text.Trim());
                ms.INSERT_Or_SAVE_Successfull();
                cn.CreateCustomerID(txtcusid);
                SengkeoHotel.room_Service_controller.ReserveBooking.frmBookingReserveDetails f = new frmBookingReserveDetails();
                frmBookingReserveDetails.cusname = txtname.Text;
                frmBookingReserveDetails.custmeraddress = txtaddress.Text;
                frmBookingReserveDetails.customertel = txttel.Text;
                frmBookingReserveDetails.cusemail = txtemail.Text;
                this.Close();
            }
            else { return; }
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txttel.Text, "[^0-9^]"))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຕົວເລກສະເພາະ");
                txttel.Text = txttel.Text.Remove(txttel.Text.Length - 1);
                return;
            }
        }
    }
}
