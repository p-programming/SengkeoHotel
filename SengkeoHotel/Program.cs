using SengkeoHotel.contrl_Sell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SengkeoHotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SengkeoHotel.room_Service_controller.ReserveBooking.frmBookingReserveDetails());
            //Application.Run(new room_Service_controller.DuplexReserve.frmDuplexReserveDetail());
            Application.Run(new FormMain());
            //Application.Run(new Form_SellProducts());
        }
    }
}
