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
    public partial class FormDatHang : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string TenNv;
        FormNhapHang formnhaphang;
        public FormDatHang()
        {
            InitializeComponent();
        }
        public FormDatHang(string TenNv,FormNhapHang f)
        {
            InitializeComponent();
            this.TenNv = TenNv;
            loadCbbTenNl();
            lblTenNv.Text = TenNv;
            dptNgayTao.Value = DateTime.Now;
            formnhaphang = f;
        }
        private bool checkNhap()
        {
            if (txtSoLuongDat.Text == "")
            {
                MessageBox.Show("ko được để trống số lượng");
                return false;
            }
            return true;
        }
        private void TinhTien()
        {
            double tt = 0;
            for (int i = 0; i < dgvDatHang.RowCount; i++)
            {
                tt += double.Parse(dgvDatHang.Rows[i].Cells[4].Value.ToString());
            }

            lblThanhTien.Text = string.Format("{0:N0}", tt);
        }
        private void loadCbbTenNl()
        {
            try
            {
                var query = from nl in db.NguyenLieus
                            select new
                            {
                                nl.TenNl
                            };
                if(query.Count() > 0)
                {
                    foreach(var item in query)
                    {
                        cbbTenNl.Items.Add(item.TenNl);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                if(int.Parse(txtSoLuongDat.Text) > 0) 
                {
                    try
                    {
                        int sl = int.Parse(txtSoLuongDat.Text);
                        dgvDatHang.Columns["Gia"].DefaultCellStyle.Format = "N0";
                        dgvDatHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                        var query = from nl in db.NguyenLieus
                                    where nl.TenNl == cbbTenNl.Text
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
                                if (dgvDatHang.RowCount > 0)
                                {
                                    for (int i = 0; i < dgvDatHang.RowCount; i++)
                                    {

                                        if (dgvDatHang.Rows[i].Cells[0].Value.ToString() == item.MaNl.ToString() && dgvDatHang.Rows[i].Cells[1].Value.ToString() == item.TenNl.ToString())
                                        {
                                            dgvDatHang.Rows[i].Cells[2].Value = sl + int.Parse(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                                            dgvDatHang.Rows[i].Cells[4].Value = double.Parse(dgvDatHang.Rows[i].Cells[2].Value.ToString()) * item.DonGia;
                                            check++;
                                        }
                                    }
                                }
                                if (check == 0)
                                {
                                    dgvDatHang.Rows.Add(item.MaNl, item.TenNl, sl, item.DonGia, sl * item.DonGia);
                                }
                            }
                            TinhTien();
                            txtSoLuongDat.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thêm được nguyên liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (int.Parse(txtSoLuongDat.Text) == 0)
                {
                    MessageBox.Show("Số lượng đặt phải lớn hơn 0", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Số lượng đặt phải là số", "Thông báo");
                }
                
            }
        }

        private void cbbTenNl_TextChanged(object sender, EventArgs e)
        {
            txtSoLuongDat.Clear();
            if (cbbTenNl.Text == "")
            {
                txtDonGia.Text = "";
                txtSLton.Text = "";
            }
            else
            {
                var query = from nl in db.NguyenLieus
                            where nl.TenNl == cbbTenNl.Text
                            select new
                            {
                                nl.DonGia,
                                nl.Kho.SoLuong
                            };    
               
                    foreach (var item in query)
                    {
                        txtDonGia.Text = item.DonGia.ToString();
                        txtSLton.Text = item.SoLuong.ToString();
                    }
                         
            }       
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                if (int.Parse(txtSoLuongDat.Text) > 0)
                {
                    try
                    {
                        int sl = int.Parse(txtSoLuongDat.Text);
                        dgvDatHang.Columns["Gia"].DefaultCellStyle.Format = "N0";
                        dgvDatHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                        var query = from nl in db.NguyenLieus
                                    where nl.TenNl == cbbTenNl.Text
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
                                if (dgvDatHang.RowCount > 0)
                                {
                                    for (int i = 0; i < dgvDatHang.RowCount; i++)
                                    {

                                        if (dgvDatHang.Rows[i].Cells[0].Value.ToString() == item.MaNl.ToString() && dgvDatHang.Rows[i].Cells[1].Value.ToString() == item.TenNl.ToString())
                                        {
                                            dgvDatHang.Rows[i].Cells[2].Value = sl;
                                            dgvDatHang.Rows[i].Cells[4].Value = double.Parse(dgvDatHang.Rows[i].Cells[2].Value.ToString()) * item.DonGia;
                                            check++;
                                        }
                                    }
                                }
                                if (check == 0)
                                {
                                    MessageBox.Show("Nguyên liệu chưa có trong đơn hàng, không thể sửa", "Thông báo");
                                }
                            }
                            TinhTien();
                            txtSoLuongDat.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thêm được nguyên liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (int.Parse(txtSoLuongDat.Text) == 0)
                {
                    MessageBox.Show("Số lượng đặt phải lớn hơn 0", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Số lượng đặt phải là số", "Thông báo");
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkNhap())
            {
                try
                {
                    var query = from nl in db.NguyenLieus
                                where nl.TenNl == cbbTenNl.Text
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
                            if (dgvDatHang.RowCount > 0)
                            {
                                for (int i = 0; i < dgvDatHang.RowCount; i++)
                                {

                                    if (dgvDatHang.Rows[i].Cells[0].Value.ToString() == item.MaNl.ToString() && dgvDatHang.Rows[i].Cells[1].Value.ToString() == item.TenNl.ToString())
                                    {
                                        dgvDatHang.Rows.RemoveAt(i);
                                        check++;
                                    }
                                }
                            }
                            if (check == 0)
                            {
                                MessageBox.Show("Nguyên liệu chưa có trong đơn hàng, không thể xóa", "Thông báo");
                            }

                        }
                        TinhTien();
                        txtSoLuongDat.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var query = from nl in db.NguyenLieus
                            where nl.TenNl == dgvDatHang.Rows[e.RowIndex].Cells[1].Value.ToString()
                            select new
                            {
                                nl.Kho.SoLuong
                            };
                foreach(var item in query)
                {
                    txtSLton.Text = item.SoLuong + "";
                }
                cbbTenNl.Text = "";
                cbbTenNl.Text = dgvDatHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDonGia.Text = dgvDatHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSoLuongDat.Text = dgvDatHang.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgvDatHang.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có nguyên liệu trong danh sách", "Thông báo");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Xác nhận tạo đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    HoaDonKho hdk = new HoaDonKho();
                    hdk.NgayCc = dptNgayTao.Value.Date;
                    hdk.TrangThai = "Chờ xác nhận";
                    db.Add(hdk);
                    try
                    {
                        db.SaveChanges();
                        CthoaDonKho cthdk = new CthoaDonKho();
                        cthdk.MaHdk = hdk.MaHdk;
                        for (int i = 0; i < dgvDatHang.RowCount; i++)
                        {
                            cthdk.MaNl = int.Parse(dgvDatHang.Rows[i].Cells[0].Value.ToString());
                            cthdk.SoLuong = int.Parse(dgvDatHang.Rows[i].Cells[2].Value.ToString());
                            db.Add(cthdk);
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error");
                            }
                        }
                        MessageBox.Show("Tạo đơn nhập hàng thành công", "Thông báo");
                        formnhaphang.loadData();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                    
            }
        }
    }
}
