namespace QuanLyCuaHangLotte
{
    partial class FormNhapHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelView = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvHoaDonKho = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDatHang = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbTrangthai = new System.Windows.Forms.ComboBox();
            this.btnFind = new FontAwesome.Sharp.IconButton();
            this.dptTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDropMenu1 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.btnDoiMatKhau = new FontAwesome.Sharp.IconButton();
            this.btnXemInfo = new FontAwesome.Sharp.IconButton();
            this.panelView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonKho)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelDropMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelView.Controls.Add(this.panel1);
            this.panelView.Controls.Add(this.label7);
            this.panelView.Controls.Add(this.label1);
            this.panelView.Controls.Add(this.panelDropMenu1);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(1249, 855);
            this.panelView.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1249, 820);
            this.panel1.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1249, 571);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.dgvHoaDonKho);
            this.panel6.Location = new System.Drawing.Point(118, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1022, 374);
            this.panel6.TabIndex = 1;
            // 
            // dgvHoaDonKho
            // 
            this.dgvHoaDonKho.AllowUserToAddRows = false;
            this.dgvHoaDonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonKho.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDonKho.ColumnHeadersHeight = 45;
            this.dgvHoaDonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoaDonKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dgvHoaDonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonKho.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDonKho.MultiSelect = false;
            this.dgvHoaDonKho.Name = "dgvHoaDonKho";
            this.dgvHoaDonKho.ReadOnly = true;
            this.dgvHoaDonKho.RowHeadersVisible = false;
            this.dgvHoaDonKho.RowHeadersWidth = 51;
            this.dgvHoaDonKho.RowTemplate.Height = 29;
            this.dgvHoaDonKho.Size = new System.Drawing.Size(1022, 374);
            this.dgvHoaDonKho.TabIndex = 1;
            this.dgvHoaDonKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDonKho_CellClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FillWeight = 42.78075F;
            this.Column1.HeaderText = "Mã";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.FillWeight = 119.0731F;
            this.Column2.HeaderText = "Ngày cung cấp";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.FillWeight = 119.0731F;
            this.Column4.HeaderText = "Trạng thái";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "Thông tin";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Text = "Chi tiết";
            this.Column3.UseColumnTextForButtonValue = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.btnDatHang);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 423);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1249, 148);
            this.panel5.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(420, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 54);
            this.button1.TabIndex = 80;
            this.button1.Text = "Tạo mới";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnDatHang
            // 
            this.btnDatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDatHang.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDatHang.ForeColor = System.Drawing.Color.White;
            this.btnDatHang.Location = new System.Drawing.Point(637, 45);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(147, 54);
            this.btnDatHang.TabIndex = 79;
            this.btnDatHang.Text = "Đặt Hàng";
            this.btnDatHang.UseVisualStyleBackColor = false;
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 714);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1249, 106);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbTrangthai);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.dptTimKiem);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1249, 143);
            this.panel2.TabIndex = 0;
            // 
            // cbbTrangthai
            // 
            this.cbbTrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrangthai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbbTrangthai.FormattingEnabled = true;
            this.cbbTrangthai.Location = new System.Drawing.Point(913, 101);
            this.cbbTrangthai.Name = "cbbTrangthai";
            this.cbbTrangthai.Size = new System.Drawing.Size(227, 36);
            this.cbbTrangthai.TabIndex = 79;
            this.cbbTrangthai.TextChanged += new System.EventHandler(this.cbbTrangthai_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnFind.IconColor = System.Drawing.Color.DimGray;
            this.btnFind.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnFind.IconSize = 25;
            this.btnFind.Location = new System.Drawing.Point(334, 85);
            this.btnFind.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(126, 44);
            this.btnFind.TabIndex = 78;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dptTimKiem
            // 
            this.dptTimKiem.CustomFormat = "dd-MM-yyyy";
            this.dptTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptTimKiem.Location = new System.Drawing.Point(118, 93);
            this.dptTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dptTimKiem.Name = "dptTimKiem";
            this.dptTimKiem.Size = new System.Drawing.Size(193, 27);
            this.dptTimKiem.TabIndex = 71;
            this.dptTimKiem.Value = new System.DateTime(2021, 12, 6, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(400, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "Danh Sách Đơn Đặt Hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 766);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nhập Hàng";
            // 
            // panelDropMenu1
            // 
            this.panelDropMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDropMenu1.BackColor = System.Drawing.Color.Gainsboro;
            this.panelDropMenu1.Controls.Add(this.btnDangXuat);
            this.panelDropMenu1.Controls.Add(this.btnDoiMatKhau);
            this.panelDropMenu1.Controls.Add(this.btnXemInfo);
            this.panelDropMenu1.Location = new System.Drawing.Point(2108, 1);
            this.panelDropMenu1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelDropMenu1.Name = "panelDropMenu1";
            this.panelDropMenu1.Size = new System.Drawing.Size(187, 231);
            this.panelDropMenu1.TabIndex = 8;
            this.panelDropMenu1.Visible = false;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangXuat.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnDangXuat.IconColor = System.Drawing.Color.DarkCyan;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.IconSize = 25;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 118);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(187, 59);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDoiMatKhau.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnDoiMatKhau.IconColor = System.Drawing.Color.DarkCyan;
            this.btnDoiMatKhau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoiMatKhau.IconSize = 25;
            this.btnDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 59);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnDoiMatKhau.Size = new System.Drawing.Size(187, 59);
            this.btnDoiMatKhau.TabIndex = 1;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            // 
            // btnXemInfo
            // 
            this.btnXemInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnXemInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXemInfo.FlatAppearance.BorderSize = 0;
            this.btnXemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXemInfo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnXemInfo.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnXemInfo.IconColor = System.Drawing.Color.DarkCyan;
            this.btnXemInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXemInfo.IconSize = 25;
            this.btnXemInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemInfo.Location = new System.Drawing.Point(0, 0);
            this.btnXemInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXemInfo.Name = "btnXemInfo";
            this.btnXemInfo.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnXemInfo.Size = new System.Drawing.Size(187, 59);
            this.btnXemInfo.TabIndex = 0;
            this.btnXemInfo.Text = "Thông tin cá nhân";
            this.btnXemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemInfo.UseVisualStyleBackColor = true;
            // 
            // FormNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 855);
            this.Controls.Add(this.panelView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNhapHang";
            this.Text = "FormNhapHang";
            this.panelView.ResumeLayout(false);
            this.panelView.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonKho)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelDropMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelView;
        private Panel panel1;
        private Panel panel4;
        private Panel panel6;
        private Panel panel5;
        private Panel panel3;
        private Panel panel2;
        private Label label7;
        private Label label1;
        private Panel panelDropMenu1;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private FontAwesome.Sharp.IconButton btnDoiMatKhau;
        private FontAwesome.Sharp.IconButton btnXemInfo;
        private Label label2;
        private Button btnDatHang;
        private DateTimePicker dptTimKiem;
        private FontAwesome.Sharp.IconButton btnFind;
        private DataGridView dgvHoaDonKho;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewButtonColumn Column3;
        private ComboBox cbbTrangthai;
        private Button button1;
    }
}