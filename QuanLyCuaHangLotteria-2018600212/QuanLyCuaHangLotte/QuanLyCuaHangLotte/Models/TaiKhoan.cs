using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int Id { get; set; }
        public string TaiKhoan1 { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public int? Quyen { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
