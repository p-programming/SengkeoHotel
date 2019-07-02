namespace SengkeoHotel.room_Service_controller.ReserveBooking
{
    partial class frmCustomerReservBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label customerNameLabel;
            System.Windows.Forms.Label customerSurnameLabel;
            System.Windows.Forms.Label telLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label label1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btsave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtcusid = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.txttel = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            customerIDLabel = new System.Windows.Forms.Label();
            customerNameLabel = new System.Windows.Forms.Label();
            customerSurnameLabel = new System.Windows.Forms.Label();
            telLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(15, 18);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(48, 24);
            customerIDLabel.TabIndex = 0;
            customerIDLabel.Text = "ລະຫັດ:";
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Location = new System.Drawing.Point(15, 49);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new System.Drawing.Size(18, 24);
            customerNameLabel.TabIndex = 2;
            customerNameLabel.Text = "ຊື່";
            // 
            // customerSurnameLabel
            // 
            customerSurnameLabel.AutoSize = true;
            customerSurnameLabel.Location = new System.Drawing.Point(15, 80);
            customerSurnameLabel.Name = "customerSurnameLabel";
            customerSurnameLabel.Size = new System.Drawing.Size(68, 24);
            customerSurnameLabel.TabIndex = 4;
            customerSurnameLabel.Text = "ນາມສະກຸນ:";
            // 
            // telLabel
            // 
            telLabel.AutoSize = true;
            telLabel.Location = new System.Drawing.Point(15, 209);
            telLabel.Name = "telLabel";
            telLabel.Size = new System.Drawing.Size(43, 24);
            telLabel.TabIndex = 6;
            telLabel.Text = "ເບີໂທ:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(15, 240);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(42, 24);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "ອີເມວ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 111);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 24);
            label1.TabIndex = 4;
            label1.Text = "ທີ່ຢູ່:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 43);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btsave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 43);
            this.panel2.TabIndex = 1;
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(479, 6);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(86, 34);
            this.btsave.TabIndex = 0;
            this.btsave.Text = "ບັນທຶກ";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(customerIDLabel);
            this.panel3.Controls.Add(this.txtcusid);
            this.panel3.Controls.Add(customerNameLabel);
            this.panel3.Controls.Add(this.txtname);
            this.panel3.Controls.Add(label1);
            this.panel3.Controls.Add(this.txtaddress);
            this.panel3.Controls.Add(customerSurnameLabel);
            this.panel3.Controls.Add(this.txtlname);
            this.panel3.Controls.Add(telLabel);
            this.panel3.Controls.Add(this.txttel);
            this.panel3.Controls.Add(emailLabel);
            this.panel3.Controls.Add(this.txtemail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(577, 267);
            this.panel3.TabIndex = 2;
            // 
            // txtcusid
            // 
            this.txtcusid.Location = new System.Drawing.Point(151, 15);
            this.txtcusid.Name = "txtcusid";
            this.txtcusid.ReadOnly = true;
            this.txtcusid.Size = new System.Drawing.Size(171, 30);
            this.txtcusid.TabIndex = 1;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(151, 46);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(414, 30);
            this.txtname.TabIndex = 0;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(151, 108);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(414, 97);
            this.txtaddress.TabIndex = 2;
            // 
            // txtlname
            // 
            this.txtlname.Location = new System.Drawing.Point(151, 77);
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(414, 30);
            this.txtlname.TabIndex = 1;
            // 
            // txttel
            // 
            this.txttel.Location = new System.Drawing.Point(151, 206);
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(414, 30);
            this.txttel.TabIndex = 3;
            this.txttel.TextChanged += new System.EventHandler(this.txttel_TextChanged);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(151, 237);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(414, 30);
            this.txtemail.TabIndex = 4;
            // 
            // frmCustomerReservBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 353);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Saysettha OT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(593, 392);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(593, 392);
            this.Name = "frmCustomerReservBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCustomerReservBooking_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtcusid;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtlname;
        private System.Windows.Forms.TextBox txttel;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Button btsave;
    }
}