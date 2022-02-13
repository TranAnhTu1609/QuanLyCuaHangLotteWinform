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
    public partial class FormChiTietDonNhapHang : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string TenNv;
        int MaHdk;
        FormNhapHang form;
        public FormChiTietDonNhapHang()
        {
            InitializeComponent();
        }
        public FormChiTietDonNhapHang(string TenNv, int Ma,FormNhapHang f)
        {
            InitializeComponent();
            this.TenNv = TenNv;
            form = f;
            MaHdk = Ma;
            lblMhdk.Text = MaHdk+"";
            lblTenNv.Text = TenNv;
            var trangthai = db.HoaDonKhos.FirstOrDefault(x=>x.MaHdk == Ma); 
            if (trangthai != null)
            {
                lblTrangthai.Text = trangthai.TrangThai;
                dptNgayTao.Value = trangthai.NgayCc.Date;
            }
            LoadData();
            TinhTien();
        }
        private void LoadData()
        {
            dgvDatHang.Rows.Clear();
            dgvDatHang.Columns["Gia"].DefaultCellStyle.Format = "N0";
            dgvDatHang.Columns["SL"].DefaultCellStyle.Format = "N0";
            dgvDatHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            var query = from hdk in db.CthoaDonKhos
                        where hdk.MaHdk == MaHdk
                        select new
                        {
                            hdk.MaNl,
                            hdk.SoLuong,
                            hdk.MaHdkNavigation.TrangThai,
                            hdk.MaHdkNavigation.NgayCc,
                            hdk.MaNlNavigation.DonGia,
                            hdk.MaNlNavigation.TenNl
                        };
            if(query.Count() > 0)
            {
                foreach(var item in query)
                {
                    dgvDatHang.Rows.Add(item.MaNl,item.TenNl,item.SoLuong,item.DonGia,item.SoLuong*item.DonGia);
                }
            }
        }
        private void TinhTien()
        {
            int tt=0;
            if (dgvDatHang.RowCount > -1)
            {
                for(int i = 0; i < dgvDatHang.RowCount; i++)
                {
                    tt += int.Parse(dgvDatHang.Rows[i].Cells[4].Value.ToString());
                }
                lblThanhTien.Text = string.Format("{0:N0}",tt);
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if(lblTrangthai.Text=="Chờ xác nhận" || lblTrangthai.Text=="Đang giao hàng")
            {
                MessageBox.Show("Đơn hàng đang trên đường vận chuyển, chưa thể nhập hàng", "Thông báo");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Xác nhận nhập hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    var hdk = db.HoaDonKhos.FirstOrDefault(x => x.MaHdk == MaHdk);
                    hdk.TrangThai = "Hoàn thành";
                    db.SaveChanges();

                    string Mota = "";
                    var query = db.Khos.Select(x => x);
                    BaoCao bc = new BaoCao();
                    bc.NgayLap = DateTime.Now;
                    bc.Loai = "Nhập Hàng";
                    bc.TenNv = TenNv;
                    for (var i = 0; i < dgvDatHang.RowCount; i++)
                    {
                        string manl = dgvDatHang.Rows[i].Cells[0].Value.ToString();
                        string tennl = dgvDatHang.Rows[i].Cells[1].Value.ToString();
                        int sl = int.Parse(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                        int dg = int.Parse(dgvDatHang.Rows[i].Cells[3].Value.ToString());
                        Mota += "\n" + tennl + " SL: " + sl + " DG: " + dg + "-Thành tiền:" + sl * dg + " VNĐ";
                        foreach (var item in query)
                        {
                            if (manl == item.MaNl.ToString())
                                item.SoLuong += sl;
                        }
                    }
                    Mota += "\n" + "Tổng: " + lblThanhTien.Text + " VNĐ";
                    bc.Mota = Mota;
                    db.BaoCaos.Add(bc);
                    try
                    {
                        db.SaveChanges();
                        form.loadData();
                        FormXemDonHangNhap xem = new FormXemDonHangNhap(TenNv,MaHdk);
                        xem.ShowDialog();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error");
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            /*var hdk = db.HoaDonKhos.FirstOrDefault(x => x.MaHdk == MaHdk);
            hdk.TrangThai = "Hủy đơn";
            db.SaveChanges();*/
            string Mota = "";
            /*BaoCao bc = new BaoCao();
            bc.NgayLap = DateTime.Now;
            bc.Loai = "Nhập Hàng";
            bc.TenNv = TenNv;*/
            for (var i = 0; i < dgvDatHang.RowCount; i++)
            {
                string manl = dgvDatHang.Rows[i].Cells[0].Value.ToString();
                string tennl = dgvDatHang.Rows[i].Cells[1].Value.ToString();
                int sl = int.Parse(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                int dg = int.Parse(dgvDatHang.Rows[i].Cells[3].Value.ToString());
                Mota += "\n" + tennl + " SL: " + sl + " DG: " + dg + "-Thành tiền:" + sl * dg + " VNĐ";
            }
            Mota += "\n" + "Tổng: " + lblThanhTien.Text + " VNĐ";
            /*bc.Mota = Mota;
            db.BaoCaos.Add(bc);*/
            FormLyDoHuyHang formHuyDon = new FormLyDoHuyHang(Mota,TenNv,MaHdk,form);
            formHuyDon.ShowDialog();
            this.Close();
        }
    }
}
