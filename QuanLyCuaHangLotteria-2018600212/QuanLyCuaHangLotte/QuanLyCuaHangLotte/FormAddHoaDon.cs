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
    public partial class FormAddHoaDon : Form
    {
        string TenNV;
        int maHD;
        int pageNu = 1, numberRe = 10;
        FormHoaDon f;
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormAddHoaDon()
        {
            InitializeComponent();
            LoadDataSanPham(pageNu, numberRe);
            loadCmb();
        }
        private bool checkNhapDL()
        {
            if (txtSL.Text == "")
            {
                MessageBox.Show("ko được để trống số lượng");
                return false;
            }
            return true;
        }
        public FormAddHoaDon(FormHoaDon form, string TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
            LoadDataSanPham(pageNu, numberRe);
            panel19.Visible = false;
            loadCmb();
            f = form;
        }
        private void TinhTien()
        {
            double km = 1;
            
            double tt = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                tt += double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            double thanhtoan = 0;
            if (lblKM.Text != "0")
            {
                km = Convert.ToDouble(lblKM.Text);
                thanhtoan =tt-( tt * km / 100);
            }
            else
            {
                thanhtoan = tt;
            }
            lblThanhTien.Text = string.Format("{0:N0}", tt);
            lblThanhToan.Text = string.Format("{0:N0}", thanhtoan);

        }
        private void clearTextBox()
        {
            txtTimkiem.Clear();
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtSL.Clear();
            pcbMoTa.Image = null;
        }
        private void clearThanhToan()
        {
            txtTimkiem.Clear();
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtSL.Clear();
            pcbMoTa.Image = null;
            dataGridView1.Rows.Clear();
            txtKM.Clear();
            lblKM.Visible = false;
            lblThanhTien.Text = "0";
            lblThanhToan.Text = "0";
            lblTienThua.Text = "0";
            textBox3.Clear();
        }
        private string pathImage()
        {
            //Lấy đường dẫn thư mục lưu ảnh
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }
        private void loadCmb()
        {
            try
            {
                var query = from lsp in db.LoaiSps
                            select new
                            {
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    cmbLoc.Items.Add(item.TenLsp);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }

        }
        private void LoadDataSanPham(int page, int recordNum)
        {
            dataSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSps on sp.MaLsp equals lsp.MaLsp
                        select new { 
                        sp.MaSp,
                        sp.TenSp,
                        lsp.TenLsp,
                        sp.DonVi,
                        sp.DonGia
                        };
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        dataSP.Rows.Add(item.MaSp, item.TenSp,item.TenLsp, item.DonVi, item.DonGia); i++;
                    }
                    else
                        break;
                }
            }
            dataSP.Columns["DonGia"].DefaultCellStyle.Format = "N0";
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
        private void locDL(int page, int recordNum, string loc)
        {
            dataSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSps on sp.MaLsp equals lsp.MaLsp
                        where lsp.TenLsp.Contains(loc)
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,                        
                            lsp.TenLsp,
                            sp.DonVi,
                            sp.DonGia
                        };
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        dataSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.DonVi, item.DonGia);
                        i++;
                    }
                    else
                        break;
                }
            }
            dataSP.Columns["DonGia"].DefaultCellStyle.Format = "N0";

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
        private void LocByTen(int page, int recordNum, string loc)
        {
            dataSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSps on sp.MaLsp equals lsp.MaLsp
                        where sp.TenSp.Contains(loc)
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            lsp.TenLsp,
                            sp.DonVi,
                            sp.DonGia
                        };
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        dataSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.DonVi, item.DonGia);
                        i++;
                    }
                    else
                        break;
                }
            }
            dataSP.Columns["DonGia"].DefaultCellStyle.Format = "N0";

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
        private void LocByMa(int page, int recordNum, int loc)
        {
            dataSP.Rows.Clear();
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSps on sp.MaLsp equals lsp.MaLsp
                        where sp.MaSp == loc
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            lsp.TenLsp,
                            sp.DonVi,
                            sp.DonGia
                        };
            int i = 0, d = 0;
            foreach (var item in query)
            {
                if (d < (page - 1) * recordNum)
                    d++;
                else
                {
                    if (i < recordNum)
                    {
                        dataSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.DonVi, item.DonGia);
                        i++;
                    }
                    else
                        break;
                }
            }
            dataSP.Columns["DonGia"].DefaultCellStyle.Format = "N0";

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

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageNu = 1;
            txtSoTrang.Text = pageNu + "";
            txtTimkiem.Clear();
            locDL(pageNu, numberRe, cmbLoc.Text.ToString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pageNu = 1;
            LoadDataSanPham(pageNu, numberRe);
            clearTextBox();
            cmbLoc.Text = null;
            txtTimkiem.Clear();
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTimkiem.Text == "")
                {
                    pageNu = 1;
                    txtSoTrang.Text = pageNu + "";
                    LoadDataSanPham(pageNu, numberRe);
                }
                else
                {
                    if (IsNumber(txtTimkiem.Text))
                    {
                        pageNu = 1;
                        txtSoTrang.Text = pageNu + "";
                        LocByMa(pageNu, numberRe, int.Parse(txtTimkiem.Text));
                    }
                    else
                    {
                        pageNu = 1;
                        txtSoTrang.Text = pageNu + "";
                        LocByTen(pageNu, numberRe, txtTimkiem.Text);
                    }
                }
                if (dataSP.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm phù hợp", "Thông báo");
                }
            }
            catch
            {
                
            }
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

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoc.Text == "")
            {
                LoadDataSanPham(pageNu, numberRe);
            }
            else
            {
                locDL(pageNu, numberRe, cmbLoc.Text);
            }
        }

        private void dataSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {             
                    var sp = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(dataSP.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        txtMaMon.Text = sp.MaSp + "";
                        txtTenMon.Text = sp.TenSp;
                        txtSL.Text = "";
                        if (sp.HinhAnh != null)
                        {
                            pcbMoTa.Image = new Bitmap(pathImage() + sp.HinhAnh);
                        }
                        else
                        {
                            pcbMoTa.Image = null;
                        }    
            }
        }

        private void iBtnXem_Click(object sender, EventArgs e)
        {
            if (checkNhapDL())
            {
                try
                {
                    int sl = int.Parse(txtSL.Text);
                    dataGridView1.Columns["Gia"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    var query = from sp in db.SanPhams
                                where sp.MaSp == int.Parse(txtMaMon.Text)
                                select sp;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            int check = 0;
                            if (dataGridView1.RowCount > 0)
                            {
                                for (int i = 0; i < dataGridView1.RowCount; i++)
                                {

                                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == item.MaSp.ToString() && dataGridView1.Rows[i].Cells[1].Value.ToString() == item.TenSp.ToString())
                                    {
                                        dataGridView1.Rows[i].Cells[2].Value = sl;
                                        dataGridView1.Rows[i].Cells[4].Value = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * item.DonGia;
                                        check++;
                                    }
                                }
                            }
                            if (check == 0)
                            {
                                MessageBox.Show("Sản phẩm chưa có trong đơn hàng, không thể sửa", "Thông báo");
                            }
                        }
                        TinhTien();
                        clearTextBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thêm được sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                var sp = db.SanPhams.SingleOrDefault(sp => sp.MaSp == int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                txtMaMon.Text = sp.MaSp + "";
                txtTenMon.Text = sp.TenSp;
                txtSL.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                try
                {
                    pcbMoTa.Image = new Bitmap(pathImage() + sp.HinhAnh);
                }
                catch (Exception)
                {
                    pcbMoTa.Image = null;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkNhapDL())
            {
                try
                {
                    var query = from sp in db.SanPhams
                                where sp.MaSp == int.Parse(txtMaMon.Text)
                                select sp;
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thống báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        if (query.Count() > 0)
                        {
                            foreach (var item in query)
                            {
                                int check = 0;
                                if (dataGridView1.RowCount > 0)
                                {
                                    
                                    for (int i = 0; i < dataGridView1.RowCount; i++)
                                    {


                                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == item.MaSp.ToString() && dataGridView1.Rows[i].Cells[1].Value.ToString() == item.TenSp.ToString())
                                        {
                                            dataGridView1.Rows.RemoveAt(i);
                                            clearTextBox();
                                            check++;
                                        }

                                    }
                                    
                                }
                                if (check == 0)
                                {
                                    MessageBox.Show("Sản phẩm không có trong đơn hàng, không thể xóa", "Thông báo");
                                }

                            }
                        }
                        TinhTien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                dataSP.Rows.Clear();
                try
                {
                    var query = from sp in db.SanPhams
                                join lsp in db.LoaiSps on sp.MaLsp equals lsp.MaLsp
                                where sp.MaSp == int.Parse(txtTimkiem.Text)
                                select new
                                {
                                    sp.MaSp,
                                    sp.TenSp,
                                    sp.DonGia,
                                    lsp.TenLsp,
                                    sp.DonVi,
                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {

                            dataSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.DonVi, item.DonGia);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm", "Thông Báo");
                    }
                }
                catch
                {
                    var query = from sp in db.SanPhams
                                join lsp in db.LoaiSps on sp.MaLsp equals lsp.MaLsp
                                where sp.TenSp.Contains(txtTimkiem.Text)
                                select new
                                {
                                    sp.MaSp,
                                    sp.TenSp,
                                    sp.DonGia,
                                    lsp.TenLsp,
                                    sp.DonVi,

                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {

                            dataSP.Rows.Add(item.MaSp, item.TenSp, item.TenLsp, item.DonVi, item.DonGia);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm", "Thông Báo");
                    }
                }
            }
        }

        private void btnAddKM_Click(object sender, EventArgs e)
        {
            if (txtKM.Text == "")
            {
                MessageBox.Show("Chưa có mã khuyến mại");
            }
            else
            {
                panel19.Visible = true;
                var query = from ma in db.KhuyenMais
                            where txtKM.Text == ma.MaKm
                            select ma;
                if(query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        if (item.NgayKt.Value < DateTime.Now)
                        {
                            lblKM.Text = "0";
                            txtKM.Clear();
                            MessageBox.Show("Đã hết hạn","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else if (item.NgayBd <= DateTime.Now && item.NgayKt >= DateTime.Now)
                        {
                            txtKM.Text = item.MaKm.ToString();
                            lblKM.Text = item.GiamGia.ToString();
                            MessageBox.Show("Áp dụng mã thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TinhTien();
                        }
                    }
                
                }
                else
                {
                    lblKM.Text = "0";
                    txtKM.Clear();
                    MessageBox.Show("Mã không đúng. Mời bạn nhập lại!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try 
            {
                if (e.KeyChar == '\r')
                {
                    if (double.Parse(textBox3.Text) > double.Parse(lblThanhToan.Text))
                    {
                        lblTienThua.Text = string.Format("{0:N0}", (float.Parse(textBox3.Text) - float.Parse(lblThanhToan.Text)));
                    }
                    else if (double.Parse(textBox3.Text) < double.Parse(lblThanhToan.Text))
                    {

                        MessageBox.Show("Tiền đưa phải lớn hơn tổng tiền!");
                        textBox3.Clear();
                        lblTienThua.Text = 0 + "";
                    }
                }
            }
            catch
            {
                textBox3.Clear();
                lblTienThua.Text = 0 + "";
                MessageBox.Show("Bạn phải nhập đơn giá là số !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //Lấy độ rong của giấy
            var chieurong = pdHoaDon.DefaultPageSettings.PaperSize.Width;

            //Khai báo biến tọa độ
            float vtdong = 10;


            // Khai báo định dạng kiểu căn giữa
            StringFormat formatCenter = new StringFormat(StringFormatFlags.NoClip);
            formatCenter.Alignment = StringAlignment.Center;

            //Tạo khung nhập liệu
            SizeF layoutSize = new SizeF(chieurong - vtdong * 2, 20);
            #region Tạo header
            e.Graphics.DrawString("LOTTERIA",
                                new Font("Courier New", 20, FontStyle.Bold),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 40;
            e.Graphics.DrawString("i'm  happy",
                                new Font("Courier New", 20, FontStyle.Bold),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize),
                                formatCenter);
            vtdong += 40;
            e.Graphics.DrawString("CUA HANG LOTTERIA TO HIEN THANH",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize)
                                );
                               
            vtdong += 40;
            e.Graphics.DrawString("307A TO HIEN THANH, F13, Q10",
                               new Font("Courier New", 16, FontStyle.Regular),
                               Brushes.Black,
                               new RectangleF(new PointF(0, vtdong), layoutSize)
                               );
            vtdong += 40;
            e.Graphics.DrawString("TEL: (08) 38624155 - DELIVERY: 18008099",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize)
                                );
            vtdong += 40;
            e.Graphics.DrawString("WIFI FREE PASS: 18008099",
                               new Font("Courier New", 16, FontStyle.Regular),
                               Brushes.Black,
                               new RectangleF(new PointF(0, vtdong), layoutSize)
                               );
            #endregion
            //Lấy dữ liệu hóa đơn
            var hoadonin = db.HoaDons.SingleOrDefault(hd => hd.MaHd == maHD);
            #region Thông tin hóa đơn
            vtdong += 40;
            e.Graphics.DrawString("POS#" + hoadonin.Pos,
                                 new Font("Courier New", 16, FontStyle.Regular),
                                 Brushes.Black,
                                 new PointF(30, vtdong)
                                 );
            e.Graphics.DrawString("NO." + hoadonin.MaHd,
                                 new Font("Courier New", 16, FontStyle.Regular),
                                 Brushes.Black,
                                 new PointF(150, vtdong)
                                 );
            e.Graphics.DrawString(String.Format("\t\t {0}",((DateTime)hoadonin.NgayThang).ToString("dd/MMM/yyyy      HH:mm:ss")),
                               new Font("Courier New", 16, FontStyle.Regular),
                               Brushes.Black,
                               new PointF(300, vtdong));
            #endregion
            #region Lấy dữ liệu
            var dsmua = from ct in db.CthoaDons.Where(x => x.MaHd == maHD)
                        join sp in db.SanPhams on ct.MaSp equals sp.MaSp
                        select new
                        {
                            ct.MaSp,
                            ct.SoLuong,
                            sp.TenSp,
                            sp.DonGia
                        };
            #endregion
            #region Danh sách sản phẩm mua
            vtdong += 50;
            e.Graphics.DrawString("Products Name",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(30, vtdong));
            e.Graphics.DrawString("Price",
                                  new Font("Courier New", 16, FontStyle.Regular),
                                  Brushes.Black,
                                  new PointF(300, vtdong));
            e.Graphics.DrawString("Qty",
                                 new Font("Courier New", 16, FontStyle.Regular),
                                 Brushes.Black,
                                 new PointF(550, vtdong));
            e.Graphics.DrawString("Amount",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(chieurong-220, vtdong));
            vtdong += 30;
            foreach (var item in dsmua)
            {
                e.Graphics.DrawString(item.TenSp,
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(30, vtdong));
                e.Graphics.DrawString(string.Format("{0:N0}",item.DonGia),
                                   new Font("Courier New", 16, FontStyle.Regular),
                                   Brushes.Black,
                                   new PointF(300, vtdong));
                e.Graphics.DrawString(item.SoLuong + "\t",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(550, vtdong));
                e.Graphics.DrawString(string.Format("{0:N0}", item.DonGia * item.SoLuong),
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(chieurong-220, vtdong));
                vtdong += 30;
            }
            vtdong += 20;
            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(10, vtdong), layoutSize), formatCenter);
            vtdong += 30;
            e.Graphics.DrawString("Discount",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(65, vtdong));
            e.Graphics.DrawString(lblKM.Text+"%",
                                   new Font("Courier New", 16, FontStyle.Regular),
                                   Brushes.Black,
                                   new PointF(chieurong - 220, vtdong));
            vtdong += 40;
            e.Graphics.DrawString("Total(Including TAX)",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(65, vtdong));
            e.Graphics.DrawString(lblThanhToan.Text,
                                   new Font("Courier New", 16, FontStyle.Regular),
                                   Brushes.Black,
                                   new PointF(chieurong - 220, vtdong));
            vtdong += 40;
            e.Graphics.DrawString("Cash",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(30, vtdong));
            e.Graphics.DrawString(string.Format("{0:N0}", Double.Parse(textBox3.Text)),
                                   new Font("Courier New", 16, FontStyle.Regular),
                                   Brushes.Black,
                                   new PointF(chieurong - 220, vtdong));
            vtdong += 40;
            e.Graphics.DrawString("Changing",
                                    new Font("Courier New", 16, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(30, vtdong));
            e.Graphics.DrawString(lblTienThua.Text,
                                   new Font("Courier New", 16, FontStyle.Regular),
                                   Brushes.Black,
                                   new PointF(chieurong - 220, vtdong));
            vtdong += 40;
            e.Graphics.DrawString("-----------------------------------------------------------",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(10, vtdong), layoutSize), formatCenter);
            vtdong += 40;
            e.Graphics.DrawString("000000   manager",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize)
                                );

            vtdong += 40;
            e.Graphics.DrawString("ReceiptNr : 02240429596",
                               new Font("Courier New", 16, FontStyle.Regular),
                               Brushes.Black,
                               new RectangleF(new PointF(0, vtdong), layoutSize)
                               );
            vtdong += 40;
            e.Graphics.DrawString("CONG TY TNHH LOTTERIA VIET NAM",
                                new Font("Courier New", 16, FontStyle.Regular),
                                Brushes.Black,
                                new RectangleF(new PointF(0, vtdong), layoutSize)
                                );
            vtdong += 40;
            e.Graphics.DrawString("03 NGUYEN LUONG BANG, F TAN HUNG,Q7",
                               new Font("Courier New", 16, FontStyle.Regular),
                               Brushes.Black,
                               new RectangleF(new PointF(0, vtdong), layoutSize)
                               );
            vtdong += 40;
            e.Graphics.DrawString("TEL: (08)  5416107279",
                               new Font("Courier New", 16, FontStyle.Regular),
                               Brushes.Black,
                               new RectangleF(new PointF(0, vtdong), layoutSize)
                               );
            #endregion
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                    throw new Exception("Hóa đơn trắng");
                if (textBox3.Text == "")
                    throw new Exception("Bạn cần nhập tiền đưa");
                if (cbbPos.Text == "")
                {
                    throw new Exception("Chưa có pos");
                }
                HoaDon hd = new HoaDon();
                hd.TenNv = TenNV;
                hd.Pos = cbbPos.Text;
                DateTime dt = DateTime.Now;
                hd.NgayThang = dt;
                if (txtKM.Text == "")
                {
                    hd.MaKm = null;
                }
                else
                {
                    hd.MaKm = txtKM.Text;
                }
                db.HoaDons.Add(hd);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CthoaDon cthd = new CthoaDon();
                maHD = db.HoaDons.SingleOrDefault(hdm => hdm.NgayThang == dt).MaHd;
                cthd.MaHd = maHD;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    cthd.MaSp = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    cthd.SoLuong = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    db.CthoaDons.Add(cthd);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                f.LoadData(1,15);
                ppdHoaDon.ShowDialog();
                clearThanhToan();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkNhapDL())
            {
                try
                {
                    int sl = int.Parse(txtSL.Text);
                    dataGridView1.Columns["Gia"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    var query = from sp in db.SanPhams
                                where sp.MaSp == int.Parse(txtMaMon.Text)
                                select sp;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            int check = 0;
                            if (dataGridView1.RowCount > 0)
                            {
                                for (int i = 0; i < dataGridView1.RowCount; i++)
                                {
                               
                                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == item.MaSp.ToString() && dataGridView1.Rows[i].Cells[1].Value.ToString() == item.TenSp.ToString())
                                    {
                                        dataGridView1.Rows[i].Cells[2].Value = sl + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                                        dataGridView1.Rows[i].Cells[4].Value = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * item.DonGia;
                                        check++;
                                    }
                                }  
                            }
                            if (check == 0)
                            {
                                dataGridView1.Rows.Add(item.MaSp, item.TenSp, sl, item.DonGia, sl * item.DonGia);
                            }
                        }
                        TinhTien();
                        clearTextBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thêm được sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
