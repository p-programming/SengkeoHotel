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
    public partial class FormSalaryPay : Form
    {
        ConnectionManagement Con = new ConnectionManagement();
        public FormSalaryPay()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connection cd = new Connection();
        SqlCommand cmd = new SqlCommand();
        string Sql = "";
        private void FormSalaryPay_Load(object sender, EventArgs e)
        {
            ShowSalaryPay();
            ShowEmployee();


        }
        public void getEmployeeSalary(DateTime startDate)
        {
            var firstDayOfMonth = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime endDate = firstDayOfMonth.AddDays(29);

            DataTable employee = Con.Table("Employee").Select("Employee.*, Department.[DepartmentName], Position.PositionName, Position.Salary, Shift.ShiftIn, Shift.ShiftOut").
                Join("[Department]", "[Department].[DepartmentID]", "=", "Employee.[DepartmentID]").
               Join("Position", "Position.PositionID", "=", "Employee.PositionID").
               Join("Shift", "Shift.ShiftID", "=", "Employee.ShiftId").
               Where("EmployeeID", "=", labelEmId.Text).Get();
            if (employee.Rows.Count > 0)
            {
                DataTable employeeTimeWorks = Con.Table("TimeWork").SelectAll()
                    .Where("[EmployeeID]", "=", employee.Rows[0]["EmployeeID"].ToString())
                    .WhereBetween("WorkTimeDate", firstDayOfMonth.ToString("MM-dd-yyyy"), endDate.ToString("MM-dd-yyyy")).Get();
                dataGridView2.DataSource = employeeTimeWorks;
                dataGridView2.Columns[0].HeaderText = "ລະຫັດ";
                dataGridView2.Columns[1].HeaderText = "ເວລາເຂົ້າ";
                dataGridView2.Columns[2].HeaderText = "ເວລາອອກ";
                dataGridView2.Columns[3].HeaderText = "ມາຊ້າ";
                dataGridView2.Columns[4].HeaderText = "ລະຫັດພະນັກງານ";
                dataGridView2.Columns[5].HeaderText = "ວັນທີເຂົ້າວຽກ";
                dataGridView2.Columns[0].Width = 90;
                dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[2].Width = 100;
                dataGridView2.Columns[3].Width = 70;
                dataGridView2.Columns[4].Width = 130;
                dataGridView2.Columns[5].Width = 140;
                showEmployeeSalarayInfo(employee, employeeTimeWorks);

            }
        }

        private void showEmployeeSalarayInfo(DataTable employee, DataTable employeeTimeWorks)
        {
            //throw new NotImplementedException();
            int i;
            double totalAbsentMinutes = 0, totalMoney = 0, totalSubMoney = 0, currentSalary = 0, totalHours = 0;
            for (i = 0; i < employeeTimeWorks.Rows.Count; i++)
            {
                int totalAbentTime = 0;
                int.TryParse(employeeTimeWorks.Rows[i]["TimeOff"].ToString(), out totalAbentTime);
                totalAbsentMinutes += totalAbentTime;
            }
            double.TryParse(employee.Rows[0]["Salary"].ToString(), out currentSalary);

            string startTime = employee.Rows[0]["ShiftIn"].ToString();
            string endTime = employee.Rows[0]["ShiftOut"].ToString();
            TimeSpan shiftVal = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            if (shiftVal.TotalMinutes < 0)
            {
                DateTime tomorrow = DateTime.Now.AddDays(1);
                TimeSpan shiftOut = (TimeSpan)employee.Rows[0]["ShiftOut"];
                TimeSpan ts = new TimeSpan(shiftOut.Hours, shiftOut.Minutes, 0);
                tomorrow = (tomorrow.Date + ts);
                shiftVal = tomorrow.Subtract(DateTime.Parse(startTime));
            }

            totalHours = shiftVal.TotalHours;

            double totalAbsentHours = totalAbsentMinutes / 60;
            double ratePerHours = (currentSalary / 26) / totalHours;

            //cut
            totalSubMoney = totalAbsentHours * ratePerHours;
            //total
            totalMoney = employeeTimeWorks.Rows.Count * (totalHours - totalAbsentHours) * ratePerHours;
            //info
            labelName.Text = employee.Rows[0]["EmployeeName"].ToString();
            labelSurname.Text = employee.Rows[0]["EmployeeSurname"].ToString();
            labelDepartment.Text = employee.Rows[0]["DepartmentName"].ToString();
            labelPosition.Text = employee.Rows[0]["PositionName"].ToString();
            labelPositionSalary.Text = employee.Rows[0]["Salary"].ToString();
            labelOffHours.Text = totalAbsentHours.ToString();
            txt_IN.Text = employeeTimeWorks.Rows.Count.ToString();
            txt_daysOff.Text = (26 - employeeTimeWorks.Rows.Count).ToString();

            //cut
            if (totalSubMoney > 0)
            {
                labelSumMoney.Text = totalSubMoney.ToString("#,###,## KIP");
            }
            else
            {
                labelSumMoney.Text = "0 KIP";
            }
            //total
            if (totalMoney > 0)
            {
                labelTotalMoney.Text = totalMoney.ToString("#,###,## KIP");
            }
            else
            {
                labelTotalMoney.Text = "0 KIP";
            }

        }
        public void setSalaryMonth()
        {
            var firstDayOfMonth = new DateTime(datetime_DatePay.Value.Year, datetime_DatePay.Value.Month, 1);
            datetime_DatePay.Value = firstDayOfMonth;
        }

        private void datetime_DatePay_ValueChanged(object sender, EventArgs e)
        {
            getEmployeeSalary(datetime_DatePay.Value);
        }

        private void txt_RoomNo_TextChanged(object sender, EventArgs e)
        {
            labelEmId.Text = txt_RoomNo.Text;
        }

        private void labelEmId_TextChanged(object sender, EventArgs e)
        {
            getEmployeeSalary(datetime_DatePay.Value);
        }
        public void ShowEmployee()
        {
            da = new SqlDataAdapter("Select *from getSaraly", cd.ActiveCon());
            ds.Tables[0].Clear();
            da.Fill(ds, "Q");
            DGV_Employee.DataSource = ds.Tables["Q"];
            DGV_Employee.Columns[0].HeaderText = "ລະຫັດ";
            DGV_Employee.Columns[1].HeaderText = "ຊື່";
            DGV_Employee.Columns[2].HeaderText = "ນາມສະກຸນ";
            DGV_Employee.Columns[3].HeaderText = "ຕຳແໜ່ງ";
            DGV_Employee.Columns[0].Width = 90;
            DGV_Employee.Columns[1].Width = 120;
            DGV_Employee.Columns[2].Width = 120;
            DGV_Employee.Columns[3].Width = 140;
            DGV_Employee.Refresh();
        }
        private void ShowSalaryPay()
        {
            ////da = new SqlDataAdapter("Select A.EmployeeID,A.EmployeeName,A.EmployeeSurname,C.PositionName from Employee as A join Position as C on A.PositionID=C.PositionID", cd.ActiveCon());
            da = new SqlDataAdapter("Select A.SalaryPayID,A.Salary,A.SalaryCut,A.SalaryTotal,A.MonthPay,B.EmployeeName from SalaryPay as A join Employee as B on A.EmployeeID = B.EmployeeID ", cd.ActiveCon());
            //da = new SqlDataAdapter("Select * from SalaryPay ", cd.ActiveCon());
            da.Fill(ds, "sa");
            ds.Tables[0].Clear();
            da.Fill(ds, "sa");
            DGV_SalaryPay.DataSource = ds.Tables["sa"];
            DGV_SalaryPay.Columns[0].HeaderText = "ລະຫັດ";
            DGV_SalaryPay.Columns[1].HeaderText = "ຊື່ພະນັກງານ";
            DGV_SalaryPay.Columns[2].HeaderText = "ເງີນເດືອນ";
            DGV_SalaryPay.Columns[3].HeaderText = "ຖືກຕັດ";
            DGV_SalaryPay.Columns[4].HeaderText = "ເງີນເດືອນທີ່ເຫລືອ";
            DGV_SalaryPay.Columns[5].HeaderText = "ເງີນເດືອນທີ່ຈ່າຍ";
            DGV_SalaryPay.Columns[0].Width = 90;
            DGV_SalaryPay.Columns[1].Width = 90;
            DGV_SalaryPay.Columns[2].Width = 90;
            DGV_SalaryPay.Columns[3].Width = 90;
            DGV_SalaryPay.Columns[4].Width = 100;
            DGV_SalaryPay.Columns[5].Width = 100;
            DGV_SalaryPay.Refresh();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            labelEmId.Refresh();
        }
    }
}
