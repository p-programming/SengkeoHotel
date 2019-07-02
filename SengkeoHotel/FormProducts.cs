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
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        private void FormProducts_Load(object sender, EventArgs e)
        {
            AutoID();
            cb_ProductType.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_ProductID.Enabled = false;
            txt_ProductName.Focus();
            cb_ProductType.Refresh();
            cd.ActiveCon();
            Showdata();
            NewRoomType();
        }
        public void AutoID()
        {
            SqlDataAdapter daa = new SqlDataAdapter("select Max(ProductID) from Product", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "f");
            dss.Tables[0].Clear();
            daa.Fill(dss, "f");
            string ProductID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                ProductID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                ProductID = "000";
            }
            ProductID = "000" + (double.Parse(ProductID) + 1).ToString();
            txt_ProductID.Text = ProductID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Product Where ProductID=@ProductID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@ProductID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "a");
            ds.Tables["a"].Clear();
            da.Fill(ds, "a");
            if (ds.Tables["a"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void NewRoomType()
        {
            SqlDataAdapter dap = new SqlDataAdapter("select * from ProductType", cd.ActiveCon());
            DataSet dsp = new DataSet();
            dap.Fill(dsp, "s");
            cb_ProductType.DataSource = dsp.Tables["s"];
            cb_ProductType.DisplayMember = "ProductTypeName";
            cb_ProductType.ValueMember = "ProductTypeID";
        }
        public void Clear()
        {
            txt_ProductID.Clear();
            txt_ProductName.Clear();
            txt_AmountImport.Clear();
            txt_ProductBuy.Clear();
            txt_Sell.Clear();
            txt_ProductID.Focus();
            AutoID();
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select A.ProductID,A.ProductName,A.Qty,A.Buy,A.Sell,B.ProductTypeName,A.Barcode from Product As A join ProductType As B on B.ProductTypeID = A.ProductTypeID", cd.ActiveCon());
            da.Fill(ds, "m");
            ds.Tables[0].Clear();
            da.Fill(ds, "m");
            dgv_Product.DataSource = ds.Tables[0];
            dgv_Product.Columns[0].HeaderText = "ລະຫັດ";
            dgv_Product.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
            dgv_Product.Columns[2].HeaderText = "ຈໍານວນທີ່ນໍາເຂົ້າ";
            dgv_Product.Columns[3].HeaderText = "ລາຄາຊື້";
            dgv_Product.Columns[4].HeaderText = "ລາຄາຂາຍ";
            dgv_Product.Columns[5].HeaderText = "ປະເພດສິນຄ້າ";
            dgv_Product.Columns[6].HeaderText = "ບາໂຄດສິນຄ້າ";
            dgv_Product.Columns[0].Width = 120;
            dgv_Product.Columns[1].Width = 170;
            dgv_Product.Columns[2].Width = 190;
            dgv_Product.Columns[4].Width = 150;
            dgv_Product.Columns[5].Width = 200;
            dgv_Product.Columns[6].Width = 200;
            dgv_Product.Refresh();
        }

        private void dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txt_ProductID.Text = dgv_Product.CurrentRow.Cells[0].Value.ToString();
            txt_ProductName.Text = dgv_Product.CurrentRow.Cells[1].Value.ToString();
            txt_AmountImport.Text = dgv_Product.CurrentRow.Cells[2].Value.ToString();
            txt_ProductBuy.Text = dgv_Product.CurrentRow.Cells[3].Value.ToString();
            txt_Sell.Text = dgv_Product.CurrentRow.Cells[4].Value.ToString();
            cb_ProductType.Text = dgv_Product.CurrentRow.Cells[5].Value.ToString();
            txt_Barcode.Text = dgv_Product.CurrentRow.Cells[6].Value.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_ProductName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txt_AmountImport.Text.Equals(""))
            //{
            //    MessageBox.Show("ກະລຸນາປ້ອນຈໍານວນນໍາເຂົ້າກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (isExists(txt_ProductID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"insert into Product values(@Barcode,@ProductID,@ProductName,@Buy,@Sell,@Qty,@ProductTypeID)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@Barcode", txt_Barcode.Text);
                cmd.Parameters.AddWithValue("@ProductID", txt_ProductID.Text);
                cmd.Parameters.AddWithValue("@ProductName", txt_ProductName.Text);               
                cmd.Parameters.AddWithValue("@Buy", txt_ProductBuy.Text);
                cmd.Parameters.AddWithValue("@Sell", txt_Sell.Text);
                cmd.Parameters.AddWithValue("@Qty", txt_AmountImport.Text);
                cmd.Parameters.AddWithValue("@ProductTypeID", cb_ProductType.SelectedValue.ToString());
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
            if (txt_ProductName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Product set ProductName=@ProductName,Buy=@Buy,Sell=@Sell,Qty=@Qty,ProductTypeID=@ProductTypeID where ProductID=@ProductID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ProductID", txt_ProductID.Text);
                cmd.Parameters.AddWithValue("@ProductName", txt_ProductName.Text);
                cmd.Parameters.AddWithValue("@Buy", txt_AmountImport.Text);
                cmd.Parameters.AddWithValue("@Sell", txt_ProductBuy.Text);
                cmd.Parameters.AddWithValue("@Qty", txt_Sell.Text);
                cmd.Parameters.AddWithValue("@ProductTypeID", cb_ProductType.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_ProductName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນທີ່ຕ້ອງການລືບ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Product where ProductID=@ProductID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@ProductID", txt_ProductID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }
    }
}
