USE [master]
GO
/****** Object:  Database [Quanlinhansu]    Script Date: 12/27/2021 9:00:57 AM ******/
CREATE DATABASE [Quanlinhansu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quanlinhansu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Quanlinhansu.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Quanlinhansu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Quanlinhansu_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Quanlinhansu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quanlinhansu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quanlinhansu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quanlinhansu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quanlinhansu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quanlinhansu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quanlinhansu] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quanlinhansu] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Quanlinhansu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quanlinhansu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quanlinhansu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quanlinhansu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quanlinhansu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quanlinhansu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quanlinhansu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quanlinhansu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quanlinhansu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Quanlinhansu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quanlinhansu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quanlinhansu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quanlinhansu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quanlinhansu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quanlinhansu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quanlinhansu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quanlinhansu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quanlinhansu] SET  MULTI_USER 
GO
ALTER DATABASE [Quanlinhansu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quanlinhansu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quanlinhansu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quanlinhansu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Quanlinhansu] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Quanlinhansu]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [varchar](10) NOT NULL,
	[TenCV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TenCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HopDong](
	[MaHD] [varchar](20) NOT NULL,
	[NgayBD] [date] NULL,
	[HanHD] [int] NULL,
	[MaNV] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiTkhoan]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiTkhoan](
	[Matk] [varchar](10) NOT NULL,
	[Tentk] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Matk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Luong](
	[MaLuong] [varchar](10) NOT NULL,
	[LuongCB] [int] NOT NULL,
	[HSL] [float] NOT NULL,
	[PhuCap] [int] NULL,
	[Thuong] [int] NULL,
	[KiLuat] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TienLuong] [int] NULL,
	[MaNV] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NghiPhep]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NghiPhep](
	[MaNghiPhep] [varchar](10) NOT NULL,
	[NgayNghi] [date] NULL,
	[SoNgayNghi] [int] NULL,
	[LyDo] [nvarchar](50) NULL,
	[MaNV] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNghiPhep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](10) NOT NULL,
	[HoTenNV] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[CMND] [char](12) NULL,
	[SDT] [char](10) NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[Email] [nvarchar](30) NULL,
	[NgaySinh] [date] NULL,
	[MaCV] [varchar](10) NOT NULL,
	[MaPB] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [varchar](10) NOT NULL,
	[TenPB] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TenPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](30) NULL,
	[Matk] [varchar](10) NULL,
	[ID] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Luong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[NghiPhep]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([Matk])
REFERENCES [dbo].[LoaiTkhoan] ([Matk])
GO
/****** Object:  StoredProcedure [dbo].[insertNV]    Script Date: 12/27/2021 9:00:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertNV]
@MaNV nvarchar(20) , @HoTenNV nvarchar(50) , @DiaChi nvarchar(20) , @CMND nvarchar(20), @SDT nvarchar(10), @GioiTinh nvarchar(30) , @Email nvarchar(40) , @NgaySinh date, @MaCV nvarchar(10) , @MaPB nvarchar(10)
as
begin
	insert into NhanVien values (@MaNV , @HoTenNV , @DiaChi , @CMND , @SDT , @GioiTinh , @Email , @NgaySinh , @MaCV , @MaPB)
end

GO
USE [master]
GO
ALTER DATABASE [Quanlinhansu] SET  READ_WRITE 
GO
