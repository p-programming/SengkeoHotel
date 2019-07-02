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
using SengkeoHotel.cntrl_order;
using SengkeoHotel.controller;
namespace SengkeoHotel.cntrl_order
{
    public partial class From_AddSupp : Form
    {
        order_detail_controller cntrl = new order_detail_controller();
        AnymessageBox ms = new AnymessageBox();
        public From_AddSupp()
        {
            InitializeComponent();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dl = MessageBox.Show("Do you want to add new Supplier","System",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (txtid.Text == "" || txtname.Text == "")
                    {
                        ms.Check_DataEmpty();
                        txtname.Focus();
                        return;
                    }
                    cntrl.insert_supplier(txtid.Text.Trim(), txtname.Text.Trim(), txtaddr.Text.Trim(), txttel.Text.Trim());
                    SengkeoHotel.cntrl_order.Form_OrderProducts or = new Form_OrderProducts();
                    Form_OrderProducts.Supaddr =  txtaddr.Text;
                    Form_OrderProducts.supptel = txttel.Text;
                    Form_OrderProducts.suppname = txtname.Text;
                    txtid.Text = cntrl.create_id().ToString();
                    MessageBox.Show("Save new Supplier Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else { return; }
            }
            catch { }
        }

        private void From_AddSupp_Load(object sender, EventArgs e)
        {
            txtid.Text = cntrl.create_id().ToString();
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txttel.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only number");
                txttel.Text = txttel.Text.Remove(txttel.Text.Length - 1);
                return;
            }
        }
    }
}
