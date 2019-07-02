namespace SengkeoHotel.cntrol_Users
{
    partial class frm_UersProfile
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
            this.picPho = new System.Windows.Forms.PictureBox();
            this.cbEmp = new System.Windows.Forms.ComboBox();
            this.txtUsersname = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btupdate = new System.Windows.Forms.Button();
            this.btsave = new System.Windows.Forms.Button();
            this.txtGrant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPho)).BeginInit();
            this.SuspendLayout();
            // 
            // picPho
            // 
            this.picPho.Location = new System.Drawing.Point(13, 15);
            this.picPho.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.picPho.Name = "picPho";
            this.picPho.Size = new System.Drawing.Size(173, 260);
            this.picPho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPho.TabIndex = 0;
            this.picPho.TabStop = false;
            // 
            // cbEmp
            // 
            this.cbEmp.FormattingEnabled = true;
            this.cbEmp.Location = new System.Drawing.Point(198, 60);
            this.cbEmp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbEmp.Name = "cbEmp";
            this.cbEmp.Size = new System.Drawing.Size(231, 32);
            this.cbEmp.TabIndex = 1;
            this.cbEmp.SelectedValueChanged += new System.EventHandler(this.cbEmp_SelectedValueChanged);
            // 
            // txtUsersname
            // 
            this.txtUsersname.Location = new System.Drawing.Point(198, 125);
            this.txtUsersname.Name = "txtUsersname";
            this.txtUsersname.Size = new System.Drawing.Size(231, 30);
            this.txtUsersname.TabIndex = 2;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(197, 185);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(231, 30);
            this.txtpass.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "ພະນັກງານ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "ຊື່ຜູ້ໃຊ້";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "ລະຫັດ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "ປະເພດຜູ້ໃຊ້";
            // 
            // btupdate
            // 
            this.btupdate.Location = new System.Drawing.Point(336, 282);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(92, 38);
            this.btupdate.TabIndex = 7;
            this.btupdate.Text = "ແກ້ໄຂ";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Visible = false;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(337, 282);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(92, 38);
            this.btsave.TabIndex = 8;
            this.btsave.Text = "ບັນທຶກ";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Visible = false;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // txtGrant
            // 
            this.txtGrant.Location = new System.Drawing.Point(197, 245);
            this.txtGrant.Name = "txtGrant";
            this.txtGrant.Size = new System.Drawing.Size(231, 30);
            this.txtGrant.TabIndex = 9;
            // 
            // frm_UersProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 324);
            this.Controls.Add(this.txtGrant);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.btupdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtUsersname);
            this.Controls.Add(this.cbEmp);
            this.Controls.Add(this.picPho);
            this.Font = new System.Drawing.Font("Saysettha OT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximumSize = new System.Drawing.Size(458, 363);
            this.MinimumSize = new System.Drawing.Size(458, 363);
            this.Name = "frm_UersProfile";
            this.Text = "frm_UersProfile";
            this.Load += new System.EventHandler(this.frm_UersProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPho;
        private System.Windows.Forms.ComboBox cbEmp;
        private System.Windows.Forms.TextBox txtUsersname;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btupdate;
        public System.Windows.Forms.Button btsave;
        private System.Windows.Forms.TextBox txtGrant;
    }
}