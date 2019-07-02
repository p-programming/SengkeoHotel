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

namespace SengkeoHotel
{
    public partial class FormExpend : Form
    {
        public FormExpend()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        string User = "KKK";
        private void button1_Click(object sender, EventArgs e)
        {
            FormExpendType I = new FormExpendType();
            I.StartPosition = FormStartPosition.CenterScreen;
            I.ShowDialog();
        }

        private void FormExpend_Load(object sender, EventArgs e)
        {
            txt_ExID.Enabled = false;
            txt_ExID.ReadOnly = true;
            cb_PayOff.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_PayOff.Refresh();
            cd.ActiveCon();
            Showdata();
            AutoID();
            LoadExpendType();
        }
        public void AutoID()
        {
            SqlDataAdapter daa = new SqlDataAdapter("select Max(ExpendID) from Expend", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "d");
            dss.Tables[0].Clear();
            daa.Fill(dss, "d");
            string ExpendID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                ExpendID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                ExpendID = "000";
            }
            ExpendID = "000" + (double.Parse(ExpendID) + 1).ToString();
            txt_ExID.Text = ExpendID;
        }
        public void LoadExpendType()
        {
            SqlDataAdapter dap = new SqlDataAdapter("select * from ExpendType", cd.ActiveCon());
            DataSet dsp = new DataSet();
            dap.Fill(dsp, "A");
            cb_PayOff.DataSource = dsp.Tables["A"];
            cb_PayOff.DisplayMember = "ExpendTypeName";
            cb_PayOff.ValueMember = "ExpendTypeID";
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Expend Where ExpendID=@ExpendID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@ExpendID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "r");
            ds.Tables["r"].Clear();
            da.Fill(ds, "r");
            if (ds.Tables["r"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txt_ExID.Clear();
            txt_Bill.Clear();
            txt_Des.Clear();
            txt_AmPay.Clear();
            txt_ExID.Focus();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select A.ExpendID,A.ExpendBillNo,A.ExpendDate,A.ExpendAmount,A.ExpendDetail,B.ExpendTypeName from Expend As A join ExpendType As B on B.ExpendTypeID = A.ExpendTypeID", cd.ActiveCon());
            da.Fill(ds, "j");
            ds.Tables[0].Clear();
            da.Fill(ds, "j");
            DGV_Expend.DataSource = ds.Tables[0];
            DGV_Expend.Columns[0].HeaderText = "ລະຫັດ";
            DGV_Expend.Columns[1].HeaderText = "ເລກທີໃບບິນ";
            DGV_Expend.Columns[2].HeaderText = "ວັນທີຈ່າຍ";
            DGV_Expend.Columns[3].HeaderText = "ຈໍານວນທີ່ຈ່າຍ";
            DGV_Expend.Columns[4].HeaderText = "ລາຍລະອຽດ";
            DGV_Expend.Columns[5].HeaderText = "ປະເພດລາຍຈ່າຍ";
            DGV_Expend.Columns[0].Width = 90;
            DGV_Expend.Columns[1].Width = 170;
            DGV_Expend.Columns[2].Width = 160;
            DGV_Expend.Columns[3].Width = 150;
            DGV_Expend.Columns[4].Width = 160;
            DGV_Expend.Columns[5].Width = 190;
            DGV_Expend.Refresh();
        }

        private void DGV_Expend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ExID.Text = DGV_Expend.CurrentRow.Cells[0].Value.ToString();
            txt_Bill.Text = DGV_Expend.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = DGV_Expend.CurrentRow.Cells[2].Value.ToString();                        
            txt_AmPay.Text = DGV_Expend.CurrentRow.Cells[3].Value.ToString();
            txt_Des.Text = DGV_Expend.CurrentRow.Cells[4].Value.ToString();
            cb_PayOff.Text = DGV_Expend.CurrentRow.Cells[5].Value.ToString();
            
            

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Bill.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນເລກທີໃບບິນກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_AmPay.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຈໍານວນທີ່ຈ່າຍກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_Des.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລາຍລະອຽດກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_ExID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Expend values(@ExpendID,@ExpendBillNo,@ExpendDate,@ExpendAmount,@ExpendDetail,@ExpendTypeID,@UserID)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ExpendID", txt_ExID.Text);
                cmd.Parameters.AddWithValue("@ExpendBillNo", txt_Bill.Text);
                cmd.Parameters.AddWithValue("@ExpendDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ExpendAmount", txt_AmPay.Text);
                cmd.Parameters.AddWithValue("@ExpendDetail", txt_Des.Text);
                cmd.Parameters.AddWithValue("@ExpendTypeID", cb_PayOff.SelectedValue.ToString());       
                cmd.Parameters.AddWithValue("@UserID",User);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Bill.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Expend set ExpendBillNo=@ExpendBillNo,ExpendDate=@ExpendDate,ExpendAmount=@ExpendAmount,ExpendTypeID=@ExpendTypeID where ExpendID=@ExpendID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ExpendID", txt_ExID.Text);
                cmd.Parameters.AddWithValue("@ExpendBillNo", txt_Bill.Text);
                cmd.Parameters.AddWithValue("@ExpendDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ExpendAmount", txt_AmPay.Text);
                cmd.Parameters.AddWithValue("@ExpendDetail", txt_Des.Text);
                cmd.Parameters.AddWithValue("@ExpendTypeID", cb_PayOff.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Bill.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"DELETE FROM Expend WHERE ExpendID=@ExpendID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ExpendID", txt_ExID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
