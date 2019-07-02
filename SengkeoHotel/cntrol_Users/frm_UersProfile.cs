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
namespace SengkeoHotel.cntrol_Users
{
    public partial class frm_UersProfile : Form
    {
        LoginController cntrl_lg = new LoginController();
        public frm_UersProfile()
        {
            InitializeComponent();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            try {
                DialogResult dl = MessageBox.Show("Save or No","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dl == DialogResult.Yes) {
                    DataTable cr = new DataTable();
                    cr = cntrl_lg.Check_CurrentUsers(cbEmp.SelectedValue.ToString());
                   if (cr.Rows.Count > 0)
                    {
                        MessageBox.Show("ຜູ່ໃຊ້ນີ້ມີແລ້ວ");
                        return;
                    }
                    cntrl_lg.insert_users(cbEmp.SelectedValue.ToString(),txtUsersname.Text,txtpass.Text,cbEmp.SelectedValue.ToString());
                    MessageBox.Show("Save Successfull");
                } else { return; }

            } catch { }
        }

        private void frm_UersProfile_Load(object sender, EventArgs e)
        {
            cbEmp.DataSource = cntrl_lg.check_emp();
            cbEmp.DisplayMember = "EmployeeName";
            cbEmp.ValueMember = "EmpID";
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dl = MessageBox.Show("Update or No", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    cntrl_lg.Update_users(txtUsersname.Text, txtpass.Text, cbEmp.SelectedValue.ToString());
                    MessageBox.Show("upate Successfull");
                    this.Close();
                }
                else { return; }

            }
            catch { }
        }

        private void cbEmp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable current = new DataTable();
                current = cntrl_lg.get_emp(cbEmp.SelectedValue.ToString());
                txtUsersname.Text = current.Rows[0]["Username"].ToString();
                txtpass.Text = current.Rows[0]["UserPassword"].ToString();
                txtGrant.Text = current.Rows[0]["PositionName"].ToString();
            }
            catch { }
        }
    }
}
