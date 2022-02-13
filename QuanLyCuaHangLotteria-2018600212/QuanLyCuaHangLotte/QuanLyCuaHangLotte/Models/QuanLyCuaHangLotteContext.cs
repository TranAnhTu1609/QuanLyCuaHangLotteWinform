using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLyCuaHangLotte.Models
{
    public partial class QuanLyCuaHangLotteContext : DbContext
    {
        public QuanLyCuaHangLotteContext()
        {
        }

        public QuanLyCuaHangLotteContext(DbContextOptions<QuanLyCuaHangLotteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaoCao> BaoCaos { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<CthoaDon> CthoaDons { get; set; } = null!;
        public virtual DbSet<CthoaDonKho> CthoaDonKhos { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoaDonKho> HoaDonKhos { get; set; } = null!;
        public virtual DbSet<Kho> Khos { get; set; } = null!;
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; } = null!;
        public virtual DbSet<LoaiSp> LoaiSps { get; set; } = null!;
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7BGGF23;Initial Catalog=QuanLyCuaHangLotte;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaoCao>(entity =>
            {
                entity.HasKey(e => e.MaBc)
                    .HasName("PK__BaoCao__272475A6F1117D53");

                entity.ToTable("BaoCao");

                entity.Property(e => e.MaBc).HasColumnName("MaBC");

                entity.Property(e => e.Loai).HasMaxLength(50);

                entity.Property(e => e.Mota).HasMaxLength(300);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(20)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__ChucVu__27258E7617BC66EF");

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaCv).HasColumnName("MaCV");

                entity.Property(e => e.TenCv)
                    .HasMaxLength(20)
                    .HasColumnName("TenCV");
            });

            modelBuilder.Entity<CthoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp })
                    .HasName("PK__CTHoaDon__F557F66196C881DC");

                entity.ToTable("CTHoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.CthoaDons)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hd_cthd");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CthoaDons)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hd_sp");
            });

            modelBuilder.Entity<CthoaDonKho>(entity =>
            {
                entity.HasKey(e => new { e.MaHdk, e.MaNl })
                    .HasName("PK__CTHoaDon__EEE2B5B0A7B67A37");

                entity.ToTable("CTHoaDonKho");

                entity.Property(e => e.MaHdk).HasColumnName("MaHDK");

                entity.Property(e => e.MaNl).HasColumnName("MaNL");

                entity.HasOne(d => d.MaHdkNavigation)
                    .WithMany(p => p.CthoaDonKhos)
                    .HasForeignKey(d => d.MaHdk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hdk_cthdk");

                entity.HasOne(d => d.MaNlNavigation)
                    .WithMany(p => p.CthoaDonKhos)
                    .HasForeignKey(d => d.MaNl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hdk_nl");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E0AD335A5F");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.NgayThang).HasColumnType("datetime");

                entity.Property(e => e.Pos)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(20)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<HoaDonKho>(entity =>
            {
                entity.HasKey(e => e.MaHdk)
                    .HasName("PK__HoaDonKh__3C90E8C3925FFBA1");

                entity.ToTable("HoaDonKho");

                entity.Property(e => e.MaHdk).HasColumnName("MaHDK");

                entity.Property(e => e.NgayCc)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayCC");

                entity.Property(e => e.TrangThai).HasMaxLength(20);
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.MaNl)
                    .HasName("PK__Kho__2725D73C23B9B15F");

                entity.ToTable("Kho");

                entity.Property(e => e.MaNl)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNL");

                entity.HasOne(d => d.MaNlNavigation)
                    .WithOne(p => p.Kho)
                    .HasForeignKey<Kho>(d => d.MaNl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_K_SP");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKm)
                    .HasName("PK__KhuyenMa__2725CF1579011D90");

                entity.ToTable("KhuyenMai");

                entity.Property(e => e.MaKm)
                    .HasMaxLength(20)
                    .HasColumnName("MaKM");

                entity.Property(e => e.NgayBd)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKT");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLsp)
                    .HasName("PK__LoaiSP__3B983FFE1810E57A");

                entity.ToTable("LoaiSP");

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.TenLsp)
                    .HasMaxLength(20)
                    .HasColumnName("TenLSP");
            });

            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.HasKey(e => e.MaNl)
                    .HasName("PK__NguyenLi__2725D73C390B34E3");

                entity.ToTable("NguyenLieu");

                entity.Property(e => e.MaNl).HasColumnName("MaNL");

                entity.Property(e => e.TenNl)
                    .HasMaxLength(50)
                    .HasColumnName("TenNL");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A4CC601B8");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaCv).HasColumnName("MaCV");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNv)
                    .HasMaxLength(20)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__NhanVien__ID__46E78A0C");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("fk_CV_NV");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C85763F31");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.DonVi).HasMaxLength(50);

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLspNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSP_SP");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TaiKhoan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
