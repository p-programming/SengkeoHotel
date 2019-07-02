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
namespace SengkeoHotel.cntrl_order
{
    public partial class Form_OrderProducts : Form
    {

        connectdb_change cn = new connectdb_change();
        order_detail_controller cntrl_order = new order_detail_controller();
        ChangeColumns_Controller cntrl_col = new ChangeColumns_Controller();
        LoginController cntrl_login = new LoginController();
        DataGridViewRow[] rowselected;
        AnymessageBox Msg = new AnymessageBox();
        private String st1 = "Ordered", st2= "Imported";
        public Form_OrderProducts()
        {
            InitializeComponent();
            
        }
        public static string suppid, suppname, Supaddr, supptel=null;
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Form_OrderProducts_Load(object sender, EventArgs e)
        {
            txtEmp.Text = LoginController.employeelogined.Rows[0]["EmployeeName"].ToString();
            timer1.Start();
            cbSupp.DataSource = cntrl_order.get_supplier();
            cbSupp.DisplayMember = "SupplierName";
            cbSupp.ValueMember = "SupplierID";
            cbSupp.Text = "...ເລືອກຜູ່ສະໜອງ...";
            txtBill.Text = cntrl_order.billNo().ToString();
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            txtDate.Text = date.ToString();

            dgvProStock.DataSource = cntrl_order.getProduct_instock();
            String[] headername = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ປະເພດສິນຄ້າ", "ຈຳນວນ","ຫົວໜ່ວຍ" };
            cntrl_col.change_columnsname(dgvProStock, headername);
            foreach (DataGridViewRow row in dgvProStock.Rows)
            {
                int qtyChoice1 = Convert.ToInt32(row.Cells[3].Value.ToString());
                if (qtyChoice1 <= 10)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (qtyChoice1 <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void txtQTy_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQTy.Text, "[^0-9]"))
            {
                MessageBox.Show("ກະລູນາປ້ອນສະເພາະຕົວເລກ");
                txtQTy.Text = txtQTy.Text.Remove(txtQTy.Text.Length - 1);
                return;
            }
            DataTable current = new DataTable();
            current= cntrl_order.check_ProductInstock(txtQTy.Text);
           
               dgvProStock.DataSource = current;
               String[] headername = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ປະເພດສິນຄ້າ", "ຈຳນວນ" ,"ຫົວໜ່ວຍ"};
               cntrl_col.change_columnsname(dgvProStock, headername);
            foreach (DataGridViewRow row in dgvProStock.Rows)
            {
                int qtyChoice1 = Convert.ToInt32(row.Cells[3].Value.ToString());
                if (qtyChoice1 <= 10)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (qtyChoice1 <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
           
        }

        private void btaddSupp_Click(object sender, EventArgs e)
        {
            SengkeoHotel.cntrl_order.From_AddSupp f = new From_AddSupp();
            f.ShowDialog();
            txtSupAddr.Text = Supaddr;
            txtSupTel.Text = supptel;
            cbSupp.Text = suppname;
            cbSupp.DataSource = cntrl_order.get_supplier();
        }

        private void cbSupp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSupp.Text != "")
                {
                    DataTable current = new DataTable();
                    cn.da = new System.Data.SqlClient.SqlDataAdapter("Select *from Supplier where SupplierID='" + cbSupp.SelectedValue + "'", cn.cn);
                    cn.da.Fill(current);
                    txtSupAddr.Text = current.Rows[0]["SupplierAddress"].ToString();
                    txtSupTel.Text = current.Rows[0]["SupplierTel"].ToString();
                }
                else
                {
                    txtSupAddr.Text = "";
                    txtSupTel.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void dgvProStock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                if (dgvProStock.Rows.Count < 1)
                {
                    Msg.Check_DataEmpty();
                    return;
                }

                    String id = dgvProStock.Rows[row].Cells[0].Value.ToString();
                    String proname = dgvProStock.Rows[row].Cells[1].Value.ToString();
                    String cate = dgvProStock.Rows[row].Cells[2].Value.ToString();
                    int qty = Convert.ToInt32(dgvProStock.Rows[row].Cells[3].Value.ToString());
                String unitname = dgvProStock.Rows[row].Cells[4].Value.ToString();
                for (int stock = 0; stock < dgv_list.Rows.Count; stock++)
                {
                    string list_id = dgv_list.Rows[stock].Cells[0].Value.ToString();
                    if (id == list_id)
                    {
                        Msg.Check_DataSameProduct();
                        return;
                        break;
                    }
                }
                dgv_list.Rows.Add(id, proname, cate, "1",unitname); 
            }
            catch { }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການຍົກເລີກຫຼືບໍ?", "ຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                if (dgv_list.Rows.Count < 1) {

                    return;
                }
                if (dgv_list.Rows.Count > 1)
                {
                    dgv_list.Rows.Clear();
                    cbSupp.Text = "";
                }
            }
            else { return; }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຫຼືບໍ?","ຟ້ອງຈາກລະບົບ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (dgv_list.Rows.Count <= 0 || cbSupp.Text == "")
                    {
                        Msg.Check_DataEmpty();
                        return;
                    }
                        cntrl_order.insert_OrderProduct(txtBill.Text.Trim(), txtDate.Text.Trim(),st1.ToString(),LoginController.userlogined.Rows[0]["EmpID"].ToString(), cbSupp.SelectedValue.ToString());
                        for (int n = 0; n < dgv_list.Rows.Count; n++)
                        {
                            string id = dgv_list.Rows[n].Cells[0].Value.ToString();
                            string qty = dgv_list.Rows[n].Cells[3].Value.ToString();
                        cntrl_order.insert_OrderDetail(id.ToString().Trim(), qty.ToString().Trim(), txtBill.Text.Trim());
                    }
                    Msg.INSERT_Or_SAVE_Successfull();
                    DialogResult bill = MessageBox.Show("ທ່ານຕ້ອງການພີມໃບບິນບໍ?", "ຟ້ອງຈາກລະບົບ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (bill == DialogResult.Yes)
                    {
                        SengkeoHotel.cntrl_order.frmOrderBill f = new frmOrderBill(txtBill.Text);
                        f.ShowDialog();
                        txtBill.Text = cntrl_order.billNo().ToString();
                        dgv_list.Rows.Clear();
                        cbSupp.Text = "";
                    }
                    else
                    {
                        txtBill.Text = cntrl_order.billNo().ToString();
                        dgv_list.Rows.Clear();
                        cbSupp.Text = "";
                    }
                   
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
        private void dgv_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    dgv_list.Rows.Remove(dgv_list.CurrentRow);
                }
            }
            catch { }
        }
        private void btAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btAddAll_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            try
            {
               
                if (dgvProStock.Rows.Count < 1)
                {
                    MessageBox.Show("Product Is empty");
                    return;
                }
                if (dgvProStock.Rows.Count > 0)
                {
                    for(int i = 0; i <dgvProStock.Rows.Count ; i++)
                    {
                        if (dgvProStock.Rows[i].Cells[i].Value != null)
                        {
                            row = (DataGridViewRow)dgvProStock.Rows[i].Clone();
                            int intindex = 0;
                            foreach (DataGridViewCell cel in dgvProStock.Rows[i].Cells)
                            {
                                row.Cells[intindex].Value = cel.Value;
                                intindex++;
                            }
                            dgv_list.Rows.Add(row);
                        } 
                    }
                }
            }
            catch
            {

            }
        }
    }
}
