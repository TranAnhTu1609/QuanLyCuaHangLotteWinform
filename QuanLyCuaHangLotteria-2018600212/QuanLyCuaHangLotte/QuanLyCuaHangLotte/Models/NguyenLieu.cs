using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class NguyenLieu
    {
        public NguyenLieu()
        {
            CthoaDonKhos = new HashSet<CthoaDonKho>();
        }

        public int MaNl { get; set; }
        public string TenNl { get; set; } = null!;
        public double DonGia { get; set; }

        public virtual Kho Kho { get; set; } = null!;
        public virtual ICollection<CthoaDonKho> CthoaDonKhos { get; set; }
    }
}
