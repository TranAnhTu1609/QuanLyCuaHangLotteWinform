﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyCuaHangLotte.Models;

#nullable disable

namespace QuanLyCuaHangLotte.Migrations
{
    [DbContext(typeof(QuanLyCuaHangLotteContext))]
    [Migration("20211214110424_add_nullable_to_makm")]
    partial class add_nullable_to_makm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.BaoCao", b =>
                {
                    b.Property<int>("MaBc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaBC");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBc"), 1L, 1);

                    b.Property<string>("Loai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mota")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("NgayLap")
                        .HasColumnType("datetime");

                    b.Property<string>("TenNv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TenNV");

                    b.HasKey("MaBc")
                        .HasName("PK__BaoCao__272475A6F1117D53");

                    b.ToTable("BaoCao", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.ChucVu", b =>
                {
                    b.Property<int>("MaCv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaCV");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCv"), 1L, 1);

                    b.Property<string>("TenCv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TenCV");

                    b.HasKey("MaCv")
                        .HasName("PK__ChucVu__27258E7617BC66EF");

                    b.ToTable("ChucVu", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.CthoaDon", b =>
                {
                    b.Property<int>("MaHd")
                        .HasColumnType("int")
                        .HasColumnName("MaHD");

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaHd", "MaSp")
                        .HasName("PK__CTHoaDon__F557F66196C881DC");

                    b.HasIndex("MaSp");

                    b.ToTable("CTHoaDon", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.CthoaDonKho", b =>
                {
                    b.Property<int>("MaHdk")
                        .HasColumnType("int")
                        .HasColumnName("MaHDK");

                    b.Property<int>("MaNl")
                        .HasColumnType("int")
                        .HasColumnName("MaNL");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongDaNhap")
                        .HasColumnType("int");

                    b.HasKey("MaHdk", "MaNl")
                        .HasName("PK__CTHoaDon__EEE2B5B0A7B67A37");

                    b.HasIndex("MaNl");

                    b.ToTable("CTHoaDonKho", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaHD");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHd"), 1L, 1);

                    b.Property<string>("MaKm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayThang")
                        .HasColumnType("datetime");

                    b.Property<string>("Pos")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TenNv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TenNV");

                    b.HasKey("MaHd")
                        .HasName("PK__HoaDon__2725A6E0AD335A5F");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.HoaDonKho", b =>
                {
                    b.Property<int>("MaHdk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaHDK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHdk"), 1L, 1);

                    b.Property<DateTime>("NgayCc")
                        .HasColumnType("datetime")
                        .HasColumnName("NgayCC");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MaHdk")
                        .HasName("PK__HoaDonKh__3C90E8C3925FFBA1");

                    b.ToTable("HoaDonKho", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.Kho", b =>
                {
                    b.Property<int>("MaNl")
                        .HasColumnType("int")
                        .HasColumnName("MaNL");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaNl")
                        .HasName("PK__Kho__2725D73C23B9B15F");

                    b.ToTable("Kho", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.KhuyenMai", b =>
                {
                    b.Property<string>("MaKm")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("MaKM");

                    b.Property<int>("GiamGia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBd")
                        .HasColumnType("datetime")
                        .HasColumnName("NgayBD");

                    b.Property<DateTime?>("NgayKt")
                        .HasColumnType("datetime")
                        .HasColumnName("NgayKT");

                    b.HasKey("MaKm")
                        .HasName("PK__KhuyenMa__2725CF1579011D90");

                    b.ToTable("KhuyenMai", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.LoaiSp", b =>
                {
                    b.Property<int>("MaLsp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaLSP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLsp"), 1L, 1);

                    b.Property<string>("TenLsp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TenLSP");

                    b.HasKey("MaLsp")
                        .HasName("PK__LoaiSP__3B983FFE1810E57A");

                    b.ToTable("LoaiSP", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.NguyenLieu", b =>
                {
                    b.Property<int>("MaNl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaNL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNl"), 1L, 1);

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("TenNl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TenNL");

                    b.HasKey("MaNl")
                        .HasName("PK__NguyenLi__2725D73C390B34E3");

                    b.ToTable("NguyenLieu", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNv")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .HasColumnName("MaNV")
                        .IsFixedLength();

                    b.Property<string>("DiaChi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HinhAnh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int?>("MaCv")
                        .HasColumnType("int")
                        .HasColumnName("MaCV");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("TenNv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TenNV");

                    b.HasKey("MaNv")
                        .HasName("PK__NhanVien__2725D70A4CC601B8");

                    b.HasIndex("Id");

                    b.HasIndex("MaCv");

                    b.ToTable("NhanVien", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.SanPham", b =>
                {
                    b.Property<int>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSp"), 1L, 1);

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("DonVi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaLsp")
                        .HasColumnType("int")
                        .HasColumnName("MaLSP");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TenSP");

                    b.HasKey("MaSp")
                        .HasName("PK__SanPham__2725081C85763F31");

                    b.HasIndex("MaLsp");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("Quyen")
                        .HasColumnType("int");

                    b.Property<string>("TaiKhoan1")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TaiKhoan");

                    b.HasKey("Id");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.CthoaDon", b =>
                {
                    b.HasOne("QuanLyCuaHangLotte.Models.HoaDon", "MaHdNavigation")
                        .WithMany("CthoaDons")
                        .HasForeignKey("MaHd")
                        .IsRequired()
                        .HasConstraintName("fk_hd_cthd");

                    b.HasOne("QuanLyCuaHangLotte.Models.SanPham", "MaSpNavigation")
                        .WithMany("CthoaDons")
                        .HasForeignKey("MaSp")
                        .IsRequired()
                        .HasConstraintName("fk_hd_sp");

                    b.Navigation("MaHdNavigation");

                    b.Navigation("MaSpNavigation");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.CthoaDonKho", b =>
                {
                    b.HasOne("QuanLyCuaHangLotte.Models.HoaDonKho", "MaHdkNavigation")
                        .WithMany("CthoaDonKhos")
                        .HasForeignKey("MaHdk")
                        .IsRequired()
                        .HasConstraintName("fk_hdk_cthdk");

                    b.HasOne("QuanLyCuaHangLotte.Models.NguyenLieu", "MaNlNavigation")
                        .WithMany("CthoaDonKhos")
                        .HasForeignKey("MaNl")
                        .IsRequired()
                        .HasConstraintName("fk_hdk_nl");

                    b.Navigation("MaHdkNavigation");

                    b.Navigation("MaNlNavigation");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.Kho", b =>
                {
                    b.HasOne("QuanLyCuaHangLotte.Models.NguyenLieu", "MaNlNavigation")
                        .WithOne("Kho")
                        .HasForeignKey("QuanLyCuaHangLotte.Models.Kho", "MaNl")
                        .IsRequired()
                        .HasConstraintName("fk_K_SP");

                    b.Navigation("MaNlNavigation");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.NhanVien", b =>
                {
                    b.HasOne("QuanLyCuaHangLotte.Models.TaiKhoan", "IdNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK__NhanVien__ID__46E78A0C");

                    b.HasOne("QuanLyCuaHangLotte.Models.ChucVu", "MaCvNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("MaCv")
                        .HasConstraintName("fk_CV_NV");

                    b.Navigation("IdNavigation");

                    b.Navigation("MaCvNavigation");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.SanPham", b =>
                {
                    b.HasOne("QuanLyCuaHangLotte.Models.LoaiSp", "MaLspNavigation")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaLsp")
                        .IsRequired()
                        .HasConstraintName("FK_LSP_SP");

                    b.Navigation("MaLspNavigation");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.HoaDon", b =>
                {
                    b.Navigation("CthoaDons");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.HoaDonKho", b =>
                {
                    b.Navigation("CthoaDonKhos");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.LoaiSp", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.NguyenLieu", b =>
                {
                    b.Navigation("CthoaDonKhos");

                    b.Navigation("Kho")
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.SanPham", b =>
                {
                    b.Navigation("CthoaDons");
                });

            modelBuilder.Entity("QuanLyCuaHangLotte.Models.TaiKhoan", b =>
                {
                    b.Navigation("NhanViens");
                });
#pragma warning restore 612, 618
        }
    }
}
