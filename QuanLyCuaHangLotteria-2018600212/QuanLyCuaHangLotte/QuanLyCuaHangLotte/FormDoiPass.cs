using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangLotte.Models;

namespace QuanLyCuaHangLotte
{
    public partial class FormDoiPass : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormDoiPass()
        {
            InitializeComponent();
        }
        string TenTK;
        public FormDoiPass(string TenTK)
        {
            InitializeComponent();
            this.TenTK = TenTK;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string oldMK = txtMatKhauCu.Text;
            string newMK = txtMatKhauMoi.Text;
            string confirmMK = txtNhapLaiMK.Text;
            try
            {
                if (oldMK.Equals("")) throw new Exception("Mật khẩu cũ không được để trống");
                if (newMK.Equals("")) throw new Exception("Mật khẩu mới không được để trống");
                if (confirmMK.Equals("")) throw new Exception("Bạn chưa nhập lại nhập khẩu mới");
                if (!newMK.Equals(confirmMK)) throw new Exception("Mật khẩu nhập lại chưa khớp");             
                TaiKhoan TK = db.TaiKhoans.Where(tk => tk.TaiKhoan1 == TenTK).FirstOrDefault();
                if (oldMK != TK.MatKhau) throw new Exception("Mật khẩu cũ không đúng");
                TK.MatKhau = newMK;
                db.SaveChanges();
                xoaTrang();
                MessageBox.Show("Đổi mật khẩu thành công");
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void xoaTrang()
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLaiMK.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chck_Pass(object sender, EventArgs e)
        {
            if (checkBoxHienThiMatKhau.Checked == true)
            {
                checkBoxHienThiMatKhau.Text = "Ẩn Mật Khẩu";
                txtMatKhauCu.PasswordChar = '\0';
                txtMatKhauMoi.PasswordChar = '\0';
                txtNhapLaiMK.PasswordChar = '\0';
            }
            else
            {
                checkBoxHienThiMatKhau.Text = "Hiện Thị Mật Khẩu";
                txtMatKhauCu.PasswordChar = '*';
                txtMatKhauMoi.PasswordChar = '*';
                txtNhapLaiMK.PasswordChar = '*';
            }
        }
    }
}
