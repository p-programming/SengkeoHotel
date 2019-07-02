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
    public partial class FormCardType : Form
    {
        public FormCardType()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";

        private void FormCardType_Load(object sender, EventArgs e)
        {
            txt_CardTypeID.Enabled = false;
            txt_CardTypeName.Focus();
            cd.ActiveCon();
            CreateNews();
            Showdata();
        }
        public void Clear()
        {
            txt_CardTypeID.Clear();
            txt_CardTypeName.Clear();
            CreateNews();
            txt_CardTypeID.Focus();

        }
        void CreateNews()
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("New_CardType", con.ActiveCon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txt_CardTypeID.Text = dt.Rows[0][0].ToString();
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from CardType Where CardTypeID=@CardTypeID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("CardTypeID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "CardType");
            ds.Tables["CardType"].Clear();
            da.Fill(ds, "CardType");
            if (ds.Tables["CardType"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from CardType", cd.ActiveCon());
            da.Fill(ds, "CT");
            ds.Tables[0].Clear();
            da.Fill(ds, "CT");
            DGV_CardType.DataSource = ds.Tables[0];
            DGV_CardType.Columns[0].HeaderText = "ລະຫັດປະເພດບັດ";
            DGV_CardType.Columns[1].HeaderText = "ຊື່ປະເພດບັດ";
            DGV_CardType.Columns[0].Width = 120;
            DGV_CardType.Columns[1].Width = 190;
            DGV_CardType.Refresh();
        }

        private void DGV_CardType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_CardTypeID.Text = DGV_CardType.CurrentRow.Cells[0].Value.ToString();
            txt_CardTypeName.Text = DGV_CardType.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear();
            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_CardTypeID.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດປະເພດບັດກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_CardTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ປະເພດບັດກ່ອນ", "ຂໍຂອບໃຈເດີ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_CardTypeID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into CardType values(@CardTypeID,@CardTypeName)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("CardTypeID", txt_CardTypeID.Text);
                cmd.Parameters.AddWithValue("CardTypeName", txt_CardTypeName.Text);
                cmd.ExecuteNonQuery();
                Showdata();            
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_CardTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຊື່ປະເພດບັດເພື່ອຕ້ອງການແກ້ໄຂກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການແກ້ໄຂຂໍ້ມູນ ຫຼື ບໍ່?", "ແກ້ໄຂ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update CardType set CardTypeName=@CardTypeName where CardTypeID=@CardTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("CardTypeID", txt_CardTypeID.Text);
                cmd.Parameters.AddWithValue("CardTypeName", txt_CardTypeName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_CardTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຂໍ້ມູນທີ່ຕ້ອງການລືບເສຍກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(" ທ່ານຕ້ອງການລືບຂໍ້ມູນ ຫຼື ບໍ່?", "ບໍ່ລືບ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"DELETE FROM CardType WHERE CardTypeID=@CardTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("CardTypeID", txt_CardTypeID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
