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
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        private void btn_UserClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void FormUser_Load(object sender, EventArgs e)
        {
            
            cbUserAuthor.DropDownStyle = ComboBoxStyle.DropDown;
            txt_UserID.Enabled = false;
            txt_UserID.Focus();
            AutoID();
            cd.ActiveCon();
            Showdata();
        }        
            public void AutoID()
        {
            SqlDataAdapter daa = new SqlDataAdapter("select Max(EmpID) from Users", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "u");
            dss.Tables[0].Clear();
            daa.Fill(dss, "u");
            string UserID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                UserID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                UserID = "000";
            }
            UserID = "000" + (double.Parse(UserID) + 1).ToString();
            txt_UserID.Text = UserID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Users Where UserID=@UserID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@UserID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "o");
            ds.Tables["o"].Clear();
            da.Fill(ds, "o");
            if (ds.Tables["o"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txt_UserID.Clear();
            txt_UserName.Clear();
            txt_Password.Clear();
            txt_UserID.Focus();
            cbUserAuthor.Refresh();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from Users", cd.ActiveCon());
            da.Fill(ds, "j");
            ds.Tables[0].Clear();
            da.Fill(ds, "j");
            DGV_User.DataSource = ds.Tables[0];
            DGV_User.Columns[0].HeaderText = "ລະຫັດ";
            DGV_User.Columns[1].HeaderText = "ຊື່ແຈ້ງ";
            DGV_User.Columns[2].HeaderText = "ລະຫັດຜ່ານ";
            DGV_User.Columns[3].HeaderText = "ສິດທິຜູ້ໃຊ້";
            DGV_User.Columns[0].Width = 90;
            DGV_User.Columns[1].Width = 170;
            DGV_User.Columns[2].Width = 160;
            DGV_User.Columns[3].Width = 120;
            DGV_User.Refresh();
        }

        private void DGV_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_UserID.Text = DGV_User.CurrentRow.Cells[0].Value.ToString();
            txt_UserName.Text = DGV_User.CurrentRow.Cells[1].Value.ToString();
           txt_Password.Text = DGV_User.CurrentRow.Cells[2].Value.ToString();
          cbUserAuthor.Text= DGV_User.CurrentRow.Cells[3].Value.ToString();
            

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            if (txt_UserName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_Password.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_UserID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Users values(@UserID,@UserName,@Password,@UserRights)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@UserID", txt_UserID.Text);
                cmd.Parameters.AddWithValue("@UserName", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@Password", txt_Password.Text);
                cmd.Parameters.AddWithValue("@UserRights",cbUserAuthor.Text);
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
            if (txt_UserName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນເພື່ອຕ້ອງການແກ້ໄຂ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Users set UserName=@UserName,Password=@Password,UserRights=@UserRights where UserID=@UserID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@UserID", txt_UserID.Text);
                cmd.Parameters.AddWithValue("@UserName", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@Password", txt_Password.Text);
                cmd.Parameters.AddWithValue("@UserRights", cbUserAuthor.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນເພື່ອຕ້ອງການລືບ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Users where UserID=@UserID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@UserID", txt_UserID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
