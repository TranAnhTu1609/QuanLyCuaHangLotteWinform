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
    public partial class FormQuanLyChucVu : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormQuanLyChucVu()
        {
            InitializeComponent();
            loadData();
            txtTenCV.Focus();
        }
        private void clearTextBox()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
        }
        private bool kiemTraDuLieuNhap()
        {
            if (txtTenCV.Text == "")
            {
                errorProvider1.SetError(txtTenCV, "Bạn phải nhập menu!");
                return false;
            }
            return true;
        }
        private void loadData()
        {
            try
            {
                dgv_DSChucVu.Rows.Clear();
                var query = from cv in db.ChucVus
                            select new
                            {
                                cv.MaCv,
                                cv.TenCv
                            };
                foreach (var item in query)
                {
                    dgv_DSChucVu.Rows.Add(item.MaCv, item.TenCv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Thông báo");
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuNhap())
            {
                if ((db.ChucVus.SingleOrDefault(cv => cv.TenCv == txtTenCV.Text)) == null)
                {
                    ChucVu cv = new ChucVu();
                    cv.TenCv = txtTenCV.Text;
                    try
                    {
                        db.ChucVus.Add(cv);
                        db.SaveChanges();
                        MessageBox.Show("Đã được thêm!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Thông báo");
                    }
                    loadData();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại chức vụ này này!", "Thông báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuNhap())
            {
                var spSua = db.ChucVus.SingleOrDefault(cv => cv.MaCv == int.Parse(txtMaCV.Text));
                if (spSua != null)
                {
                    try
                    {
                        spSua.TenCv = txtTenCV.Text;
                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công");
                        loadData();
                        clearTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Không tồn tại chức vụ này!", "Thông báo");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuNhap())
            {
                var cvXoa = db.ChucVus.SingleOrDefault(cv => cv.MaCv == int.Parse(txtMaCV.Text));
                if (cvXoa != null)
                {
                    DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            db.Remove(cvXoa);
                            db.SaveChanges();
                            MessageBox.Show("Xóa thành công!");
                            loadData();
                            clearTextBox();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại chức vụ này!", "Thông báo");
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgv_DSChucVu.Rows.Clear();
            try
            {
                var query = from cv in db.ChucVus
                            where cv.MaCv == int.Parse(txtTimkiem.Text)
                            select new
                            {
                                cv.MaCv,
                                cv.TenCv
                            };
                foreach (var item in query)
                {
                    dgv_DSChucVu.Rows.Add(item.MaCv, item.TenCv);
                }
            }
            catch
            {
                var query = from cv in db.ChucVus
                            where cv.TenCv.Contains(txtTimkiem.Text)
                            select new
                            {
                                cv.MaCv,
                                cv.TenCv
                            };
                foreach (var item in query)
                {
                    dgv_DSChucVu.Rows.Add(item.MaCv, item.TenCv);
                }
            }
            if (dgv_DSChucVu.RowCount == 0)
            {
                MessageBox.Show("Không tìm thấy chức vụ nào");
            }
        }

        private void dgv_ChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                txtMaCV.Text = dgv_DSChucVu.Rows[index].Cells[0].Value.ToString();
                txtTenCV.Text = dgv_DSChucVu.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == '\r') 
                {
                    dgv_DSChucVu.Rows.Clear();
                    var query = from cv in db.ChucVus
                            where cv.MaCv == int.Parse(txtTimkiem.Text)
                            select new
                            {
                                cv.MaCv,
                                cv.TenCv
                            };
                foreach (var item in query)
                {
                    dgv_DSChucVu.Rows.Add(item.MaCv, item.TenCv);
                }
                    if(dgv_DSChucVu.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có sản phẩm nào ");
                    }
                }
            }
            catch
            {
                if(e.KeyChar == '\r')
                {
                    dgv_DSChucVu.Rows.Clear();
                    var query = from cv in db.ChucVus
                            where cv.TenCv.Contains(txtTimkiem.Text)
                            select new
                            {
                                cv.MaCv,
                                cv.TenCv
                            };
                foreach (var item in query)
                {
                    dgv_DSChucVu.Rows.Add(item.MaCv, item.TenCv);
                }
                    if (dgv_DSChucVu.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có sản phẩm nào ");
                    }
                }
            }
        }
    }
}
