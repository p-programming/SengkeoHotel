namespace SengkeoHotel.room_Service_controller.DuplexReserve
{
    partial class frmDuplexReserveDetail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuplexReserveDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDuplex = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.duplexReserveBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.btadd = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplex)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplexReserveBindingNavigator)).BeginInit();
            this.duplexReserveBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1068, 478);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1068, 441);
            this.panel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDuplex);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1068, 441);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ຂໍ້ມູນການຈອງ";
            // 
            // dgvDuplex
            // 
            this.dgvDuplex.AllowUserToAddRows = false;
            this.dgvDuplex.AllowUserToDeleteRows = false;
            this.dgvDuplex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDuplex.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuplex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDuplex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvDuplex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuplex.Location = new System.Drawing.Point(3, 26);
            this.dgvDuplex.Name = "dgvDuplex";
            this.dgvDuplex.ReadOnly = true;
            this.dgvDuplex.RowHeadersVisible = false;
            this.dgvDuplex.Size = new System.Drawing.Size(1062, 412);
            this.dgvDuplex.TabIndex = 0;
            this.dgvDuplex.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDuplex_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "ລາຍລະອຽດ";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Text = "ລຶບ";
            this.Column2.UseColumnTextForButtonValue = true;
            this.Column2.Width = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.duplexReserveBindingNavigator);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1068, 37);
            this.panel3.TabIndex = 1;
            // 
            // duplexReserveBindingNavigator
            // 
            this.duplexReserveBindingNavigator.AddNewItem = this.btadd;
            this.duplexReserveBindingNavigator.CountItem = null;
            this.duplexReserveBindingNavigator.DeleteItem = null;
            this.duplexReserveBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duplexReserveBindingNavigator.Font = new System.Drawing.Font("Saysettha OT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplexReserveBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btadd,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.duplexReserveBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.duplexReserveBindingNavigator.MoveFirstItem = null;
            this.duplexReserveBindingNavigator.MoveLastItem = null;
            this.duplexReserveBindingNavigator.MoveNextItem = null;
            this.duplexReserveBindingNavigator.MovePreviousItem = null;
            this.duplexReserveBindingNavigator.Name = "duplexReserveBindingNavigator";
            this.duplexReserveBindingNavigator.PositionItem = null;
            this.duplexReserveBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.duplexReserveBindingNavigator.Size = new System.Drawing.Size(1068, 37);
            this.duplexReserveBindingNavigator.TabIndex = 2;
            this.duplexReserveBindingNavigator.Text = "bindingNavigator1";
            // 
            // btadd
            // 
            this.btadd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btadd.Image = ((System.Drawing.Image)(resources.GetObject("btadd.Image")));
            this.btadd.Name = "btadd";
            this.btadd.RightToLeftAutoMirrorImage = true;
            this.btadd.Size = new System.Drawing.Size(23, 34);
            this.btadd.Text = "Add new";
            this.btadd.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 34);
            this.toolStripLabel1.Text = "ຄົ້ນຫາ:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Saysettha OT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(600, 30);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // frmDuplexReserveDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Saysettha OT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmDuplexReserveDetail";
            this.Load += new System.EventHandler(this.frmDuplexReserveDetail_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplex)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplexReserveBindingNavigator)).EndInit();
            this.duplexReserveBindingNavigator.ResumeLayout(false);
            this.duplexReserveBindingNavigator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingNavigator duplexReserveBindingNavigator;
        private System.Windows.Forms.ToolStripButton btadd;
        private System.Windows.Forms.DataGridView dgvDuplex;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}