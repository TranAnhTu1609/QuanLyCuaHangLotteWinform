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
    public partial class FormLyDoHuyHang : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string TenNv;
        string Mota;
        int MaHdk;
        FormNhapHang form;
        public FormLyDoHuyHang()
        {
            InitializeComponent();
        }
        public FormLyDoHuyHang(string Mota,string TenNv,int Ma,FormNhapHang f)
        {
            InitializeComponent();
            this.Mota = Mota;
            this.TenNv = TenNv;
            MaHdk = Ma;
            form = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Xác nhận hủy hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                var hdk = db.HoaDonKhos.FirstOrDefault(x => x.MaHdk == MaHdk);
                hdk.TrangThai = "Hủy đơn";
                db.SaveChanges();
                BaoCao bc = new BaoCao();
                bc.NgayLap = DateTime.Now;
                bc.Loai = "Hủy đơn";
                bc.TenNv = TenNv;
                Mota += "\n" + "lí do hủy đơn: " + txtHuyDon.Text;
                bc.Mota = Mota;
                db.BaoCaos.Add(bc);
                try
                {
                    db.SaveChanges();
                    form.loadData();
                    FormXemHuyDon xem = new FormXemHuyDon(TenNv, MaHdk);
                    xem.ShowDialog();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();    
        }
    }
}
