using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.controller.sellProduct_controller;
using SengkeoHotel.controller;
using SengkeoHotel.dbconnection;
using SengkeoHotel.controller.Login_Controller;
namespace SengkeoHotel.contrl_Sell
{
    public partial class Form_SellProducts : Form
    {
        AnymessageBox ms = new AnymessageBox();
        connectdb_change cn = new connectdb_change();
        SellController cntrl_sell = new SellController();
        ChangeColumns_Controller cntrl_col = new ChangeColumns_Controller();
        public Form_SellProducts()
        {
            InitializeComponent();
            rdb_SaleRoom.Checked = false;
            rdbSaleOther.Checked = false;
        }
        private int Qty = 0;
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_SellProducts_Load(object sender, EventArgs e)
        {
            txtusers.Text = LoginController.employeelogined.Rows[0]["EmployeeName"].ToString();
            txtuseauther.Text = LoginController.userlogined.Rows[0]["UserAuther"].ToString();
            txtBillno.Text = cntrl_sell.SellBill().ToString();
            timer1.Start();
            txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            cbRoom.DataSource = cntrl_sell.get_roomComb();
            cbRoom.DisplayMember = "RoomNo";
            cbRoom.ValueMember = "RoomID";
            cbRoom.Text = ".......ເລືອກຫ້ອງ......";
            dgvRoomCheck.DataSource = new DataTable();
            dgvRoomCheck.Visible = false;

            cbProductType.DataSource = cntrl_sell.getProductType();
            cbProductType.DisplayMember = "ProductTypeName";
            cbProductType.ValueMember = "ProductTypeID";
            cbProductType.Text = ".......ເລືອກປະເພດສິນຄ້່າ......";
            dgvProStock.DataSource = new DataTable();
            rdb_SaleRoom.Checked = false;
            rdbSaleOther.Checked = false;
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet current = new DataSet();
                //cn.da = new System.Data.SqlClient.SqlDataAdapter("Select *from sell_check_Product where Barcode='"+txtBarcode.Text+"'",cn.cn);
                //cn.da.Fill(current);
                current = cntrl_sell.check_Barcode(txtBarcode.Text);
                if (current.Tables[0].Rows.Count > 0) {
                    String id = current.Tables[0].Rows[0]["ProductID"].ToString();
                    String proname = current.Tables[0].Rows[0]["ProductName"].ToString();
                    String category = current.Tables[0].Rows[0]["ProductTypeName"].ToString();
                    decimal Price = Convert.ToDecimal(current.Tables[0].Rows[0]["Sell"]);
                    int qty = 0;
                    qty = Convert.ToInt32(current.Tables[0].Rows[0]["Qty"].ToString());
                    String Unit = current.Tables[0].Rows[0]["UnitName"].ToString();
                    if (qty <= 1)
                    {
                        MessageBox.Show("product is 0");
                        return;
                    }
                    for (int sr = 0; sr < dgvProductsList.Rows.Count; sr++)
                    {
                        if (id == dgvProductsList.Rows[sr].Cells[1].Value.ToString())
                        {
                            ms.Check_DataSameProduct();
                            return;
                        }
                    }
                    dgvProductsList.Rows.Add("",id, proname, category, Price, "1",Unit);
                    txtCount.Text = dgvProductsList.Rows.Count.ToString();
                    foreach (DataGridViewRow r in dgvProductsList.Rows)
                    {
                        int n = r.Index;
                        dgvProductsList.Rows[n].Cells[7].Value = double.Parse(dgvProductsList.Rows[n].Cells[4].Value.ToString()) * double.Parse(dgvProductsList.Rows[n].Cells[5].Value.ToString());
                        double PricePro = 0, Result = 0;
                        foreach (DataGridViewRow cr in dgvProductsList.Rows)
                        {
                            PricePro = Convert.ToDouble(cr.Cells[7].Value);
                            Result = Result + PricePro;
                            txtSumPrice.Text = Result.ToString("#,###");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btRefresh_Click(object sender, EventArgs e)
        {
            dgvProStock.DataSource = cntrl_sell.Load_ProductInStock();
            String[] h = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ປະເພດສິນຄ້າ", "ລາຄາ", "ຈຳນວນຍັງເຫຼຶອ", "ຫົວໜ່ວຍ" };
            cntrl_col.change_columnsname(dgvProStock, h);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvProStock.DataSource = cntrl_sell.check_ProductInStock(txtSearch.Text);
                String[] h = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ປະເພດສິນຄ້າ", "ລາຄາ", "ຈຳນວນຍັງເຫຼຶອ","ຫົວໜ່ວຍ" };
                cntrl_col.change_columnsname(dgvProStock, h);
            }
            catch { }
        }

        private void dgvProStock_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                string id = dgvProStock.Rows[row].Cells[0].Value.ToString();
                string name = dgvProStock.Rows[row].Cells[1].Value.ToString();
                string cate = dgvProStock.Rows[row].Cells[2].Value.ToString();
                string pric = dgvProStock.Rows[row].Cells[3].Value.ToString();
                int qty = Convert.ToInt32(dgvProStock.Rows[row].Cells[4].Value.ToString());
                string unit = dgvProStock.Rows[row].Cells[5].Value.ToString();
                if (qty == 0)
                {
                    MessageBox.Show("ລາຍການສິນຄ້ານີ້ໝົດແລ້ວ ຍັງ 0 ເທົ່ານັ້ນ");
                    return;
                }
                if (dgvProductsList.Rows.Count > 0)
                {
                    for (int stock = 0; stock < dgvProductsList.Rows.Count; stock++)
                    {
                        string list_id = dgvProductsList.Rows[stock].Cells[1].Value.ToString();
                        if (list_id==id)
                        {
                            ms.Check_DataSameProduct();
                            return;
                            break;
                        }
                    }

                }
                dgvProductsList.Rows.Add("",id, name, cate, pric, "1",unit);
                txtCount.Text = dgvProductsList.Rows.Count.ToString();
                double Price = 0, Result = 0;
                foreach (DataGridViewRow r in dgvProductsList.Rows)
                {
                    for (int n = r.Index; n < dgvProductsList.Rows.Count; n++)
                    {
                        dgvProductsList.Rows[n].Cells[7].Value =(double.Parse(dgvProductsList.Rows[n].Cells[4].Value.ToString()) * double.Parse(dgvProductsList.Rows[n].Cells[5].Value.ToString()));
                        //foreach (DataGridViewRow cr in dgvProductsList.Rows)
                        //{
                        Price = Convert.ToDouble(r.Cells[7].Value);
                        Result = Result + Price;
                        txtSumPrice.Text = Result.ToString("#,###");
                        //}
                    }
                }
          }
            catch (Exception ex) {  }
       }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dl = MessageBox.Show("Do you Want to Save Sell Products", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (rdb_SaleRoom.Checked == true)
                    {
                        cntrl_sell.save_sellProduct(txtBillno.Text.Trim(), txtDate.Text.Trim(), cbRoom.SelectedValue.ToString().Trim(),LoginController.userlogined.Rows[0]["EmpID"].ToString());
                        for (int list_pro = 0; list_pro < dgvProductsList.Rows.Count; list_pro++)
                        {
                            string id = dgvProductsList.Rows[list_pro].Cells[1].Value.ToString().Trim();
                            double price = double.Parse(dgvProductsList.Rows[list_pro].Cells[4].Value.ToString().Trim());
                            int Pqty = int.Parse(dgvProductsList.Rows[list_pro].Cells[5].Value.ToString().Trim());
                            double Total = double.Parse(dgvProductsList.Rows[list_pro].Cells[7].Value.ToString().Trim());
                            cntrl_sell.save_sellProduct_Detail(id.ToString().Trim(), price.ToString().Trim(), Pqty.ToString().Trim(), Total.ToString().Trim(), txtBillno.Text.Trim());
                        }
                        for (int p = 0; p < dgvProductsList.Rows.Count; p++)
                        {
                            string id = dgvProductsList.Rows[p].Cells[1].Value.ToString().Trim();
                            int P_qty = int.Parse(dgvProductsList.Rows[p].Cells[5].Value.ToString().Trim());
                            int Sum = 0;
                            cn.da = new System.Data.SqlClient.SqlDataAdapter("Select Qty From Product Where ProductID='" + id + "'", cn.cn);
                            cn.ds = new DataSet();
                            cn.da.Fill(cn.ds);
                            Qty = Convert.ToInt32(cn.ds.Tables[0].Rows[0]["Qty"].ToString());
                            Sum = Qty - P_qty;
                            cntrl_sell.Update_instock(Sum.ToString().Trim(), id.Trim());
                        }
                        ms.INSERT_Or_SAVE_Successfull();
                        DialogResult getb = MessageBox.Show("ທ່ານຕ້ອງການພີມໃບບິນຂາຍບໍ","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if (getb == DialogResult.Yes)
                        {
                            SengkeoHotel.contrl_Sell.billno.frmSellBill f = new billno.frmSellBill(txtBillno.Text);
                            f.ShowDialog();

                            txtBillno.Text = cntrl_sell.SellBill().ToString();
                            dgvProductsList.Rows.Clear();
                            dgvProStock.DataSource = new DataTable();
                            cbProductType.Text = "";
                            cbRoom.Text = "";
                            rdbSaleOther.Checked = false;
                            rdb_SaleRoom.Checked = false;
                            rdb_SaleRoom.Enabled = true;
                            rdbSaleOther.Enabled = true;
                        }
                        else
                        {
                            txtBillno.Text = cntrl_sell.SellBill().ToString();
                            dgvProductsList.Rows.Clear();
                            dgvProStock.DataSource = new DataTable();
                            cbProductType.Text = "";
                            cbRoom.Text = "";
                            rdbSaleOther.Checked = false;
                            rdb_SaleRoom.Checked = false;
                            rdb_SaleRoom.Enabled = true;
                            rdbSaleOther.Enabled = true;
                            return;
                        }
                    }
                    if (rdbSaleOther.Checked == true)
                    {
                        cntrl_sell.save_SellProductNoRoom(txtBillno.Text.Trim(), txtDate.Text.Trim(),LoginController.userlogined.Rows[0]["EmpID"].ToString());
                        for (int list_pro = 0; list_pro < dgvProductsList.Rows.Count; list_pro++)
                        {
                            string id = dgvProductsList.Rows[list_pro].Cells[1].Value.ToString().Trim();
                            double price = double.Parse(dgvProductsList.Rows[list_pro].Cells[4].Value.ToString().Trim());
                            int Pqty = int.Parse(dgvProductsList.Rows[list_pro].Cells[5].Value.ToString().Trim());
                            double Total = double.Parse(dgvProductsList.Rows[list_pro].Cells[7].Value.ToString().Trim());
                            cntrl_sell.save_sellProduct_Detail(id.ToString().Trim(), price.ToString().Trim(), Pqty.ToString().Trim(), Total.ToString().Trim(), txtBillno.Text.Trim());
                        }
                        for (int p = 0; p < dgvProductsList.Rows.Count; p++)
                        {
                            string id = dgvProductsList.Rows[p].Cells[1].Value.ToString().Trim();
                            int P_qty = int.Parse(dgvProductsList.Rows[p].Cells[5].Value.ToString().Trim());
                            int Sum = 0;
                            cn.da = new System.Data.SqlClient.SqlDataAdapter("Select Qty From Product Where ProductID='" + id + "'", cn.cn);
                            cn.ds = new DataSet();
                            cn.da.Fill(cn.ds);
                            Qty = Convert.ToInt32(cn.ds.Tables[0].Rows[0]["Qty"].ToString());
                            Sum = Qty - P_qty;
                            cntrl_sell.Update_instock(Sum.ToString().Trim(), id.Trim());
                        }
                        ms.INSERT_Or_SAVE_Successfull();
                        DialogResult getb = MessageBox.Show("ທ່ານຕ້ອງການພີມໃບບິນຂາຍບໍ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (getb == DialogResult.Yes)
                        {
                            SengkeoHotel.contrl_Sell.billno.frmSellBill f = new billno.frmSellBill(txtBillno.Text);
                            f.ShowDialog();

                            txtBillno.Text = cntrl_sell.SellBill().ToString();
                            dgvProductsList.Rows.Clear();
                            dgvProStock.DataSource = new DataTable();
                            cbProductType.Text = "";
                            cbRoom.Text = "";
                            rdbSaleOther.Checked = false;
                            rdb_SaleRoom.Checked = false;
                            rdb_SaleRoom.Enabled = true;
                            rdbSaleOther.Enabled = true;
                        }
                        else
                        {
                            txtBillno.Text = cntrl_sell.SellBill().ToString();
                            dgvProductsList.Rows.Clear();
                            dgvProStock.DataSource = new DataTable();
                            cbProductType.Text = "";
                            cbRoom.Text = "";
                            rdbSaleOther.Checked = false;
                            rdb_SaleRoom.Checked = false;
                            rdb_SaleRoom.Enabled = true;
                            rdbSaleOther.Enabled = true;
                            return;
                        }
                    }
                }
                else { return; }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProductsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                if (e.ColumnIndex == 5)
                {
                    int QtyList = Convert.ToInt32(dgvProductsList.Rows[row].Cells[5].Value.ToString());
                    string id = dgvProductsList.Rows[row].Cells[1].Value.ToString();
                    for (int q = 0; q < dgvProStock.Rows.Count; q++)
                    {
                        string stock_id = dgvProStock.Rows[q].Cells[0].Value.ToString();
                        if (stock_id == id)
                        {
                            int stock_qty = Convert.ToInt32(dgvProStock.Rows[q].Cells[4].Value);
                            if ((stock_qty == 0))
                            {
                                MessageBox.Show("ສິນຄ້ານີ້ໝົດໃນສັງແລ້ວ ");
                                dgvProductsList.Rows.RemoveAt(row);
                            }
                            else if (QtyList > stock_qty)
                            {
                                ms.Check_DataProduct_Amount_Morethan();
                                MessageBox.Show("Product is not enough " + (QtyList - Convert.ToInt32(dgvProStock.Rows[q].Cells[4].Value) + " piece"));
                                dgvProductsList.Rows[row].Cells[5].Value = stock_qty;
                            }
                        }
                    }
                    dgvProductsList.Rows[row].Cells[7].Value = double.Parse(dgvProductsList.Rows[row].Cells[4].Value.ToString()) * double.Parse(dgvProductsList.Rows[row].Cells[5].Value.ToString());
                    double Price = 0, Result = 0;
                    foreach (DataGridViewRow cr in dgvProductsList.Rows)
                    {
                        Price = Convert.ToDouble(cr.Cells[7].Value);
                        Result = Result + Price;
                        txtSumPrice.Text = Result.ToString("#,###");
                        //txtListPrice.Text = Result.ToString();
                    }
                }
            }
            catch { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtcusPaid.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only integer");
                    txtcusPaid.Text = txtcusPaid.Text.Remove(txtcusPaid.Text.Length - 1);
                    return;
                }
                if (txtcusPaid.Text != "")
                {
                    //double payment = double.Parse(txtCusPaid.Text.ToString());
                    double Payback;
                    //double Result = double.Parse(txtTotalPaid.Text.ToString());
                    Payback = double.Parse(txtcusPaid.Text.ToString()) - double.Parse(txtSumPrice.Text.ToString());
                    txtpayback.Text = Payback.ToString("#,###");
                }
                else if (txtcusPaid.Text == "")
                {
                    txtpayback.Text = "0.000";
                }
            }
            catch { }
        }
        private void dgvRoomCheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void cbProductType_TextChanged(object sender, EventArgs e)
        {
            dgvProStock.DataSource = cntrl_sell.check_ProductInStock_OnProductType(cbProductType.Text);
            String[] h = { "ລະຫັດສິນຄ້າ", "ຊື່ສິນຄ້າ", "ປະເພດສິນຄ້າ", "ລາຄາ", "ຈຳນວນຍັງເຫຼຶອ", "ຫົວໜ່ວຍ" };
            cntrl_col.change_columnsname(dgvProStock, h);

        }

