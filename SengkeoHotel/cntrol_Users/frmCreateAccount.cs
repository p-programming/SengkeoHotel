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
    public partial class frmCreateAccount : Form
    {
        LoginController cntrl_users = new LoginController();
        public static String UsersGrant = "ຜູ້ຈັດການ";
        AnymessageBox ms = new AnymessageBox();
        String form = "";
        public frmCreateAccount(String f)
        {
            InitializeComponent();
            form = f;
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            try {
                DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການສ້າງບັນຊີຜູ່ໃຊ້ລະບົບບໍ","System",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (txtUserID.Text == "" || txtpassword.Text == "" || txtusername.Text == "" )
                    {
                        ms.Check_DataEmpty();
                        return;
                    }
                   
                    DataTable current = new DataTable();
                    current = cntrl_users.check_userAutherCurrent(txtusername.Text);
                    if (current.Rows.Count > 0)
                    {
                        ms.Check_exitingDataIN_SYSTEM();
                        return;
                    }
                    cntrl_users.create_newUsers(txtUserID.Text.Trim(),txtusername.Text.Trim(),txtpassword.Text.Trim(),UsersGrant.ToString());
                    cntrl_users.Create_Position_users("1",UsersGrant.ToString());
                    cntrl_users.createUser_Emp("1001", txtusername.Text.Trim(),"1");
                    ms.createUsers_Successfully();
                    this.Close();
                }
                else { } 
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            txtUserID.Text = cntrl_users.create_id().ToString();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            try {
                DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການຍົກເລິກຫຼືບໍ?","ຟ້ອງຈາກລະບົບ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    txtpassword.Text = "";
                    txtusername.Text = "";
                    
                    this.Close();
                }
                else
                {
                    return;
                }

            } catch { }
        }

        private void rdb_CounterRecive_CheckedChanged(object sender, EventArgs e)
        {
            UsersGrant = "ຜູ້ຈັດການ";
        }

        private void rdbCounter_CheckedChanged(object sender, EventArgs e)
        {
            UsersGrant = "ພະນັກງານບັນຊີ";
        }

        private void rdbadmin_CheckedChanged(object sender, EventArgs e)
        {
            UsersGrant = "ພະນັກງານຕ້ອນຮັບ";
        }
    }
}
