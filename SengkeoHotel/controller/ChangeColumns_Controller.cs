using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SengkeoHotel.controller
{
    class ChangeColumns_Controller
    {
        public void change_columnsname(DataGridView dgv, String[] header)
        {
            int columns_total = dgv.Columns.Count;
            for (int i =0; i <= columns_total - 1; i++)
            {
                dgv.Columns[i].HeaderText = header[i];
            }
        }
    }
}
