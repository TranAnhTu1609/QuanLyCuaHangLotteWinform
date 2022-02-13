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
    public partial class FormQuanLyLoaiMon : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormQuanLyLoaiMon()
        {
            InitializeComponent();
            loadData();
            txtTenLoaiMon.Focus();
        }
        private void clearTextBox()
        {
            txtMaMon.Clear();
            txtTenLoaiMon.Clear();
        }
        private bool kiemTraDuLieuNhap()
        {
            if (txtTenLoaiMon.Text == "")
            {
                errorProvider1.SetError(txtTenLoaiMon, "Bạn phải nhập menu!");
                return false;
            }
            return true;
        }
        private void loadData()
        {
            try
            {
                dgv_DSLoaiSPham.Rows.Clear();
                var query = from lsp in db.LoaiSps
                            select new
                            {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    dgv_DSLoaiSPham.Rows.Add(item.MaLsp, item.TenLsp);
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
                if ((db.LoaiSps.SingleOrDefault(lsp => lsp.TenLsp == txtTenLoaiMon.Text)) == null)
                {
                    LoaiSp lsp = new LoaiSp();
                    lsp.TenLsp = txtTenLoaiMon.Text;
                    try
                    {
                        db.LoaiSps.Add(lsp);
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
                    MessageBox.Show("Đã tồn tại loại sản phẩm này!", "Thông báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuNhap())
            {
                var spSua = db.LoaiSps.SingleOrDefault(lsp => lsp.MaLsp == int.Parse(txtMaMon.Text));
                if (spSua != null)
                {
                    try
                    {
                        spSua.TenLsp = txtTenLoaiMon.Text;
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
                    MessageBox.Show("Không tồn tại menu này!", "Thông báo");
                }
            }
        }

        private void dgv_DSLoaiSPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                txtMaMon.Text = dgv_DSLoaiSPham.Rows[index].Cells[0].Value.ToString();
                txtTenLoaiMon.Text = dgv_DSLoaiSPham.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kiemTraDuLieuNhap())
            {
                var lspXoa = db.LoaiSps.SingleOrDefault(lsp => lsp.MaLsp == int.Parse(txtMaMon.Text));
                if (lspXoa != null)
                {
                    DialogResult dialog = MessageBox.Show("Bạn muốn đóng xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            db.Remove(lspXoa);
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
                    MessageBox.Show("Không tồn tại menu này!", "Thông báo");
                }
            }
        }

        private void txtMaMon_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgv_DSLoaiSPham.Rows.Clear();
            try
            {
                var query = from lsp in db.LoaiSps
                            where lsp.MaLsp == int.Parse(txtTimkiem.Text)
                            select new {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    dgv_DSLoaiSPham.Rows.Add(item.MaLsp,item.TenLsp);
                }
            }
            catch
            {
                var query = from lsp in db.LoaiSps
                            where lsp.TenLsp.Contains(txtTimkiem.Text)
                            select new
                            {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    dgv_DSLoaiSPham.Rows.Add(item.MaLsp, item.TenLsp);
                }
            }
            if(dgv_DSLoaiSPham.RowCount==0)
            {
                MessageBox.Show("Không tìm thấy menu nào");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') { 
            try
            {
                dgv_DSLoaiSPham.Rows.Clear();
                var query = from lsp in db.LoaiSps
                            where lsp.MaLsp == int.Parse(txtTimkiem.Text)
                            select new
                            {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    dgv_DSLoaiSPham.Rows.Add(item.MaLsp, item.TenLsp);
                }
                if (dgv_DSLoaiSPham.RowCount == 0)
                {
                    MessageBox.Show("Không tìm thấy menu nào");
                }
            }
            catch
            {
                dgv_DSLoaiSPham.Rows.Clear();
                var query = from lsp in db.LoaiSps
                            where lsp.TenLsp.Contains(txtTimkiem.Text)
                            select new
                            {
                                lsp.MaLsp,
                                lsp.TenLsp
                            };
                foreach (var item in query)
                {
                    dgv_DSLoaiSPham.Rows.Add(item.MaLsp, item.TenLsp);
                }
                if (dgv_DSLoaiSPham.RowCount == 0)
                {
                    MessageBox.Show("Không tìm thấy menu nào");
                }
            }
            }

        }
    }
}
