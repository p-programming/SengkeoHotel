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
namespace SengkeoHotel
{
    public partial class frmUnit : Form
    {
        ProductController cn = new ProductController();
        ChangeColumns_Controller cl = new ChangeColumns_Controller();
        AnymessageBox ms = new AnymessageBox();
        public frmUnit()
        {
            InitializeComponent();
        }

        private void frmUnit_Load(object sender, EventArgs e)
        {
            show();
            textBox1.Text = cn.createID().ToString();
        }
        void show()
        {
            dataGridView1.DataSource = cn.get_unit();
            String[] h = { "", "", "ລະຫັດຫົວໜ່ວຍ", "ຊື່ຫົວໜ່ວຍ" };
            cl.change_columnsname(dataGridView1, h);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("ປ້ອນຊື່ຫົວໜ່ວຍ");
                textBox2.Focus();
                return;
            }
            cn.insert_unit(textBox1.Text,textBox2.Text.Trim());
            ms.INSERT_Or_SAVE_Successfull();
            textBox2.Text = "";
            textBox1.Text = cn.createID().ToString();
            show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            try {
                if (e.ColumnIndex == 0)
                {
                    cn.Update_unit(dataGridView1.Rows[r].Cells[3].Value.ToString(), dataGridView1.Rows[r].Cells[2].Value.ToString());
                    ms.UPDATE_Data_Successfull();
                    show();
                }
                if (e.ColumnIndex == 1)
                {
                    cn.delete_unit(dataGridView1.Rows[r].Cells[2].Value.ToString());
                    ms.DELETE_DataSuccessfull();
                    show();
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
