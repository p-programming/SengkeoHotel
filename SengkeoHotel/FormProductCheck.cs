using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.controller.orderProduct_controller;
using SengkeoHotel.controller;
using SengkeoHotel.dbconnection;
using SengkeoHotel.controller.Login_Controller;
namespace SengkeoHotel
{
    public partial class FormProductCheck : Form
    {
        connectdb_change cntrl1 = new connectdb_change();
        check_order_controller cntrl_check = new check_order_controller();
        ChangeColumns_Controller cntrl_col = new ChangeColumns_Controller();
        public FormProductCheck()
        {
            InitializeComponent();
        }

        private void FormProductCheck_Load(object sender, EventArgs e)
        {
            //txtUsername.Text= LoginController.employeelogined.Rows[0]["EmployeeName"].ToString();
            //txtGrant.Text = LoginController.userlogined.Rows[0]["UserAuther"].ToString();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable get = new DataTable();
            get = cntrl_check.get_productType_showRing();
            cb_ReserveName.DataSource = get;
            cb_ReserveName.DisplayMember = "ProductTypeName";
            cb_ReserveName.ValueMember = "ProductTypeID";
            cb_ReserveName.Text = "...ເລືອກປະເພດສິນຄ້າ...";
            if (cb_ReserveName.Text == "...ເລືອກປະເພດສິນຄ້າ...")
            {
                txt_RoomNo.Enabled = false;
            }
            dgv_Stock.DataSource = new DataTable();



        }
        private void cb_ReserveName_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
             
                cntrl1.da = new System.Data.SqlClient.SqlDataAdapter("Select ProductID,ProductName,Qty from check_stock where ProductTypeID='"+cb_ReserveName.SelectedValue+"'", cntrl1.cn);
                DataSet current = new DataSet();
                cntrl1.da.Fill(current);
                dgv_Stock.DataSource = current.Tables[0];
                
                String[] hearder = {"ລະຫັດສິນຄ້າ","ຊື່ສິນຄ້າ","ຈຳນວນສິນຄ້າໃນສັງ"};
                cntrl_col.change_columnsname(dgv_Stock, hearder);
               
                foreach (DataGridViewRow row in dgv_Stock.Rows)
                {
                    int qtyChoice1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                   if( qtyChoice1 <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                   if (qtyChoice1 <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
               
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txt_RoomNo_TextChanged(object sender, EventArgs e)
        {
            if (txt_RoomNo.Text != "")
            {
                cntrl1.da = new System.Data.SqlClient.SqlDataAdapter("Select ProductID,ProductName,Qty from check_stock where ProductID Like '%" + txt_RoomNo.Text + "%' Or ProductName Like N'%" + txt_RoomNo.Text + "%'", cntrl1.cn);
                cntrl1.ds = new DataSet();
                cntrl1.da.Fill(cntrl1.ds);
                dgv_Stock.DataSource = cntrl1.ds.Tables[0];
                String[] hearder = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ຈຳນວນສິນຄ້າໃນສັງ" };
                cntrl_col.change_columnsname(dgv_Stock, hearder);
            }
            if (txt_RoomNo.Text == "")
            {
                dgv_Stock.DataSource = new DataSet();
            }
        }

        private void cb_ReserveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ReserveName.SelectedIndex == 0)
            {
                cntrl1.da = new System.Data.SqlClient.SqlDataAdapter("Select ProductID,ProductName,Qty from check_stock where ProductTypeID='" + cb_ReserveName.SelectedValue + "'", cntrl1.cn);
                DataSet current = new DataSet();
                cntrl1.da.Fill(current);
                dgv_Stock.DataSource = current.Tables[0];

                String[] hearder = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ຈຳນວນສິນຄ້າໃນສັງ" };
                cntrl_col.change_columnsname(dgv_Stock, hearder);

                foreach (DataGridViewRow row in dgv_Stock.Rows)
                {
                    int qtyChoice1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                    if (qtyChoice1 <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        
                    }
                    if (qtyChoice1 <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                txt_RoomNo.Enabled = true;
            }
            else if (cb_ReserveName.SelectedIndex == 1)
            {
                cntrl1.da = new System.Data.SqlClient.SqlDataAdapter("Select ProductID,ProductName,Qty from check_stock where ProductTypeID='" + cb_ReserveName.SelectedValue + "'", cntrl1.cn);
                DataSet current = new DataSet();
                cntrl1.da.Fill(current);
                dgv_Stock.DataSource = current.Tables[0];

                String[] hearder = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ຈຳນວນສິນຄ້າໃນສັງ" };
                cntrl_col.change_columnsname(dgv_Stock, hearder);

                foreach (DataGridViewRow row in dgv_Stock.Rows)
                {
                    int qtyChoice1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                    if (qtyChoice1 <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (qtyChoice1 <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                txt_RoomNo.Enabled = true;
            }
            if (cb_ReserveName.SelectedIndex == 2)
            {
                cntrl1.da = new System.Data.SqlClient.SqlDataAdapter("Select ProductID,ProductName from check_stock where ProductTypeID='" + cb_ReserveName.SelectedValue + "'", cntrl1.cn);
                DataSet current = new DataSet();
                cntrl1.da.Fill(current);
                dgv_Stock.DataSource = current.Tables[0];
                String[] hearder = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ" };
                cntrl_col.change_columnsname(dgv_Stock, hearder);
                foreach (DataGridViewRow row in dgv_Stock.Rows)
                {
                    int qtyChoice1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                    if (qtyChoice1 <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (qtyChoice1 <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                txt_RoomNo.Enabled = true;
            }
        }


        private void cb_ReserveName_TextChanged(object sender, EventArgs e)
        {
            try {
                DataSet current = new DataSet();
                current = cntrl_check.check_ProductStock(cb_ReserveName.Text);
            } catch { }
        }
    }
}
