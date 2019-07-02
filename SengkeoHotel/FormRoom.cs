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
    public partial class FormRoom : Form
    {
        public FormRoom()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string Sql = "";
        private void FormRoom_Load(object sender, EventArgs e)
        {
            AutoBillNo();
            cmb_RoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_RoomID.Enabled = false;
            txt_Room.Focus();
            cmb_RoomType.Refresh();
            cd.ActiveCon();
            Showdata();           
            NewRoomType();
        }
        private void AutoBillNo()
        {

            SqlDataAdapter daa = new SqlDataAdapter("select Max(RoomID) from Room", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "h");
            dss.Tables[0].Clear();
            daa.Fill(dss, "h");
            string RoomID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                RoomID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                RoomID = "000";
            }
            RoomID = "000" + (double.Parse(RoomID) + 1).ToString();
            txt_RoomID.Text = RoomID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Room Where RoomID=@RoomID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@RoomID", id);
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
        public void NewRoomType()
        {
            SqlDataAdapter dap = new SqlDataAdapter("select * from RoomType", cd.ActiveCon());
            DataSet dsp = new DataSet();
            dap.Fill(dsp, "i");
            cmb_RoomType.DataSource = dsp.Tables[0];
            cmb_RoomType.DisplayMember = "RoomTypeName";
            cmb_RoomType.ValueMember = "RoomTypeID";
        }
        private void Clear()
        {
            txt_Room.Clear();
            txt_DesRoom.Clear();
            txt_RoomID.Focus();
            AutoBillNo();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select A.RoomID,A.RoomNO,B.RoomTypeName,A.Descrition from Room As A join RoomType As B on B.RoomTypeID = A.RoomTypeID", cd.ActiveCon());
            da.Fill(ds, "Rs");
            ds.Tables[0].Clear();
            da.Fill(ds, "Rs");
            DGV_Room.DataSource = ds.Tables[0];
            DGV_Room.Columns[0].HeaderText = "ລະຫັດຫ້ອງ";
            DGV_Room.Columns[1].HeaderText = "ຊື່ຫ້ອງ";
            DGV_Room.Columns[2].HeaderText = "ປະເພດຫ້ອງ";
            DGV_Room.Columns[3].HeaderText = "ລາຍລະອຽດຫ້ອງ";
            DGV_Room.Columns[0].Width = 120;
            DGV_Room.Columns[1].Width = 170;
            DGV_Room.Columns[2].Width = 190;
            DGV_Room.Columns[3].Width = 150;
            DGV_Room.Refresh();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
           
            if (txt_Room.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ຫ້ອງກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txt_DesRoom.Text.Equals(""))
            //{
            //    MessageBox.Show("ກະລຸນາປ້ອນລາຍລະອຽດຫ້ອງກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (isExists(txt_RoomID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Room values(@RoomID,@RoomNO,@RoomTypeID,@Descrition)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@RoomID", txt_RoomID.Text);
                cmd.Parameters.AddWithValue("@RoomNO", txt_Room.Text);
                cmd.Parameters.AddWithValue("@RoomTypeID", cmb_RoomType.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Descrition", txt_DesRoom.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
                
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Room.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຊື່ຫ້ອງ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Room where RoomID=@RoomID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@RoomID", txt_RoomID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void DGV_Room_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_RoomID.Text = DGV_Room.CurrentRow.Cells[0].Value.ToString();
                txt_Room.Text = DGV_Room.CurrentRow.Cells[1].Value.ToString();
                cmb_RoomType.Text = DGV_Room.CurrentRow.Cells[2].Value.ToString();
                txt_DesRoom.Text = DGV_Room.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {

            }

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            AutoBillNo();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Room.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ຫ້ອງກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txt_DesRoom.Text.Equals(""))
            //{
            //    MessageBox.Show("ກະລຸນາປ້ອນລາຍລະອຽດຫ້ອງກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Room set RoomNO=@RoomNO,RoomTypeID=@RoomTypeID,Descrition=@Descrition where RoomID=@RoomID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@RoomID", txt_RoomID.Text);
                cmd.Parameters.AddWithValue("@RoomNO", txt_Room.Text);
                cmd.Parameters.AddWithValue("@RoomTypeID", cmb_RoomType.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Descrition", txt_DesRoom.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}

