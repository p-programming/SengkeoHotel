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

namespace SengkeoHotel
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        string rt = "";
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            AutoID();
            txt_EmID.Enabled = false;
            cmb_Department.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Province.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Position.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Shift.DropDownStyle = ComboBoxStyle.DropDownList;            
            LoadDepartment();
            LoadPosition();
            LoadShift();
            rdb_Male.Checked = true;
            Showdata();

        }
        private void LoadDepartment()
        {
            da = new SqlDataAdapter("select * from Department", cd.ActiveCon());
            var dsType = new DataSet();
            da.Fill(dsType, "SS");
            cmb_Department.DataSource = dsType.Tables["SS"];
            cmb_Department.DisplayMember = "DepartmentName";
            cmb_Department.ValueMember = "DepartmentID";
        }
        private void LoadPosition()
        {
            da = new SqlDataAdapter("select * from Position", cd.ActiveCon());
            var dsType = new DataSet();
            da.Fill(dsType, "AA");
            cmb_Position.DataSource = dsType.Tables["AA"];
            cmb_Position.DisplayMember = "PositionName";
            cmb_Position.ValueMember = "PositionID";
        }
        private void LoadShift()
        {
            da = new SqlDataAdapter("select * from Shift", cd.ActiveCon());
            var dsType = new DataSet();
            da.Fill(dsType, "SSS");
            cmb_Shift.DataSource = dsType.Tables["SSS"];
            cmb_Shift.DisplayMember = "ShiftName";
            cmb_Shift.ValueMember = "ShiftID";
        }
        public void AutoID()
        {
            SqlDataAdapter daa = new SqlDataAdapter("select Max(EmployeeID) from Employee", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "d");
            dss.Tables[0].Clear();
            daa.Fill(dss, "d");
            string EmployeeID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                EmployeeID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                EmployeeID = "000";
            }
            EmployeeID = "000" + (double.Parse(EmployeeID) + 1).ToString();
            txt_EmID.Text = EmployeeID;
        }
        private bool isExists(string id)
        {
            cmd = new SqlCommand("select * from Employee Where EmployeeID=@EmployeeID", cd.ActiveCon());
            cmd.Parameters.AddWithValue("@EmployeeID", id);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "i");
            ds.Tables["i"].Clear();
            da.Fill(ds, "i");
            if (ds.Tables["i"].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            AutoID();
            //txt_EmID.Clear();
            txt_EmName.Clear();
            txt_Surname.Clear();
            txt_Village.Clear();
            txt_District.Clear();
            txt_Age.Clear();
            txt_tel.Clear();
            txt_tel1.Clear();
            cmb_Department.Refresh();
            cmb_Position.Refresh();
            cmb_Province.Refresh();
            txtpath.Clear();
            picture.Refresh();
            txt_EmID.Focus();
            
        }
        public void Showdata()
        {
            da = new SqlDataAdapter("Select A.EmployeeID,A.Sex,A.EmployeeName,A.EmployeeSurname,A.birth,A.Age,A.Tel,A.Tel1,A.Village,A.District,A.Country,C.DepartmentName,D.ShiftName,B.PositionName,A.PathPicture from Employee As A join  Position as B on A.PositionID=B.PositionID join Department as C on A.DepartmentID=C.DepartmentID join Shift as D on A.ShiftID = D.ShiftID", cd.ActiveCon());
            da.Fill(ds, "j");
            ds.Tables[0].Clear();
            da.Fill(ds, "j");
            DGV_Employee.DataSource = ds.Tables[0];
            DGV_Employee.Columns[0].HeaderText = "ລະຫັດ";
            DGV_Employee.Columns[1].HeaderText = "ເພດ";
            DGV_Employee.Columns[2].HeaderText = "ຊື່";
            DGV_Employee.Columns[3].HeaderText = "ນາມສະກຸນ";
            DGV_Employee.Columns[4].HeaderText = "ວ/ດ/ປ";
            DGV_Employee.Columns[5].HeaderText = "ອາຍຸ";
            DGV_Employee.Columns[6].HeaderText = "ເບີມືຖື";
            DGV_Employee.Columns[7].HeaderText = "ຕັ້ງໂຕ";
            DGV_Employee.Columns[8].HeaderText = "ບ້ານ";
            DGV_Employee.Columns[9].HeaderText = "ເມືອງ";
            DGV_Employee.Columns[10].HeaderText = "ແຂວງ";
            DGV_Employee.Columns[11].HeaderText = "ພະແນກ";
            DGV_Employee.Columns[12].HeaderText = "ກະວຽກ";
            DGV_Employee.Columns[13].HeaderText = "ຕໍາແໜ່ງ";
            DGV_Employee.Columns[14].HeaderText = "ຂໍ້ມູນຮູບພາບ";
            DGV_Employee.Columns[0].Width = 90;
            DGV_Employee.Columns[1].Width = 120;
            DGV_Employee.Columns[2].Width = 160;
            DGV_Employee.Columns[3].Width = 150;
            DGV_Employee.Columns[4].Width = 160;
            DGV_Employee.Columns[5].Width = 90;
            DGV_Employee.Columns[6].Width = 120;
            DGV_Employee.Columns[7].Width = 120;
            DGV_Employee.Columns[8].Width = 120;
            DGV_Employee.Columns[9].Width = 120;
            DGV_Employee.Columns[10].Width = 120;
            DGV_Employee.Columns[11].Width = 120;
            DGV_Employee.Columns[12].Width = 120;
            DGV_Employee.Columns[13].Width = 120;
            DGV_Employee.Columns[14].Width = 100;
            DGV_Employee.Refresh();
        }
        private void btn_Pic_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                txtpath.Text = openFileDialog1.FileName;
                if (txtpath.Text == ""|| txtpath.Text== "openFileDialog1")
                {
                    picture.Image = null;
                    txtpath.Text = "";
                }
                else
                {
                    picture.Image = Image.FromFile(txtpath.Text);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_EmName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txt_Surname.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ລູກຄ້າກ່ອນ", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isExists(txt_EmID.Text))
            {
                MessageBox.Show("ຂໍ້ມູນໄອດີນີ້ມີຢູ່ແລ້ວ", "ກະລຸນະກວດສອບອີກຄັ້ງ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
                if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (rdb_Male.Checked)
                {
                    rt = "ຊາຍ";
                }
                else if (rdb_Female.Checked)
                {
                    rt = "ຍິງ";
                }
                Sql = @"insert into Employee values(@EmployeeID,@EmployeeName,@EmployeeSurname,@Age,@Sex,@Tel,@Tel1,@Village,@District,@Country,@UserID,@PositionID,@PositionName,@DepartmentID,@PathPicture,@birth,@ShiftId)";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@EmployeeID", txt_EmID.Text);
                cmd.Parameters.AddWithValue("@EmployeeName", txt_EmName.Text);
                cmd.Parameters.AddWithValue("@EmployeeSurname", txt_Surname.Text);
                cmd.Parameters.AddWithValue("@Age", txt_Age.Text);
                cmd.Parameters.AddWithValue("@Sex", rt);
                cmd.Parameters.AddWithValue("@Tel", txt_tel.Text);
                cmd.Parameters.AddWithValue("@Tel1", txt_tel1.Text);
                cmd.Parameters.AddWithValue("@Village", txt_Village.Text);
                cmd.Parameters.AddWithValue("@District", txt_District.Text);
                cmd.Parameters.AddWithValue("@Country", cmb_Province.Text);
                cmd.Parameters.AddWithValue("@UserID",FormLogIn.UserID);
                cmd.Parameters.AddWithValue("@PositionID", cmb_Position.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@PositionName", cmb_Position.Text);
                cmd.Parameters.AddWithValue("@DepartmentID", cmb_Department.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@PathPicture", txtpath.Text);
                DateTime d = DateTime.Parse(datetime_Birth.Text);              
                cmd.Parameters.AddWithValue("@birth", d.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@ShiftId", cmb_Shift.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void rdb_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Male.Checked )
            {
                rt = "ຊາຍ";
            }
            else if (rdb_Female.Checked)
            {
                rt = "ຍິງ";
            }            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_EmName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນະເລືອກຂໍ້ມູນທີ່ຕ້ອງການລືບເສຍກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"delete from Employee where EmployeeID=@EmployeeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@EmployeeID", txt_EmID.Text);
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_EmName.Text.Equals(""))
            {
                MessageBox.Show("ກະລຸນາເລືອກຂໍ້ມູນເພື່ອຕ້ອງການແກ້ໄຂກ່ອນ", "ຂໍຂອບໃຈ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("ທ່ານຕ້ອງການບັນທຶກຂໍ້ມູນ ຫຼື ບໍ່?", "ຕ້ອງການ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sql = @"update Employee set EmployeeName=@EmployeeName,EmployeeSurname=@EmployeeSurname,Age=@Age,Sex=@Sex,Tel=@Tel,Tel1=@Tel1,Village=@Village,District=@District,Country=@Country,UserID=@UserID,PositionID=@PositionID,DepartmentID=@DepartmentID,PositionName=@PositionName,PathPicture=@PathPicture,birth=@birth where  EmployeeID=@EmployeeID";
                cmd = new SqlCommand(Sql, cd.ActiveCon());
                cmd.Parameters.AddWithValue("@EmployeeID", txt_EmID.Text);
                cmd.Parameters.AddWithValue("@EmployeeName", txt_EmName.Text);
                cmd.Parameters.AddWithValue("@EmployeeSurname", txt_Surname.Text);
                cmd.Parameters.AddWithValue("@Age", txt_Age.Text);
                cmd.Parameters.AddWithValue("@Sex", rt);
                cmd.Parameters.AddWithValue("@Tel", txt_tel.Text);
                cmd.Parameters.AddWithValue("@Tel1", txt_tel1.Text);
                cmd.Parameters.AddWithValue("@Village", txt_Village.Text);
                cmd.Parameters.AddWithValue("@District", txt_District.Text);
                cmd.Parameters.AddWithValue("@Country", cmb_Province.Text);
                cmd.Parameters.AddWithValue("@UserID", FormLogIn.UserID);
                cmd.Parameters.AddWithValue("@PositionID", cmb_Position.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DepartmentID", cmb_Department.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@PositionName", cmb_Position.Text);           
                cmd.Parameters.AddWithValue("@PathPicture", txtpath.Text);
                DateTime d = DateTime.Parse(datetime_Birth.Text);
                cmd.Parameters.AddWithValue("@birth", d.ToString("MM/dd/yyyy"));
                cmd.ExecuteNonQuery();
                Showdata();
                Clear();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DGV_Employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_EmID.Text = DGV_Employee.CurrentRow.Cells[0].Value.ToString();
            rt = DGV_Employee.CurrentRow.Cells[1].Value.ToString();
            txt_EmName.Text = DGV_Employee.CurrentRow.Cells[2].Value.ToString();
            txt_Surname.Text = DGV_Employee.CurrentRow.Cells[3].Value.ToString();
            datetime_Birth.Text = DGV_Employee.CurrentRow.Cells[4].Value.ToString();
            txt_Age.Text = DGV_Employee.CurrentRow.Cells[5].Value.ToString();
            txt_tel.Text = DGV_Employee.CurrentRow.Cells[6].Value.ToString();
            txt_tel1.Text = DGV_Employee.CurrentRow.Cells[7].Value.ToString();
            txt_Village.Text = DGV_Employee.CurrentRow.Cells[8].Value.ToString();
            txt_District.Text = DGV_Employee.CurrentRow.Cells[9].Value.ToString();
            cmb_Province.Text = DGV_Employee.CurrentRow.Cells[10].Value.ToString();
            cmb_Department.Text = DGV_Employee.CurrentRow.Cells[11].Value.ToString();
            cmb_Position.Text = DGV_Employee.CurrentRow.Cells[12].Value.ToString();
            txt_PositionName.Text = DGV_Employee.CurrentRow.Cells[13].Value.ToString();
            txtpath.Text = DGV_Employee.Rows[DGV_Employee.CurrentRow.Index].Cells[14].Value.ToString();
            picture.ImageLocation = txtpath.Text;
            //cmb_Department.Text = DGV_Employee.CurrentRow.Cells[15].Value.ToString();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
