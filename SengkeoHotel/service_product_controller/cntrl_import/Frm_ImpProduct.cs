using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.cntrl_import;
using SengkeoHotel.controller;
using SengkeoHotel.controller.Login_Controller;
using SengkeoHotel.controller.importProduct_controller;
using SengkeoHotel.dbconnection;
namespace SengkeoHotel.cntrl_import
{
    public partial class Frm_ImpProduct : Form
    {
        AnymessageBox ms = new AnymessageBox();
        connectdb_change cn = new connectdb_change();
        LoginController get_user = new LoginController();
        Import_controller cntrl_import = new Import_controller();
        ChangeColumns_Controller cntrl_col = new ChangeColumns_Controller();
        private String St1 = "Ordered", St2 = "Imported";
        public Frm_ImpProduct()
        {
            InitializeComponent();
        }
        public DataGridViewRow row;
        private void Frm_ImpProduct_Load(object sender, EventArgs e)
        {
            DataTable d = new DataTable();

            txtEmp.Text = LoginController.employeelogined.Rows[0]["EmployeeName"].ToString();
            cbOrderBill.DataSource = cntrl_import.get_OrderID();
            cbOrderBill.DisplayMember = "OrderID";
            cbOrderBill.ValueMember = "OrderID";
            timer1.Start();
            txtdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            cbOrderBill.Text = "....ເລືອກລະຫັດໃບບິນສັ່ງຊຶ້....";
            //dgvImport.Rows.Clear();
            dgvImport.DataSource = new DataTable();
            try {
                dgvImport.Rows.Add(row.Cells[2].Value);
            }
            catch { }
            if (dgvImport.Rows.Count <= 0)
            {
                for (int i = 0; i < dgvImport.Rows.Count; i++) ;
                double pr = 0, sum = 0;
                foreach (DataGridViewRow cr in dgvImport.Rows)
                {
                    dgvImport.Rows.Clear();
                    pr = Convert.ToDouble(cr.Cells[9].Value);
                    sum = sum + pr;
                    label5.Text = sum.ToString("#,###");
                }
            }
        }

