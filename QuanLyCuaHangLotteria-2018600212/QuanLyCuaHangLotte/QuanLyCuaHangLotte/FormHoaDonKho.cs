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

    public partial class FormHoaDonKho : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string TenNv;
        public FormHoaDonKho()
        {
            InitializeComponent();
        }
        public FormHoaDonKho(string TenNv)
        {
            InitializeComponent();
            this.TenNv = TenNv;
            loadData();
            loadCbb();
        }
        private void loadCbb()
        {
            cbbTrangthai.Items.Add("Hoàn thành");
            cbbTrangthai.Items.Add("Hủy đơn");
        }
        public void loadData()
        {
            dgvHoaDonKho.Rows.Clear();
            var query = from hdk in db.HoaDonKhos
                        where hdk.TrangThai == "Hoàn thành" || hdk.TrangThai == "Hủy đơn"
                        select hdk;
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    dgvHoaDonKho.Rows.Add(item.MaHdk, item.NgayCc, item.TrangThai);
                }
            }
            checkDonHuy();
        }
        public void checkDonHuy()
        {
            for (int i = 0; i < dgvHoaDonKho.Rows.Count; i++)
            {
                if (dgvHoaDonKho.Rows[i].Cells[2].Value.Equals("Hủy đơn"))
                    dgvHoaDonKho.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            }
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
                    if (item.TrangThai == "Hoàn thành" || item.TrangThai == "Hủy đơn")
                    {
                        dgvHoaDonKho.Rows.Add(item.MaHdk, item.NgayCc, item.TrangThai);
                    }
                }
                checkDonHuy();
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
                var query = from hdk in db.HoaDonKhos
                            where hdk.TrangThai == cbbTrangthai.Text
                            select hdk;
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        dgvHoaDonKho.Rows.Add(item.MaHdk, item.NgayCc, item.TrangThai);
                    }
                    checkDonHuy();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbbTrangthai.SelectedItem = null;
            loadData();
        }

        private void dgvHoaDonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvHoaDonKho.Rows[e.RowIndex].Cells[3].Selected)
                {
                    int Ma = int.Parse(dgvHoaDonKho.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if(dgvHoaDonKho.Rows[e.RowIndex].Cells[2].Value.ToString()=="Hoàn thành")
                    {
                        FormXemDonHangNhap xem = new FormXemDonHangNhap(TenNv, Ma);
                        xem.ShowDialog();
                    }
                    if (dgvHoaDonKho.Rows[e.RowIndex].Cells[2].Value.ToString() == "Hủy đơn")
                    {
                        FormXemHuyDon huy = new FormXemHuyDon(TenNv, Ma);
                        huy.ShowDialog();
                    }


                }
            }
        }
    }
}
