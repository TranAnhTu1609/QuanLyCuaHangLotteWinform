USE [QuanLyCuaHangLotte]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoCao]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCao](
	[MaBC] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](20) NOT NULL,
	[NgayLap] [datetime] NULL,
	[Loai] [nvarchar](50) NULL,
	[Mota] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHoaDon]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDon](
	[MaHD] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHoaDonKho]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonKho](
	[MaHDK] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDK] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](20) NULL,
	[Pos] [varchar](10) NULL,
	[NgayThang] [datetime] NULL,
	[MaKm] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonKho]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonKho](
	[MaHDK] [int] IDENTITY(1,1) NOT NULL,
	[NgayCC] [datetime] NOT NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaNL] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKM] [nvarchar](20) NOT NULL,
	[GiamGia] [int] NOT NULL,
	[NgayBD] [datetime] NULL,
	[NgayKT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLSP] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNL] [int] IDENTITY(1,1) NOT NULL,
	[TenNL] [nvarchar](50) NOT NULL,
	[DonGia] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](12) NOT NULL,
	[MaCV] [int] NULL,
	[ID] [int] NULL,
	[TenNV] [nvarchar](20) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SoDienThoai] [char](10) NULL,
	[Email] [varchar](50) NULL,
	[HinhAnh] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](50) NOT NULL,
	[MaLSP] [int] NOT NULL,
	[DonVi] [nvarchar](50) NOT NULL,
	[DonGia] [float] NOT NULL,
	[MoTa] [nvarchar](200) NOT NULL,
	[HinhAnh] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/13/2022 9:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](20) NOT NULL,
	[MatKhau] [varchar](20) NOT NULL,
	[Quyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211214105304_createdatabase', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211214105425_add_column_makm_to_table_HD', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211214110424_add_nullable_to_makm', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211219092745_drop_columns_SoLuongDaNhap_to_CtHoaDonKho', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[BaoCao] ON 

INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (1, N'Trần Anh Tú', CAST(N'2021-12-20T23:02:41.257' AS DateTime), N'Xuất Hàng', N'Bánh mì SL: 3 DG: 15000Thành tiền:45000 VNĐGà SL: 6 DG: 75000Thành tiền:450000 VNĐNước ngọt SL: 5 DG: 15000Thành tiền:75000 VNĐCơm SL: 5 DG: 100000Thành tiền:500000 VNĐ
Tổng: 1,070,000 VNĐ')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (2, N'Trần Anh Tú', CAST(N'2021-12-22T04:11:22.137' AS DateTime), N'Nhập Hàng', N'
Bánh mì SL: 10 DG: 15000-Thành tiền:150000 VNĐ
Cơm SL: 10 DG: 100000-Thành tiền:1000000 VNĐ
Gà SL: 10 DG: 75000-Thành tiền:750000 VNĐ
Nước ngọt SL: 50 DG: 15000-Thành tiền:750000 VNĐ
Tổng: 2,650,000 VNĐ')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (3, N'Trần Anh Tú', CAST(N'2021-12-22T04:22:32.740' AS DateTime), N'Nhập Hàng', N'
Bánh mì SL: 10 DG: 15000-Thành tiền:150000 VNĐ
Cơm SL: 10 DG: 100000-Thành tiền:1000000 VNĐ
Gà SL: 10 DG: 75000-Thành tiền:750000 VNĐ
Nước ngọt SL: 50 DG: 15000-Thành tiền:750000 VNĐ
Tổng: 2,650,000 VNĐ')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (8, N'Trần Anh Tú', CAST(N'2021-12-22T13:48:39.270' AS DateTime), N'Hủy đơn', N'
Bánh mì SL: 10 DG: 15000-Thành tiền:150000 VNĐ
Cơm SL: 10 DG: 100000-Thành tiền:1000000 VNĐ
Gà SL: 10 DG: 75000-Thành tiền:750000 VNĐ
Nước ngọt SL: 50 DG: 15000-Thành tiền:750000 VNĐ
Tổng: 2,650,000 VNĐ
lí do hủy đơn: Số lượng hàng thiếu')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (13, N'Trần Anh Tú', CAST(N'2021-12-31T22:50:56.740' AS DateTime), N'Xuất Hàng', N'
Bánh mì SL: 1 DG: 15000-Thành tiền:15000 VNĐ
Cơm SL: 1 DG: 100000-Thành tiền:100000 VNĐ
Tổng: 115,000 VNĐ')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (14, N'Trần Anh Tú', CAST(N'2022-01-05T10:36:58.590' AS DateTime), N'Nhập Hàng', N'
Bánh mì SL: 20 DG: 15000-Thành tiền:300000 VNĐ
Cơm SL: 15 DG: 100000-Thành tiền:1500000 VNĐ
Gà SL: 2 DG: 75000-Thành tiền:150000 VNĐ
Nước ngọt SL: 5 DG: 15000-Thành tiền:75000 VNĐ
Tổng: 2,025,000 VNĐ')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [Mota]) VALUES (15, N'Trần Anh Tú', CAST(N'2022-01-13T21:04:38.283' AS DateTime), N'Hủy đơn', N'
Mì Ý SL: 20 DG: 20000-Thành tiền:400000 VNĐ
Thịt bò SL: 5 DG: 160000-Thành tiền:800000 VNĐ
Cà chua SL: 10 DG: 5000-Thành tiền:50000 VNĐ
Tổng: 1,250,000 VNĐ
lí do hủy đơn: Thiếu hàng')
SET IDENTITY_INSERT [dbo].[BaoCao] OFF
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (1, N'Admin')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (2, N'Quản Lý Kho')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (3, N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (2, 8, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (3, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (4, 16, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (5, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (5, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (5, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (5, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (6, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (6, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (6, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (6, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (7, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (7, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (7, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (7, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (7, 17, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (8, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (8, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (8, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (8, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (9, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (9, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (9, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (9, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (9, 7, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (10, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (10, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (10, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (10, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (11, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (11, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (11, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (11, 4, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (11, 7, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 1, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 7, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 8, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 9, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 16, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 17, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (13, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (13, 3, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (13, 16, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (13, 17, 1)
GO
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (1, 1, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (1, 2, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (1, 3, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (1, 5, 50)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (2, 2, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (2, 3, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (3, 1, 20)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (3, 2, 15)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (3, 3, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (3, 5, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (4, 1, 1)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (4, 2, 4)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (4, 3, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (4, 5, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (5, 1, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (5, 2, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (5, 3, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (5, 5, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (6, 7, 20)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (6, 8, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (6, 9, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (7, 7, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (7, 8, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (7, 9, 10)
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (1, N'Trần Anh Tú', N'1', CAST(N'2021-12-14T21:47:27.697' AS DateTime), NULL)
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (2, N'Trần Anh Tú', N'1', CAST(N'2021-12-15T00:19:11.733' AS DateTime), N'KM02')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (3, N'Trần Anh Tú', N'1', CAST(N'2021-12-15T00:28:25.377' AS DateTime), N'KM02')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (4, N'Trần Anh Tú', N'3', CAST(N'2021-12-15T00:32:34.680' AS DateTime), N'KM02')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (5, N'Trần Anh Tú', N'3', CAST(N'2021-12-15T00:45:51.160' AS DateTime), N'KM02')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (6, N'Trần Anh Tú', N'1', CAST(N'2021-12-15T00:51:37.583' AS DateTime), NULL)
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (7, N'Trần Anh Tú', N'3', CAST(N'2021-12-15T00:55:14.883' AS DateTime), N'KM02')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (8, N'Trần Anh Tú', N'', CAST(N'2021-12-19T22:43:52.947' AS DateTime), NULL)
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (9, N'Trần Việt Tiến', N'1', CAST(N'2021-12-31T23:08:07.203' AS DateTime), N'KM03')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (10, N'Trần Việt Tiến', N'2', CAST(N'2021-12-31T23:09:47.743' AS DateTime), N'KM03')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (11, N'Trần Việt Tiến', N'1', CAST(N'2021-12-31T23:25:53.713' AS DateTime), NULL)
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (12, N'Trần Anh Tú', N'3', CAST(N'2022-01-13T18:39:18.303' AS DateTime), N'KM04')
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [Pos], [NgayThang], [MaKm]) VALUES (13, N'Trần Anh Tú', N'3', CAST(N'2022-01-13T18:40:21.970' AS DateTime), N'KM04')
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonKho] ON 

INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (1, CAST(N'2021-12-21T00:00:00.000' AS DateTime), N'Hoàn thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (2, CAST(N'2021-12-22T00:00:00.000' AS DateTime), N'Hủy đơn')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (3, CAST(N'2021-12-22T00:00:00.000' AS DateTime), N'Hoàn thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (4, CAST(N'2021-12-31T00:00:00.000' AS DateTime), N'Chờ hoàn thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (5, CAST(N'2022-01-05T00:00:00.000' AS DateTime), N'Chờ hoàn thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (6, CAST(N'2022-01-05T00:00:00.000' AS DateTime), N'Hủy đơn')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (7, CAST(N'2022-01-05T00:00:00.000' AS DateTime), N'Chờ hoàn thành')
SET IDENTITY_INSERT [dbo].[HoaDonKho] OFF
GO
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (1, 59)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (2, 54)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (3, 42)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (5, 165)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (7, 0)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (8, 0)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (9, 0)
GO
INSERT [dbo].[KhuyenMai] ([MaKM], [GiamGia], [NgayBD], [NgayKT]) VALUES (N'KM01', 10, CAST(N'2021-12-09T00:00:00.000' AS DateTime), CAST(N'2021-12-10T00:00:00.000' AS DateTime))
INSERT [dbo].[KhuyenMai] ([MaKM], [GiamGia], [NgayBD], [NgayKT]) VALUES (N'KM02', 30, CAST(N'2021-12-11T00:00:00.000' AS DateTime), CAST(N'2021-12-17T00:00:00.000' AS DateTime))
INSERT [dbo].[KhuyenMai] ([MaKM], [GiamGia], [NgayBD], [NgayKT]) VALUES (N'KM03', 15, CAST(N'2021-12-23T00:00:00.000' AS DateTime), CAST(N'2022-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[KhuyenMai] ([MaKM], [GiamGia], [NgayBD], [NgayKT]) VALUES (N'KM04', 20, CAST(N'2022-01-08T00:00:00.000' AS DateTime), CAST(N'2022-02-04T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 

INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (1, N'Combo')
INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (2, N'Burger')
INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (3, N'Gà Rán')
INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (4, N'Cơm-Mì Ý')
INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (5, N'Đồ Uống')
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
GO
SET IDENTITY_INSERT [dbo].[NguyenLieu] ON 

INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (1, N'Bánh mì', 15000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (2, N'Cơm', 100000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (3, N'Gà', 75000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (5, N'Nước ngọt', 15000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (7, N'Mì Ý', 20000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (8, N'Thịt bò', 160000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (9, N'Cà chua', 5000)
SET IDENTITY_INSERT [dbo].[NguyenLieu] OFF
GO
INSERT [dbo].[NhanVien] ([MaNV], [MaCV], [ID], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [HinhAnh]) VALUES (N'NV01        ', 1, 1, N'Trần Anh Tú', N'Nam', CAST(N'2000-09-16T00:00:00.000' AS DateTime), N'Hưng Yên', N'0987654321', N'admin@gmail.com', N'pl.jpg')
INSERT [dbo].[NhanVien] ([MaNV], [MaCV], [ID], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [HinhAnh]) VALUES (N'NV02        ', 2, 9, N'Trần Việt Tiến', N'Nam', CAST(N'1999-05-29T00:00:00.000' AS DateTime), N'Ha Noi', N'012345678 ', N'viettien@gmail.com', N'02058c576dfd81a3d8ec.jpg')
INSERT [dbo].[NhanVien] ([MaNV], [MaCV], [ID], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [HinhAnh]) VALUES (N'NV03        ', 2, 10, N'Trần Tú Anh', N'Nam', CAST(N'2000-09-16T00:00:00.000' AS DateTime), N'Hưng Yên', N'0192837465', N'anhtu@gmail.com', NULL)
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (1, N'Burger Mozzarella', 2, N'Cái', 58364, N'1 Burger Mozzarella', N'burger-534x374px_mozzarella-burger.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (2, N'Gà nướng', 3, N'Miếng', 301545, N'9 miếng', N'chicken-534x374px_grilled-chicken_2.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (3, N'Gà sốt H&S', 3, N'Miếng', 301545, N'9 miếng', N'chicken-534x374px_hs-chicken_1.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (4, N'Gà sốt phô mai', 3, N'Miếng', 301545, N'9 miếng', N'chicken-534x374px_cheese-chicken_1.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (7, N'Combo 129', 1, N'combo', 125482, N'Combo bao gồm:

- 01 Burger double double 

- 01 Gà rán

- 01 Khoai tây lắc 

- 02 Pepsi (M)', N'vuive-534x374px-02.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (8, N'Combo 79', 1, N'combo', 76845, N'Combo bao gồm:

- 01 Burger bò Teriyaki trứng 

- 01 Mì ý

- 01 Khoai tây chiên (M) 

- 01 Pepsi (M)', N'vuive-534x374px-01.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (9, N'Combo Pokemon 1', 1, N'combo', 164391, N'Combo bao gồm:

- 02 Miếng Gà Rán

- 01 Burger Tôm

- 01 Khoai Tây Chiên (M)

- 02 Pepsi (M)

Tặng kèm 1 gấu bông Pokemon (ngẫu nhiên)', N'pokemon-534x374px_combo1.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (10, N'Combo Pokemon 2', 1, N'combo', 164391, N'Combo bao gồm:

- 01 Gà rán 

- 01 Burger bulgogi

- 01 Burger tôm

- 01 Khoai tây chiên (M) 

- 02 Pepsi (M)

Tặng kèm 1 gấu bông Pokemon (ngẫu nhiên)', N'pokemon-534x374px_combo2.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (15, N'Combo Pokemon 3', 1, N'combo', 164391, N'Combo bao gồm:

- 02 Gà rán 

- 01 Mì ý

- 01 Phần cá nugget (3 miếng)

- 01 Khoai tây chiên (M) 

- 02 Pepsi (M)

Tặng kèm 1 gấu bông Pokemon (ngẫu nhiên)', N'pokemon-534x374px_combo3.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (16, N'Nước Cam', 5, N'cốc', 27236, N'1 nước cam', N'drink-534x374px_orange.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (17, N'7 Up Cherry', 5, N'cốc', 24318, N'1 7 Up Cherry', N'drink-534x374px_7upcherry.png')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [DonVi], [DonGia], [MoTa], [HinhAnh]) VALUES (18, N'7 Up Rose', 5, N'cốc', 24318, N'1 7 Up Rose', N'drink-534x374px_7uprose.png')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (1, N'admin', N'12345678', 1)
INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (9, N'tien1999', N'12345678', 2)
INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (10, N'tu2000', N'12345678', 2)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[CTHoaDon]  WITH CHECK ADD  CONSTRAINT [fk_hd_cthd] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[CTHoaDon] CHECK CONSTRAINT [fk_hd_cthd]
GO
ALTER TABLE [dbo].[CTHoaDon]  WITH CHECK ADD  CONSTRAINT [fk_hd_sp] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[CTHoaDon] CHECK CONSTRAINT [fk_hd_sp]
GO
ALTER TABLE [dbo].[CTHoaDonKho]  WITH CHECK ADD  CONSTRAINT [fk_hdk_cthdk] FOREIGN KEY([MaHDK])
REFERENCES [dbo].[HoaDonKho] ([MaHDK])
GO
ALTER TABLE [dbo].[CTHoaDonKho] CHECK CONSTRAINT [fk_hdk_cthdk]
GO
ALTER TABLE [dbo].[CTHoaDonKho]  WITH CHECK ADD  CONSTRAINT [fk_hdk_nl] FOREIGN KEY([MaNL])
REFERENCES [dbo].[NguyenLieu] ([MaNL])
GO
ALTER TABLE [dbo].[CTHoaDonKho] CHECK CONSTRAINT [fk_hdk_nl]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [fk_K_SP] FOREIGN KEY([MaNL])
REFERENCES [dbo].[NguyenLieu] ([MaNL])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [fk_K_SP]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[TaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [fk_CV_NV] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [fk_CV_NV]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_LSP_SP] FOREIGN KEY([MaLSP])
REFERENCES [dbo].[LoaiSP] ([MaLSP])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_LSP_SP]
GO
