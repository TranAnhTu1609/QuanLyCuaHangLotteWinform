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
    public partial class FormNhapHang : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string TenNv;
        public FormNhapHang()
        {
            InitializeComponent();
        }
        public FormNhapHang(string TenNv)
        {
            InitializeComponent();
            this.TenNv = TenNv;
            AutoGiaoHang();
            loadData(); 
            loadCbb();
        }
        private void loadCbb()
        {
            cbbTrangthai.Items.Add("Chờ xác nhận");
            cbbTrangthai.Items.Add("Đang giao hàng");
            cbbTrangthai.Items.Add("Chờ hoàn thành");
        }
        public void loadData()
        {
            dgvHoaDonKho.Rows.Clear();
            var query = from hdk in db.HoaDonKhos
                        where hdk.TrangThai!="Hoàn thành" && hdk.TrangThai!="Hủy đơn"
                        select hdk;
            if(query.Count() > 0)
            {
                foreach (var item in query)
                {
                    dgvHoaDonKho.Rows.Add(item.MaHdk,item.NgayCc,item.TrangThai);
                }
            }
        }
        //Tự động chuyển trạng thái đang giao hàng khi qua ngày mới
        public void AutoGiaoHang()
        {
            var query = from tt in db.HoaDonKhos
                        where tt.TrangThai!="Hoàn thành" && tt.TrangThai!="Hủy đơn"
                        select tt;

            foreach (var item in query)
            {
                TimeSpan time = DateTime.Now.Date - item.NgayCc.Date;
                int songay = time.Days;
                if (songay>=2)
                {
                    item.TrangThai = "Chờ hoàn thành";
                }
                else if (songay >= 1)
                {
                    item.TrangThai = "Đang giao hàng";
                }
            }
            db.SaveChanges();
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            FormDatHang datHang = new FormDatHang(TenNv,this);
            datHang.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            cbbTrangthai.SelectedItem = null;
            dgvHoaDonKho.Rows.Clear();
            var query = from hdk in db.HoaDonKhos
                        where hdk.NgayCc.Date == dptTimKiem.Value.Date
                        select hdk;
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    if(item.TrangThai !="Hoàn thành" && item.TrangThai!="Hủy đơn")
                    {
                        dgvHoaDonKho.Rows.Add(item.MaHdk,item.NgayCc,item.TrangThai);
                    }
                }
            }
            else
            {
                MessageBox.Show("không tìm thấy đơn hàng phù hợp", "Thông báo");
            }
        }

        private void dgvHoaDonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvHoaDonKho.Rows[e.RowIndex].Cells[3].Selected)
                {
                    int Ma = int.Parse(dgvHoaDonKho.Rows[e.RowIndex].Cells[0].Value.ToString());
                    FormChiTietDonNhapHang formChiTietDonNhapHang = new FormChiTietDonNhapHang(TenNv,Ma,this);
                    formChiTietDonNhapHang.ShowDialog();
                }
            }
        }

        private void cbbTrangthai_TextChanged(object sender, EventArgs e)
        {
            if (cbbTrangthai.Text == "")
            {
                loadData();
            }
            else
            {
                dgvHoaDonKho.Rows.Clear();
                var query =  from hdk in db.HoaDonKhos
                             where hdk.TrangThai == cbbTrangthai.Text
                             select hdk;
                if(query.Count() > 0)
                {
                    foreach(var item in query)
                    {
                        dgvHoaDonKho.Rows.Add(item.MaHdk,item.NgayCc,item.TrangThai);
                    }
                }
            }
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            cbbTrangthai.SelectedItem = null;
            loadData();    
        }
    }
}
