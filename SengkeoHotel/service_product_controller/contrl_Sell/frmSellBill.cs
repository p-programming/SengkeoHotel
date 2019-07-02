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
namespace SengkeoHotel.contrl_Sell.billno
{
    public partial class frmSellBill : Form
    {
        SellController b = new SellController();
        String getbill = "";
        public frmSellBill(String setbill)
        {
            InitializeComponent();
            getbill = setbill;
        }

        private void frmSellBill_Load(object sender, EventArgs e)
        {
            if (getbill.ToString() != "")
            {
                b.Get_SaleBillNo(getbill);
                SellBillNo rp = new SellBillNo();
                rp.SetDataSource(b.dtr);
                crystalReportViewer1.ReportSource = rp;
                crystalReportViewer1.RefreshReport();
            }
        }
    }
}
