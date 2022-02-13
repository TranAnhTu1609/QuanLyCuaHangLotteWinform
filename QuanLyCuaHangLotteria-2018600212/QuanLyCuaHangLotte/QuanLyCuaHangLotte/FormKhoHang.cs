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
    public partial class FormKhoHang : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string TenNV;
        public FormKhoHang()
        {
            InitializeComponent();
        }
        public FormKhoHang(string TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
            LoadDataNguyenLieu();
        }
        private void clearTextBox()
        {
            txtMaNl.Text = "";
            txtTenNl.Text = "";
            txtSL.Text = "";
        }
        private bool checkNhap()
        {
            if (txtSL.Text == "")
            {
                MessageBox.Show("ko được để trống số lượng");
                return false;
            }
            return true;
        }
        private void TinhTien()
        {
            double tt = 0;
            for (int i = 0; i < dgvXuatKho.RowCount; i++)
            {
                tt += double.Parse(dgvXuatKho.Rows[i].Cells[4].Value.ToString());
            }
          
            lblThanhTien.Text = string.Format("{0:N0}", tt);
        }
        private void LoadDataNguyenLieu()
        {
            try
            {
                dgvNL.Rows.Clear();
                dgvNL.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvNL.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
                dgvNL.Columns["Tong"].DefaultCellStyle.Format = "N0";
                var query = from nl in db.NguyenLieus
                            select new
                            {
                                nl.MaNl,
                                nl.TenNl,
                                nl.DonGia,
                                nl.Kho.SoLuong
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        dgvNL.Rows.Add(item.MaNl, item.TenNl, item.SoLuong, item.DonGia, item.SoLuong * item.DonGia);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo");
            }
            
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            dgvNL.Rows.Clear();
            dgvNL.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvNL.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
            dgvNL.Columns["Tong"].DefaultCellStyle.Format = "N0";
            try
            {
                if (int.Parse(txtTimkiem.Text) > 0)
                {
                    var query = from nl in db.NguyenLieus
                                where nl.MaNl == int.Parse(txtTimkiem.Text)
                                select new
                                {
                                    nl.MaNl,
                                    nl.TenNl,
                                    nl.DonGia,
                                    nl.Kho.SoLuong
                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            dgvNL.Rows.Add(item.MaNl, item.TenNl, item.SoLuong, item.DonGia, item.SoLuong * item.DonGia);
                        }
                    }
                }
                else
                {
                    var query = from nl in db.NguyenLieus
                                where nl.TenNl.Contains(txtTimkiem.Text)
                                select new
                                {
                                    nl.MaNl,
                                    nl.TenNl,
                                    nl.DonGia,
                                    nl.Kho.SoLuong
                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            dgvNL.Rows.Add(item.MaNl, item.TenNl, item.SoLuong, item.DonGia, item.SoLuong * item.DonGia);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nguyên liệu", "Thông Báo");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                try
                {
                    int sl = int.Parse(txtSL.Text);
                    dgvXuatKho.Columns["Gia"].DefaultCellStyle.Format = "N0";
                    dgvXuatKho.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    var query = from nl in db.NguyenLieus
                                where nl.MaNl == int.Parse(txtMaNl.Text)
                                select new
                                {
                                    nl.MaNl,
                                    nl.TenNl,
                                    nl.DonGia,
                                    nl.Kho.SoLuong
                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            int check = 0;
                            if (dgvXuatKho.RowCount > 0)
                            {
                                for (int i = 0; i < dgvXuatKho.RowCount; i++)
                                {

                                    if (dgvXuatKho.Rows[i].Cells[0].Value.ToString() == item.MaNl.ToString() && dgvXuatKho.Rows[i].Cells[1].Value.ToString() == item.TenNl.ToString())
                                    {
                                        if (sl + int.Parse(dgvXuatKho.Rows[i].Cells[2].Value.ToString()) > item.SoLuong)
                                        {
                                            MessageBox.Show("Số lượng xuất phải nhỏ hơn số lượng trong kho", "Thông Báo");
                                        }
                                        else
                                        {
                                            dgvXuatKho.Rows[i].Cells[2].Value = sl + int.Parse(dgvXuatKho.Rows[i].Cells[2].Value.ToString());
                                            dgvXuatKho.Rows[i].Cells[4].Value = double.Parse(dgvXuatKho.Rows[i].Cells[2].Value.ToString()) * item.DonGia;
                                        }
                                        check++;
                                    }
                                }
                            }
                            if (check == 0)
                            {
                                if (sl > item.SoLuong)
                                {
                                    MessageBox.Show("Số lượng xuất phải nhỏ hơn sô lượng trong kho", "Thông Báo");
                                }
                                else
                                {
                                    dgvXuatKho.Rows.Add(item.MaNl, item.TenNl, sl, item.DonGia, sl * item.DonGia);
                                }
                            }

                        }
                        TinhTien();
                        clearTextBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var nl =db.NguyenLieus.SingleOrDefault(x=>x.MaNl == int.Parse(dgvNL.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (nl != null)
                {
                    txtMaNl.Text = nl.MaNl.ToString();
                    txtTenNl.Text = nl.TenNl.ToString();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearTextBox();
            LoadDataNguyenLieu();
        }

        private void iBtnXem_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                try
                {
                    int sl = int.Parse(txtSL.Text);
                    dgvXuatKho.Columns["Gia"].DefaultCellStyle.Format = "N0";
                    dgvXuatKho.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    var query = from nl in db.NguyenLieus
                                where nl.MaNl == int.Parse(txtMaNl.Text)
                                select new
                                {
                                    nl.MaNl,
                                    nl.TenNl,
                                    nl.DonGia,
                                    nl.Kho.SoLuong
                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            int check = 0;
                            if (dgvXuatKho.RowCount > 0)
                            {
                                for (int i = 0; i < dgvXuatKho.RowCount; i++)
                                {

                                    if (dgvXuatKho.Rows[i].Cells[0].Value.ToString() == item.MaNl.ToString() && dgvXuatKho.Rows[i].Cells[1].Value.ToString() == item.TenNl.ToString())
                                    {
                                        if (sl > item.SoLuong)
                                        {
                                            MessageBox.Show("Số lượng xuất phải nhỏ hơn số lượng trong kho", "Thông Báo");
                                        }
                                        else
                                        {
                                            dgvXuatKho.Rows[i].Cells[2].Value = sl;
                                            dgvXuatKho.Rows[i].Cells[4].Value = double.Parse(dgvXuatKho.Rows[i].Cells[2].Value.ToString()) * item.DonGia;
                                        }
                                        check++;
                                    }
                                }
                            }
                            if (check == 0)
                            {  
                                    MessageBox.Show("Nguyên Liệu ko có trong danh sách xuất hàng", "Thông Báo");
                            }

                        }
                        TinhTien();
                        clearTextBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                try
                {
                    var query = from nl in db.NguyenLieus
                                where nl.MaNl == int.Parse(txtMaNl.Text)
                                select new
                                {
                                    nl.MaNl,
                                    nl.TenNl,
                                    nl.DonGia,
                                    nl.Kho.SoLuong
                                };
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            int check = 0;
                            if (dgvXuatKho.RowCount > 0)
                            {
                                for (int i = 0; i < dgvXuatKho.RowCount; i++)
                                {

                                    if (dgvXuatKho.Rows[i].Cells[0].Value.ToString() == item.MaNl.ToString() && dgvXuatKho.Rows[i].Cells[1].Value.ToString() == item.TenNl.ToString())
                                    {
                                        dgvXuatKho.Rows.RemoveAt(i);
                                        check++;
                                    }
                                }
                            }
                            if(check == 0)
                            {
                                MessageBox.Show("Không có trong danh sách xuất hàng.không thể xóa", "Thông báo");
                            }

                        }
                        TinhTien();
                        clearTextBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvXuatKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var nl = db.NguyenLieus.SingleOrDefault(x => x.MaNl == int.Parse(dgvXuatKho.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (nl != null)
                {
                    txtMaNl.Text = nl.MaNl.ToString();
                    txtTenNl.Text = nl.TenNl.ToString();
                    txtSL.Text = dgvXuatKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
        }
        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                dgvNL.Rows.Clear();
                dgvNL.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvNL.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
                dgvNL.Columns["Tong"].DefaultCellStyle.Format = "N0";
                try
                {
                    if (int.Parse(txtTimkiem.Text) > 0)
                    {
                        var query = from nl in db.NguyenLieus
                                    where nl.MaNl == int.Parse(txtTimkiem.Text)
                                    select new
                                    {
                                        nl.MaNl,
                                        nl.TenNl,
                                        nl.DonGia,
                                        nl.Kho.SoLuong
                                    };
                        if (query.Count() > 0)
                        {
                            foreach (var item in query)
                            {
                                dgvNL.Rows.Add(item.MaNl, item.TenNl, item.SoLuong, item.DonGia, item.SoLuong * item.DonGia);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nguyên liệu", "Thông Báo");
                        }
                    }
                    else
                    {
                        var query = from nl in db.NguyenLieus
                                    where nl.TenNl.Contains(txtTimkiem.Text)
                                    select new
                                    {
                                        nl.MaNl,
                                        nl.TenNl,
                                        nl.DonGia,
                                        nl.Kho.SoLuong
                                    };
                        if (query.Count() > 0)
                        {
                            foreach (var item in query)
                            {
                                dgvNL.Rows.Add(item.MaNl, item.TenNl, item.SoLuong, item.DonGia, item.SoLuong * item.DonGia);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nguyên liệu", "Thông Báo");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            int index = dgvXuatKho.Rows.Count;
            var query = db.Khos.Select(x => x);
            DialogResult dialog = MessageBox.Show("Bạn muốn xuất kho?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                if (index == 0)
                    MessageBox.Show("Chưa có nguyên liệu nào !");
                else
                {
                    string Mota="";
                    BaoCao bc = new BaoCao();
                    bc.NgayLap = DateTime.Now;
                    bc.Loai = "Xuất Hàng";
                    bc.TenNv = TenNV;
                    for(var i = 0; i < index; i++)
                    {
                        string manl = dgvXuatKho.Rows[i].Cells[0].Value.ToString();
                        string tennl = dgvXuatKho.Rows[i].Cells[1].Value.ToString();
                        int sl = int.Parse(dgvXuatKho.Rows[i].Cells[2].Value.ToString());
                        int dg = int.Parse(dgvXuatKho.Rows[i].Cells[3].Value.ToString());
                        Mota += "\n"+tennl + " SL: " + sl + " DG: " + dg + "-Thành tiền:" + sl * dg + " VNĐ";
                        foreach (var item in query)
                        {
                            if (manl == item.MaNl.ToString())
                                item.SoLuong -= sl;
                        }
                    }
                    Mota += "\n" + "Tổng: " + lblThanhTien.Text + " VNĐ";
                    bc.Mota = Mota;
                    db.BaoCaos.Add(bc);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Xuất kho thành công !");
                        dgvXuatKho.Rows.Clear();
                        LoadDataNguyenLieu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error");
                    }
                }
            }
               
        }
    }
}
