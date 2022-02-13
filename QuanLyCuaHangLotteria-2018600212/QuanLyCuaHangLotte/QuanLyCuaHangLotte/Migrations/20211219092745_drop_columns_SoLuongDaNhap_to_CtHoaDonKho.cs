using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangLotte.Migrations
{
    public partial class drop_columns_SoLuongDaNhap_to_CtHoaDonKho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongDaNhap",
                table: "CTHoaDonKho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongDaNhap",
                table: "CTHoaDonKho",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
