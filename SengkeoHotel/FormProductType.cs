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
    public partial class FormProductType : Form
    {
        public FormProductType()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string Sql = "";
        private void FormProductType_Load(object sender, EventArgs e)
        {
            txt_ProTypeID.Enabled = false;
            cd.ActiveCon();           
            AutoID();
            Clear();
            Showdata();
        }
        public void AutoID()
        {

            SqlDataAdapter daa = new SqlDataAdapter("select Max(ProductTypeID) from ProductType", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "l");
            dss.Tables[0].Clear();
            daa.Fill(dss, "l");
            string ProductTypeID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                ProductTypeID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                ProductTypeID = "000";
            }
            ProductTypeID = "000" + (double.Parse(ProductTypeID) + 1).ToString();
            txt_ProTypeID.Text = ProductTypeID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from ProductType Where ProductTypeID=@ProductTypeID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@ProductTypeID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "s");
            ds.Tables["s"].Clear();
            da.Fill(ds, "s");
            if (ds.Tables["s"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        private void Clear()
        {
            txt_ProTypeID.Clear();
            txt_ProTypeName.Clear();
            txt_ProTypeID.Focus();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select * from ProductType", cd.ActiveCon());
            da.Fill(ds, "T");
            ds.Tables[0].Clear();
            da.Fill(ds, "T");
            DGV_ProType.DataSource = ds.Tables[0];
            DGV_ProType.Columns[0].HeaderText = "ລະຫັດ";
            DGV_ProType.Columns[1].HeaderText = "ປະເພດສິນຄ້າ";
            DGV_ProType.Columns[0].Width = 140;
            DGV_ProType.Columns[1].Width = 200;
            DGV_ProType.Refresh();
        }

        private void DGV_ProType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ProTypeID.Text = DGV_ProType.CurrentRow.Cells[0].Value.ToString();
            txt_ProTypeName.Text = DGV_ProType.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {            
            
            if (txt_ProTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນປະເພດສິນຄ້າກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_ProTypeID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into ProductType values(@ProductTypeID,@ProductTypeName)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ProductTypeID", txt_ProTypeID.Text);
                cmd.Parameters.AddWithValue("@ProductTypeName", txt_ProTypeName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {            
            if (txt_ProTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຊື່ສິນຄ້າກ່ອນເພື່ອຕ້ອງການແກ້ໄຂ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update ProductType set ProductTypeName=@ProductTypeName where ProductTypeID=@ProductTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ProductTypeID", txt_ProTypeID.Text);
                cmd.Parameters.AddWithValue("@ProductTypeName", txt_ProTypeName.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_ProTypeName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຊື່ສິນຄ້າເພື່ອຕ້ອງການລືບ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from ProductType where ProductTypeID=@ProductTypeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ProductTypeID", txt_ProTypeID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
