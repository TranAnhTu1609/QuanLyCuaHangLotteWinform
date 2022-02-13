namespace QuanLyCuaHangLotte
{
    partial class FormDoiPass
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
            this.checkBoxHienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            this.txtNhapLaiMK = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxHienThiMatKhau
            // 
            this.checkBoxHienThiMatKhau.AutoSize = true;
            this.checkBoxHienThiMatKhau.FlatAppearance.BorderSize = 0;
            this.checkBoxHienThiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxHienThiMatKhau.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxHienThiMatKhau.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxHienThiMatKhau.Location = new System.Drawing.Point(51, 354);
            this.checkBoxHienThiMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxHienThiMatKhau.Name = "checkBoxHienThiMatKhau";
            this.checkBoxHienThiMatKhau.Size = new System.Drawing.Size(137, 23);
            this.checkBoxHienThiMatKhau.TabIndex = 27;
            this.checkBoxHienThiMatKhau.Text = "Hiển thị mật khẩu";
            this.checkBoxHienThiMatKhau.UseVisualStyleBackColor = true;
            this.checkBoxHienThiMatKhau.CheckedChanged += new System.EventHandler(this.Chck_Pass);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHuy.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHuy.IconColor = System.Drawing.Color.Black;
            this.btnHuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHuy.IconSize = 40;
            this.btnHuy.Location = new System.Drawing.Point(438, 422);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(102, 45);
            this.btnHuy.TabIndex = 26;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtNhapLaiMK
            // 
            this.txtNhapLaiMK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhapLaiMK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNhapLaiMK.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNhapLaiMK.Location = new System.Drawing.Point(47, 311);
            this.txtNhapLaiMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNhapLaiMK.Name = "txtNhapLaiMK";
            this.txtNhapLaiMK.PasswordChar = '*';
            this.txtNhapLaiMK.Size = new System.Drawing.Size(296, 27);
            this.txtNhapLaiMK.TabIndex = 21;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMatKhauMoi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(47, 226);
            this.txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(296, 27);
            this.txtMatKhauMoi.TabIndex = 20;
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMatKhauCu.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMatKhauCu.Location = new System.Drawing.Point(47, 135);
            this.txtMatKhauCu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '*';
            this.txtMatKhauCu.Size = new System.Drawing.Size(296, 27);
            this.txtMatKhauCu.TabIndex = 19;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnXacNhan.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnXacNhan.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnXacNhan.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnXacNhan.IconSize = 30;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.Location = new System.Drawing.Point(169, 419);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(113, 48);
            this.btnXacNhan.TabIndex = 18;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(44, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nhập lại mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(44, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(44, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(40, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 50);
            this.label1.TabIndex = 14;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // FormDoiPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 510);
            this.Controls.Add(this.checkBoxHienThiMatKhau);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.txtNhapLaiMK);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDoiPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDoiPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBoxHienThiMatKhau;
        private FontAwesome.Sharp.IconButton btnHuy;
        private TextBox txtNhapLaiMK;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauCu;
        private FontAwesome.Sharp.IconButton btnXacNhan;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}