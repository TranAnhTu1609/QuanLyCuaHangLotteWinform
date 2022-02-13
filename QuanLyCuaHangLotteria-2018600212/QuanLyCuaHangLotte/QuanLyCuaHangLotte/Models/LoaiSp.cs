using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaLsp { get; set; }
        public string TenLsp { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
