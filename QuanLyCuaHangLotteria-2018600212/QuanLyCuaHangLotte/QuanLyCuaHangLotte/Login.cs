using QuanLyCuaHangLotte.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyCuaHangLotte
{
    public partial class Login : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public Login()
        {
            InitializeComponent();
        }
        public int Quyen { get; set; }
        public string Tennv { get; set; }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DangNhap()
        {
            string ten =  txtDangNhap.Text.Trim();
            string mk = txtPassWord.Text.Trim();
            
            try
            {
                if (ten.Equals("")) throw new Exception("Tài khoản không được để trống!");
                if (mk.Equals("")) throw new Exception("Mật khẩu không được để trống!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            TaiKhoan taikhoan;
            taikhoan = db.TaiKhoans.Where(tk => tk.TaiKhoan1 == ten).FirstOrDefault(); 
            if (taikhoan == null)
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác");
            }
            else
            {
                if (taikhoan.MatKhau != mk)
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Quyen = taikhoan.Quyen.Value;
                Tennv = db.NhanViens.Where(nv => nv.Id == taikhoan.Id).FirstOrDefault().TenNv;
                this.Hide();
                Trangchu tc = new Trangchu(Quyen, Tennv);
                tc.ShowDialog();
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void CheckHien_checkedchanged(object sender, EventArgs e)
        {
            if(cbHienThiMatKhau.Checked==true)
            {
                cbHienThiMatKhau.Text = "Ẩn Mật Khẩu";
                txtPassWord.PasswordChar = '\0';
            }
            else
            {
                cbHienThiMatKhau.Text = "Hiện Thị Mật Khẩu";
                txtPassWord.PasswordChar = '*';
            }
        }
    }
}
