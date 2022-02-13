using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class CthoaDonKho
    {
        public int MaHdk { get; set; }
        public int MaNl { get; set; }
        public int SoLuong { get; set; }
        public virtual HoaDonKho MaHdkNavigation { get; set; } = null!;
        public virtual NguyenLieu MaNlNavigation { get; set; } = null!;
    }
}
