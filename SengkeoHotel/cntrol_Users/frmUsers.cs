using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.controller.Login_Controller;
using SengkeoHotel.controller;
namespace SengkeoHotel.cntrol_Users
{
    public partial class frmUsers : Form
    {
        LoginController lg_cntrl = new LoginController();
        ChangeColumns_Controller cntrl_cl = new ChangeColumns_Controller();
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {

            refresh();
        }
        void refresh()
        {
            dataGridView1.DataSource = lg_cntrl.check_emp();
            String[] h = { "", "", "ລະຫັດພະນັກງານ", "ຊື່ພະນັກງານ", "ຕຳແໜ່ງ" };
            cntrl_cl.change_columnsname(dataGridView1, h);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SengkeoHotel.cntrol_Users.frm_UersProfile f = new frm_UersProfile();
            f.btsave.Visible = true;
            f.ShowDialog();
            refresh();

        }
    }
}
