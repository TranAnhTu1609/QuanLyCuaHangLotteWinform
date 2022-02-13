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
    public partial class InfoNV : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string filename, iname;
        public InfoNV(string TenNv)
        {
            InitializeComponent();
            LoadInfo(TenNv);
        }
        public InfoNV()
        {
            InitializeComponent();
        }
        private void LoadInfo(string TenNv)
        {
            NhanVien nhanVien;
            nhanVien = db.NhanViens.Where(nv=>nv.TenNv == TenNv).FirstOrDefault();
           
            if (nhanVien != null)
            {
                ChucVu chucVu;
                chucVu = db.ChucVus.Where(cv => cv.MaCv == nhanVien.MaCv).FirstOrDefault();
                labelHoTen.Text = nhanVien.TenNv;
                labelGioiTinh.Text = nhanVien.GioiTinh;
                labelSDT.Text = nhanVien.SoDienThoai;
                labelChucVu.Text = chucVu.TenCv;
            }
            try
            {
                pcbMoTa.Image = new Bitmap(pathImage() + nhanVien.HinhAnh);
            }
            catch (Exception)
            {
                pcbMoTa.Image = null;
            }
        }
        private string pathImage()
        {
            //Lấy đường dẫn thư mục lưu ảnh
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }
        private void btnThoát_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
