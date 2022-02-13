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
    public partial class Trangchu : Form
    {
        int Quyen;
        string TenNv;
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public Trangchu(int Quyen,string TenNv)
        {
            InitializeComponent();
            hideSubMenu();
            this.Quyen = Quyen;
            this.TenNv = TenNv;
            avt.Text = TenNv;
            phanquyen();
        }
        public Trangchu()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private Form currentViewForm;
        private void avt_Click(object sender, EventArgs e)
        {
            if (panelDropMenu1.Visible)
            {
                panelDropMenu1.Visible = false;

            }
            else
            {
                panelView.Controls.Add(panelDropMenu1);
                panelDropMenu1.BringToFront();
                panelDropMenu1.Visible = true;
            }
        }
        private void phanquyen()
        {
            if (Quyen == 3) 
            {
                button2.Visible = false;
                button3.Visible = false;
                button14.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button9.Visible = false;
                button13.Visible = false;
                btnKho.Visible = false;
                panel_Kho.Visible = false;
                btnBaoCao.Visible = false;
            }
            else if(Quyen == 2)
            {
                button5.Visible = false;
                button6.Visible = false;
            }
        }

        // Mo form moi trong panelView
        private void OpenChildForm(Form childForm)
        {
            // Bat form moi thi an drop menu di
            panelDropMenu1.Visible = false;

            // Neu co form mo dong form do va mo form moi
            if (currentViewForm != null)
            {
                currentViewForm.Close();
            }
            currentViewForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelView.Controls.Add(childForm);
            panelView.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        //ẩn submenu
        private void hideSubMenu()
        {
            panel_Kho.Visible = false;
            panel_HD.Visible = false;  
        }
        //hiển thị submenu
        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentViewForm != null)
            {
                currentViewForm.Close();
            }
            hideSubMenu();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_Kho);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_HD);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnXemInfo_Click(object sender, EventArgs e)
        {
            InfoNV infoNV = new InfoNV(TenNv);
            infoNV.ShowDialog();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien;
            nhanVien = db.NhanViens.Where(nv=>nv.TenNv == TenNv).FirstOrDefault();
            if (nhanVien != null)
            {
                TaiKhoan taiKhoan;
                taiKhoan = db.TaiKhoans.Where(tk=>tk.Id == nhanVien.Id).FirstOrDefault();
                if(taiKhoan != null)
                {
                    FormDoiPass form  = new FormDoiPass(taiKhoan.TaiKhoan1);
                    form.ShowDialog();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyLoaiMon());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyMonAn());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyChucVu());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyNhanSu());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyKhuyenMai());
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormHoaDon(TenNv,Quyen));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNguyenLieu());
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhoHang(TenNv));
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhapHang(TenNv));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHoaDonKho(TenNv));
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBaoCao(TenNv));
        }

        private void btnXemInfo_Click_1(object sender, EventArgs e)
        {
            InfoNV infoNV = new InfoNV(TenNv);
            infoNV.ShowDialog();
        }

        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            var query = from nv in db.NhanViens
                        join tk in db.TaiKhoans on nv.Id equals tk.Id
                        where nv.TenNv == TenNv
                        select new {
                            tk.TaiKhoan1
                        };
            foreach (var item in query)
            {
                FormDoiPass formDoiPass = new FormDoiPass(item.TaiKhoan1);
                formDoiPass.ShowDialog();
            }
            
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
