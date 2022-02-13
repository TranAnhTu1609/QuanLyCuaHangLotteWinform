using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CthoaDons = new HashSet<CthoaDon>();
        }

        public int MaSp { get; set; }
        public string TenSp { get; set; } = null!;
        public int MaLsp { get; set; }
        public string DonVi { get; set; } = null!;
        public double DonGia { get; set; }
        public string MoTa { get; set; } = null!;
        public string HinhAnh { get; set; } = null!;

        public virtual LoaiSp MaLspNavigation { get; set; } = null!;
        public virtual ICollection<CthoaDon> CthoaDons { get; set; }
    }
}
