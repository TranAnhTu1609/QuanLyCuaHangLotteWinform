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
    public partial class FormQuanLyKhuyenMai : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormQuanLyKhuyenMai()
        {
            InitializeComponent();
            LoadData();
        }
        private bool checkLoiNhapDL()
        {
            if(txtMaKM.Text.Trim() == "")
            {
                errorProvider1.SetError(txtMaKM, "Phải nhập mã khuyến mại!");
                txtMaKM.Focus();
                return false;
            }
            else if(txtGiam.Text.Trim() =="")
            {
                errorProvider1.SetError(txtGiam, "Không được để trống");
                txtGiam.Focus();
                return false;
            }
            else if(dptKT.Value<dtpBD.Value)
            {
                errorProvider1.SetError(dptKT, "Ngày kết thúc trước ngày bắt đầu");
                dptKT.Focus();
                return false;
            }
            return true;
        }
        private void clearTextBox()
        {
            txtMaKM.Text = "";
            txtGiam.Text = "";
        }
        private void LoadData()
        {
            dgv_DSKM.Rows.Clear();
            try
            {
                var query = from km in db.KhuyenMais
                            select km;
                foreach(var item in query)
                {
                    var trangthai = "";
                    if(item.NgayBd.Value>DateTime.Now)
                    {
                        trangthai = "Chưa áp dụng";
                    }
                    else if (item.NgayKt.Value < DateTime.Now)
                    {
                        trangthai = "Đã hết hạn";
                    }
                    else if(item.NgayBd<=DateTime.Now && item.NgayKt >= DateTime.Now)
                    {
                        trangthai = "Đang áp dụng";
                    }
                    dgv_DSKM.Rows.Add(item.MaKm,item.GiamGia,item.NgayBd,item.NgayKt,trangthai.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkLoiNhapDL())
                {
                    KhuyenMai km = new KhuyenMai();
                    km.MaKm = txtMaKM.Text;
                    if (db.KhuyenMais.Where(k => k.MaKm == km.MaKm).FirstOrDefault() != null)
                        throw new Exception("Mã khuyến mại đã tồn tại");
                    km.GiamGia = int.Parse(txtGiam.Text);
                    if (km.GiamGia == null)
                        throw new Exception("Bạn phải nhập số");
                    km.NgayBd = dtpBD.Value;
                    km.NgayKt = dptKT.Value;
                    db.KhuyenMais.Add(km);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                    DialogResult = DialogResult.OK;
                    clearTextBox();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaKM_TextChanged(object sender, EventArgs e)
        {
            if(txtMaKM.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void txtGiam_TextChanged(object sender, EventArgs e)
        {
            if (txtGiam.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void dptKT_ValueChanged(object sender, EventArgs e)
        {
            if(dptKT.Value != null)
            {
                errorProvider1.Clear();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkLoiNhapDL())
                {
                    KhuyenMai km = db.KhuyenMais.Where(km=>km.MaKm==txtMaKM.Text).FirstOrDefault();
                    if (km != null)
                    {
                        km.GiamGia = int.Parse(txtGiam.Text);
                        if (km.GiamGia == null)
                            throw new Exception("Phải nhập số vào Giảm Giá");
                        km.NgayBd = dtpBD.Value;
                        km.NgayKt = dptKT.Value;
                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công");
                        DialogResult = DialogResult.OK;
                        clearTextBox();
                        LoadData();
                    }
                    else
                        throw new Exception("Không tồn tại mã");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkLoiNhapDL())
                {
                    KhuyenMai km = db.KhuyenMais.Where(km => km.MaKm == txtMaKM.Text).FirstOrDefault();
                    if (km != null)
                    {
                        db.Remove(km);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công");
                        DialogResult = DialogResult.OK;
                        clearTextBox();
                        LoadData();
                    }
                    else
                        throw new Exception("Không tồn tại mã");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LoadData();
            clearTextBox();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgv_DSKM.Rows.Clear();
            try
            {
                var query = from km in db.KhuyenMais
                            where km.NgayBd.Value.Date <= dptTimKiem.Value.Date && km.NgayKt.Value.Date >= dptTimKiem.Value.Date
                            select new
                            {
                                km.MaKm,
                                km.GiamGia,
                                km.NgayBd,
                                km.NgayKt
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        var trangthai = "";
                        if (item.NgayBd.Value > DateTime.Now)
                        {
                            trangthai = "Chưa áp dụng";
                        }
                        else if (item.NgayKt.Value < DateTime.Now)
                        {
                            trangthai = "Đã hết hạn";
                        }
                        else if (item.NgayBd <= DateTime.Now && item.NgayKt >= DateTime.Now)
                        {
                            trangthai = "Đang áp dụng";
                        }
                        dgv_DSKM.Rows.Add(item.MaKm, item.GiamGia, item.NgayBd, item.NgayKt, trangthai.ToString());
                    }
                    clearTextBox();
                }
                else
                    throw new Exception("Ko tìm thấy mã khuyến mại");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_DSKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var km = db.KhuyenMais.SingleOrDefault(nv => nv.MaKm == dgv_DSKM.Rows[e.RowIndex].Cells[0].Value);
                txtMaKM.Text = km.MaKm;
                txtGiam.Text = km.GiamGia.ToString();
                dtpBD.Value = km.NgayBd.Value;
                dptKT.Value = km.NgayKt.Value;
            }
        }
    }
}
