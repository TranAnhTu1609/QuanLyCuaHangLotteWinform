using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using QuanLyCuaHangLotte.Models;

namespace QuanLyCuaHangLotte
{
    public partial class FormQuanLyNhanSu : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        string filename, iname;
        public FormQuanLyNhanSu()
        {
            InitializeComponent();
            LoadData();
            loadCmb();
        }
        private bool KTEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool checkEmail()
        {
            if (txtEmail.Text == "")
            {
                
                errorProvider1.SetError(txtEmail, "Bạn hãy nhập Email!");
                txtEmail.Focus();
                return false;
            }
            else
            {
                if (KTEmail(txtEmail.Text) == false)
                {
                    
                    errorProvider1.SetError(txtEmail, "Email bạn nhập không chính xác");
                    txtEmail.Focus();
                    return false;
                }
                return true;
            }
        }
        private bool checkLoiNhapLieu()
        {
            if (txtTenNV.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTenNV, "Phải nhập tên nhân viên!");
                txtTenNV.Focus();
                return false;
            }
            else if (dtpNgaySinh.Text == "")
            {
                errorProvider1.SetError(dtpNgaySinh, "Bạn hãy nhập ngày sinh!");
                dtpNgaySinh.Focus();
            }
            else if (dtpNgaySinh.Text !="")
            {
                try
                {
                    int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;
                    if (tuoi < 18)
                        throw new Exception("Nhân viên phải từ 18 tuổi trở lên!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtDiaChi.Text.Trim() == "")
            {
                errorProvider1.SetError(txtDiaChi, "Phải nhập địa chỉ");
                txtDiaChi.Focus();
                return false;
            }
            else if (cmbChucVu.SelectedItem == null)
            {
                errorProvider1.SetError(cmbChucVu, "Phải chọn chức vụ");
                cmbChucVu.Focus();
                return false;
            }
            else if (txtSdt.Text.Trim() == "")
            {
                errorProvider1.SetError(txtSdt, "Phải nhập số điện thoại");
                txtSdt.Focus();
                return false;
            }
            else if (txtTaiKhoan.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTaiKhoan, "Phải nhập tên tài khoản");
                txtTaiKhoan.Focus();
                return false;
            }

            return true;
        }
        private void clearTextBox()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSdt.Text = "";
            txtTaiKhoan.Text = "";
            cmbChucVu.Text = "";
            txtTimkiem.Text = "";
            pcbMoTa.Image = null;
        }
        public void LoadData()
        {
            try
            {
                dgv_DSNV.Rows.Clear();
                var query = from nv in db.NhanViens
                            select new
                            {
                                nv.MaNv,
                                nv.TenNv,
                                nv.GioiTinh,
                                nv.NgaySinh,
                                nv.DiaChi,
                                nv.SoDienThoai,
                                nv.Email,
                                cv = nv.MaCvNavigation.TenCv
                            };
                foreach (var item in query)
                {
                    dgv_DSNV.Rows.Add(item.MaNv, item.TenNv, item.GioiTinh, item.cv, item.NgaySinh, item.DiaChi, item.SoDienThoai, item.Email);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkLoiNhapLieu() && checkEmail())
                {
                    NhanVien nvm = new NhanVien();
                    nvm.MaNv = txtMaNV.Text;
                    nvm.TenNv = txtTenNV.Text;
                    if (radNam.Checked)
                        nvm.GioiTinh = "Nam";
                    else if (radNu.Checked)
                        nvm.GioiTinh = "Nữ";
                    nvm.NgaySinh = dtpNgaySinh.Value;
                    nvm.DiaChi = txtDiaChi.Text;
                    nvm.Email = txtEmail.Text;
                    nvm.SoDienThoai = txtSdt.Text;
                    foreach (var item in db.ChucVus)
                    {
                        if (item.TenCv == cmbChucVu.Text)
                        {
                            nvm.MaCv = item.MaCv;
                        }
                    }
                    if (iname != null)
                    {
                        nvm.HinhAnh = iname;
                        if (!File.Exists(pathImage() + iname))
                        {
                            File.Copy(filename, pathImage() + iname);
                        }
                    }
                    if (db.TaiKhoans.Where(tk => tk.TaiKhoan1 == txtTaiKhoan.Text).FirstOrDefault() != null)
                        throw new Exception("Tài khoản đã tồn tại");
                    TaiKhoan tkm = new TaiKhoan();
                    tkm.TaiKhoan1 = txtTaiKhoan.Text;
                    tkm.MatKhau = txtMatKhau.Text;
                    if (cmbChucVu.Text == "Admin")
                        tkm.Quyen = 1;
                    else if (cmbChucVu.Text == "Nhân Viên")
                        tkm.Quyen = 3;
                    else
                        tkm.Quyen = 2;
                    db.TaiKhoans.Add(tkm);
                    db.SaveChanges();
                    foreach (var item in db.TaiKhoans)
                    {
                        if (item.TaiKhoan1 == txtTaiKhoan.Text)
                            nvm.Id = item.Id;
                    }
                    db.NhanViens.Add(nvm);

                    db.SaveChanges();
                    iname = null;
                    MessageBox.Show("Thêm thành công");
                    DialogResult = DialogResult.OK;
                    clearTextBox();
                    LoadData();
                }
                 
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbChucVu_TextChanged(object sender, EventArgs e)
        {
            if (cmbChucVu.SelectedItem != null)
                errorProvider1.Clear();
        }
        private void loadCmb()
        {
            try
            {
                var query = from cv in db.ChucVus
                            select cv.TenCv;
                foreach (var item in query)
                {
                    cmbChucVu.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Thông báo");
            }
        }
        private string pathImage()
        {
            //Lấy đường dẫn thư mục lưu ảnh
            string pathProject = Application.StartupPath;
            string newPath = pathProject.Substring(0, pathProject.Length - 25) + "Image" + '\\';
            return newPath;
        }

        private void dgv_DSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var nv = db.NhanViens.SingleOrDefault(nv => nv.MaNv == dgv_DSNV.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtMaNV.Text = nv.MaNv;
                txtTenNV.Text = nv.TenNv;
                if (nv.GioiTinh == "Nam")
                    radNam.Checked = true;
                else if (nv.GioiTinh == "Nữ")
                    radNu.Checked = true;
                dtpNgaySinh.Value = nv.NgaySinh.Value;
                txtDiaChi.Text = nv.DiaChi;
                txtEmail.Text = nv.Email;
                txtSdt.Text = nv.SoDienThoai;
                cmbChucVu.Text = db.ChucVus.SingleOrDefault(ch=>ch.MaCv.Equals(nv.MaCv)).TenCv;
                txtTaiKhoan.Text = db.TaiKhoans.SingleOrDefault(tk => tk.Id.Equals(nv.Id)).TaiKhoan1;
                try
                {
                    pcbMoTa.Image = new Bitmap(pathImage() + nv.HinhAnh);
                }
                catch (Exception)
                {
                    pcbMoTa.Image = null;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkLoiNhapLieu() && checkEmail())
                {
                    NhanVien nvm = db.NhanViens.Where(nvm => nvm.MaNv == txtMaNV.Text).FirstOrDefault();
                    if (nvm == null)
                    {
                        throw new Exception("Mã Nhân Viên ko tồn tại");
                    }
                    else
                    {
                        nvm.TenNv = txtTenNV.Text;
                        if (radNam.Checked)
                            nvm.GioiTinh = "Nam";
                        else if (radNu.Checked)
                            nvm.GioiTinh = "Nữ";
                        nvm.NgaySinh = dtpNgaySinh.Value;
                        nvm.DiaChi = txtDiaChi.Text;
                        nvm.Email = txtEmail.Text;
                        nvm.SoDienThoai = txtSdt.Text;
                        foreach (var item in db.ChucVus)
                        {
                            if (item.TenCv == cmbChucVu.Text)
                            {
                                nvm.MaCv = item.MaCv;
                            }
                        }
                        if (iname != null)
                        {
                            nvm.HinhAnh = iname;
                            if (!File.Exists(pathImage() + iname))
                            {
                                File.Copy(filename, pathImage() + iname);
                            }
                        }
                        TaiKhoan tkm = db.TaiKhoans.Where(tk=>tk.Id==nvm.Id).FirstOrDefault();
                        tkm.TaiKhoan1 = txtTaiKhoan.Text;
                        if (cmbChucVu.Text == "Admin")
                            tkm.Quyen = 1;
                        else if (cmbChucVu.Text == "Nhân Viên")
                            tkm.Quyen = 3;
                        else
                            tkm.Quyen = 2;
                        db.SaveChanges();
                        iname = null;
                        MessageBox.Show("Sửa thành công");
                        DialogResult = DialogResult.OK;
                        clearTextBox();
                        LoadData();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkLoiNhapLieu())
            {
                
                try
                {
                    NhanVien nvm = db.NhanViens.Where(nvm => nvm.MaNv == txtMaNV.Text).FirstOrDefault();
                    if (nvm == null)
                    {
                        throw new Exception("Mã Nhân Viên ko tồn tại");
                    }
                    
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        TaiKhoan tkm = db.TaiKhoans.Where(tk => tk.Id == nvm.Id).FirstOrDefault();
                        db.TaiKhoans.Remove(tkm);     
                        db.SaveChanges();
                        db.NhanViens.Remove(nvm);
                        db.SaveChanges();
                        MessageBox.Show("Đã được xóa!");
                        LoadData();
                        clearTextBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgv_DSNV.Rows.Clear();
            try
            {
                var query = from nv in db.NhanViens
                            join cv in db.ChucVus on nv.MaCv equals cv.MaCv
                            where nv.MaNv.Contains(txtTimkiem.Text)
                            select new
                            {
                                nv.MaNv,
                                nv.TenNv,
                                nv.GioiTinh,
                                nv.SoDienThoai,
                                nv.DiaChi,
                                nv.Email,
                                nv.NgaySinh,
                                cv.TenCv
                            };
                var query1 = from nv in db.NhanViens
                            join cv in db.ChucVus on nv.MaCv equals cv.MaCv
                            where nv.TenNv.Contains(txtTimkiem.Text)
                            select new
                            {
                                nv.MaNv,
                                nv.TenNv,
                                nv.GioiTinh,
                                nv.SoDienThoai,
                                nv.DiaChi,
                                nv.Email,
                                nv.NgaySinh,
                                cv.TenCv
                            };
                if (query.Count() > 0)
                {
                    foreach(var item in query)
                    {
                        dgv_DSNV.Rows.Add(item.MaNv,item.TenNv,item.GioiTinh,item.TenCv,item.NgaySinh,item.DiaChi,item.SoDienThoai,item.Email);
                    }
                }
                else if(query1.Count()>0)
                {
                    foreach (var item in query1)
                    {
                        dgv_DSNV.Rows.Add(item.MaNv, item.TenNv, item.GioiTinh, item.TenCv, item.NgaySinh, item.DiaChi, item.SoDienThoai, item.Email);
                    }
                }
                else
                {
                    LoadData();
                    MessageBox.Show("không tìm thấy kết quả phù hợp");
                }
                clearTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if(txtMaNV.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

            if (txtDiaChi.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            if (txtEmail.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            if (txtSdt.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != null)
            {
                errorProvider1.Clear();
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog browse = new()
                {
                    Title = "Chọn ảnh",
                    Filter = "All files|*.*|Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|Png files(*.png)|*.png|Jpeg files(*.jpeg)|*.jpeg|Jpe files(*.jpe)|*.jpe|Jpg files(*.jpg)|*.jpg"
                };
                if (browse.ShowDialog() == DialogResult.OK)
                {
                    iname = Path.GetFileName(browse.FileName);
                    filename = browse.FileName;
                    pcbMoTa.Image = Image.FromFile(browse.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
