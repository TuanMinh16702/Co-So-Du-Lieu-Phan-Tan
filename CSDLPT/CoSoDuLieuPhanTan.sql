USE [QLVT]
GO
/****** Object:  User [NV7]    Script Date: 12/23/2024 11:56:49 PM ******/
CREATE USER [NV7] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[NV7]
GO
/****** Object:  DatabaseRole [MSmerge_5DA03BAA894C403DBA24AF9930560074]    Script Date: 12/23/2024 11:56:49 PM ******/
CREATE ROLE [MSmerge_5DA03BAA894C403DBA24AF9930560074]
GO
/****** Object:  DatabaseRole [MSmerge_7BF0B2728CFD479EBC40BE818BC6DFF5]    Script Date: 12/23/2024 11:56:49 PM ******/
CREATE ROLE [MSmerge_7BF0B2728CFD479EBC40BE818BC6DFF5]
GO
/****** Object:  DatabaseRole [MSmerge_PAL_role]    Script Date: 12/23/2024 11:56:49 PM ******/
CREATE ROLE [MSmerge_PAL_role]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_5DA03BAA894C403DBA24AF9930560074]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_7BF0B2728CFD479EBC40BE818BC6DFF5]
GO
/****** Object:  Schema [MSmerge_PAL_role]    Script Date: 12/23/2024 11:56:49 PM ******/
CREATE SCHEMA [MSmerge_PAL_role]
GO
/****** Object:  Schema [NV7]    Script Date: 12/23/2024 11:56:49 PM ******/
CREATE SCHEMA [NV7]
GO
/****** Object:  View [dbo].[Get_Subscribes]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Get_Subscribes]
AS
SELECT TENCN=PUBS.description, TENSERVER=subscriber_server
 FROM sysmergepublications  PUBS, sysmergesubscriptions SUBS
 WHERE PUBS.pubid = SUBS.pubid AND  publisher <> subscriber_server
GO
/****** Object:  Table [dbo].[ChiNhanh]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiNhanh](
	[MaCN] [char](10) NOT NULL,
	[TenCN] [nvarchar](100) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__ChiNhanh__27258E0EDB38D27A] PRIMARY KEY CLUSTERED 
(
	[MaCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonDatHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonDatHang](
	[MaDDH] [char](10) NOT NULL,
	[MaHH] [char](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ChiTietDonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaDDH] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[SoHD] [char](10) NOT NULL,
	[MaHH] [char](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__ChiTietH__EE4EF139F828EEE7] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietNhanVien]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNhanVien](
	[MACN] [char](10) NOT NULL,
	[MANV] [char](10) NOT NULL,
	[NGAYCHUYEN] [date] NOT NULL,
	[NGAYKETTHUC] [date] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_CT_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MACN] ASC,
	[MANV] ASC,
	[NGAYCHUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[SoPN] [char](10) NOT NULL,
	[MaHH] [char](10) NOT NULL,
	[SoLuong] [int] NULL,
	[SoluongTon] [int] NULL,
	[DonGia] [float] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__ChiTietP__EE4E301DCC4EF17B] PRIMARY KEY CLUSTERED 
(
	[SoPN] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonDatHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatHang](
	[MaDDH] [char](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaNV] [char](10) NOT NULL,
	[MaNCC] [char](10) NOT NULL,
	[MaKho] [char](10) NULL,
	[TrangThai] [bit] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__DonDatHa__3D88C804389B4B3A] PRIMARY KEY CLUSTERED 
(
	[MaDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHH] [char](10) NOT NULL,
	[TenHH] [nvarchar](100) NOT NULL,
	[DonViTinh] [nvarchar](20) NOT NULL,
	[MaLH] [char](10) NOT NULL,
	[TrangThai] [bit] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__HangHoa__2725A6E49A6928B6] PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[SoHD] [char](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaNV] [char](10) NOT NULL,
	[MaKH] [char](10) NOT NULL,
	[MaKho] [char](10) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__HoaDon__BC3CAB57DEAF1061] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [char](10) NOT NULL,
	[TenKH] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SoDienThoai] [char](10) NOT NULL,
	[MaCN] [char](10) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__KhachHan__2725CF1E2ABA66B1] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaKho] [char](10) NOT NULL,
	[TenKho] [nvarchar](100) NOT NULL,
	[MaCN] [char](10) NOT NULL,
	[TrangThai] [bit] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__Kho__3BDA9350B5EAA5B3] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLH] [char](10) NOT NULL,
	[TenLH] [nvarchar](100) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__LoaiHang__2725C77F8985B9FA] PRIMARY KEY CLUSTERED 
(
	[MaLH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [char](10) NOT NULL,
	[TenNCC] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SoDienThoai] [char](10) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__NhaCungC__3A185DEB02B089ED] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](10) NOT NULL,
	[Ho] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[Phai] [nvarchar](3) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SoDienThoai] [char](10) NOT NULL,
	[TrangThai] [bit] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__NhanVien__2725D70AC8CF8E74] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[SoPN] [char](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaDDH] [char](10) NOT NULL,
	[MaNV] [char](10) NOT NULL,
	[MaKho] [char](10) NOT NULL,
	[TrangThai] [bit] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK__PhieuNha__BC3C6A73C7AD817B] PRIMARY KEY CLUSTERED 
(
	[SoPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiNhanh] ([MaCN], [TenCN], [rowguid]) VALUES (N'CN1       ', N'Chi Nhánh 1', N'b080e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiNhanh] ([MaCN], [TenCN], [rowguid]) VALUES (N'CN2       ', N'Chi Nhánh 2', N'b180e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH1      ', N'MG1       ', 2, 60000000, N'1081e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH10     ', N'MG1       ', 1, 20000000, N'1181e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH11     ', N'MS1       ', 50, 20000000, N'1281e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH12     ', N'TV3       ', 6, 20000000, N'1381e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH13     ', N'MG1       ', 10, 20000000, N'1481e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH14     ', N'TV1       ', 5, 40000000, N'1581e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH15     ', N'MS2       ', 10, 1000000, N'1681e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH16     ', N'TV2       ', 5, 20000000, N'1781e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH17     ', N'MS2       ', 1, 1000000, N'beedf8bf-82c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH2      ', N'TL2       ', 2, 40000000, N'1881e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH3      ', N'TV1       ', 2, 46000000, N'1981e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH4      ', N'MS2       ', 5, 1000000, N'1a81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH5      ', N'MS2       ', 5, 1000000, N'1b81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH6      ', N'TL2       ', 10, 20000000, N'1c81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH8      ', N'MS2       ', 2, 10000000, N'1d81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietDonDatHang] ([MaDDH], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'DDH9      ', N'TV3       ', 1, 50000000, N'1e81e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'1         ', N'MG1       ', 1, 40000000, N'1f81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'10        ', N'MG1       ', 1, 60000000, N'3457a2ff-d8c0-ef11-9b30-dc215ca89f93')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'10        ', N'MS2       ', 2, 60000000, N'3357a2ff-d8c0-ef11-9b30-dc215ca89f93')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'2         ', N'TL2       ', 1, 25000000, N'2081e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'3         ', N'TV1       ', 1, 25000000, N'2181e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'4         ', N'MS2       ', 3, 250000, N'2281e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'5         ', N'MG1       ', 1, 60000000, N'2381e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'6         ', N'MS2       ', 2, 1000000, N'2481e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'6         ', N'TV3       ', 2, 20000000, N'2581e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'7         ', N'MG1       ', 2, 20000000, N'2681e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'7         ', N'MS2       ', 2, 1000000, N'2781e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'8         ', N'MS2       ', 1, 60000000, N'ff32e7b8-7bc0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaHH], [SoLuong], [DonGia], [rowguid]) VALUES (N'9         ', N'TV2       ', 1, 20000000, N'c3db974f-7cc0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN1       ', N'NV1       ', CAST(N'2024-10-15' AS Date), NULL, N'dd80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN1       ', N'NV11      ', CAST(N'2024-12-22' AS Date), NULL, N'3a8b5118-7dc0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN1       ', N'NV3       ', CAST(N'2024-10-16' AS Date), NULL, N'de80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN1       ', N'NV5       ', CAST(N'2024-10-20' AS Date), NULL, N'df80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN1       ', N'NV7       ', CAST(N'2024-12-01' AS Date), NULL, N'e080e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN2       ', N'NV10      ', CAST(N'2024-12-14' AS Date), NULL, N'e180e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN2       ', N'NV2       ', CAST(N'2024-10-16' AS Date), NULL, N'e280e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN2       ', N'NV4       ', CAST(N'2024-10-17' AS Date), NULL, N'e380e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN2       ', N'NV6       ', CAST(N'2024-10-20' AS Date), NULL, N'e480e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN2       ', N'NV8       ', CAST(N'2024-12-14' AS Date), NULL, N'e580e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietNhanVien] ([MACN], [MANV], [NGAYCHUYEN], [NGAYKETTHUC], [rowguid]) VALUES (N'CN2       ', N'NV9       ', CAST(N'2024-12-14' AS Date), NULL, N'e680e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN1       ', N'MG1       ', 1, 0, 60000000, N'2a81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN10      ', N'TV3       ', 2, 2, 20000000, N'2b81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN11      ', N'TV3       ', 1, 1, 20000000, N'2c81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN12      ', N'TV3       ', 1, 1, 20000000, N'2d81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN13      ', N'MG1       ', 5, 3, 20000000, N'2e81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN14      ', N'MG1       ', 2, 2, 20000000, N'2f81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN15      ', N'MG1       ', 3, 3, 20000000, N'3081e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN16      ', N'TV2       ', 3, 2, 20000000, N'3181e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN2       ', N'TL2       ', 2, 2, 20000000, N'3281e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN3       ', N'TV1       ', 2, 2, 46000000, N'3381e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN4       ', N'MS2       ', 5, 3, 1000000, N'3481e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN5       ', N'MS2       ', 3, 0, 60000000, N'3581e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN6       ', N'MG1       ', 1, 1, 60000000, N'3681e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN7       ', N'MG1       ', 1, 1, 60000000, N'3781e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN8       ', N'MS2       ', 2, 2, 1000000, N'3881e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaHH], [SoLuong], [SoluongTon], [DonGia], [rowguid]) VALUES (N'PN9       ', N'TV3       ', 2, 2, 20000000, N'3981e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH1      ', CAST(N'2024-09-15' AS Date), N'NV1       ', N'NCC2      ', N'1         ', 1, N'e780e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH10     ', CAST(N'2024-12-01' AS Date), N'NV3       ', N'NCC1      ', N'3         ', 1, N'e880e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH11     ', CAST(N'2024-12-02' AS Date), N'NV3       ', N'NCC2      ', N'2         ', 0, N'e980e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH12     ', CAST(N'2024-12-11' AS Date), N'NV3       ', N'NCC4      ', N'3         ', 1, N'ea80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH13     ', CAST(N'2024-12-13' AS Date), N'NV4       ', N'NCC1      ', N'4         ', 1, N'eb80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH14     ', CAST(N'2024-12-13' AS Date), N'NV4       ', N'NCC1      ', N'4         ', 1, N'ec80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH15     ', CAST(N'2024-12-14' AS Date), N'NV4       ', N'NCC3      ', N'10        ', 1, N'ed80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH16     ', CAST(N'2024-12-22' AS Date), N'NV3       ', N'NCC3      ', N'3         ', 1, N'ee80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH17     ', CAST(N'2024-12-22' AS Date), N'NV3       ', N'NCC1      ', N'1         ', 0, N'bdedf8bf-82c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH2      ', CAST(N'2024-09-14' AS Date), N'NV2       ', N'NCC3      ', N'4         ', 1, N'ef80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH3      ', CAST(N'2024-09-15' AS Date), N'NV1       ', N'NCC1      ', N'2         ', 1, N'f080e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH4      ', CAST(N'2024-09-15' AS Date), N'NV2       ', N'NCC2      ', N'5         ', 1, N'f180e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH5      ', CAST(N'2024-10-01' AS Date), N'NV1       ', N'NCC2      ', N'3         ', 1, N'f280e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH6      ', CAST(N'2024-10-02' AS Date), N'NV1       ', N'NCC2      ', N'3         ', 1, N'f380e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH7      ', CAST(N'2024-10-02' AS Date), N'NV7       ', N'NCC2      ', N'3         ', 1, N'f480e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH8      ', CAST(N'2024-12-01' AS Date), N'NV3       ', N'NCC1      ', N'2         ', 1, N'f580e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayLap], [MaNV], [MaNCC], [MaKho], [TrangThai], [rowguid]) VALUES (N'DDH9      ', CAST(N'2024-11-30' AS Date), N'NV3       ', N'NCC4      ', N'2         ', 0, N'f680e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'MG1       ', N'Máy giặt Electrolux', N'Cái', N'MG        ', 1, N'c580e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'MG2       ', N'Máy giặt Xiaomi', N'Cái', N'MG        ', 1, N'c680e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'MS1       ', N'Máy sấy Panasonic', N'Cái', N'MS        ', 1, N'c880e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'MS2       ', N'Máy sấy Dyson', N'Cái', N'MS        ', 1, N'c780e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'MS3       ', N'anh', N'Cái', N'MS        ', 1, N'c480e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'TL1       ', N'Tủ lạnh Toshiba', N'', N'TL        ', 0, N'cd80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'TL2       ', N'Tủ lạnh Hitachi', N'Cái', N'TL        ', 1, N'cc80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'TL3       ', N'Tủ lạnh LG', N'Cái', N'TL        ', 1, N'83d31a5f-78c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'TV1       ', N'Ti vi SamSung', N'Cái', N'TV        ', 1, N'ca80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'TV2       ', N'Ti vi LG', N'Cái', N'TV        ', 1, N'c980e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [DonViTinh], [MaLH], [TrangThai], [rowguid]) VALUES (N'TV3       ', N'Ti vi Xiaomi', N'Cái', N'TV        ', 1, N'cb80e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'1         ', CAST(N'2024-11-25' AS Date), N'NV1       ', N'1         ', N'1         ', N'f780e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'10        ', CAST(N'2024-12-23' AS Date), N'NV3       ', N'5         ', N'1         ', N'3257a2ff-d8c0-ef11-9b30-dc215ca89f93')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'2         ', CAST(N'2024-11-25' AS Date), N'NV2       ', N'2         ', N'4         ', N'f880e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'3         ', CAST(N'2024-11-26' AS Date), N'NV1       ', N'3         ', N'2         ', N'f980e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'4         ', CAST(N'2024-11-26' AS Date), N'NV2       ', N'4         ', N'5         ', N'fa80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'5         ', CAST(N'2024-12-10' AS Date), N'NV3       ', N'5         ', N'1         ', N'fb80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'6         ', CAST(N'2024-12-11' AS Date), N'NV3       ', N'5         ', N'2         ', N'fc80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'7         ', CAST(N'2024-12-13' AS Date), N'NV4       ', N'4         ', N'5         ', N'fd80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'8         ', CAST(N'2024-12-22' AS Date), N'NV3       ', N'6         ', N'1         ', N'fe32e7b8-7bc0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[HoaDon] ([SoHD], [NgayLap], [MaNV], [MaKH], [MaKho], [rowguid]) VALUES (N'9         ', CAST(N'2024-12-22' AS Date), N'NV3       ', N'5         ', N'1         ', N'c2db974f-7cc0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SoDienThoai], [MaCN], [rowguid]) VALUES (N'1         ', N'Nguyễn Quốc Khả Phi', N'Bình Dường', N'012222121 ', N'CN1       ', N'ce80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SoDienThoai], [MaCN], [rowguid]) VALUES (N'2         ', N'Nguyễn Trần Tấn Quy', N'Gia Lai', N'024343431 ', N'CN2       ', N'd080e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SoDienThoai], [MaCN], [rowguid]) VALUES (N'3         ', N'Trang Tuấn Phi', N'Tiền Giang', N'045827527 ', N'CN1       ', N'd180e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SoDienThoai], [MaCN], [rowguid]) VALUES (N'4         ', N'Lê Phương Kiều', N'Đồng Tháp', N'022727139 ', N'CN2       ', N'cf80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SoDienThoai], [MaCN], [rowguid]) VALUES (N'5         ', N'Tmm', N'tphcm', N'0908613902', N'CN1       ', N'd280e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SoDienThoai], [MaCN], [rowguid]) VALUES (N'6         ', N'Lê Mộng Diễm', N'Bình Tân', N'0122515026', N'CN1       ', N'fd32e7b8-7bc0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'1         ', N'Kho 1', N'CN1       ', 1, N'd480e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'10        ', N'Kho 6', N'CN2       ', 1, N'd980e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'2         ', N'Kho 2', N'CN1       ', 1, N'd580e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'3         ', N'Kho 3', N'CN1       ', 1, N'd680e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'4         ', N'Kho 4', N'CN2       ', 1, N'd780e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'5         ', N'Kho 5', N'CN2       ', 1, N'd880e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'6         ', N'rwe', N'CN1       ', 0, N'db80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'7         ', N'twrwe', N'CN1       ', 0, N'dc80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'8         ', N'poi', N'CN1       ', 0, N'da80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[Kho] ([MaKho], [TenKho], [MaCN], [TrangThai], [rowguid]) VALUES (N'9         ', N'ik', N'CN1       ', 0, N'd380e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[LoaiHang] ([MaLH], [TenLH], [rowguid]) VALUES (N'MG        ', N'Máy Giặt', N'b280e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[LoaiHang] ([MaLH], [TenLH], [rowguid]) VALUES (N'MS        ', N'Máy Sấy', N'b380e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[LoaiHang] ([MaLH], [TenLH], [rowguid]) VALUES (N'TL        ', N'Tủ Lạnh', N'b580e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[LoaiHang] ([MaLH], [TenLH], [rowguid]) VALUES (N'TV        ', N'TiVi', N'b480e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDienThoai], [rowguid]) VALUES (N'NCC1      ', N'Nhà Cung Cấp 1', N'TPHCM', N'012345678 ', N'b680e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDienThoai], [rowguid]) VALUES (N'NCC2      ', N'Nhà Cung Cấp 2', N'HN', N'012345677 ', N'b780e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDienThoai], [rowguid]) VALUES (N'NCC3      ', N'Nhà Cung Cấp 3', N'Bình Dương', N'012345676 ', N'b880e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDienThoai], [rowguid]) VALUES (N'NCC4      ', N'Nhà Cung Cấp 4', N'Long An', N'012345675 ', N'b980e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV1       ', N'Trang', N'Tuấn Minh', N'Nam', CAST(N'2002-07-15' AS Date), N'TPHCM', N'0908613902', 1, N'be80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV10      ', N'Trần', N'Trọng Nghĩa', N'Nam', CAST(N'2001-12-13' AS Date), N'TPHCM', N'0123483432', 1, N'ba80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV11      ', N'Nguyễn', N'Tấn Đạt', N'Nam', CAST(N'2002-05-15' AS Date), N'Tân Phú', N'0585686658', 0, N'398b5118-7dc0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV2       ', N'Nguyễn ', N'Văn Tài', N'Nam', CAST(N'2002-09-16' AS Date), N'Quãng Ngãi', N'0989675522', 1, N'c280e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV3       ', N'Trần', N'Thị Ngọc Hân', N'Nữ', CAST(N'2002-07-14' AS Date), N'TPHCM', N'0908357002', 1, N'bd80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV4       ', N'Nguyễn', N'Gia Vinh', N'Nam', CAST(N'2002-04-12' AS Date), N'Long An', N'0822931990', 1, N'bc80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV5       ', N'Nguyễn Quốc', N'Khả Phi', N'Nam', CAST(N'2002-12-11' AS Date), N'Bình Dương', N'0923549292', 1, N'c180e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV6       ', N'Nguyễn ', N'Văn Trường', N'Nam', CAST(N'2002-11-03' AS Date), N'TPHCM', N'0244399522', 1, N'bb80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV7       ', N'wqwq', N'wqwq', N'wqw', CAST(N'2000-12-02' AS Date), N'1212      ', N'wqwq      ', 1, N'c380e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV8       ', N'Vương', N'Hữu Hiếu', N'Nam', CAST(N'2002-06-26' AS Date), N'TPHCM', N'0908613903', 1, N'bf80e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Phai], [NgaySinh], [DiaChi], [SoDienThoai], [TrangThai], [rowguid]) VALUES (N'NV9       ', N'Vương', N'Hữu Trung', N'Nam', CAST(N'2001-12-14' AS Date), N'TPHCM', N'0908613904', 1, N'c080e580-73c0-ef11-9b2f-dc215ca89f90')
GO
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN1       ', CAST(N'2024-09-20' AS Date), N'DDH1      ', N'NV3       ', N'1         ', 1, N'0081e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN10      ', CAST(N'2024-12-11' AS Date), N'DDH12     ', N'NV3       ', N'1         ', 1, N'0181e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN11      ', CAST(N'2024-12-11' AS Date), N'DDH12     ', N'NV3       ', N'1         ', 1, N'0281e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN12      ', CAST(N'2024-12-11' AS Date), N'DDH12     ', N'NV3       ', N'1         ', 1, N'0381e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN13      ', CAST(N'2024-12-13' AS Date), N'DDH13     ', N'NV4       ', N'4         ', 1, N'0481e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN14      ', CAST(N'2024-12-13' AS Date), N'DDH13     ', N'NV4       ', N'4         ', 1, N'0581e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN15      ', CAST(N'2024-12-14' AS Date), N'DDH13     ', N'NV4       ', N'4         ', 1, N'0681e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN16      ', CAST(N'2024-12-22' AS Date), N'DDH16     ', N'NV3       ', N'1         ', 0, N'0781e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN2       ', CAST(N'2024-09-20' AS Date), N'DDH2      ', N'NV4       ', N'4         ', 1, N'0881e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN3       ', CAST(N'2024-09-21' AS Date), N'DDH3      ', N'NV3       ', N'3         ', 1, N'0981e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN4       ', CAST(N'2024-09-21' AS Date), N'DDH4      ', N'NV4       ', N'5         ', 1, N'0a81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN5       ', CAST(N'2024-10-02' AS Date), N'DDH5      ', N'NV3       ', N'1         ', 1, N'0b81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN6       ', CAST(N'2024-12-01' AS Date), N'DDH1      ', N'NV3       ', N'1         ', 1, N'0c81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN7       ', CAST(N'2024-12-04' AS Date), N'DDH10     ', N'NV3       ', N'3         ', 1, N'0d81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN8       ', CAST(N'2024-12-02' AS Date), N'DDH5      ', N'NV3       ', N'2         ', 1, N'0e81e580-73c0-ef11-9b2f-dc215ca89f90')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayLap], [MaDDH], [MaNV], [MaKho], [TrangThai], [rowguid]) VALUES (N'PN9       ', CAST(N'2024-12-11' AS Date), N'DDH12     ', N'NV3       ', N'1         ', 1, N'0f81e580-73c0-ef11-9b2f-dc215ca89f90')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_ChiNhanh]    Script Date: 12/23/2024 11:56:49 PM ******/
ALTER TABLE [dbo].[ChiNhanh] ADD  CONSTRAINT [UK_ChiNhanh] UNIQUE NONCLUSTERED 
(
	[TenCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_KhachHang]    Script Date: 12/23/2024 11:56:49 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [UK_KhachHang] UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Kho]    Script Date: 12/23/2024 11:56:49 PM ******/
