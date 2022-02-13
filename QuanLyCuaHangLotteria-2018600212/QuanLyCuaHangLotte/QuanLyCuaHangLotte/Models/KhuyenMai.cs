using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class KhuyenMai
    {
        public string MaKm { get; set; } = null!;
        public int GiamGia { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }
    }
}
