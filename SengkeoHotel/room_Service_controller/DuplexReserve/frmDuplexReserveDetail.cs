using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SengkeoHotel.controller.controller_service_room.duplexreserve_controller;
using SengkeoHotel.controller;
namespace SengkeoHotel.room_Service_controller.DuplexReserve
{
    public partial class frmDuplexReserveDetail : Form
    {
        duplexreserveController cn = new duplexreserveController();
        ChangeColumns_Controller cnl = new ChangeColumns_Controller();
        AnymessageBox ms = new AnymessageBox();
        public frmDuplexReserveDetail()
        {
            InitializeComponent();
        }
        private void frmDuplexReserveDetail_Load(object sender, EventArgs e)
        {
            btadd.Enabled = true;
            show(cn.get_Reserve("50",false));
        }
        void show(DataTable Duplex)
        {
            //DataTable d = new DataTable();
            //d = cn.get_Reserve("50", false);
            dgvDuplex.DataSource = Duplex;
            String[] header = { "", "", "ລະຫັດຈອງ", "ຊື່ລູກຄ້າ","ເບີໂທ", "ວັນຈອງ", "ວັນຈັດງານ", "ລວມເງິນທັງໝົດ", "ຄ່າມັດຈຳ", "ຍອດຄົງເຫຼຶອ" };
            cnl.change_columnsname(dgvDuplex, header);
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            room_Service_controller.DuplexReserve.frmDuplexReservemanage f = new frmDuplexReservemanage("");
            f.btSave.Visible = true;
            f.ShowDialog();
            show(cn.get_Reserve("50", false));
        }

        private void dgvDuplex_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    String DRseid = "";
                    DataGridViewRow dgv = new DataGridViewRow();
                    dgv = this.dgvDuplex.Rows[e.RowIndex];
                    DRseid = dgv.Cells["DResID"].Value.ToString();
                    SengkeoHotel.room_Service_controller.DuplexReserve.frmDuplexReservemanage f = new frmDuplexReservemanage(DRseid);
                    show(cn.get_Reserve("50", false));
                    f.btUpdate.Visible = true;
                    f.btSave.Visible = false;
                    f.ShowDialog();
                    show(cn.get_Reserve("50", false));
                }
                if (e.ColumnIndex == 1) {
                    int row = dgvDuplex.CurrentRow.Index;
                    DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການລຶບຂໍ້ມຸນນີ້ບໍ", "ຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl == DialogResult.Yes)
                    {
                        cn.Delete_DuplexReserve(dgvDuplex[2,row].Value.ToString());
                        ms.DELETE_DataSuccessfull();
                        show(cn.get_Reserve("50", false));
                    }
                    else {
                        return;
                    }
                }
            }
            catch
            {

            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable r = new DataTable();
                r = cn.Search_Reserve(toolStripTextBox1.Text);
                if (r.Rows.Count > 0)
                {
                    dgvDuplex.DataSource = r;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
