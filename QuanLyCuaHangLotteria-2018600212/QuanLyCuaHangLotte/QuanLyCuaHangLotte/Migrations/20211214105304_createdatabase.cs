using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangLotte.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "BaoCao",
                columns: table => new
                {
                    MaBC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BaoCao__272475A6F1117D53", x => x.MaBC);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChucVu__27258E7617BC66EF", x => x.MaCV);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Pos = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NgayThang = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDon__2725A6E0AD335A5F", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonKho",
                columns: table => new
                {
                    MaHDK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayCC = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDonKh__3C90E8C3925FFBA1", x => x.MaHDK);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaKM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GiamGia = table.Column<int>(type: "int", nullable: false),
                    NgayBD = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayKT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhuyenMa__2725CF1579011D90", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSP",
                columns: table => new
                {
                    MaLSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLSP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiSP__3B983FFE1810E57A", x => x.MaLSP);
                });

            migrationBuilder.CreateTable(
                name: "NguyenLieu",
                columns: table => new
                {
                    MaNL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NguyenLi__2725D73C390B34E3", x => x.MaNL);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Quyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaLSP = table.Column<int>(type: "int", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__2725081C85763F31", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_LSP_SP",
                        column: x => x.MaLSP,
                        principalTable: "LoaiSP",
                        principalColumn: "MaLSP");
                });

            migrationBuilder.CreateTable(
                name: "CTHoaDonKho",
                columns: table => new
                {
                    MaHDK = table.Column<int>(type: "int", nullable: false),
                    MaNL = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    SoLuongDaNhap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CTHoaDon__EEE2B5B0A7B67A37", x => new { x.MaHDK, x.MaNL });
                    table.ForeignKey(
                        name: "fk_hdk_cthdk",
                        column: x => x.MaHDK,
                        principalTable: "HoaDonKho",
                        principalColumn: "MaHDK");
                    table.ForeignKey(
                        name: "fk_hdk_nl",
                        column: x => x.MaNL,
                        principalTable: "NguyenLieu",
                        principalColumn: "MaNL");
                });

            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    MaNL = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kho__2725D73C23B9B15F", x => x.MaNL);
                    table.ForeignKey(
                        name: "fk_K_SP",
                        column: x => x.MaNL,
                        principalTable: "NguyenLieu",
                        principalColumn: "MaNL");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    MaCV = table.Column<int>(type: "int", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: true),
                    TenNV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__2725D70A4CC601B8", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK__NhanVien__ID__46E78A0C",
                        column: x => x.ID,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_CV_NV",
                        column: x => x.MaCV,
                        principalTable: "ChucVu",
                        principalColumn: "MaCV");
                });

            migrationBuilder.CreateTable(
                name: "CTHoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CTHoaDon__F557F66196C881DC", x => new { x.MaHD, x.MaSP });
                    table.ForeignKey(
                        name: "fk_hd_cthd",
                        column: x => x.MaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD");
                    table.ForeignKey(
                        name: "fk_hd_sp",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDon_MaSP",
                table: "CTHoaDon",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDonKho_MaNL",
                table: "CTHoaDonKho",
                column: "MaNL");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ID",
                table: "NhanVien",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaCV",
                table: "NhanVien",
                column: "MaCV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaLSP",
                table: "SanPham",
                column: "MaLSP");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropTable(
                name: "CTHoaDon");

            migrationBuilder.DropTable(
                name: "CTHoaDonKho");

            migrationBuilder.DropTable(
                name: "Kho");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "HoaDonKho");

            migrationBuilder.DropTable(
                name: "NguyenLieu");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "LoaiSP");
        }
    }
}
