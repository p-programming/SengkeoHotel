using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.controller.importProduct_controller;
using SengkeoHotel.controller;
namespace SengkeoHotel.cntrl_import
{
    public partial class frmShowProductInStock : Form
    {
        Import_controller cntrl_imp = new Import_controller();
        ChangeColumns_Controller cl = new ChangeColumns_Controller();
        public frmShowProductInStock()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmShowProductInStock_Load(object sender, EventArgs e)
        {
            //DataTable cur = new DataTable();
            dgv_Products.DataSource  = cntrl_imp.Show_ProductImport_InStock("50",false);
            String[] h = { "ລະຫັດສິນຄ້າ","ຊື່ສິນຄ້າ","ປະເພດສິນຄ້າ","ຈຳນວນນຳເຂົ້າ","ຈຳນວນຍັງເຫຼຶອໃນສັງ"};
            cl.change_columnsname(dgv_Products, h);
        }
    }
}
