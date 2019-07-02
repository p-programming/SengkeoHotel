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
    public partial class FormWorkInWorkOut : Form
    {
        public FormWorkInWorkOut()
        {
            InitializeComponent();
        }
        ConnectionManagement Con = new ConnectionManagement();
        SqlConnection connection = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        //string Sql = "";
        public static string RemoveNewLine(string input)
        {
            return input.Replace("\n\r", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (txt.Text.Contains(Environment.NewLine))
                {
                    textBox2.Text = RemoveNewLine(textBox2.Text);
                    textBox2.SelectionLength = textBox2.Text.Length;
                }
            }
                    getEmployeeSalary();
            
        }
        public void getEmployeeSalary()
        {
            DataTable employee = Con.Table("Employee").Select("Employee.*, Position.PositionName, Position.Salary, Shift.ShiftIn, Shift.ShiftOut").
               Join("Position", "Position.PositionID", "=", "Employee.PositionID").
               Join("Shift", "Shift.ShiftID", "=", "Employee.ShiftId").
               Where("EmployeeID", "=", textBox2.Text).Get();

            if (employee.Rows.Count > 0)
            {

                DataTable employeeTimeWorks = Con.Table("TimeWork").SelectAll()
               .Where("[EmployeeID]", "=", employee.Rows[0]["EmployeeID"].ToString()).Get();

                string newId = "000" + (employeeTimeWorks.Rows.Count + 1).ToString();

                AutoIDas();
                DataTable toDayEmployeeTimeWork = Con.Table("TimeWork").SelectAll()
                  .Where("[EmployeeID]", "=", employee.Rows[0]["EmployeeID"].ToString())
                  .Where("WorkTimeDate", "=", DateTime.Now.ToString("MM-dd-yyyy")).Get();
                dataGridView1.DataSource = employeeTimeWorks;
                dataGridView1.Columns[0].HeaderText = "ລະຫັດ";                
                dataGridView1.Columns[1].HeaderText = "ເວລາເຂົ້າ";
                dataGridView1.Columns[2].HeaderText = "ເວລາອອກ";
                dataGridView1.Columns[3].HeaderText = "ມາຊ້າ";
                dataGridView1.Columns[4].HeaderText = "ລະຫັດພະນັກງານ";
                dataGridView1.Columns[5].HeaderText = "ວັນທີເຂົ້າວຽກ";
                dataGridView1.Columns[0].Width = 90;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[4].Width = 130;
                dataGridView1.Columns[5].Width = 140;
                AutoIDas();
                Con.ShowInformationMessage(toDayEmployeeTimeWork.Rows.Count.ToString(), "f");

        
                if (toDayEmployeeTimeWork.Rows.Count <= 0)
                {

                    String hours = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
                    string startTime = employee.Rows[0]["ShiftIn"].ToString();
                    TimeSpan hoursVal = DateTime.Parse(hours).Subtract(DateTime.Parse(startTime));
                    int totalMinutes = (int)hoursVal.TotalMinutes;
                    totalMinutes = totalMinutes < 0 ? 0 : totalMinutes;
                    int res = Con.Create("TimeWork:TimeWorKID, TimeIn, TimOut, TimeOff, EmployeeID, WorkTimeDate", newId, hoursVal.Hours < 0 ? startTime : hours, "", totalMinutes, textBox2.Text, DateTime.Now);
                }
                else
                {
                    Con.setUpdateCondition("TimeWorKID", toDayEmployeeTimeWork.Rows[0]["TimeWorKID"]);
                    String hours = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
                    string startTime = employee.Rows[0]["ShiftIn"].ToString();
                    string endTime = employee.Rows[0]["ShiftOut"].ToString();
                    TimeSpan shiftVal = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                    TimeSpan hoursVal = DateTime.Parse(endTime).Subtract(DateTime.Parse(hours));
                    if (shiftVal.TotalMinutes < 0)
                    {
                        DateTime tomorrow = DateTime.Now.AddDays(1);
                        TimeSpan shiftOut = (TimeSpan)employee.Rows[0]["ShiftOut"];
                        TimeSpan ts = new TimeSpan(shiftOut.Hours, shiftOut.Minutes, 0);
                        tomorrow = (tomorrow.Date + ts);
                        hoursVal = tomorrow.Subtract(DateTime.Parse(hours));
                    }
                    int totalMinutes = hoursVal.Minutes;
                    if (hoursVal.TotalMinutes <= 0)
                    {
                        int res = Con.Update("TimeWork:TimOut", endTime);
                    }
                    else if (checkBoxEmergancy.Checked)
                    {
                        hours = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
                        DateTime tomorrow = DateTime.Now.AddDays(1);
                        TimeSpan shiftOut = (TimeSpan)employee.Rows[0]["ShiftOut"];
                        TimeSpan ts = new TimeSpan(shiftOut.Hours, shiftOut.Minutes, 0);
                        tomorrow = (tomorrow.Date + ts);
                        hoursVal = tomorrow.Subtract(DateTime.Parse(hours));

                        int timeoff = (int)toDayEmployeeTimeWork.Rows[0]["TimeOff"];

                        totalMinutes = timeoff + (int)hoursVal.TotalMinutes;
                        int res = Con.Update("TimeWork:TimOut, TimeOff, Note", hours, totalMinutes, txtNote.Text);
                    }
                    else
                    {
                        Con.ShowInformationMessage("ຍັງບໍ່ທັນຮອດໂມງອອກ ຖ້າກໍລະນີສຸກເສີນກະລຸນາຕິດຕໍ່ຜຸ້ຈັດການເພື່ອອອກດ່ວນ!.", "Warning");
                    }
                }

                employeeTimeWorks = Con.Table("TimeWork").SelectAll()
                  .Where("[EmployeeID]", "=", employee.Rows[0]["EmployeeID"].ToString()).Get();

                dataGridView1.DataSource = employeeTimeWorks;

            }
        }
        public void AutoIDas()
        {
            SqlDataAdapter daa = new SqlDataAdapter("select Max(EmployeeID) from Employee", cd.ActiveCon());
            DataSet dss = new DataSet();
            daa.Fill(dss, "d");
            dss.Tables[0].Clear();
            daa.Fill(dss, "d");
            string TimeWorKID;
            if ((!DBNull.Value.Equals(dss.Tables[0].Rows[0][0])))
            {
                TimeWorKID = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                TimeWorKID = "000";
            }
            TimeWorKID = "000" + (double.Parse(TimeWorKID) + 1).ToString();
            txtIDTable.Text = TimeWorKID;
        }
        private void FormWorkInWorkOut_Load(object sender, EventArgs e)
        {
            AutoIDas();
            textBox2.Clear();
        }
    }
}
