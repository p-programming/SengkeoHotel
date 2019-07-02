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
namespace SengkeoHotel.cntrl_order
{
    
    public partial class frmOrderBill : Form
    {
        order_detail_controller b = new order_detail_controller();
        String getbill = "";
        public frmOrderBill(String setbill)
        {
            InitializeComponent();
            getbill = setbill;
        }

        private void frmOrderBill_Load(object sender, EventArgs e)
        {
            if (getbill.ToString() != "")
            {
                b.OrderBllNo(getbill);
                OrderBillNo rb = new OrderBillNo();
                rb.SetDataSource(b.dtr);
                crystalReportViewer1.ReportSource = rb;
                crystalReportViewer1.RefreshReport();
            }
        }
    }
}