        private void cbOrderBill_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet current_st = new DataSet();
            current_st = cntrl_import.check_orderStatus(cbOrderBill.Text);
            String st = current_st.Tables[0].Rows[0]["OrderStatus"].ToString();
            if (st == St2)
            {
                    ms.Check_DataImpor_had_In_System();
                return;
            }
            if (st == St1)
            {
                //DataSet current = new DataSet();
                //current = cntrl_import.chec_OrderBill(cbOrderBill.Text);
                //for (int i = 0; i < current.Tables[0].Rows.Count; i++)
                //    {
                //dgvImport.Rows.Add(current.Tables[0].Rows[i][1].ToString());
                //        //current.Tables[0].Rows[i][2].ToString(),
                //        //current.Tables[0].Rows[i][3].ToString(),
                //        //current.Tables[0].Rows[i][4].ToString(),
                //        //current.Tables[0].Rows[i][5].ToString(),
                //        //current.Tables[0].Rows[i][6].ToString(),
                //        //current.Tables[0].Rows[i][7].ToString(), "1000", "1");
                dgvImport.DataSource = cntrl_import.chec_OrderBill(cbOrderBill.Text);
                String[] headername = { "","ວັນທີ", "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ປະເພດສິນຄ້າ", "ຈຳນວນສ້່ງຊື້","ຜູ້ສະໜອງ", "ລາຄາຊື້", "ຈຳນວນນເຂົ້າ", "ລວມທັງໝົດ" };
                cntrl_col.change_columnsname(dgvImport, headername);
                textBox3.Text = dgvImport.Rows.Count.ToString();
                foreach (DataGridViewRow r in dgvImport.Rows)
                {
                        int n = r.Index;
                        dgvImport.Rows[n].Cells[9].Value = int.Parse(dgvImport.Rows[n].Cells[7].Value.ToString()) * int.Parse(dgvImport.Rows[n].Cells[8].Value.ToString());
                        double pr = 0, sum = 0;
                        pr = Convert.ToDouble(r.Cells[9].Value);
                        sum = sum + pr;
                        label5.Text = sum.ToString("#,###");
                }
              }
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການຍົກເລີກຫຼືບໍ","ຢືນຢັນ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                if (dgvImport.Rows.Count < 1)
                {
                    return;
                }
                if (dgvImport.Rows.Count > 1)
                {
                    dgvImport.DataSource = "";
                }
            }
            else { return; }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            SengkeoHotel.cntrl_import.frmShowProductInStock f = new frmShowProductInStock();
            f.ShowDialog();
        }

        private void dgvImport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    DialogResult dl = MessageBox.Show("Do you want to remove this products???", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl == DialogResult.Yes)
                    {
                        dgvImport.Rows.Remove(dgvImport.CurrentRow);
                        textBox3.Text = dgvImport.Rows.Count.ToString();
                        for (int i = 0; i < dgvImport.Rows.Count; i++) ;
                        double pr = 0, sum = 0;
                        foreach (DataGridViewRow cr in dgvImport.Rows)
                        {
                            pr = Convert.ToDouble(cr.Cells[9].Value);
                            sum = sum + pr;
                            label5.Text = sum.ToString("#,###");
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch { }
        }

        private void dgvImport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                if (e.ColumnIndex == 7)
                {
                    dgvImport.Rows[row].Cells[9].Value = double.Parse(dgvImport.Rows[row].Cells[7].Value.ToString()) * double.Parse(dgvImport.Rows[row].Cells[8].Value.ToString());
                    for (int i = 0; i < dgvImport.Rows.Count; i++) ;
                    double pr = 0, sum = 0;
                    foreach (DataGridViewRow cr in dgvImport.Rows)
                    {
                        pr = Convert.ToDouble(cr.Cells[9].Value);
                        sum = sum + pr;
                        label5.Text = sum.ToString("#,###");
                    }
                }
                if (e.ColumnIndex == 8)
                {
                    dgvImport.Rows[row].Cells[9].Value = double.Parse(dgvImport.Rows[row].Cells[7].Value.ToString()) * double.Parse(dgvImport.Rows[row].Cells[8].Value.ToString());
                    for (int i = 0; i < dgvImport.Rows.Count; i++) ;
                    double pr = 0, sum = 0;
                    foreach (DataGridViewRow cr in dgvImport.Rows)
                    {
                        pr = Convert.ToDouble(cr.Cells[9].Value);
                        sum = sum + pr;
                        label5.Text = sum.ToString("#,###");
                    }
                }

            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຫຼືບໍ?", "ຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (dgvImport.Rows.Count < 1)
                    {
                        ms.Check_DataEmpty();
                        return;
                    }
                    DataSet current_St = new DataSet();
                    current_St = cntrl_import.check_orderStatus(cbOrderBill.Text);
                    String st = current_St.Tables[0].Rows[0]["OrderStatus"].ToString();
                    if (st == St2)
                    {
                        return;
                    }
                    if (st == St1)
                    {
                        DataTable d = new DataTable();
                        d = cntrl_import.check_current(cbOrderBill.Text);
                        if (d.Rows.Count > 0)
                        {
                            return;
                        }
                        cntrl_import.Save_importProduct(cbOrderBill.Text, txtdate.Text,LoginController.userlogined.Rows[0]["EmpID"].ToString());
                        cntrl_import.Update_OrderProduct_Status(St2.ToString(), cbOrderBill.Text);
                                for (int i = 0; i < dgvImport.Rows.Count; i++)
                                {
                                    String id = dgvImport.Rows[i].Cells[2].Value.ToString();
                                    String Price = dgvImport.Rows[i].Cells[7].Value.ToString();
                                    String qty = dgvImport.Rows[i].Cells[8].Value.ToString();
                                    String total = dgvImport.Rows[i].Cells[9].Value.ToString();
                                    cntrl_import.Save_importDetail(id.ToString().Trim(), Price.Trim().ToString(), qty.Trim().ToString(), cbOrderBill.Text, total.Trim().ToString());
                                }
                                for (int up = 0; up < dgvImport.Rows.Count; up++)
                                {
                                    String upProid = dgvImport.Rows[up].Cells[2].Value.ToString();
                                    int upProqty = int.Parse(dgvImport.Rows[up].Cells[8].Value.ToString());
                                    DataTable current = new DataTable();
                                    current = cntrl_import.plus_qty(upProid);
                                    int stock = int.Parse(current.Rows[0]["Qty"].ToString());
                                    int sum = 0;
                                    sum = int.Parse(stock.ToString()) + int.Parse(upProqty.ToString());
                                    cntrl_import.Update_Product(sum.ToString(), upProid.ToString());
                                }
                            }
                        ms.INSERT_Or_SAVE_Successfull();
                        dgvImport.DataSource = new DataTable(); ;
                textBox3.Text = dgvImport.Rows.Count.ToString();
                label5.Text = "0.000";
            }
            else
            {
                return;
            }
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message); } 
        }
    }
}