ALTER TABLE [dbo].[Kho] ADD  CONSTRAINT [UK_Kho] UNIQUE NONCLUSTERED 
(
	[TenKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_LoaiHang]    Script Date: 12/23/2024 11:56:49 PM ******/
ALTER TABLE [dbo].[LoaiHang] ADD  CONSTRAINT [UK_LoaiHang] UNIQUE NONCLUSTERED 
(
	[TenLH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_NhanVien]    Script Date: 12/23/2024 11:56:49 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [UK_NhanVien] UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiNhanh] ADD  CONSTRAINT [MSmerge_df_rowguid_2BC3D3C0FA8D45D1863C7934B5FBEC5C]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] ADD  CONSTRAINT [MSmerge_df_rowguid_54AC5EAD2B41474B9AD41C1FBFDE936E]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  CONSTRAINT [MSmerge_df_rowguid_7E349C92A79E4D8DB1E5E52C072F9599]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[ChiTietNhanVien] ADD  CONSTRAINT [MSmerge_df_rowguid_B1323568AE5B48E08110672447B2C789]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] ADD  CONSTRAINT [MSmerge_df_rowguid_BFFC79F7518D445F9F3BF75E425B5394]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[DonDatHang] ADD  CONSTRAINT [MSmerge_df_rowguid_83FB738BC6064F55BD8DFE4BEFB52571]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[HangHoa] ADD  CONSTRAINT [MSmerge_df_rowguid_8334DC474F504A3A86B0002A09529D0C]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [MSmerge_df_rowguid_EC29E1323FD94061A928331F375F2C76]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [MSmerge_df_rowguid_34F657CB2F094C4A8AEEC9A494F64469]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[Kho] ADD  CONSTRAINT [MSmerge_df_rowguid_4D7BA62EB7894C67AC93799EFF9A4C7C]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[LoaiHang] ADD  CONSTRAINT [MSmerge_df_rowguid_030BBE54644546C59417263297B5575E]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [MSmerge_df_rowguid_CE92FF4B000D471E838E386C6B061154]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [MSmerge_df_rowguid_581D90783AE3470FA3250BB2005F9324]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  CONSTRAINT [MSmerge_df_rowguid_9180FE2C5E924BF3943A48D5F85117DE]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietDon__MaHH__3E52440B] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK__ChiTietDon__MaHH__3E52440B]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonDatHang_DonDatHang] FOREIGN KEY([MaDDH])
