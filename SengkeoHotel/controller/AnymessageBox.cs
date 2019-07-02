using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace SengkeoHotel.controller
{
    class AnymessageBox
    {
        public void CheckQty()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ກວດສອບຈຳນວນຄືນໃໝ່";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void INSERT_Or_SAVE_Successfull()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ບັນທຶກຂໍ້ມູນສຳເລັດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void    INSERT_DATA_Error()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ບັນທຶກຂໍ້ມູນບໍ່ສຳເລັດ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();

        }
        public void Check_DataEmpty()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataQtyInstock(string Qty)
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            //mss.ContentText = "";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_exitingDataIN_SYSTEM()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ຂໍ້ມູນນີ້ມີຢູ່ໃນລະບົບສຳເລັດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void DELETE_DataSuccessfull()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ລຶບຂໍ້ມູນສຳເລັດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void DELETE_Error()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ລຶບຂໍ້ມູນບໍ່ສຳເລັດ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void UPDATE_Data_Successfull()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ແກ້ໄຂຂໍ້ມູນສຳເລັດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void UPDATE_Data_Error()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ແກ້ໄຂຂໍ້ມູນບໍ່ສຳເລັດ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void SellProduct_Successfullty()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ຂາຍສິນຄ້າສິນຄ້າສຳເລັດ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataProduct_Amount_Morethan()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ຂໍ້ມູນທີ່ທ່ານປ້ອນຫຼາຍກວ່າໃນສາງ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_Data_AmountLessthan()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ກະລຸນກວດສອບຄ່າຈຳນວນກ່ອນ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataProductQtyLess()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ສິນຄ້ານີ້ໃນສາງໝົດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataQtyInputMorethan()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ຈຳນວນທີ່ທ່ານປ້ອນຫຼາຍກວ່າຈຳນວນທີ່ໄດ້ສັ່ງຊື້";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataCurrent_Can_not_DELETE()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ບໍ່ສາມາດລຶບຂໍ້ມູນນີ້";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataImpor_had_In_System()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ຂໍ້ມູນລາຍການນີ້ໄດ້ນຳເຂົ້າແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataSameProduct()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ສິນຄ້ານີ້ໄດ້ເພີ່ມໄປແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataSame()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ຂໍ້ມູນນີ້ມີຢູ່ໃນລະບົບແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_DataCurrentError()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ການຢືນຢັນລົ້ມເຫຼວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Check_PassConfrimNotCurrent()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ລະຫັດຢືນຢັນ ແລະ ລະຫັດຜ່ານບໍ່ກົງກັນ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void Login_Successfully()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ເຂົ້າສູ່ລະບົບສຳເລັດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void createUsers_Successfully()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ຟ້ອງຈາກລະບົບ";
            mss.ContentText = "ລົງທະບຽນສຳເລັດແລ້ວ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void LoginFailed()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ເຂົ້າສູ່ລະບົບບໍ່ສຳເລັດ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void PriceLessThan()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ລາຄາທີ່ທ່ານປ້ອນນ້ອຍກວ່າລາຄາເດີມ";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
        public void DateLessThan()
        {
            PopupNotifier mss = new PopupNotifier();
            mss.Size = new System.Drawing.Size(270, 100);
            mss.BodyColor = Color.Black;
            mss.BorderColor = Color.Azure;
            mss.ContentFont = new System.Drawing.Font("Phetsarath OT", 11, FontStyle.Bold);
            mss.TitleFont = new System.Drawing.Font("Phetsarath OT", 14, FontStyle.Bold);
            mss.TitleText = "ກວດສອບໃໝ່";
            mss.ContentText = "ກະລຸນາກວດສອບວັນທີໃໝ່";
            mss.HeaderColor = Color.BurlyWood;
            mss.HeaderHeight = 20;
            mss.ImagePadding = new Padding(7, 15, 20, 30);
            mss.ContentColor = Color.White;
            mss.Popup();
        }
    }
}
