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
    public partial class FormEmployeeCard : Form
    {
        public FormEmployeeCard()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        public void Showdata()
        {
            da = new SqlDataAdapter("Select A.EmployeeID,A.EmployeeName,A.EmployeeSurname,C.PositionName,A.PathPicture from Employee as A join Position as C on A.PositionID=C.PositionID", cd.ActiveCon());
            da.Fill(ds, "j");
            ds.Tables[0].Clear();
            da.Fill(ds, "j");
            dataGridView1.DataSource = ds.Tables[0];        
            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ຊື່";
            dataGridView1.Columns[2].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[3].HeaderText = "ຕຳແໜ່ງ";
            dataGridView1.Columns[4].HeaderText = "ຮູບ";
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 160;
            dataGridView1.Refresh();
        }
        private void FormEmployeeCard_Load(object sender, EventArgs e)
        {
            Showdata();
            txtpath.Hide();
            txtnum.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            label3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            label10.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtpath.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            pictureBox1.ImageLocation = txtpath.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບກ່ອນ");
            }
            else
            {
                string sql = " select EmployeeID,EmployeeName,EmployeeSurname,PositionName  from PrintCard  where EmployeeID  ='" + label2.Text + "'";
                for (int i = 1; i < int.Parse(txtnum.Text); i++)
                {
                    sql = sql + " Union All select EmployeeID,EmployeeName,EmployeeSurname,PositionName  from PrintCard  where EmployeeID  ='" + label2.Text + "'";
                }
                da = new SqlDataAdapter(sql, cd.ActiveCon());
                da.Fill(ds, "b");
                ds.Tables["b"].Clear();
                da.Fill(ds, "b");
                    
                PrintEmployeeCard F_Print = new PrintEmployeeCard();
                CrystalReport1 rp = new CrystalReport1();
                rp.SetDataSource(ds.Tables["b"]);
                F_Print.crystalReportViewer1.ReportSource = rp;
                F_Print.Show();
            }

            }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtpath_Click(object sender, EventArgs e)
        {

        }
    }
}
