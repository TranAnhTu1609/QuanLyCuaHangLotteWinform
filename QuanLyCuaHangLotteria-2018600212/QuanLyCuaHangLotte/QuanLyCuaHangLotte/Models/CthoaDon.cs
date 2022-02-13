using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class CthoaDon
    {
        public int MaHd { get; set; }
        public int MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; } = null!;
        public virtual SanPham MaSpNavigation { get; set; } = null!;
    }
}
