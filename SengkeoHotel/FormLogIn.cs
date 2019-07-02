using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SengkeoHotel.controller.Login_Controller;
using SengkeoHotel.dbconnection;
using SengkeoHotel.controller;
namespace SengkeoHotel
{
    public partial class FormLogIn : Form
    {
        LoginController cntrl_log = new LoginController();
        connectdb_change cn_users = new connectdb_change();
        AnymessageBox ms = new AnymessageBox();
        public String UserAuther = "";
        public FormLogIn()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        SqlDataReader dr;
        public static string UserName = "";
        public static string UserAuthor = "";
        public static string status = "";
        public static string UserID = "";
        private void txt_User_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void cb_Show_CheckedChanged(object sender, EventArgs e)
        {
        }
        public void Clear()
        {
            txt_User.Clear();
            txt_Password.Clear();
        }
        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("Select * from Users where Username=@Username and Password=@Password", cd.ActiveCon());
            //cmd.Parameters.AddWithValue("Username", txt_User.Text);
            //cmd.Parameters.AddWithValue("Password", txt_Password.Text);
            //dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    UserName = txt_User.Text;

            //    dt.Load(dr);
            //    UserAuthor = dt.Rows[0][3].ToString();
            //    status = dt.Rows[0][3].ToString();
            //    UserID = dt.Rows[0][0].ToString();
            //    FormMain frm = new FormMain();
            //    frm.ShowDialog();
            //    FormLogIn j = new FormLogIn();
            //    j.Close();
            //    dr.Close();
            //    dt.Clear();
            //    Clear();
            //}
            //else
            //{
            //    MessageBox.Show("ຊື່ຜູ້ໃຊ້ແລະລະຫັດຜ່ານບໍ່ຖືກຕ້ອງ");
            //    txt_User.Clear();
            //    txt_Password.Clear();
            //    txt_User.Focus();
            //    dr.Close();
            //    dt.Clear();
            //    Clear();
            //}
            try {
                DialogResult dl = MessageBox.Show("ທ່ານຕ້ອງການເຂົ້າສູ່ລະບົບຫຼືບໍ?","ຢືນຢັນ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (txt_User.Text == "" || txt_Password.Text == "") {
                        ms.Check_DataEmpty();
                        return;
                    }
                    cn_users.da = new SqlDataAdapter("Select *from Users Where Username ='"+txt_User.Text+"' and UserPassword ='"+txt_Password.Text+"'", cn_users.cn);
                    DataSet current = new DataSet();
                    cn_users.da.Fill(current);
                    if (current.Tables[0].Rows.Count > 0)
                    {
                        LoginController.userlogined = current.Tables[0];
                        ms.Login_Successfully();
                        this.Close();
                        UserAuther = current.Tables[0].Rows[0]["UserAuther"].ToString();
                        //MessageBox.Show(UserAuther);
                    }
                    else
                    {
                        ms.LoginFailed();
                        txt_User.Text = "";
                        txt_User.Focus();
                        txt_Password.Text = "";
                        return;
                    }
                }
                else {
                    return;
                }

            } catch { }

        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            
        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {

        }

        private void btn_LogIn_Enter(object sender, EventArgs e)
        {

        }
    }
}
