using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class NhanVien
    {
        public string MaNv { get; set; } = null!;
        public int? MaCv { get; set; }
        public int? Id { get; set; }
        public string? TenNv { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? HinhAnh { get; set; }

        public virtual TaiKhoan? IdNavigation { get; set; }
        public virtual ChucVu? MaCvNavigation { get; set; }
    }
}
