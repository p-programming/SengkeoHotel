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
    public partial class FormExpendType : Form
    {
        public FormExpendType()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        private void FormExpendType_Load(object sender, EventArgs e)
        {
            txt_ExpendTypeID.Enabled = false;
            txt_ExpendTypeName.Focus();
            cd.ActiveCon();
            CreateNews();          
            Showdata();
            
        }
        public void Clear()
        {
            txt_ExpendTypeID.Clear();
            txt_ExpendTypeName.Clear();
            CreateNews();
            txt_ExpendTypeID.Focus();

        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from ExpendType Where ExpendTypeID=@ExpendTypeID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("ExpendTypeID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ExpendType");
            ds.Tables["ExpendType"].Clear();
            da.Fill(ds, "ExpendType");
            if (ds.Tables["ExpendType"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        private void CreateNews()
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("New_ExpendType", con.ActiveCon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txt_ExpendTypeID.Text = dt.Rows[0][0].ToString();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from ExpendType", cd.ActiveCon());
            da.Fill(ds, "ET");
            ds.Tables[0].Clear();
            da.Fill(ds, "ET");
            DGV_ExpendType.DataSource = ds.Tables[0];
            DGV_ExpendType.Columns[0].HeaderText = "ລະຫັດ";
            DGV_ExpendType.Columns[1].HeaderText = "ຊື່ປະເພດລາຍຈ່າຍ";
            DGV_ExpendType.Columns[0].Width = 130;
            DGV_ExpendType.Columns[1].Width = 240;
            DGV_ExpendType.Refresh();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_ExpendTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ປະເພດລາຍຈ່າຍ", "ຂໍຂອບໃຈເດີ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_ExpendTypeID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into ExpendType values(@ExpendTypeID,@ExpendTypeName)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("ExpendTypeID", txt_ExpendTypeID.Text);
                cmd.Parameters.AddWithValue("ExpendTypeName", txt_ExpendTypeName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void DGV_ExpendType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ExpendTypeID.Text = DGV_ExpendType.CurrentRow.Cells[0].Value.ToString();
            txt_ExpendTypeName.Text = DGV_ExpendType.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_ExpendTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນເພື່ອຕ້ອງການແກ້ໄຂກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update ExpendType set ExpendTypeName=@ExpendTypeName where ExpendTypeID=@ExpendTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("ExpendTypeID", txt_ExpendTypeID.Text);
                cmd.Parameters.AddWithValue("ExpendTypeName", txt_ExpendTypeName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_ExpendTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຂໍ້ມູນທີ່ຕ້ອງການລືບເສຍກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"DELETE FROM ExpendType WHERE ExpendTypeID=@ExpendTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("ExpendTypeID", txt_ExpendTypeID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
