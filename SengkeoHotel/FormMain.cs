using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using SengkeoHotel.controller.Login_Controller;

namespace SengkeoHotel
{
    
    public partial class FormMain : Form
    {
        LoginController cntrl = new LoginController();
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void ລກຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer fc = new Customer();
            fc.StartPosition = FormStartPosition.CenterScreen;
            fc.ShowDialog();
        }

        private void ຂມນຫອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoom frs = new FormRoom();
            frs.StartPosition = FormStartPosition.CenterScreen;
            frs.ShowDialog();
            
        }

        private void ຂມນປະເພດຫອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoomType ft = new FormRoomType();
            ft.StartPosition = FormStartPosition.CenterScreen;
            ft.ShowDialog();
            
        }

        private void ຂມນສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProducts fp = new FormProducts();
            fp.StartPosition = FormStartPosition.CenterScreen;
            fp.ShowDialog();
            
        }

        private void ຂມນປະເພດສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductType fpt = new FormProductType();
            fpt.StartPosition = FormStartPosition.CenterScreen;
            fpt.ShowDialog();
            
        }

        private void ຂມນພະນກງານToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployee fe = new FormEmployee();
            fe.StartPosition = FormStartPosition.CenterScreen;
            fe.ShowDialog();
            
        }

        private void ຂມນຕາແໜງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPosition fpt = new FormPosition();
            fpt.StartPosition = FormStartPosition.CenterScreen;
            fpt.ShowDialog();
            
        }

        private void ຂມນລາຍຈາຍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDepartment fpf = new FormDepartment();
            fpf.StartPosition = FormStartPosition.CenterScreen;
            fpf.ShowDialog();
            
        }

        private void ຂມນຜໃຊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormUser fus = new FormUser();
            //fus.StartPosition = FormStartPosition.CenterScreen;
            //fus.ShowDialog();
            SengkeoHotel.cntrol_Users.frmUsers f = new cntrol_Users.frmUsers();
            f.MdiParent = this;
            f.Text = "Users" + childFormNumber++;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void ຂມນອດຕາແລກປຽນToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCurrency fc = new FormCurrency();
            fc.StartPosition = FormStartPosition.CenterScreen;
            fc.Text = "Form Currency" + childFormNumber++;
            fc.MdiParent = this;
            fc.Show();
            //fc.WindowState = FormWindowState.Maximized;
        }

        private void ຈອງຫອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ຍາຍຫອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMovesRoom fm = new FormMovesRoom();
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.ShowDialog();
            
        }

        private void ແຈງເຂາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckIn fci = new FormCheckIn();
            fci.StartPosition = FormStartPosition.CenterScreen;
            fci.ShowDialog();
            
        }

        private void ແຈງອອກToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckOut fco = new FormCheckOut();
            fco.StartPosition = FormStartPosition.CenterScreen;
            fco.ShowDialog();
           
        }

        private void ນາເຂາສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormProductImport fpi = new FormProductImport();
            //fpi.StartPosition = FormStartPosition.CenterScreen;
            //fpi.ShowDialog();
            
        }

        private void ຂາຍສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormProductSell fps = new FormProductSell();
            //fps.StartPosition = FormStartPosition.CenterScreen;
            //fps.ShowDialog();
            
        }

        private void ຄດໄລເງນເດອນToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSalaryPay fsr = new FormSalaryPay();
            fsr.StartPosition = FormStartPosition.CenterScreen;
            fsr.ShowDialog();
           
        }

        private void ເບກຈາຍເງນເດອນToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormSalaryPay fed = new FormSalaryPay();
            //fed.StartPosition = FormStartPosition.CenterParent;
            //fed.ShowDialog();
            
        }

        private void ຈອງຫອງToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FormBooking fs = new FormBooking();
            //fs.StartPosition = FormStartPosition.CenterScreen;
            //fs.ShowDialog();
            SengkeoHotel.room_Service_controller.ReserveBooking.frmBookingReserveDetails f = new room_Service_controller.ReserveBooking.frmBookingReserveDetails();
            f.MdiParent = this;
            f.Text = ""+ childFormNumber ++;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void ຈອງພດຕະຄານToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SengkeoHotel.room_Service_controller.DuplexReserve.frmDuplexReserveDetail f = new room_Service_controller.DuplexReserve.frmDuplexReserveDetail();
            f.MdiParent = this;
            f.Text = ""+ childFormNumber++;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void ບນທກໂມງເຮດວຽກToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWorkInWorkOut fwi = new FormWorkInWorkOut();
            fwi.StartPosition = FormStartPosition.CenterScreen;
            fwi.ShowDialog();
           
        }

        private void ອອກຈາກໂປແກມToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string UserName = "";
        string UserID = "";

        public object MDIGracular { get; private set; }
        public int childFormNumber { get; private set; }
        public int chlid { get; private set; }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            showuser.Text = "ຊື່ຜູ້ໃຊ້ລະບົບ: " +FormLogIn.UserName;

            toolStripStatusLabel2.Text= "| ສິດທິຜູ້ໃຊ້: " + FormLogIn.status;
           
            //Regex rx = new Regex(@"\s");
            //FormLogIn.UserAuthor = rx.Replace(FormLogIn.UserAuthor, "");
            //if (FormLogIn.UserAuthor == "ຜູ້ໃຊ້ທົ່ວໄປ")
            //{
            //    Service();
            //}
            //else if (FormLogIn.UserAuthor == "ຜູ້ດູແລລະບົບ")
            //{
            //    Admin();
            //}
            this.Location = new Point(4, 370);

            try {
                DataTable current = new DataTable();
                current = cntrl.check_UserCount_InSystem();
                if (current.Rows.Count > 0)
                {
                    mnlCreateAcount.Visible = false;
                    mnlLogin.Visible = true;
                }
                else
                {
                    mnlCreateAcount.Visible = true;
                    mnlLogin.Visible = false;
                }
            }
            catch { }
        }
        private void Admin()
        {
            mnl_Customer.Enabled = true;
            mnl_ProductType.Enabled = true;
            mnl_Product.Enabled = true;
            mnl_Exchange.Enabled = true;
            mnl_Playment.Enabled = true;
            mnl_Roomtype.Enabled = true;
            mnl_room.Enabled = true;
            mnl_Employee.Enabled = true;
            mnl_Position.Enabled = true;
            mnl_Department.Enabled = true;
            mnl_Users.Enabled = true;
        }
        private void Service()
        {
            mnl_Customer.Enabled = true;
            mnl_ProductType.Enabled = true;
            mnl_Product.Enabled = true;
            mnl_Exchange.Enabled = true;
            mnl_Playment.Enabled = true;
            mnl_Roomtype.Enabled = false;
            mnl_room.Enabled = false;
            mnl_Employee.Enabled = false;
            mnl_Position.Enabled = false;
            mnl_Department.Enabled = false;
            mnl_Users.Enabled = false;
        }

        private void ຄນຫາຂມນພະນກງານToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchEmployee fse = new FormSearchEmployee();
            fse.StartPosition = FormStartPosition.CenterScreen;
            fse.ShowDialog();
        }

        private void ຄນຫາຂມນຫອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormSearchRoom ss = new FormSearchRoom();
            //ss.StartPosition = FormStartPosition.CenterScreen;
            //ss.ShowDialog();
        }

        private void ຄນຫາຂມນລກຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchCustomer dd = new FormSearchCustomer();
            dd.StartPosition = FormStartPosition.CenterScreen;
            dd.ShowDialog();
        }

        private void ຄນຫາຂມນສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormSearchProduct ff = new FormSearchProduct();
            //ff.StartPosition = FormStartPosition.CenterScreen;
            //ff.ShowDialog();
        }

        private void ຄນຫາຂມນການຈອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormSearchReserve gg = new FormSearchReserve();
            //gg.StartPosition = FormStartPosition.CenterScreen;
            //gg.ShowDialog();
        }

        private void ອອກບດພະນກງານToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEmployeeCard hh = new FormEmployeeCard();
            hh.StartPosition = FormStartPosition.CenterScreen;
            hh.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //lbtime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void ຈດການຂມນລາຍຈາຍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExpend II = new FormExpend();
           II.StartPosition = FormStartPosition.CenterScreen;
           II.ShowDialog();

        }

        private void ກວດສອບToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormRoomCheck JJ = new FormRoomCheck();
            JJ.MdiParent = this;
            JJ.Text = ""+ childFormNumber ++;
            JJ.Show();
            JJ.WindowState = FormWindowState.Maximized;
        }

        private void ກວດສອບToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormProductCheck NN = new FormProductCheck();
            //NN.StartPosition = FormStartPosition.CenterScreen;
            NN.MdiParent = this;
            NN.Text = "ຟອມກວດສອບສິນຄ້າ" + chlid++;
            NN.Show();
            NN.WindowState = FormWindowState.Maximized;
        }

        private void ສງຊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SengkeoHotel.cntrl_order.Form_OrderProducts f = new cntrl_order.Form_OrderProducts();
            f.MdiParent = this;
            f.Text = "" + childFormNumber++;
            f.Show();

            //FormOrder ll = new FormOrder();
            //ll.StartPosition = FormStartPosition.CenterScreen;
            //ll.ShowDialog();
        }

        private void ນາເຂາສນຄາToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            SengkeoHotel.cntrl_import.Frm_ImpProduct f = new cntrl_import.Frm_ImpProduct();
            f.MdiParent = this;
            f.Text = "ຟອມນຳສິນຄ້າເຂົ້າສັງ"+childFormNumber++;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void ຂາຍສນຄາToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FormSell p = new FormSell();
            //p.StartPosition = FormStartPosition.CenterScreen;
            //p.ShowDialog();
            SengkeoHotel.contrl_Sell.Form_SellProducts f = new contrl_Sell.Form_SellProducts();
            f.ShowDialog();
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
           lbTime.Text = "| ວັນທີ: " +  DateTime.Now.ToString("hh:mm:ss");
        }

        private void mnlCreateAcount_Click(object sender, EventArgs e)
        {
            SengkeoHotel.cntrol_Users.frmCreateAccount fuser = new cntrol_Users.frmCreateAccount("");
            fuser.ShowDialog();
            mnlCreateAcount.Visible = false;
            mnlLogin.Visible = true;
        }

        private void mnlLogin_Click(object sender, EventArgs e)
        {
            FormLogIn f = new FormLogIn();
            f.ShowDialog();
            if (f.UserAuther.Trim() == "")
            {
                return;
            }
            LoginController.employeelogined = new LoginController().getEmployeename(LoginController.userlogined.Rows[0]["EmpID"].ToString());
            txtUsername.Text = LoginController.employeelogined.Rows[0]["EmployeeName"].ToString();
            txtUserAuther.Text = LoginController.userlogined.Rows[0]["UserAuther"].ToString();
            if (f.UserAuther == "ຜູ້ຈັດການ")
            {
                mnlLogin.Visible = false;
            }
            if (f.UserAuther == "ພະນັກງານບັນຊີ")
            {
                mnlLogin.Visible = false;
            }
            if (f.UserAuther == "ພະນັກງານຕ້ອນຮັບ")
            {
                mnlLogin.Visible = false;
            }
        }

        private void ຂມນຫວໜວຍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnit f = new frmUnit();
            f.ShowDialog();
        }
    }
}