        private void dgvProductsList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    dgvProductsList.Rows.Remove(dgvProductsList.CurrentRow);
                    txtCount.Text = dgvProductsList.Rows.Count.ToString();
                    double Price = 0, Result = 0;
                    foreach (DataGridViewRow cr in dgvProductsList.Rows)
                    {
                        Price = Convert.ToDouble(cr.Cells[7].Value);
                        Result = Result + Price;
                        txtSumPrice.Text = Result.ToString("#,###");
                    }
                    if (Price <= 1)
                    {
                        txtSumPrice.Text = "0.000";
                    }
                }
            }
            catch { }
        }
        private void cbRoom_TextChanged_1(object sender, EventArgs e)
        {
            DataTable c = new DataTable();
            c = cntrl_sell.check_room(cbRoom.Text);
            dgvRoomCheck.DataSource = c;
            if (c.Rows.Count > 0)
            {
                dgvRoomCheck.Visible = true;
                String[] header = { "ລະຫັດຫ້ອງ", "ຫ້ອງເບີ" };
                cntrl_col.change_columnsname(dgvRoomCheck, header);
            }
            else
            {
                dgvRoomCheck.Visible = false;
            }
            if (cbRoom.Text == "")
            {
                dgvRoomCheck.Visible = false;
            }
        }

        private void dgvRoomCheck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cbRoom.Text = dgvRoomCheck.CurrentRow.Cells[1].Value.ToString();
                dgvRoomCheck.Visible = false;
            }
            catch { }
        }

        private void rdb_SaleRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_SaleRoom.Checked == true)
            {
                cbRoom.Enabled = true;
                dgvRoomCheck.Enabled = true;
                rdbSaleOther.Enabled = false;
                btRefresh.Enabled = true;
                txtSearch.Enabled = true;
                cbProductType.Enabled = true;
                dgvProStock.Enabled = true;

            }
            else
            {
                cbRoom.Enabled = false;
                dgvRoomCheck.Enabled = false;
                btRefresh.Enabled = false;
                txtSearch.Enabled = false;
                cbProductType.Enabled = false;
                dgvProStock.Enabled = false;
            }
        }

        private void rdbSaleOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSaleOther.Checked == true)
            {
                cbRoom.Enabled = false;
                dgvRoomCheck.Enabled = false;
                txtcusemail.Text = "";
                txtCustel.Text = "";
                txtCustomer.Text = "";
                cbRoom.Text = ".......ເລືອກຫ້ອງ......";
                rdb_SaleRoom.Enabled = false;
                btRefresh.Enabled = true;
                txtSearch.Enabled = true;
                cbProductType.Enabled = true;
                dgvProStock.Enabled = true;
            }
            else
            {
                cbRoom.Enabled = true;
                dgvRoomCheck.Enabled = true;
                btRefresh.Enabled = false;
                txtSearch.Enabled = false;
                cbProductType.Enabled = false;
                dgvProStock.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            rdbSaleOther.Checked = false;
            rdb_SaleRoom.Checked = false;
            rdbSaleOther.Enabled = true;
            rdb_SaleRoom.Enabled = true;
            cbRoom.Text = ".......ເລືອກຫ້ອງ......";
        }
    }
}
