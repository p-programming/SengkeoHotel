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
    public partial class FormDepartment : Form
    {
        public FormDepartment()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string Sql = "";
        private void FormDepartment_Load(object sender, EventArgs e)
        {
            txt_DepartmentID.Enabled = false;
            txt_DepartmentID.Focus();
            AutoID();
            cd.ActiveCon();
            Showdata();
        }
        public void AutoID()
        {

            SqlDataAdapter daa = new SqlDataAdapter("select Max(DepartmentID) from Department", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "p");
            dss.Tables[0].Clear();
            daa.Fill(dss, "p");
            string DepartmentID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                DepartmentID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                DepartmentID = "000";
            }
            DepartmentID = "000" + (double.Parse(DepartmentID) + 1).ToString();
            txt_DepartmentID.Text = DepartmentID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Department Where DepartmentID=@DepartmentID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@DepartmentID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "q");
            ds.Tables["q"].Clear();
            da.Fill(ds, "q");
            if (ds.Tables["q"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txt_DepartmentID.Clear();
            txt_DepartmentName.Clear();
            txt_DepartmentID.Focus();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from Department", cd.ActiveCon());
            da.Fill(ds, "p");
            ds.Tables[0].Clear();
            da.Fill(ds, "p");
            DGV_DepartmentType.DataSource = ds.Tables[0];
            DGV_DepartmentType.Columns[0].HeaderText = "ລະຫັດ";
            DGV_DepartmentType.Columns[1].HeaderText = "ພະແນກ";
            DGV_DepartmentType.Columns[0].Width = 120;
            DGV_DepartmentType.Columns[1].Width = 230;
            DGV_DepartmentType.Refresh();
        }

        private void DGV_DepartmentType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_DepartmentID.Text = DGV_DepartmentType.CurrentRow.Cells[0].Value.ToString();
            txt_DepartmentName.Text = DGV_DepartmentType.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            if (txt_DepartmentName.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ພະແນກກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_DepartmentID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Department values(@DepartmentID,@DepartmentName)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@DepartmentID", txt_DepartmentID.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", txt_DepartmentName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_DepartmentName.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນເພື່ອຕ້ອງການແກ້ໄຂກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Department set DepartmentName=@DepartmentName where DepartmentID=@DepartmentID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@DepartmentID", txt_DepartmentID.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", txt_DepartmentName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_DepartmentName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນເພື່ອຕ້ອງການລືບກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Department where DepartmentID=@DepartmentID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@DepartmentID", txt_DepartmentID.Text);
                cmd.Parameters.AddWithValue("@DepartmentName", txt_DepartmentName.Text);
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
