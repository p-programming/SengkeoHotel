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
    public partial class FormRoomType : Form
    {
        public FormRoomType()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";

        private void FormRoomType_Load(object sender, EventArgs e)
        {
            txt_rtID.Enabled = false;
            txt_RoomType.Focus();
            txt_RoomPrice.Refresh();           
            cd.ActiveCon();
            CreateNewser();
            Showdata();
            

        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from RoomType", cd.ActiveCon());
            da.Fill(ds, "RT");
            ds.Tables[0].Clear();
            da.Fill(ds, "RT");
            DGV_RoomType.DataSource = ds.Tables[0];
            DGV_RoomType.Columns[0].HeaderText = "ລະຫັດ";
            DGV_RoomType.Columns[1].HeaderText = "ປະເພດຫ້ອງ";
            DGV_RoomType.Columns[2].HeaderText = "ລາຄາຕໍ່ວັນ";
            DGV_RoomType.Columns[0].Width = 100;
            DGV_RoomType.Columns[1].Width = 150;
            DGV_RoomType.Columns[2].Width = 150;
            DGV_RoomType.Refresh();
        }
        void CreateNewser()
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("New_RoomTypes", con.ActiveCon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txt_rtID.Text = dt.Rows[0][0].ToString();
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from RoomType Where RoomTypeID=@RoomTypeID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@RoomTypeID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "m");
            ds.Tables["m"].Clear();
            da.Fill(ds, "m");
            if (ds.Tables["m"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txt_rtID.Clear();
            txt_RoomType.Clear();
            txt_RoomPrice.Clear();                       
            txt_rtID.Focus();
            CreateNewser();
        }

        private void DGV_RoomType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_rtID.Text = DGV_RoomType.CurrentRow.Cells[0].Value.ToString();
            txt_RoomType.Text = DGV_RoomType.CurrentRow.Cells[1].Value.ToString();
            txt_RoomPrice.Text = DGV_RoomType.CurrentRow.Cells[2].Value.ToString();
        }
        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_rtID.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດບັດກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_RoomType.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ປະເພດຫ້ອງກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_RoomPrice.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລາຄາກ່ອນ", "ຂໍຂອບໃຈເດີ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_rtID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into RoomType values(@RoomTypeID,@RoomTypeName,@RoomPirce)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@RoomTypeID", txt_rtID.Text);
                cmd.Parameters.AddWithValue("@RoomTypeName", txt_RoomType.Text);
                cmd.Parameters.AddWithValue("@RoomPirce", txt_RoomPrice.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_RoomType.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຊື່ປະເພດຫ້ອງເພື່ອຕ້ອງການແກ້ໄຂກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການແກ້ໄຂຂໍ້ມູນ ຫຼື ບໍ່?", "ແກ້ໄຂ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update RoomType set RoomTypeName=@RoomTypeName,RoomPrice=@RoomPrice where RoomTypeID=@RoomTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@RoomTypeID", txt_rtID.Text);
                cmd.Parameters.AddWithValue("@RoomTypeName", txt_RoomType.Text);
                cmd.Parameters.AddWithValue("@RoomPrice", txt_RoomPrice.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_RoomType.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຂໍ້ມູນທີ່ຕ້ອງການລືບເສຍກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(" ທ່ານຕ້ອງການລືບຂໍ້ມູນ ຫຼື ບໍ່?", "ບໍ່ລືບ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"DELETE FROM RoomType WHERE RoomTypeID=@RoomTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@RoomTypeID", txt_rtID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            
        }
    }
    }
