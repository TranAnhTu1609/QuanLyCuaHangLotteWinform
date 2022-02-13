using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int MaCv { get; set; }
        public string TenCv { get; set; } = null!;

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
