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
    public partial class FormHoaDon : Form
    {
        string TenNV;
        int Quyen;
        int pageNu = 1, numberRe = 15;
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormHoaDon()
        {
            InitializeComponent();
        }
        public FormHoaDon(string TenNV,int Quyen)
        {
            InitializeComponent();        
            this.TenNV = TenNV;
            this.Quyen = Quyen;
            LoadData(pageNu, numberRe);
        }
        private void TinhTien()
        {
            double tt = 0;
            if (dgvCTHD.RowCount > 0)
            {
                for (var i = 0; i < dgvCTHD.RowCount; i++)
                {
                    tt += int.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString());
                }
            }
            if (lblKM.Text == "0")
            {
                lblThanhTien.Text = string.Format("{0:N0}", tt); 
                lblThanhToan.Text = string.Format("{0:N0}", tt);
            }
            else
            {
                lblThanhTien.Text = string.Format("{0:N0}", tt);
                double thanhtoan = tt - tt * (int.Parse(lblKM.Text)) / 100;
                lblThanhToan.Text = string.Format("{0:N0}", thanhtoan);
            }
        }
        public void LoadData(int page, int recordNum)
        {
            dgvHD.Rows.Clear();
            int i = 0, d = 0;
            if (Quyen == 1 || Quyen == 2)
                    {
                        var query = from hd in db.HoaDons
                                    select new
                                    {
                                        hd.MaHd,
                                        hd.TenNv,
                                        hd.Pos,
                                        hd.NgayThang,
                                        hd.MaKm
                                    };
                        if (query.Count() > 0)
                        {
                            
                            foreach (var item in query)
                            {
                                if (d < (page - 1) * recordNum)
                                    d++;
                                else
                                {
                                    if (i < recordNum)
                                    {
                                        dgvHD.Rows.Add(item.MaHd, item.TenNv, item.Pos, item.NgayThang, item.MaKm); i++;
                                    }
                                    else
                                        break;
                                }
                            }
                            if (page == 1)
                                btnLeft.Visible = false;
                            else
                                btnLeft.Visible = true;

                            if (page - 1 >= query.Count() / recordNum ||
                                (page == query.Count() / recordNum && query.Count() % recordNum == 0))
                                btnRight.Visible = false;
                            else
                                btnRight.Visible = true;
                        }
                    }
                    else
                    {
                        var query = from hd in db.HoaDons
                                    where hd.TenNv == TenNV
                                    select new
                                    {
                                        hd.MaHd,
                                        hd.TenNv,
                                        hd.Pos,
                                        hd.NgayThang,
                                        hd.MaKm
                                    };
                if (query.Count() > 0)
                        {
                            foreach (var item1 in query)
                            {
                                if (d < (page - 1) * recordNum)
                                    d++;
                                else
                                {
                                    if (i < recordNum)
                                    {
                                        dgvHD.Rows.Add(item1.MaHd, item1.TenNv, item1.Pos, item1.NgayThang, item1.MaKm); i++;
                                    }
                                    else
                                        break;
                                }
                            }
                            if (page == 1)
                                btnLeft.Visible = false;
                            else
                                btnLeft.Visible = true;

                            if (page - 1 >= query.Count() / recordNum ||
                                (page == query.Count() / recordNum && query.Count() % recordNum == 0))
                                btnRight.Visible = false;
                            else
                                btnRight.Visible = true;
                        }
                    }
        }
        private void SortByMa(int page, int recordNum, int loc)
        {
            dgvHD.Rows.Clear();
            var query = from hd in db.HoaDons
                        where hd.MaHd == loc
                        select hd;
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        dgvHD.Rows.Add(item.MaHd, item.TenNv, item.Pos, item.NgayThang, item.MaKm); i++;
                    }
                    else
                        break;
                }
            }
            if (page == 1)
                btnLeft.Visible = false;
            else
                btnLeft.Visible = true;

            if (page - 1 >= query.Count() / recordNum ||
                (page == query.Count() / recordNum && query.Count() % recordNum == 0))
                btnRight.Visible = false;
            else
                btnRight.Visible = true;
        }
        private void SortByTenNV(int page, int recordNum, string loc)
        {
            dgvHD.Rows.Clear();
            var query = from hd in db.HoaDons
                        where hd.TenNv.Contains(loc)
                        select hd;
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        dgvHD.Rows.Add(item.MaHd, item.TenNv, item.Pos, item.NgayThang, item.MaKm); i++;
                    }
                    else
                        break;
                }
            }
            if (page == 1)
                btnLeft.Visible = false;
            else
                btnLeft.Visible = true;

            if (page - 1 >= query.Count() / recordNum ||
                (page == query.Count() / recordNum && query.Count() % recordNum == 0))
                btnRight.Visible = false;
            else
                btnRight.Visible = true;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (pageNu - 1 < db.SanPhams.Count() / numberRe)
            {
                pageNu++;
                txtSoTrang.Text = pageNu + "";
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (pageNu - 1 > 0)
            {
                pageNu--;
                txtSoTrang.Text = pageNu + "";
            }
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    if(txtTimkiem.Text == "")
                    {
                        pageNu = 1;
                        txtSoTrang.Text = pageNu + "";
                        LoadData(pageNu, numberRe);
                    }
                    else
                    {
                        if (IsNumber(txtTimkiem.Text))
                        {
                            pageNu = 1;
                            txtSoTrang.Text = pageNu + "";
                            SortByMa(pageNu, numberRe, int.Parse(txtTimkiem.Text));
                        }
                        else
                        {
                            pageNu = 1;
                            txtSoTrang.Text = pageNu + "";
                            SortByTenNV(pageNu, numberRe, txtTimkiem.Text);
                        }
                    }
                    if(dgvHD.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm phù hợp", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pageNu = 1;
            LoadData(pageNu, numberRe);
            txtTimkiem.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgvHD.Rows.Clear();
            var query = from hd in db.HoaDons
                        where hd.NgayThang.Value.Date == dptTimKiem.Value.Date
                        select hd;
            if(query.Count() > 0)
            {
                foreach(var item in query)
                {
                    dgvHD.Rows.Add(item.MaHd, item.TenNv, item.Pos, item.NgayThang, item.MaKm);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào !");
            }
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1)
            {
                dgvCTHD.Rows.Clear();
                txtKM.Clear();
                txtPos.Text = dgvHD.Rows[e.RowIndex].Cells[2].Value.ToString();
                var query = from cthd in db.CthoaDons
                            where cthd.MaHd == int.Parse(dgvHD.Rows[e.RowIndex].Cells[0].Value.ToString())
                            select new
                            {
                                cthd.MaSp,
                                cthd.SoLuong,
                                cthd.MaSpNavigation.TenSp,
                                cthd.MaSpNavigation.DonGia
                            };
                if(query.Count() > 0)
                {
                    foreach(var item in query)
                    { 

                        dgvCTHD.Rows.Add(item.MaSp.ToString(), item.TenSp, item.SoLuong.ToString(), item.DonGia, item.SoLuong * item.DonGia);
                        
                    }
                }
                dgvCTHD.Columns["Gia"].DefaultCellStyle.Format = "N0";
                dgvCTHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                if (dgvHD.Rows[e.RowIndex].Cells[4].Value == null)
                    lblKM.Text = "0";
                else
                {
                    txtKM.Text = dgvHD.Rows[e.RowIndex].Cells[4].Value.ToString();
                    var query1 = from k in db.KhuyenMais
                                 where k.MaKm == dgvHD.Rows[e.RowIndex].Cells[4].Value.ToString()
                                 select k;
                    if (query1.Count() > 0)
                    {
                        foreach (var item in query1)
                        {
                            lblKM.Text = item.GiamGia.ToString();
                        }

                    }
                }
                TinhTien();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormAddHoaDon formAddHoaDon = new FormAddHoaDon(this,TenNV);
            formAddHoaDon.ShowDialog();
        }
    }
}
