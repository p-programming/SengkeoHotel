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
    public partial class FormPosition : Form
    {
        public FormPosition()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string Sql = "";
        private void FormPosition_Load(object sender, EventArgs e)
        {
            txt_PositionID.Enabled = false;
            txt_PositionID.Focus();
            AutoID();
            cd.ActiveCon();
            Showdata();
        }
        public void AutoID()
        {

            SqlDataAdapter daa = new SqlDataAdapter("select Max(PositionID) from Position", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "p");
            dss.Tables[0].Clear();
            daa.Fill(dss, "p");
            string PositionID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                PositionID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                PositionID = "000";
            }
            PositionID = "000" + (double.Parse(PositionID) + 1).ToString();
            txt_PositionID.Text = PositionID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Position Where PositionID=@PositionID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@PositionID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "v");
            ds.Tables["v"].Clear();
            da.Fill(ds, "v");
            if (ds.Tables["v"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txt_PositionID.Clear();
            txt_Name.Clear();
            txt_Money.Clear();
            txt_PositionID.Focus();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from Position", cd.ActiveCon());
            da.Fill(ds, "j");
            ds.Tables[0].Clear();
            da.Fill(ds, "j");
            DGV_Position.DataSource = ds.Tables[0];
            DGV_Position.Columns[0].HeaderText = "ລະຫັດ";
            DGV_Position.Columns[1].HeaderText = "ຕໍາແໜ່ງ";
            DGV_Position.Columns[2].HeaderText = "ເງີນເດືອນ";
            DGV_Position.Columns[0].Width = 120;
            DGV_Position.Columns[1].Width = 170;
            DGV_Position.Columns[2].Width = 190;
            DGV_Position.Refresh();
        }

        private void DGV_Position_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_PositionID.Text = DGV_Position.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = DGV_Position.CurrentRow.Cells[1].Value.ToString();
            txt_Money.Text = DGV_Position.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຕໍາແໜ່ງກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_Money.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນເງີນກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_PositionID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Position values(@PositionID,@PositionName,@Salary)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@PositionID", txt_PositionID.Text);
                cmd.Parameters.AddWithValue("@PositionName", txt_Name.Text);
                cmd.Parameters.AddWithValue("@Salary", txt_Money.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນເພື່ອຕ້ອງການແກ້ໄຂ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Position set PositionName=@PositionName,Salary=@Salary where PositionID=@PositionID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@PositionID", txt_PositionID.Text);
                cmd.Parameters.AddWithValue("@PositionName", txt_Name.Text);
                cmd.Parameters.AddWithValue("@Salary", txt_Money.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນເພື່ອຕ້ອງການລືບ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Position where PositionID=@PositionID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@PositionID", txt_PositionID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
