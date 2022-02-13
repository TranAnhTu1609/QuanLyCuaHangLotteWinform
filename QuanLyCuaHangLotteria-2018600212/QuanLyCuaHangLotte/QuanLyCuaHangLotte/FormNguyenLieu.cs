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
    public partial class FormNguyenLieu : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        public FormNguyenLieu()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dgvNl.Rows.Clear();
            var query = from nl in db.NguyenLieus
                        select nl;
            dgvNl.Columns["Gia"].DefaultCellStyle.Format = "N0";
            if (query.Count() > 0)
            {
                foreach(var item in query)
                {
                    dgvNl.Rows.Add(item.MaNl,item.TenNl,item.DonGia);
                } 
            }
        }
        private void clearTextbox()
        {
            txtDonGia.Text = "";
            txtMaNl.Text = "";
            txtTenNl.Text = "";
            txtTimkiem.Text = "";
        }
        private bool checkNhap()
        {
            
            if(txtTenNl.Text == "")
            {
                MessageBox.Show("Tên nguyên liệu trống !", "Thông báo");
                return false;
            }
            if(txtDonGia.Text == "")
            {
                MessageBox.Show("Đơn giá trống !", "Thông báo");
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                if ((db.NguyenLieus.SingleOrDefault(cv => cv.TenNl == txtTenNl.Text)) == null)
                {
                    if (txtMaNl.Text != "")
                    {
                        var query = from nls in db.NguyenLieus
                                    where nls.MaNl == int.Parse(txtMaNl.Text)
                                    select nls;
                        if (query.Count() > 0)
                        {
                            MessageBox.Show("Mã nguyên liệu đã tồn tại !", "Thông báo");
                        }
                    }
                    else
                    {
                        NguyenLieu nl = new NguyenLieu();
                        nl.TenNl = txtTenNl.Text;
                        if (int.Parse(txtDonGia.Text) > 0)
                        {
                            nl.DonGia = int.Parse(txtDonGia.Text);
                            try
                            {
                                db.NguyenLieus.Add(nl);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Thông báo");
                            }
                            Kho kh = new Kho();
                            kh.MaNl = db.NguyenLieus.SingleOrDefault(nl => nl.TenNl == txtTenNl.Text).MaNl;
                            kh.SoLuong = 0;
                            try
                            {
                                db.Khos.Add(kh);
                                db.SaveChanges();
                                MessageBox.Show("Đã được thêm !");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Thông báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đơn giá phải là số", "Thống báo");
                        }

                        LoadData();
                        clearTextbox();
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại Nguyên Liệu này này này!", "Thông báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                dgvNl.Rows.Clear();                
                var nl = db.NguyenLieus.SingleOrDefault(nls=>nls.MaNl == int.Parse(txtMaNl.Text));
                if(nl != null)
                {
                    nl.TenNl = txtTenNl.Text;
                    if (int.Parse(txtDonGia.Text) > 0)
                    {
                        nl.DonGia = int.Parse(txtDonGia.Text);
                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Sửa thành công", "Thông báo");
                            LoadData();
                            clearTextbox();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn giá phải là số", "Thống báo");
                    }
                }
                else
                {
                    MessageBox.Show("Không có nguyên liệu này trong danh sách","Thông báo");
                }     
            }
        }

        private void dgvNl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    var nl = db.NguyenLieus.SingleOrDefault(nl => nl.TenNl == dgvNl.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtMaNl.Text = nl.MaNl.ToString();
                    txtTenNl.Text = nl.TenNl;
                    txtDonGia.Text = nl.DonGia.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextbox();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                var nl = db.NguyenLieus.SingleOrDefault(nl => nl.MaNl == int.Parse(txtMaNl.Text));
                if(nl != null)
                {
                    DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            var nlk = db.Khos.SingleOrDefault(nlk => nlk.MaNl == nl.MaNl);
                            if(nlk != null)
                            {
                                if (nlk.SoLuong != 0)
                                {
                                    MessageBox.Show("Hàng trong kho vẫn còn, không được xóa!", "Thông Báo");
                                }
                                else
                                {
                                    db.Remove(nlk);
                                    db.SaveChanges();
                                    db.Remove(nl);
                                    db.SaveChanges();
                                    MessageBox.Show("Xóa thành công!");
                                }
                            }
                            clearTextbox();
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Không có nguyên liệu này trong danh sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                try
                {
                    dgvNl.Rows.Clear();
                    dgvNl.Columns["Gia"].DefaultCellStyle.Format = "N0";
                    var query = from nl in db.NguyenLieus
                                where nl.TenNl.Contains(txtTimkiem.Text)
                                select nl;
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            dgvNl.Rows.Add(item.MaNl, item.TenNl, item.DonGia);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nguyên liệu nào", "Thông Báo");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                dgvNl.Rows.Clear();
                dgvNl.Columns["Gia"].DefaultCellStyle.Format = "N0";
                var query = from nl in db.NguyenLieus
                            where nl.TenNl.Contains(txtTimkiem.Text)
                            select nl;
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        dgvNl.Rows.Add(item.MaNl, item.TenNl, item.DonGia);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu nào", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
