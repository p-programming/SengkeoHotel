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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";

        public void Clear()
        {
            txt_CusID.Clear();
            txt_CusName.Clear();
            txt_CusSurname.Clear();
            txt_CusTel.Clear();
            txt_CusEmail.Clear();
            txt_CusCardNo.Clear();
            CreateNews();
            cmb_CusCardType.Focus();          
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ClosePro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            cmb_CusCardType.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_CusID.Enabled = false;
            txt_CusName.Focus();
            cd.ActiveCon();
            CreateNews();
            Showdata();
            NewCustomers();
            
        }
        private void NewCustomers()
        {
            da = new SqlDataAdapter("select * from CardType", cd.ActiveCon());
            var dsType = new DataSet();
            da.Fill(dsType, "Type");
            cmb_CusCardType.DataSource = dsType.Tables["Type"];
            cmb_CusCardType.DisplayMember = "CardTypeName";
            cmb_CusCardType.ValueMember = "CardTypeID";
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            cmb_CusCardType.Refresh();
            Clear();
        }
        void CreateNews()
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("New_Customer", con.ActiveCon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txt_CusID.Text = dt.Rows[0][0].ToString();
            
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Customer Where CustomerID=@CustomerID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("CustomerID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Akon");
            ds.Tables["Akon"].Clear();
            da.Fill(ds, "Akon");
            if (ds.Tables["Akon"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select A.CustomerID,A.CustomerName,A.CustomerSurname,A.Tel,A.Email,A.CardNo,B.CardTypeName From Customer As A join CardType as B on A.CardTypeID=B.CardTypeID", cd.ActiveCon());
            da.Fill(ds,"Cus");
            ds.Tables[0].Clear();
            da.Fill(ds,"Cus");
            DGV_Cus.DataSource = ds.Tables[0];
            DGV_Cus.Columns[0].HeaderText = "ລະຫັດລູກຄ້າ";
            DGV_Cus.Columns[1].HeaderText = "ຊື່";
            DGV_Cus.Columns[2].HeaderText = "ນາມສະກຸນ";
            DGV_Cus.Columns[3].HeaderText = "ເບີໂທ";
            DGV_Cus.Columns[4].HeaderText = "ອີເມວ";
            DGV_Cus.Columns[5].HeaderText = "ເລກທີບັດ";
            DGV_Cus.Columns[6].HeaderText = "ປະເພດບັດ";
            DGV_Cus.Columns[0].Width = 120;
            DGV_Cus.Columns[1].Width = 120;
            DGV_Cus.Columns[2].Width = 130;
            DGV_Cus.Columns[3].Width = 140;
            DGV_Cus.Columns[4].Width = 150;
            DGV_Cus.Columns[5].Width = 130;
            DGV_Cus.Columns[6].Width = 140;
            DGV_Cus.Refresh();

        }

        private void DGV_Cus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_Cus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                     
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_CusID.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດລູກຄ້າກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txt_CusName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ລູກຄ້າກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_CusID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Sql = @"insert into Customer values(@CustomerID,@CustomerName,@CustomerSurname,@Tel,@Email,@CardNo,@CardtypeID)";
                    cmd = new SqlCommand(Sql, cd.ActiveCon());
                    cmd.Parameters.AddWithValue("CustomerID", txt_CusID.Text);
                    cmd.Parameters.AddWithValue("CustomerName", txt_CusName.Text);
                    cmd.Parameters.AddWithValue("CustomerSurname", txt_CusSurname.Text);
                    cmd.Parameters.AddWithValue("Tel", txt_CusTel.Text);
                    cmd.Parameters.AddWithValue("Email", txt_CusEmail.Text);
                    cmd.Parameters.AddWithValue("CardNo", txt_CusCardNo.Text);
                    cmd.Parameters.AddWithValue("CardTypeID", cmb_CusCardType.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    Showdata();                  
                    cmb_CusCardType.SelectedIndex = 0;
                    Clear();
                }
        }

        private void txt_CusTel_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txt_CusTel.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.","Stop",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            //    txt_CusTel.Text = txt_CusTel.Text.Remove(txt_CusTel.Text.Length - 1);
            //}
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_CusName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນເພື່ອຕ້ອງການແກ້ໄຂກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການແກ້ໄຂຂໍ້ມູນ ຫຼື ບໍ່?", "ແກ້ໄຂ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Customer set CustomerName=@CustomerName,CustomerSurname=@CustomerSurname,Tel=@Tel,Email=@Email,CardNo=@CardNo,CardTypeID=@CardTypeID where CustomerID=@CustomerID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("CustomerID", txt_CusID.Text);
                cmd.Parameters.AddWithValue("CustomerName", txt_CusName.Text);
                cmd.Parameters.AddWithValue("CustomerSurname", txt_CusSurname.Text);
                cmd.Parameters.AddWithValue("Tel", txt_CusTel.Text);
                cmd.Parameters.AddWithValue("Email", txt_CusEmail.Text);
                cmd.Parameters.AddWithValue("CardNo", txt_CusCardNo.Text);
                cmd.Parameters.AddWithValue("CardTypeID", cmb_CusCardType.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_CusName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຂໍ້ມູນທີ່ຕ້ອງການລືບເສຍກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(" ທ່ານຕ້ອງການລືບຂໍ້ມູນ ຫຼື ບໍ່?", "ບໍ່ລືບ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"DELETE FROM Customer WHERE CustomerID=@CustomerID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("CustomerID", txt_CusID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void DGV_Cus_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txt_CusID.Text = DGV_Cus.CurrentRow.Cells[0].Value.ToString();
            txt_CusName.Text = DGV_Cus.CurrentRow.Cells[1].Value.ToString();
            txt_CusSurname.Text = DGV_Cus.CurrentRow.Cells[2].Value.ToString();
            txt_CusTel.Text = DGV_Cus.CurrentRow.Cells[3].Value.ToString();
            txt_CusEmail.Text = DGV_Cus.CurrentRow.Cells[4].Value.ToString();
            txt_CusCardNo.Text = DGV_Cus.CurrentRow.Cells[5].Value.ToString();
            cmb_CusCardType.Text = DGV_Cus.CurrentRow.Cells[6].Value.ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCardType ec = new FormCardType();
            ec.StartPosition = FormStartPosition.CenterScreen;
            ec.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
