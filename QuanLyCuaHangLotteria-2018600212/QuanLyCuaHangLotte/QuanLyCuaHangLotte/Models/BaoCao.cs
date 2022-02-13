using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class BaoCao
    {
        public int MaBc { get; set; }
        public string TenNv { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public string? Loai { get; set; }
        public string? Mota { get; set; }
    }
}
