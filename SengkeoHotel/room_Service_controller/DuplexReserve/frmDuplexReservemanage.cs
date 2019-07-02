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
using SengkeoHotel.dbconnection;
using SengkeoHotel.controller;
using System.Data.SqlClient;

namespace SengkeoHotel.room_Service_controller.DuplexReserve
{
    public partial class frmDuplexReservemanage : Form
    {
        connectdb_change cn = new connectdb_change();
        duplexreserveController cntrl_duplex = new duplexreserveController();
        AnymessageBox ms = new AnymessageBox();
        String getDuplex = "";
        public frmDuplexReservemanage(String setDuplex)
        {
            InitializeComponent();
            timer1.Start();
            getDuplex = setDuplex;
        }
        private void frmDuplexReservemanage_Load(object sender, EventArgs e)
        {


            cbCustomer.DataSource = cntrl_duplex.get_customerReserve();
            cbCustomer.DisplayMember = "CustomerName";
            cbCustomer.ValueMember = "CustomerID";
            cbCustomer.Text = "....ເລືອກລູກຄ້າ...";
            txtCusAddress.Text = "";
            txtCustel.Text = "";
            txtCusEmail.Text = "";
            if (getDuplex.ToString() != "")
            {
                DataTable current = new DataTable();
                current = cntrl_duplex.get_ReserveShowOnfrm(getDuplex);
                txtID.Text = current.Rows[0]["DResID"].ToString();
                cbCustomer.Text = current.Rows[0]["CustomerName"].ToString();
                txtPayment.Text = current.Rows[0]["TotalPayment"].ToString();
            }
            if (getDuplex.ToString() == "")
            {
                CreateAuto_ID();
                //cntrl_duplex.create_AutoID(txtID);
            }
        }

        private void cbCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet drs = new DataSet();
                drs = cntrl_duplex.set_customerReserv(cbCustomer.Text);
                if (drs.Tables[0].Rows.Count > 0)
                {
                    txtCusAddress.Text = drs.Tables[0].Rows[0].ItemArray[1].ToString();
                    txtCusEmail.Text = drs.Tables[0].Rows[0].ItemArray[2].ToString();
                    txtCustel.Text = drs.Tables[0].Rows[0].ItemArray[3].ToString();
                }
                else
                {
                    cbCustomer.Text = "....ເລືອກລູກຄ້າ...";
                    txtCusAddress.Text = "";
                    txtCustel.Text = "";
                    txtCusEmail.Text = "";
                }
            }
            catch { }
        }
        private void CreateAuto_ID()
        {
            cn.da = new SqlDataAdapter("create_DuplexReserverID", cn.cn);
            cn.da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable id = new DataTable();
            cn.da.Fill(id);
            txtID.Text = id.Rows[0].ItemArray[0].ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກບໍ", "ຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                if (txtPayment.Text == "")
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເງິນ");
                    txtPayment.Focus();
                    return;
                }
              
                cntrl_duplex.Inser_DuplexReserve(txtID.Text.Trim().ToUpper(), cbCustomer.SelectedValue.ToString().Trim(), dtpbegindate.Value.ToString("yyyy/MM/dd").Trim(), dtpreservdate.Value.ToString("yyyy/MM/dd").Trim(), txtPayment.Text.Trim(),double.Parse( txtDeposit.Text).ToString().Trim(), double.Parse( txtbalance.Text).ToString().Trim());
                ms.INSERT_Or_SAVE_Successfull();
                CreateAuto_ID();
            }
            else
            {
                return;
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            try {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtPayment.Text, "[^0-9^]"))
                {
                    MessageBox.Show("ກະລຸນາປ້ອນສະເພາະຕົວເລກ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    txtPayment.Text = txtPayment.Text.Remove(txtPayment.Text.Length - 1);
                    txtPayment.Focus();
                    txtPayment.Select();
                    return;
                }
                    Double payment = 0, deposit = 0, balance = 0;
                    payment = Double.Parse(txtPayment.Text);
                    deposit = (payment * 60) / 100;
                    txtDeposit.Text = deposit.ToString("#,###");
                    balance = (Double.Parse(payment.ToString()) - Double.Parse(deposit.ToString()));
                    txtbalance.Text = balance.ToString("#,###");
            }
            catch { }
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    if (txtPayment.Text == "")
                    {
                        MessageBox.Show("ປ້ອນມູນຄ່າຈຳນວນເງິນກ່ອນ");
                        txtPayment.Focus();

                        return;
                    }
                    if (txtPayment.Text != "")
                    {
                        double  dep = 0, bal = 0, Result =0; 
                        dep = double.Parse(txtDeposit.Text);
                        bal = double.Parse(txtbalance.Text);
                        Result = double.Parse(dep.ToString()) + double.Parse(bal.ToString());
                        txtDeposit.Text = Result.ToString();
                        txtbalance.Text = "0";
                    }
                }
                else if (checkBox1.Checked == false)
                {
                    Double payment = 0, deposit = 0, balance = 0;
                    payment = Double.Parse(txtPayment.Text);
                    deposit = (payment * 60) / 100;
                    txtDeposit.Text = deposit.ToString("#,###");
                    balance = (Double.Parse(payment.ToString()) - Double.Parse(deposit.ToString()));
                    txtbalance.Text = balance.ToString("#,###");
                }
            }
            catch { }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການແກ້ໄຂຂໍ້ມູນນີ້ບໍ", "ຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                cntrl_duplex.Update_DuplexReserve(dtpbegindate.Value.ToString(),dtpreservdate.Value.ToString(),txtPayment.Text.ToString().Trim(),double.Parse( txtDeposit.Text).ToString().Trim(),double.Parse( txtbalance.Text).ToString().Trim(),txtID.Text.Trim());
                ms.UPDATE_Data_Successfull();
                this.Close();
            }
            else { return; }
        }
    }
}
