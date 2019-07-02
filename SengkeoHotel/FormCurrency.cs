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
    public partial class FormCurrency : Form
    {
        public FormCurrency()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCurrency_Load(object sender, EventArgs e)
        {
            //txt_UserID.Enabled = false;
            txt_IDCur.Focus();
            AutoID();
            cd.ActiveCon();
            Showdata();
        }
        public void AutoID()
        {
            SqlDataAdapter daa = new SqlDataAdapter("select Max(CurrencyID) from Currency", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "c");
            dss.Tables[0].Clear();
            daa.Fill(dss, "c");
            string CurrencyID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                CurrencyID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                CurrencyID = "00";
            }
            CurrencyID = "00" + (double.Parse(CurrencyID) + 1).ToString();
            txt_IDCur.Text = CurrencyID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Currency Where CurrencyID=@CurrencyID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@CurrencyID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "c");
            ds.Tables["c"].Clear();
            da.Fill(ds, "c");
            if (ds.Tables["c"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txt_IDCur.Clear();
            txt_CurName.Clear();
            txt_CurAmount.Clear();
            txt_IDCur.Focus();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from Currency", cd.ActiveCon());
            da.Fill(ds, "n");
            ds.Tables[0].Clear();
            da.Fill(ds, "n");
            DGV_Cur.DataSource = ds.Tables[0];
            DGV_Cur.Columns[0].HeaderText = "ລະຫັດ";
            DGV_Cur.Columns[1].HeaderText = "ສະກຸນເງີນ";
            DGV_Cur.Columns[2].HeaderText = "ອັດຕາແລກປ່ຽນ";
            DGV_Cur.Columns[0].Width = 90;
            DGV_Cur.Columns[1].Width = 170;
            DGV_Cur.Columns[2].Width = 160;
            DGV_Cur.Refresh();
        }

        private void DGV_Cur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_IDCur.Text = DGV_Cur.CurrentRow.Cells[0].Value.ToString();
            txt_CurName.Text = DGV_Cur.CurrentRow.Cells[1].Value.ToString();
            txt_CurAmount.Text = DGV_Cur.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_CurName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_CurAmount.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນອັດຕາແລກປ່ຽນກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_IDCur.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Currency values(@CurrencyID,@CurrencyName,@RateAmount)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@CurrencyID", txt_IDCur.Text);
                cmd.Parameters.AddWithValue("@CurrencyName", txt_CurName.Text);
                cmd.Parameters.AddWithValue("@RateAmount", txt_CurAmount.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_CurAmount.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນອັດຕາແລກປ່ຽນກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Currency set CurrencyName=@CurrencyName,RateAmount=@RateAmount where CurrencyID=@UCurrencyID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@CurrencyID", txt_IDCur.Text);
                cmd.Parameters.AddWithValue("@CurrencyName", txt_CurName.Text);
                cmd.Parameters.AddWithValue("@RateAmount", txt_CurAmount.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_CurName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນເພື່ອຕ້ອງການລືບ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Currency where CurrencyID=@CurrencyID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@UserID", txt_IDCur.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