REFERENCES [dbo].[DonDatHang] ([MaDDH])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_ChiTietDonDatHang_DonDatHang]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHoa__MaHH__3F466844] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHoa__MaHH__3F466844]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHoa__SoHD__403A8C7D] FOREIGN KEY([SoHD])
REFERENCES [dbo].[HoaDon] ([SoHD])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHoa__SoHD__403A8C7D]
GO
ALTER TABLE [dbo].[ChiTietNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhanVien_ChiNhanh] FOREIGN KEY([MACN])
REFERENCES [dbo].[ChiNhanh] ([MaCN])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietNhanVien] CHECK CONSTRAINT [FK_ChiTietNhanVien_ChiNhanh]
GO
ALTER TABLE [dbo].[ChiTietNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhanVien_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietNhanVien] CHECK CONSTRAINT [FK_ChiTietNhanVien_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPhi__MaHH__4316F928] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPhi__MaHH__4316F928]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPhi__SoPN__440B1D61] FOREIGN KEY([SoPN])
REFERENCES [dbo].[PhieuNhap] ([SoPN])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPhi__SoPN__440B1D61]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_Kho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_Kho]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_NhaCungCap]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_NhanVien]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_LoaiHang] FOREIGN KEY([MaLH])
REFERENCES [dbo].[LoaiHang] ([MaLH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_LoaiHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Kho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Kho]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_ChiNhanh1] FOREIGN KEY([MaCN])
REFERENCES [dbo].[ChiNhanh] ([MaCN])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_ChiNhanh1]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [FK_Kho_ChiNhanh] FOREIGN KEY([MaCN])
REFERENCES [dbo].[ChiNhanh] ([MaCN])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [FK_Kho_ChiNhanh]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_DonDatHang] FOREIGN KEY([MaDDH])
REFERENCES [dbo].[DonDatHang] ([MaDDH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_DonDatHang]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_Kho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[Kho] ([MaKho])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_Kho]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [CK_DonGiaDonDatHang] CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [CK_DonGiaDonDatHang]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [CK_SoLuongDonDatHang] CHECK  (([SoLuong]>=(0)))
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [CK_SoLuongDonDatHang]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [CK_DonGiaChiTietHoaDon] CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [CK_DonGiaChiTietHoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [CK_SoLuongHoaDon] CHECK  (([SoLuong]>=(0)))
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [CK_SoLuongHoaDon]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [CK_ChiTietPhieuNhap] CHECK  (([DonGia]>=(0)))
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [CK_ChiTietPhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [CK_SoLuongPhieuNhap] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [CK_SoLuongPhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [CK_SoLuongTonPhieuNhap] CHECK  (([SoluongTon]>=(0)))
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [CK_SoLuongTonPhieuNhap]
GO
/****** Object:  StoredProcedure [dbo].[GET_STAFFLIST]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GET_STAFFLIST]
AS
BEGIN 
	SELECT MaNV, Ho, Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
	FROM NHANVIEN
	WHERE TrangThai = 1
END
GO
/****** Object:  StoredProcedure [dbo].[KiemTraDonDatHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[KiemTraDonDatHang]
as
begin
		select ddh.MaDDH ,HH.MaHH,TenNCC , TenHH,
		   ctddh.SoLuong as Soluongnhan, 
		   Isnull(sum(ctpn.SoLuong),0) as Soluongnhap , 
		   soluongcannhap = ctddh.SoLuong -  Isnull(sum(ctpn.SoLuong),0), 
		   DonGia
	from (select MaDDH, TenNCC, TrangThai from DonDatHang, NhaCungCap WHERE DonDatHang.MaNCC = NhaCungCap.MaNCC AND TRANGTHAI = 1) as ddh
	join (select MaDDH, SoLuong, MaHH, DonGia from ChiTietDonDatHang) as ctddh
	on ctddh.MaDDH = ddh.MaDDH
	join (select MaHH, TenHH from HangHoa where TrangThai = 1) as HH 
	on ctddh.MaHH = HH.MaHH
	left join (select MaDDH, SoPN, MaKho,TrangThai from PhieuNhap WHERE TrangThai = 1) as pn
	on pn.MaDDH = ctddh.MaDDH
	left join (select SoPN, SoLuong from ChiTietPhieuNhap) as ctpn
	on ctpn.SoPN = pn.SoPN
	where  ctddh.SoLuong > ISNULL(ctpn.SoLuong, 0) or ctpn.SoLuong is null 
	group by ddh.MaDDH,ctddh.SoLuong,TenNCC , TenHH, DonGia, HH.MaHH
	Having ctddh.SoLuong -  Isnull(sum(ctpn.SoLuong),0) > 0
end
GO
/****** Object:  StoredProcedure [dbo].[KiemTraToanBoDonDatHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[KiemTraToanBoDonDatHang]
as
begin
	select ddh.MaDDH ,HH.MaHH,TenNCC , TenHH,ctddh.SoLuong as Soluongnhan, Isnull(sum(ctpn.SoLuong),0) as Soluongnhap , soluongcannhap = ctddh.SoLuong -  Isnull(sum(ctpn.SoLuong),0), DonGia
	from (select MaDDH, TenNCC, TrangThai from DonDatHang, NhaCungCap WHERE DonDatHang.MaNCC = NhaCungCap.MaNCC AND TRANGTHAI = 1) as ddh
	join (select MaDDH, SoLuong, MaHH, DonGia from ChiTietDonDatHang) as ctddh
	on ctddh.MaDDH = ddh.MaDDH
	join (select MaHH, TenHH from HangHoa) as HH 
	on ctddh.MaHH = HH.MaHH
	left join (select MaDDH, SoPN, MaKho from PhieuNhap) as pn
	on pn.MaDDH = ctddh.MaDDH
	left join (select SoPN, SoLuong from ChiTietPhieuNhap) as ctpn
	on ctpn.SoPN = pn.SoPN
	group by ddh.MaDDH,ctddh.SoLuong,TenNCC , TenHH, DonGia, HH.MaHH
end
GO
/****** Object:  StoredProcedure [dbo].[NEW]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[NEW]
	@NGAYSINH date
AS
BEGIN 
	INSERT INTO NhanVien(MaNV,Ho,Ten,Phai,NgaySinh,SoDienThoai,DiaChi,TrangThai) 
		VALUES('NV200', '1', '1', '1', @NGAYSINH ,'1','1',1)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDBILL]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDBILL]
	@SoHD char(10),
	@NgayLap date,
	@MaNV char(10),
	@MaKho char(10),
	@MaKh char(10)
	
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	

	INSERT INTO HoaDon(SOHD,NgayLap,MaNV,MAKH,MaKho)
	VALUES(@SoHD,@NgayLap,@MaNV,@MaKh,@MaKho)

	
END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDDETAILBILL]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDDETAILBILL]
	@SoHD INT,
	@MaHH char(10),
	@MaKho char(10),
	@SoLuong int,
	@DonGia float
	
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWSOLUONG INT
	

	INSERT INTO ChiTietHoaDon(SoHD,MaHH,SoLuong,DonGia)
	VALUES(@SoHD,@MaHH,@SoLuong,@DonGia)

	WHILE (@SOLUONG > 0)
	BEGIN
		-- Cập nhật từng dòng một
		WITH CTE AS		(
			SELECT TOP 1
                CTPN.MaHH, CTPN.SoPN, CTPN.SoluongTon
            FROM ChiTietPhieuNhap AS CTPN
            FULL JOIN PhieuNhap AS PN ON PN.SoPN = CTPN.SoPN
            JOIN KHO ON KHO.MaKho = PN.MaKho
            JOIN HangHoa AS HH ON HH.MaHH = CTPN.MaHH
            WHERE CTPN.MaHH = @MAHH 
				  AND Kho.MaKho = @MAKHO 
                  AND Kho.TrangThai = 1 
                  AND HH.TrangThai = 1 
                  AND CTPN.SoluongTon > 0
            ORDER BY CTPN.SoluongTon DESC
		)
		UPDATE CTE
        SET SoluongTon = SoluongTon - 1


		SET @SOLUONG = @SOLUONG - 1; 
        -- Giảm số lượng cần trừ (tổng số cần cập nhật)

        
        -- Thoát vòng lặp nếu không còn dòng nào để trừ
        
	END

END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDIMPORT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDIMPORT]
	@NgayLap date,
	@MaNV char(10),
	@MaDDH char(10),
	@MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWMAPN CHAR(10)
	SET @NEWMAPN = (SELECT CONCAT('PN' ,COUNT(SoPN) + 1) FROM LINK0.QLVT.DBO.PHIEUNHAP)

	INSERT INTO PhieuNhap(SOPN,NgayLap,MaDDH,MaNV,MaKho,TrangThai)
	VALUES(@NEWMAPN,@NgayLap,@MaDDH,@MaNV,@MaKho,1)

	INSERT INTO ChiTietPhieuNhap(SoPN,MaHH,SoLuong,SoluongTon,DonGia)
	VALUES(@NEWMAPN,@MaHH,@SoLuong,@SoLuong,@DonGia)
END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDORDER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDORDER]
	@NgayLap date,
	@MaNV char(10),
	@MaNCC char(10),
	@MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWMADDH CHAR(10)
	SET @NEWMADDH = (SELECT CONCAT('DDH' ,COUNT(MaDDH) + 1) FROM LINK0.QLVT.DBO.DONDATHANG)

	INSERT INTO DonDatHang(MaDDH,NgayLap,MaNV,MaNCC,MaKho,TrangThai)
	VALUES(@NEWMADDH,@NgayLap,@MaNV,@MaNCC,@MaKho,1)

	INSERT INTO ChiTietDonDatHang(MaDDH,MaHH,SoLuong,DonGia)
	VALUES(@NEWMADDH,@MaHH,@SoLuong,@DonGia)
END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDPRODUCT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDPRODUCT]
    @TenHH NVARCHAR(100),
	@DonViTinh nvarchar(20),
	@MaLH Char(10)
AS
BEGIN
	DECLARE @NewMaHH CHAR(10);

    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    --SELECT @NewMaHH = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;

	SELECT @NewMaHH =  Trim(@MaLH) + TRIM(cast((count(MaHH) + 1 )as CHAR))
	FROM HangHoa 
	WHERE TRIM(MaLH) =  Trim(@MaLH);

    -- Chèn vào bảng với mã kho mới
    INSERT INTO HANGHOA (MaHH, TenHH, DonViTinh, MaLH, TrangThai)
    VALUES (@NewMaHH, @TenHH, @DonViTinh ,@MaLH, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDRECEIPT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDRECEIPT]
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	DECLARE @NEWSOPN CHAR(10)
	SET @NEWSOPN= (SELECT CONCAT('DDH' ,COUNT(SOPN) + 1) FROM LINK0.QLVT.DBO.PHIEUNHAP)
END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_ADDSTAFF]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDSTAFF]
	
	@HO NVARCHAR(50),
	@TEN NVARCHAR(50),
	@PHAI NVARCHAR(3),
	@NGAYSINH DATE, 
	@DIACHI NVARCHAR(100),
	@SODIENTHOAI CHAR(10)
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
		
		DECLARE @MANV CHAR(10)
		SET @MANV = (SELECT NEWMANV = CONCAT('NV' ,COUNT(MaNV) + 1)
					FROM LINK0.QLVT.DBO.NHANVIEN)

		
		 

		INSERT INTO NhanVien(MaNV,Ho,Ten,Phai,NgaySinh,DiaChi, SoDienThoai,TrangThai) 
		VALUES(@MANV, @HO, @TEN, @PHAI, @NGAYSINH ,@DIACHI,@SODIENTHOAI,1)

		DECLARE @NGAYCHUYEN DATE
		DECLARE @MACN CHAR(10)
		SET @NGAYCHUYEN = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd') AS CurrentDate);
		SET @MACN = (SELECT MACN FROM ChiNhanh)

		INSERT INTO ChiTietNhanVien(MANV,MACN,NGAYCHUYEN) 
		VALUES(@MANV,@MACN,@NGAYCHUYEN)
		
	
END
COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[SP_ADDWAREHOUSE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ADDWAREHOUSE]
    @TenKho NVARCHAR(100)
	
AS
BEGIN
	DECLARE @NewMaKho INT;
	DECLARE @MaCN Char(10);
    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    SELECT @NewMaKho = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;
	SELECT @MaCN = MaCN FROM ChiNhanh
    -- Chèn vào bảng với mã kho mới
    INSERT INTO Kho (MaKho, TenKho, MaCN, TrangThai)
    VALUES (@NewMaKho, @TenKho, @MaCN, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CHECKCUSTOMER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHECKCUSTOMER]
 @SDT CHAR(10)
AS
BEGIN
	SELECT MaKH,TenKH, SoDienThoai, DiaChi
	FROM KhachHang
	WHERE SoDienThoai = @SDT
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietSoLuongTriGiaHangHoaNhapXuat]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChiTietSoLuongTriGiaHangHoaNhapXuat]
@MACN_CBX CHAR(4),
@TYPE NVARCHAR(4),
@DATEFROM DATETIME,
@DATETO DATETIME
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN != @MACN_CBX)
	BEGIN
		IF(@TYPE = 'NHAP')--NHAP
		BEGIN
				SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
				FROM
					( SELECT NgayLap,SoPN 
						FROM LINK2.QLVT.DBO.PhieuNhap
						WHERE NgayLap BETWEEN @DATEFROM AND @DATETO   ) AS PHIEU,
					( SELECT TenHH ,MaHH FROM HangHoa ) HH,
					( SELECT SoLuong, DonGia, SoPN, MaHH FROM LINK2.QLVT.DBO.ChiTietPhieuNhap) AS CT
				WHERE PHIEU.SoPN = CT.SoPN
				AND HH.MaHH = CT.MaHH
				GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
				ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END

		ELSE--@TYPE = 'XUAT'
		BEGIN
					SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
					FROM
						( SELECT NgayLap,SoHD
							FROM LINK2.QLVT.DBO.HoaDon
							WHERE NgayLap BETWEEN @DATEFROM AND @DATETO   ) AS PHIEU,
						( SELECT TenHH,MaHH FROM HangHoa ) AS HH,
						( SELECT SoLuong, DonGia, SoHD, MaHH FROM LINK2.QLVT.DBO.ChiTietHoaDon) AS CT
					WHERE PHIEU.SoHD = CT.SoHD
					AND HH.MaHH = CT.MaHH
					GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
					ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END
	END

	ELSE -- CHI NHANH & USER
	BEGIN
		IF(@TYPE = 'NHAP')
		BEGIN
				SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
				FROM
					( SELECT NgayLap,SoPN 
						FROM PhieuNhap
						WHERE NgayLap BETWEEN @DATEFROM  AND @DATETO ) AS PHIEU,
					( SELECT TenHH , MaHH FROM HangHoa ) AS HH,
					( SELECT SoLuong, DonGia, SoPN ,MaHH FROM ChiTietPhieuNhap) CT
				WHERE PHIEU.SoPN = CT.SoPN
				AND HH.MaHH = CT.MaHH
				GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
				ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END
		ELSE -- @LOAI = 'XUAT'
		BEGIN
					SELECT FORMAT(NgayLap,'MM-yyyy') AS THANGNAM, 
						TenHH, 
						SUM(SOLUONG) AS TONGSOLUONG,
						FORMAT(SUM(SOLUONG * DONGIA),'N0') AS TRIGIA
					FROM
						( SELECT NgayLap,SoHD
							FROM HoaDon
							WHERE NgayLap BETWEEN @DATEFROM AND @DATETO   ) AS PHIEU,
						( SELECT TenHH,MaHH FROM HangHoa ) AS HH,
						( SELECT SoLuong, DonGia, SoHD, MaHH FROM ChiTietHoaDon) AS CT
					WHERE PHIEU.SoHD = CT.SoHD
					AND HH.MaHH = CT.MaHH
					GROUP BY FORMAT(NgayLap,'MM-yyyy'), TenHH
					ORDER BY FORMAT(NgayLap,'MM-yyyy'), TenHH
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChuyenChiNhanh]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChuyenChiNhanh] 
	@MANV char(10),
	@NGAYCHUYEN DATE
AS
DECLARE @LGNAME VARCHAR(50)
DECLARE @USERNAME VARCHAR(50)
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN
	BEGIN DISTRIBUTED TRAN
		DECLARE @HONV NVARCHAR(40)
		DECLARE @TENNV NVARCHAR(10)
		DECLARE @DIACHINV NVARCHAR(100)
		DECLARE @NGAYSINHNV DATE
		DECLARE @PHAI NVARCHAR(3)	
		DECLARE @SODIENTHOAI CHAR(10)
		-- Lưu lại thông tin nhân viên cần chuyển chi nhánh để làm điều kiện kiểm tra
		SELECT @HONV = HO, @TENNV = TEN, @DIACHINV = DIACHI, @NGAYSINHNV = NGAYSINH, @SODIENTHOAI = SoDienThoai, @PHAI = Phai FROM NhanVien WHERE MANV = @MANV
		-- Kiểm tra xem bên Site chuyển tới đã có dữ liệu nhân viên đó chưa. Nếu có rồi thì đổi trạng thái, chưa thì thêm vào
		IF EXISTS(select MANV
				from LINK2.QLVT.dbo.NhanVien
				where HO = @HONV and TEN = @TENNV and DIACHI = @DIACHINV
				and NGAYSINH = @NGAYSINHNV AND SoDienThoai = @SODIENTHOAI)
		BEGIN
				UPDATE LINK2.QLVT.dbo.NhanVien
				SET TrangThai = 1
				WHERE MANV = (	select MANV
								from LINK2.QLVT.dbo.NhanVien
								where HO = @HONV and TEN = @TENNV and DIACHI = @DIACHINV
										and NGAYSINH = @NGAYSINHNV AND SoDienThoai = @SODIENTHOAI AND PHAI = @PHAI )
		END
		ELSE
		-- nếu chưa tồn tại thì thêm mới hoàn toàn vào chi nhánh mới với MANV sẽ là MANV lớn nhất hiện tại + 1
		BEGIN
			DECLARE @NEWMaNV CHAR(10)
			SET @NEWMaNV = (SELECT CONCAT('NV' ,COUNT(MaNV) + 1) FROM LINK0.QLVT.dbo.NhanVien)
			DECLARE @NEWMACN CHAR(10)
			SET @NEWMACN = (SELECT MACN FROM LINK2.QLVT.dbo.ChiNhanh)
			INSERT INTO LINK2.QLVT.dbo.NhanVien (MANV, HO, TEN, DIACHI, NGAYSINH, SoDienThoai, Phai ,TrangThai)
			VALUES (@NEWMaNV, @HONV, @TENNV, @DIACHINV, @NGAYSINHNV, @SODIENTHOAI ,@PHAI, 1)
			INSERT INTO LINK2.QLVT.dbo.ChiTietNhanVien(MACN, MANV, NGAYCHUYEN)
			VALUES(@NEWMACN, @NEWMaNV, @NGAYCHUYEN)
		END
		-- Đổi trạng thái xóa đối với tài khoản cũ ở site hiện tại
		UPDATE dbo.NhanVien
		SET TrangThai = 0
		WHERE MANV = @MANV

		-- sp_droplogin và sp_dropuser không thể được thực thi trong một giao tác do người dùng định nghĩa
		-- Kiểm tra xem Nhân viên đã có login chưa. Có thì xóa
		

	COMMIT TRAN;
	IF EXISTS(SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR))
		BEGIN
			SET @LGNAME = CAST((SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR)) AS VARCHAR(50))
			SET @USERNAME = CAST(@MANV AS VARCHAR(50))
			EXEC SP_DROPUSER @USERNAME;
			EXEC SP_DROPLOGIN @LGNAME;
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CHUYENCHINHANH2]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CHUYENCHINHANH2]
@MACN_CBX CHAR(4)

AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT MaNV, Ho, Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
		FROM NHANVIEN
		WHERE TrangThai = 1
	END

	ELSE
	BEGIN
		SELECT MaNV, Ho, Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
		FROM LINK2.QLVT.DBO.NHANVIEN
		WHERE TrangThai = 1	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhap]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DangNhap]
	@TENLOGIN NVARCHAR( 100)
AS
	DECLARE @UID INT
	DECLARE @MANV NVARCHAR(100)
	SELECT @UID= uid , @MANV= NAME FROM sys.sysusers 
  	WHERE sid = SUSER_SID(@TENLOGIN)

	SELECT  MANV= @MANV, 
       		HOTEN = (SELECT HO+ ' '+TEN FROM dbo.NhanVien WHERE MANV=@MANV ), 
			NGAYSINH = (SELECT NgaySinh FROM dbo.NhanVien WHERE MANV=@MANV ),
			DIACHI = (SELECT DiaChi FROM dbo.NhanVien WHERE MANV=@MANV ),
			SODIENTHOAI = (SELECT SoDienThoai FROM dbo.NhanVien WHERE MANV=@MANV ),
			MACN = (SELECT MACN FROM CHINHANH),
			PHAI = (SELECT PHAI FROM dbo.NhanVien WHERE MANV=@MANV ),
       		TENNHOM=NAME
  	FROM sys.sysusers
    	WHERE UID = (SELECT groupuid FROM sys.sysmembers WHERE memberuid=@uid)
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETEORDER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DELETEORDER]
	@MADDH CHAR(10)
AS

BEGIN
	UPDATE DonDatHang
	SET TrangThai = 0
	WHERE MaDDH = @MADDH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETEPRODUCT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DELETEPRODUCT]
	@MaHH CHAR(10)
AS
BEGIN
	UPDATE HangHoa
	SET TrangThai = 0
	WHERE MaHH = @MaHH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETERECEIPT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DELETERECEIPT]
	@SOPN CHAR(10)
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	UPDATE PhieuNhap
	SET TrangThai = 0
	WHERE SoPN = @SOPN
END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETEWAREHOUSE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DELETEWAREHOUSE]
	@MaKho CHAR(10)
AS
BEGIN
	UPDATE Kho
	SET TrangThai = 0
	WHERE MaKho = @MaKho
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DonHangKhongPhieuNhap]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DonHangKhongPhieuNhap]
@MACN_CBX CHAR(4)
AS
BEGIN
DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT DH.MaDDH, 
			   DH.NgayLap, 
			   TenNCC, 
			   HOTEN,
			   TenHH,
			   SOLUONG,
			   DONGIA = FORMAT(DONGIA,'N0')
		FROM 
			(SELECT MaDDH, NgayLap, TrangThai,NCC.TenNCC, HOTEN = (SELECT HOTEN = HO + ' ' + TEN 
														 FROM NhanVien 
														 WHERE DDH.MaNV = NhanVien.MANV) 
			 FROM DonDatHang AS DDH , NhaCungCap AS NCC WHERE DDH.MaNCC = NCC.MaNCC) AS DH,
			 (SELECT MaDDH, MAHH,SOLUONG,DONGIA FROM ChiTietDonDatHang ) AS CTDDH,
			 (SELECT TENHH, MAHH FROM HangHoa ) HH
			WHERE CTDDH.MaDDH = DH.MaDDH
			AND HH.MAHH = CTDDH.MAHH
			AND DH.MaDDH NOT IN (SELECT MaDDH FROM PhieuNhap)
			AND TrangThai = 1
	end
	ELSE
	BEGIN
		SELECT DH.MaDDH, 
			   DH.NgayLap, 
			   TenNCC, 
			   HOTEN,
			   TenHH,
			   SOLUONG,
			   FORMAT(DONGIA,'N0')
		FROM 
			(SELECT MaDDH, NgayLap, TrangThai,NCC.TenNCC, HOTEN = (SELECT HOTEN = HO + ' ' + TEN 
														 FROM  LINK2.QLVT.DBO.NhanVien 
														 WHERE DDH.MaNV = NhanVien.MANV) 
			 FROM  LINK2.QLVT.DBO.DonDatHang AS DDH , NhaCungCap AS NCC WHERE DDH.MaNCC = NCC.MaNCC) AS DH,
			 (SELECT MaDDH, MAHH,SOLUONG,DONGIA FROM  LINK2.QLVT.DBO.ChiTietDonDatHang ) AS CTDDH,
			 (SELECT TENHH, MAHH FROM HangHoa ) HH
			WHERE CTDDH.MaDDH = DH.MaDDH
			AND HH.MAHH = CTDDH.MAHH
			AND DH.MaDDH NOT IN (SELECT MaDDH FROM  LINK2.QLVT.DBO.PhieuNhap)
			AND TrangThai = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_NEWIDPRODUCT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GET_NEWIDPRODUCT]
	@MaLH Char(10)
AS
BEGIN
	DECLARE @NewMaHH CHAR(10);

    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    --SELECT @NewMaHH = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;

	SELECT NewMaHH = Trim(@MaLH) + trim(cast((count(MaHH) + 1 )as CHAR))
	FROM HangHoa 
	WHERE Trim(MaLH) = Trim(@MaLH);

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETBILL]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETBILL]
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT HD.SoHD, NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), HOTENNV, K.TenKho, TenKH, DonGia =  sum(DonGia) * sum(SoLuong)
		FROM HoaDon AS HD
		JOIN ChiTietHoaDon AS CTHD 
		ON HD.SoHD = CTHD.SoHD
		JOIN (SELECT MaKho, TenKho, TrangThai FROM Kho WHERE TRANGTHAI = 1) AS K
		ON K.MaKho = HD.MaKhO
		JOIN (SELECT MaNV, HOTENNV = HO +' ' + TEN FROM NHANVIEN) AS NV
		ON NV.MaNV = HD.MaNV
		JOIN HangHoa AS HH
		ON CTHD.MaHH = HH.MaHH
		JOIN (SELECT MaKH, TenKH FROM KhachHang) AS KH
		ON KH.MaKH = HD.MaKH 
		GROUP BY HD.SoHD, NgayLap , HOTENNV, K.TenKho, TenKH
	end
	ELSE
	BEGIN
		SELECT HD.SoHD, NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), HOTENNV, K.TenKho, TenKH, DonGia =  sum(DonGia) * sum(SoLuong)
		FROM  LINK2.QLVT.DBO.HoaDon AS HD
		JOIN  LINK2.QLVT.DBO.ChiTietHoaDon AS CTHD 
		ON HD.SoHD = CTHD.SoHD
		JOIN (SELECT MaKho, TenKho, TrangThai FROM  LINK2.QLVT.DBO.Kho WHERE TRANGTHAI = 1) AS K
		ON K.MaKho = HD.MaKhO
		JOIN (SELECT MaNV, HOTENNV = HO +' ' + TEN FROM  LINK2.QLVT.DBO.NHANVIEN) AS NV
		ON NV.MaNV = HD.MaNV
		JOIN  LINK2.QLVT.DBO.HangHoa AS HH
		ON CTHD.MaHH = HH.MaHH
		JOIN (SELECT MaKH, TenKH FROM  LINK2.QLVT.DBO.KhachHang) AS KH
		ON KH.MaKH = HD.MaKH 
		GROUP BY HD.SoHD, NgayLap , HOTENNV, K.TenKho, TenKH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETIMPORT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETIMPORT]
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT PN.SoPN, HH.MaHH ,TenHH ,NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), NV.MaNV ,HOTEN, K.TenKho, MaDDH, SoLuong, SoluongTon ,DonGia
		FROM PhieuNhap AS PN
		JOIN ChiTietPhieuNhap AS CTPN 
		ON PN.SoPN = CTPN.SoPN
		JOIN (SELECT MaKho, TenKho FROM Kho WHERE TrangThai = 1) AS K
		ON K.MaKho = PN.MaKhO
		JOIN (SELECT MaNV, HOTEN = HO +' ' + TEN FROM NHANVIEN) AS NV
		ON NV.MaNV = PN.MaNV
		JOIN HangHoa AS HH
		ON CTPN.MaHH = HH.MaHH
		WHERE PN.TrangThai = 1
	END
	ELSE
	BEGIN
		SELECT PN.SoPN, HH.MaHH ,TenHH ,NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), NV.MaNV ,HOTEN, K.TenKho, MaDDH, SoLuong, SoluongTon ,DonGia
		FROM  LINK2.QLVT.DBO.PhieuNhap AS PN
		JOIN  LINK2.QLVT.DBO.ChiTietPhieuNhap AS CTPN 
		ON PN.SoPN = CTPN.SoPN
		JOIN (SELECT MaKho, TenKho FROM  LINK2.QLVT.DBO.Kho WHERE TrangThai = 1) AS K
		ON K.MaKho = PN.MaKhO
		JOIN (SELECT MaNV, HOTEN = HO +' ' + TEN FROM  LINK2.QLVT.DBO.NHANVIEN) AS NV
		ON NV.MaNV = PN.MaNV
		JOIN HangHoa AS HH
		ON CTPN.MaHH = HH.MaHH
		WHERE PN.TrangThai = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWCUSTOMER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWCUSTOMER]
	@TenKH nvarchar(100),
	@DiaChi nvarchar(100),
	@SoDienThoai char(10)
	
AS

BEGIN
	DECLARE @NEWMAHD CHAR(10)
	SET @NEWMAHD = (SELECT COUNT(MaKH) + 1 FROM LINK0.QLVT.DBO.KhachHang)

	DECLARE @Macn CHAR(10)
	SET @Macn = (SELECT MaCN  FROM ChiNhanh)
	
	INSERT INTO KhachHang(MaKH,TenKH,DiaChi,SoDienThoai,MaCN)
	VALUES(@NEWMAHD, @TenKH, @DiaChi, @SoDienThoai ,@Macn)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDBILL]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWIDBILL]
AS

BEGIN
	
	SELECT NEWMAHD = ISNULL(MAX(CAST(SoHD AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.HoaDon
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDCUSTOMER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWIDCUSTOMER]
AS

BEGIN
	
	SELECT NEWMAPN = (SELECT (COUNT(MaKH) + 1) FROM LINK0.QLVT.DBO.KHACHHANG)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDIMOPRT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWIDIMOPRT]
AS

BEGIN
	
	SELECT NEWMAPN = (SELECT CONCAT('PN' ,COUNT(SOPN) + 1) FROM LINK0.QLVT.DBO.PHIEUNHAP)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDORDER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWIDORDER]
AS

BEGIN
	
	SELECT NEWMADDH = (SELECT CONCAT('DDH' ,COUNT(MaDDH) + 1) FROM LINK0.QLVT.DBO.DONDATHANG)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDSTAFF]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWIDSTAFF]
AS

BEGIN
	
	SELECT NEWMANV = (SELECT NEWMANV = CONCAT('NV' ,COUNT(MaNV) + 1)
					FROM LINK0.QLVT.DBO.NHANVIEN)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETNEWIDWAREHOUSE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETNEWIDWAREHOUSE]
   
AS
BEGIN
	

    -- Lấy mã kho lớn nhất hiện tại và tăng thêm 1
    SELECT NewMaKho = ISNULL(MAX(CAST(MaKho AS INT)), 0) + 1 FROM LINK0.QLVT.DBO.Kho;

    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETORDER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETORDER]
	@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT DDH.MaDDH, TenHH ,NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), NV.MaNV ,HOTEN, K.TenKho, NCC.TenNCC, SoLuong, DonGia
		FROM DonDatHang AS DDH
		JOIN ChiTietDonDatHang AS CTDDH 
		ON DDH.MaDDH = CTDDH.MaDDH
		JOIN (SELECT MaKho, TenKho, TrangThai FROM Kho) AS K
		ON K.MaKho = DDH.MaKho
		JOIN (SELECT MaNCC, TenNCC FROM NhaCungCap) AS NCC
		ON NCC.MaNCC = DDH.MaNCC
		JOIN (SELECT MaNV, HOTEN = HO +' ' + TEN FROM NHANVIEN) AS NV
		ON NV.MaNV = DDH.MaNV
		JOIN HangHoa AS HH
		ON CTDDH.MaHH = HH.MaHH
		WHERE DDH.TrangThai = 1
	END
	ELSE
	BEGIN
		SELECT DDH.MaDDH, TenHH ,NgayLap = FORMAT(NgayLap,'dd-MM-yyyy'), NV.MaNV ,HOTEN, K.TenKho, NCC.TenNCC, SoLuong, DonGia
		FROM  LINK2.QLVT.DBO.DonDatHang AS DDH
		JOIN  LINK2.QLVT.DBO.ChiTietDonDatHang AS CTDDH 
		ON DDH.MaDDH = CTDDH.MaDDH
		JOIN (SELECT MaKho, TenKho, TrangThai FROM  LINK2.QLVT.DBO.Kho) AS K
		ON K.MaKho = DDH.MaKho
		JOIN (SELECT MaNCC, TenNCC FROM  LINK2.QLVT.DBO.NhaCungCap) AS NCC
		ON NCC.MaNCC = DDH.MaNCC
		JOIN (SELECT MaNV, HOTEN = HO +' ' + TEN FROM  LINK2.QLVT.DBO.NHANVIEN) AS NV
		ON NV.MaNV = DDH.MaNV
		JOIN HangHoa AS HH
		ON CTDDH.MaHH = HH.MaHH
		WHERE DDH.TrangThai = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETPRODUCT]
AS
BEGIN
	
		SELECT MaHH, TenHH, DonViTinh ,LH.TenLH
		FROM HangHoa AS HH WITH (INDEX(IX_TenHangHoa)) , (SELECT MALH, TenLH FROM LOAIHANG) AS LH  
		WHERE HH.MaLH = LH.MaLH AND TrangThai = 1
		
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCTINWAREHOUSE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETPRODUCTINWAREHOUSE]
	@MAHH CHAR(10)
AS
BEGIN
	SELECT ctpn.MaHH, KHO.MaKho ,TenKho , SOLUONG =  SUM(SoluongTon), DonGia
	FROM PhieuNhap AS PN JOIN ChiTietPhieuNhap AS CTPN
	ON PN.SoPN = CTPN.SoPN
	JOIN KHO 
	ON KHO.MaKho = PN.MaKho
	JOIN HangHoa
	ON HangHoa.MaHH = CTPN.MaHH
	WHERE CTPN.MaHH = @MAHH AND Kho.TrangThai = 1 AND HangHoa.TrangThai = 1 AND PN.TrangThai = 1
	GROUP BY ctpn.MaHH, TENKHO, DonGia, kho.MaKho
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCTINWAREHOUSE2]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETPRODUCTINWAREHOUSE2]
	@MAHH CHAR(10),
	@MAKHO CHAR(10)
AS
BEGIN
	SELECT MaHH, KHO.MaKho ,TenKho , SOLUONG =  SUM(SoluongTon), DonGia
	FROM  ChiTietPhieuNhap AS CTPN 
	JOIN PhieuNhap AS PN
	ON PN.SoPN = CTPN.SoPN
	JOIN KHO 
	ON KHO.MaKho = PN.MaKho
	WHERE CTPN.MaHH = @MAHH AND Kho.MaKho = @MAKHO AND Kho.TrangThai = 1 
	GROUP BY MaHH, TENKHO, DonGia, kho.MaKho
	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GETPRODUCTTYPE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETPRODUCTTYPE] 
AS
BEGIN
	SELECT MaLH, TenLH
	FROM LoaiHang
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETSTAFFLIST]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETSTAFFLIST]
	@MACN_CBX CHAR(4)
AS
BEGIN 
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT MaNV, HOTEN = Ho +' ' + Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
		FROM NHANVIEN
		WHERE TrangThai = 1
	END
	ELSE
	BEGIN
		SELECT MaNV, HOTEN = Ho +' ' + Ten, Phai, NgaySinh = FORMAT(NgaySinh,'dd-MM-yyyy'), DiaChi, SoDienThoai 
		FROM  LINK2.QLVT.DBO.NHANVIEN
		WHERE TrangThai = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETSUPPLIER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETSUPPLIER]
AS
BEGIN
	SELECT MaNCC, TenNCC
	FROM NhaCungCap
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GETWAREHOUSE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GETWAREHOUSE]
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		SELECT MaKho, TenKho
		FROM KHO
		WHERE TrangThai = 1
	END
	ELSE
	BEGIN
		SELECT MaKho, TenKho
		FROM  LINK2.QLVT.DBO.KHO
		WHERE TrangThai = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoatDongNhanVien]
@MANV Char(10),
@LOAI NVARCHAR(4),
@DATEFROM DATE,
@DATETO DATE
AS
BEGIN
	IF( @LOAI = 'NHAP')
	BEGIN
		SELECT FORMAT(PN.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
				PN.NgayLap, 
				PN.SoPN AS MAPHIEU,
				TenHH, 
				TENKHO, 
				SOLUONG,
				SOLUONG * DONGIA AS TRIGIA
		FROM (SELECT NgayLap, 
					 SoPN,
					 TENKHO = ( SELECT TENKHO FROM Kho WHERE PN.MAKHO = Kho.MAKHO )
			  FROM PhieuNhap AS PN
			  WHERE NgayLap BETWEEN @DATEFROM AND @DATETO AND MANV = @MANV ) AS  PN,
			  ChiTietPhieuNhap AS CTPN,
			  (SELECT MAHH, TENHH FROM HangHoa ) VT
		      WHERE PN.SoPN =CTPN.SoPN
		      AND VT.MaHH = CTPN.MaHH
		      ORDER BY NgayLap, MAPHIEU, TenHH
	END

	ELSE
	BEGIN
		SELECT FORMAT(HD.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
				HD.NgayLap, 
				HD.SoHD AS MAPHIEU,
				TENHH, 
				TENKHO, 
				SOLUONG,
				SOLUONG * DONGIA AS TRIGIA
		FROM (SELECT NgayLap, 
					SoHD,
					TENKHO = ( SELECT TENKHO FROM Kho WHERE HD.MAKHO = Kho.MAKHO )
				FROM HoaDon AS HD
				WHERE NgayLap BETWEEN @DATEFROM AND @DATETO 
				AND MANV = @MANV ) AS HD,
				ChiTietHoaDon AS CTHD,
				(SELECT MAHH, TENHH FROM HangHoa ) AS HH
				WHERE HD.SoHD =CTHD.SOHD
				AND HH.MaHH = CTHD.MaHH
				ORDER BY NGAYLAP, MAPHIEU, TENHH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien2]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoatDongNhanVien2]
@MANV Char(10),
@DATEFROM DATE,
@DATETO DATE,
@MACN_CBX CHAR(4)
AS
BEGIN
	DECLARE @MACN CHAR(10)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
		BEGIN
			SELECT FORMAT(PN.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'NHAP' AS LOAI,
					PN.NgayLap, 
					PN.SoPN AS MAPHIEU,
					TenHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						 SoPN,
						 TENKHO = ( SELECT TENKHO FROM Kho WHERE PN.MAKHO = Kho.MAKHO )
				  FROM PhieuNhap AS PN
				  WHERE NgayLap BETWEEN @DATEFROM AND @DATETO AND MANV = @MANV ) AS  PN,
				  ChiTietPhieuNhap AS CTPN,
				  (SELECT MAHH, TENHH FROM HangHoa ) VT
				  WHERE PN.SoPN =CTPN.SoPN
				  AND VT.MaHH = CTPN.MaHH   
			UNION ALL
			SELECT FORMAT(HD.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'XUAT' AS LOAI,
					HD.NgayLap, 
					HD.SoHD AS MAPHIEU,
					TENHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						SoHD,
						TENKHO = ( SELECT TENKHO FROM Kho WHERE HD.MAKHO = Kho.MAKHO )
					FROM HoaDon AS HD
					WHERE NgayLap BETWEEN @DATEFROM AND @DATETO 
					AND MANV = @MANV ) AS HD,
					ChiTietHoaDon AS CTHD,
					(SELECT MAHH, TENHH FROM HangHoa ) AS HH
					WHERE HD.SoHD =CTHD.SOHD
					AND HH.MaHH = CTHD.MaHH
			ORDER BY NGAYLAP, MAPHIEU, TENHH
		END
	ELSE
		BEGIN
			SELECT FORMAT(PN.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'NHAP' AS LOAI,
					PN.NgayLap, 
					PN.SoPN AS MAPHIEU,
					TenHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						 SoPN,
						 TENKHO = ( SELECT TENKHO FROM  LINK2.QLVT.DBO.Kho WHERE PN.MAKHO = Kho.MAKHO )
				  FROM  LINK2.QLVT.DBO.PhieuNhap AS PN
				  WHERE NgayLap BETWEEN @DATEFROM AND @DATETO AND MANV = @MANV ) AS  PN,
				  LINK2.QLVT.DBO.ChiTietPhieuNhap AS CTPN,
				  (SELECT MAHH, TENHH FROM HangHoa ) VT
				  WHERE PN.SoPN =CTPN.SoPN
				  AND VT.MaHH = CTPN.MaHH   
			UNION ALL
			SELECT FORMAT(HD.NgayLap,'MM-yyyy') AS THANGNAM, -- Group theo mẫu
					'XUAT' AS LOAI,
					HD.NgayLap, 
					HD.SoHD AS MAPHIEU,
					TENHH, 
					TENKHO, 
					SOLUONG,
					DONGIA,
					SOLUONG * DONGIA AS TRIGIA
			FROM (SELECT NgayLap, 
						SoHD,
						TENKHO = ( SELECT TENKHO FROM  LINK2.QLVT.DBO.Kho WHERE HD.MAKHO = Kho.MAKHO )
					FROM  LINK2.QLVT.DBO.HoaDon AS HD
					WHERE NgayLap BETWEEN @DATEFROM AND @DATETO 
					AND MANV = @MANV ) AS HD,
					 LINK2.QLVT.DBO.ChiTietHoaDon AS CTHD,
					(SELECT MAHH, TENHH FROM HangHoa ) AS HH
					WHERE HD.SoHD =CTHD.SOHD
					AND HH.MaHH = CTHD.MaHH
			ORDER BY NGAYLAP, MAPHIEU, TENHH
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LapDonDatHang]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LapDonDatHang]
    @MaDDH char(10),
    @NgayLap DATE,
    @MaNV char(50),
    @MaNCC char(50),
    @MaKho char(50),
	@SoLuong int,
	@DonGia float,
	@MaHH char(10)
AS
BEGIN
    -- Bắt đầu transaction
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Thực hiện chèn dữ liệu vào bảng DonDatHang
        INSERT INTO DonDatHang (MaDDH, NgayLap, MaNV, MaNCC, MaKho)
        VALUES (@MaDDH, @NgayLap, @MaNV, @MaNCC, @MaKho);
        
		INSERT INTO ChiTietDonDatHang (MaDDH, MaHH, SoLuong, DonGia)
		VALUES (@MaDDH, @MaHH, @SoLuong, @DonGia);
        -- Nếu thành công, commit transaction
        COMMIT TRANSACTION;
        
        -- Thông báo thành công
        PRINT 'Đơn đặt hàng đã được tạo thành công.';
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback transaction
        ROLLBACK TRANSACTION;
        
        -- Bắt lỗi và trả về thông báo lỗi
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_TAOLOGIN]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TAOLOGIN]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'QLVT'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
	
     RETURN 1
 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RETURN 2
  END
  EXEC sp_addrolemember @ROLE, @USERNAME
  IF @ROLE= 'CONGTY' OR @ROLE= 'CHINHANH'
  BEGIN 
    EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
  END
RETURN 0  -- THANH CONG
GO
/****** Object:  StoredProcedure [dbo].[sp_TongHopNhapXuat]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_TongHopNhapXuat]
@MACN_CBX CHAR(4),
@FromDate DATETIME,
@ToDate DATETIME
AS
BEGIN
	DECLARE @MACN CHAR(4)
	SET @MACN = (SELECT MACN FROM ChiNhanh)
	IF( @MACN = @MACN_CBX)
	BEGIN
		--------------------phieu xuat--------------------------
		SELECT PN.NgayLap,
				NHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG)),
				TYLENHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG) / (SELECT SUM(DONGIA * SOLUONG)
							FROM ChiTietPhieuNhap  , PhieuNhap WHERE ChiTietPhieuNhap.SoPN = PhieuNhap.SoPN
							AND PhieuNhap.NgayLap BETWEEN @FromDate AND @ToDate   )) INTO #PHIEUNHAPTABLE
		FROM PhieuNhap AS PN,
			ChiTietPhieuNhap AS CTPN
		WHERE PN.SoPN = CTPN.SoPN
		AND PN.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY PN.NgayLap
	
		--------------------phieu xuat--------------------------
		SELECT HD.NgayLap,
				XUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)),
				TYLEXUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)/ (SELECT SUM(DONGIA * SOLUONG)
							FROM ChiTietHoaDon , HOADON WHERE ChiTietHoaDon.SoHD = HOADON.SoHD
							AND HOADON.NgayLap BETWEEN @FromDate AND @ToDate )) INTO #HOADONTABLE
		FROM HoaDon AS HD,
			ChiTietHoaDon AS CTHD
		WHERE HD.SoHD = CTHD.SoHD
		AND HD.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY HD.NgayLap
		-----------------------TONG HOP--------------------------------------
		SELECT 
			ISNULL(CONVERT(varchar,FORMAT(PN.NgayLap, 'dd-MM-yyyy'), 11), CONVERT(varchar, FORMAT(HD.NgayLap, 'dd-MM-yyyy'), 11)) AS NGAY,
			(ISNULL(PN.NHAP, 0)) AS NHAP,
			ISNULL(PN.TYLENHAP,0) TILENHAP,
			(ISNULL(HD.XUAT,0)) XUAT,
			ISNULL(HD.TYLEXUAT,0) AS TILEXUAT
		FROM #PHIEUNHAPTABLE AS PN 
		FULL JOIN #HOADONTABLE AS HD
		ON PN.NgayLap = HD.NgayLap
	END
	
	ELSE
	BEGIN 
		--------------------phieu xuat--------------------------
		SELECT PN.NgayLap,
				NHAP =(SUM (CTPN.DONGIA * CTPN.SOLUONG)),
				TYLENHAP = (SUM (CTPN.DONGIA * CTPN.SOLUONG) / (SELECT SUM(DONGIA * SOLUONG)
							FROM LINK2.QLVT.DBO.ChiTietPhieuNhap  , LINK2.QLVT.DBO.PhieuNhap WHERE ChiTietPhieuNhap.SoPN = PhieuNhap.SoPN
							AND PhieuNhap.NgayLap BETWEEN @FromDate AND @ToDate   )) INTO #PHIEUNHAPTABLE2
		FROM LINK2.QLVT.DBO.PhieuNhap AS PN,
			LINK2.QLVT.DBO.ChiTietPhieuNhap AS CTPN
		WHERE PN.SoPN = CTPN.SoPN
		AND PN.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY PN.NgayLap
	
		--------------------phieu xuat--------------------------
		SELECT HD.NgayLap,
				XUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)),
				TYLEXUAT = (SUM (CTHD.DONGIA * CTHD.SOLUONG)/ (SELECT SUM(DONGIA * SOLUONG)
							FROM LINK2.QLVT.DBO.ChiTietHoaDon , LINK2.QLVT.DBO.HOADON WHERE ChiTietHoaDon.SoHD = HOADON.SoHD
							AND HOADON.NgayLap BETWEEN @FromDate AND @ToDate )) INTO #HOADONTABLE2
		FROM LINK2.QLVT.DBO.HoaDon AS HD,
			LINK2.QLVT.DBO.ChiTietHoaDon AS CTHD
		WHERE HD.SoHD = CTHD.SoHD
		AND HD.NgayLap BETWEEN @FromDate AND @ToDate
		GROUP BY HD.NgayLap
		-----------------------TONG HOP--------------------------------------
		SELECT 
			ISNULL(CONVERT(varchar,FORMAT(PN.NgayLap, 'dd-MM-yyyy'), 11), CONVERT(varchar, FORMAT(HD.NgayLap, 'dd-MM-yyyy'), 11)) AS NGAY,
			(ISNULL(PN.NHAP, 0)) AS NHAP,
			ISNULL(PN.TYLENHAP,0) TILENHAP,
			(ISNULL(HD.XUAT,0)) XUAT,
			ISNULL(HD.TYLEXUAT,0) AS TILEXUAT
		FROM #PHIEUNHAPTABLE2 AS PN 
		FULL JOIN #HOADONTABLE2 AS HD
		ON PN.NgayLap = HD.NgayLap
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEORDER]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATEORDER]
	@MaDDH CHAR(10),
    @NgayLap date,
	@MaNCC char(10),
    @MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	UPDATE DonDatHang
	SET NgayLap = @NgayLap, MaNCC = @MaNCC, MaKho = @MaKho
	WHERE MaDDH = @MaDDH

	UPDATE ChiTietDonDatHang
	SET MaHH = @MaHH, SoLuong = @SoLuong, DonGia = @DonGia
	WHERE MaDDH = @MaDDH

END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEPRODUCT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATEPRODUCT]
	@MaHH CHAR(10),
    @TenHH NVARCHAR(100),
	@DonViTinh nvarchar(20),
    @TenLH NVARCHAR(100)
AS
BEGIN
	DECLARE @NEWMALH NVARCHAR(100)
	SET @NEWMALH = (SELECT MaLH FROM LoaiHang WHERE TenLH =@TenLH)
	UPDATE HANGHOA
	SET MaHH = @MaHH , TenHH = @TenHH, DonViTinh = @DonViTinh, MaLH = @NEWMALH
	WHERE MaHH = @MaHH

END

GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATERECEIPT]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATERECEIPT]
	@SoPN CHAR(10),
    @NgayLap date,
	@MaDDH char(10),
    @MaKho char(10),
	@MaHH char(10),
	@SoLuong int,
	@DonGia float
AS
SET XACT_ABORT ON
BEGIN DISTRIBUTED TRANSACTION
BEGIN
	UPDATE PhieuNhap
	SET NgayLap = @NgayLap, MaDDH = @MaDDH, MaKho = @MaKho
	WHERE SoPN = @SoPN

	UPDATE ChiTietPhieuNhap
	SET MaHH = @MaHH, SoLuong = @SoLuong, DonGia = @DonGia
	WHERE SoPN = @SoPN

END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATESOLUONG]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATESOLUONG]
	@MAHH CHAR(10),
	@MAKHO CHAR(10),
	@SOLUONG INT
AS
BEGIN

	WHILE (@SOLUONG > 0)
	BEGIN
		-- Cập nhật từng dòng một
		WITH CTE AS		(
			SELECT TOP 1
                CTPN.MaHH, CTPN.SoPN, CTPN.SoluongTon
            FROM ChiTietPhieuNhap AS CTPN
            FULL JOIN PhieuNhap AS PN ON PN.SoPN = CTPN.SoPN
            JOIN KHO ON KHO.MaKho = PN.MaKho
            JOIN HangHoa AS HH ON HH.MaHH = CTPN.MaHH
            WHERE CTPN.MaHH = @MAHH 
				  AND Kho.MaKho = @MAKHO 
                  AND Kho.TrangThai = 1 
                  AND HH.TrangThai = 1 
                  AND CTPN.SoluongTon > 0
            ORDER BY CTPN.SoluongTon DESC
		)
		UPDATE CTE
        SET SoluongTon = SoluongTon - 1


		SET @SOLUONG = @SOLUONG - 1; 
        -- Giảm số lượng cần trừ (tổng số cần cập nhật)

        
        -- Thoát vòng lặp nếu không còn dòng nào để trừ
        
	END
END


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATESTAFF]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATESTAFF]
	@MaNV CHAR(10),
    @Ho NVARCHAR(50),
	@Ten nvarchar(50),
    @NgaySinh date,
	@DiaCHi Nvarchar(100),
	@SoDienThoai char(10),
	@Phai nvarchar(3)
AS
BEGIN
	UPDATE NhanVien
	SET Phai = @Phai, Ho = @Ho, Ten = @Ten, NgaySinh = @NgaySinh, DiaChi = @DiaCHi, SoDienThoai = @SoDienThoai, TrangThai = 1
	WHERE MaNV = @MaNV

END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEWAREHOUSE]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UPDATEWAREHOUSE]
	@MaKho INT,
    @TenKho NVARCHAR(100)
	
AS
BEGIN
	UPDATE KHO
	SET TenKho = @TenKho
	WHERE MaKho = @MaKho
END

GO
/****** Object:  StoredProcedure [dbo].[Xoa_Login]    Script Date: 12/23/2024 11:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Xoa_Login]
  @USRNAME VARCHAR(50)
AS
SET XACT_ABORT ON;
begin
      
		
		  DECLARE @LGNAME CHAR(10)
		  
		  SET @LGNAME = CAST((SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(TRIM(@USRNAME) AS NVARCHAR)) AS VARCHAR(50))
		  IF NOT EXISTS  (SELECT 1 FROM sys.database_principals WHERE name = @USRNAME AND type = 'S')
			BEGIN
			   UPDATE NhanVien
			   SET TrangThai = 0
			   WHERE MaNV = @USRNAME
				PRINT('')
				RETURN 1;
			END
		  ELSE IF NOT EXISTS (SELECT 1 FROM sys.sysusers WHERE SUSER_SNAME(sid) = @LGNAME)
			BEGIN
				 UPDATE NhanVien
				  SET TrangThai = 0
				  WHERE MaNV = @USRNAME
				-- Nếu login name tồn tại trong sys.sysusers
				-- Thực hiện các hành động khi login name tồn tại
				PRINT 'Login name tồn tại trong sys.sysusers.';
				RETURN 2;
			END
		  ELSE
			BEGIN
				  UPDATE NhanVien
				  SET TrangThai = 0
				  WHERE MaNV = @USRNAME
				  EXEC SP_DROPUSER @USRNAME
				  EXEC SP_DROPLOGIN @LGNAME
			END
		
RETURN 0;		
			  
end

GO
