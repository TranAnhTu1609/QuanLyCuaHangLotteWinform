using System;
using System.Collections.Generic;

namespace QuanLyCuaHangLotte.Models
{
    public partial class HoaDonKho
    {
        public HoaDonKho()
        {
            CthoaDonKhos = new HashSet<CthoaDonKho>();
        }

        public int MaHdk { get; set; }
        public DateTime NgayCc { get; set; }
        public string TrangThai { get; set; } = null!;
        public virtual ICollection<CthoaDonKho> CthoaDonKhos { get; set; }
    }
}
