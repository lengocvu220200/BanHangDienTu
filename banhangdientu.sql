USE [banhangdientu]
GO
/****** Object:  Table [dbo].[chitiethoadon]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethoadon](
	[chitiethd_id] [int] IDENTITY(1,1) NOT NULL,
	[hoadon_id] [int] NOT NULL,
	[sanpham_id] [int] NOT NULL,
	[chitiethd_soluong] [int] NOT NULL,
	[chitiethd_thanhtien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[chitiethd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietphieunhaphang]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietphieunhaphang](
	[chitietpnh_id] [int] IDENTITY(1,1) NOT NULL,
	[phieunhaphang_id] [int] NOT NULL,
	[sanpham_id] [int] NOT NULL,
	[soluong] [int] NOT NULL,
	[dongia] [float] NOT NULL,
	[thanhtien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[chitietpnh_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chucvu]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chucvu](
	[chucvu_id] [int] IDENTITY(1,1) NOT NULL,
	[chucvu_ten] [nvarchar](100) NOT NULL,
	[trangthai_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[chucvu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giohang]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giohang](
	[giohang_id] [int] IDENTITY(1,1) NOT NULL,
	[khachhang_id] [int] NOT NULL,
	[sanpham_id] [int] NOT NULL,
	[giohang_soluong] [int] NOT NULL,
	[giohang_dongia] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[giohang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon](
	[hoadon_id] [int] IDENTITY(1,1) NOT NULL,
	[nhanvien_id] [int] NULL,
	[khachhang_id] [int] NOT NULL,
	[hoadon_ngaylap] [datetime] NOT NULL,
	[hoadon_tongtien] [float] NULL,
	[trangthaihoadon_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[hoadon_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[khachhang_id] [int] IDENTITY(1,1) NOT NULL,
	[khachhang_ten] [nvarchar](100) NOT NULL,
	[khachhang_ngaysinh] [date] NOT NULL,
	[khachhang_sdt] [varchar](11) NOT NULL,
	[khachhang_diachi] [nvarchar](200) NOT NULL,
	[khachhang_email] [varchar](100) NULL,
	[khachhang_matkhau] [varchar](50) NULL,
	[trangthai_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[khachhang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaisanpham]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaisanpham](
	[loaisanpham_id] [int] IDENTITY(1,1) NOT NULL,
	[loaisanpham_ten] [nvarchar](100) NOT NULL,
	[trangthai_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[loaisanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhacungcap]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhacungcap](
	[ncc_id] [int] IDENTITY(1,1) NOT NULL,
	[ncc_ten] [nvarchar](100) NOT NULL,
	[ncc_sdt] [varchar](11) NOT NULL,
	[ncc_email] [nvarchar](100) NOT NULL,
	[ncc_diachi] [nvarchar](150) NOT NULL,
	[trangthai_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ncc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien](
	[nhanvien_id] [int] IDENTITY(1,1) NOT NULL,
	[nhanvien_ten] [nvarchar](100) NOT NULL,
	[nhanvien_ngaysinh] [date] NOT NULL,
	[nhanvien_sdt] [varchar](11) NOT NULL,
	[nhanvien_email] [varchar](100) NOT NULL,
	[nhanvien_matkhau] [varchar](50) NOT NULL,
	[chucvu_id] [int] NOT NULL,
	[trangthai_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nhanvien_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieugiaohang]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieugiaohang](
	[phieugiaohang_id] [int] IDENTITY(1,1) NOT NULL,
	[hoadon_id] [int] NOT NULL,
	[phieugiaohang_tennguoinhan] [nvarchar](100) NOT NULL,
	[phieugiaohang_sdtnguoinhan] [int] NOT NULL,
	[phieugiaohang_diachinguoinhan] [nvarchar](200) NOT NULL,
	[phieugiaohang_thoigiangiaohang] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[phieugiaohang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieunhaphang]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieunhaphang](
	[phieunhaphang_id] [int] IDENTITY(1,1) NOT NULL,
	[nhanvien_id] [int] NOT NULL,
	[ncc_id] [int] NOT NULL,
	[phieunhaphang_ngaylap] [datetime] NOT NULL,
	[phieunhaphang_tongtien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[phieunhaphang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[sanpham_id] [int] IDENTITY(1,1) NOT NULL,
	[sanpham_ten] [nvarchar](100) NOT NULL,
	[sanpham_mota] [nvarchar](300) NOT NULL,
	[loaisanpham_id] [int] NOT NULL,
	[sanpham_soluong] [int] NOT NULL,
	[sanpham_dongia] [float] NOT NULL,
	[sanpham_urlhinhanh] [nvarchar](200) NULL,
	[trangthai_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trangthai]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trangthai](
	[trangthai_id] [int] IDENTITY(1,1) NOT NULL,
	[trangthai_ten] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[trangthai_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trangthaihoadon]    Script Date: 6/1/2021 3:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trangthaihoadon](
	[trangthaihoadon_id] [int] IDENTITY(1,1) NOT NULL,
	[trangthaihoadon_ten] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[trangthaihoadon_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[chitiethoadon]  WITH CHECK ADD FOREIGN KEY([hoadon_id])
REFERENCES [dbo].[hoadon] ([hoadon_id])
GO
ALTER TABLE [dbo].[chitiethoadon]  WITH CHECK ADD FOREIGN KEY([sanpham_id])
REFERENCES [dbo].[sanpham] ([sanpham_id])
GO
ALTER TABLE [dbo].[chitietphieunhaphang]  WITH CHECK ADD FOREIGN KEY([phieunhaphang_id])
REFERENCES [dbo].[phieunhaphang] ([phieunhaphang_id])
GO
ALTER TABLE [dbo].[chitietphieunhaphang]  WITH CHECK ADD FOREIGN KEY([sanpham_id])
REFERENCES [dbo].[sanpham] ([sanpham_id])
GO
ALTER TABLE [dbo].[chucvu]  WITH CHECK ADD FOREIGN KEY([trangthai_id])
REFERENCES [dbo].[trangthai] ([trangthai_id])
GO
ALTER TABLE [dbo].[giohang]  WITH CHECK ADD FOREIGN KEY([khachhang_id])
REFERENCES [dbo].[khachhang] ([khachhang_id])
GO
ALTER TABLE [dbo].[giohang]  WITH CHECK ADD FOREIGN KEY([sanpham_id])
REFERENCES [dbo].[sanpham] ([sanpham_id])
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD FOREIGN KEY([khachhang_id])
REFERENCES [dbo].[khachhang] ([khachhang_id])
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD FOREIGN KEY([nhanvien_id])
REFERENCES [dbo].[nhanvien] ([nhanvien_id])
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD FOREIGN KEY([trangthaihoadon_id])
REFERENCES [dbo].[trangthaihoadon] ([trangthaihoadon_id])
GO
ALTER TABLE [dbo].[khachhang]  WITH CHECK ADD FOREIGN KEY([trangthai_id])
REFERENCES [dbo].[trangthai] ([trangthai_id])
GO
ALTER TABLE [dbo].[loaisanpham]  WITH CHECK ADD FOREIGN KEY([trangthai_id])
REFERENCES [dbo].[trangthai] ([trangthai_id])
GO
ALTER TABLE [dbo].[nhacungcap]  WITH CHECK ADD FOREIGN KEY([trangthai_id])
REFERENCES [dbo].[trangthai] ([trangthai_id])
GO
ALTER TABLE [dbo].[nhanvien]  WITH CHECK ADD FOREIGN KEY([chucvu_id])
REFERENCES [dbo].[chucvu] ([chucvu_id])
GO
ALTER TABLE [dbo].[nhanvien]  WITH CHECK ADD FOREIGN KEY([trangthai_id])
REFERENCES [dbo].[trangthai] ([trangthai_id])
GO
ALTER TABLE [dbo].[phieugiaohang]  WITH CHECK ADD FOREIGN KEY([hoadon_id])
REFERENCES [dbo].[hoadon] ([hoadon_id])
GO
ALTER TABLE [dbo].[phieunhaphang]  WITH CHECK ADD FOREIGN KEY([ncc_id])
REFERENCES [dbo].[nhacungcap] ([ncc_id])
GO
ALTER TABLE [dbo].[phieunhaphang]  WITH CHECK ADD FOREIGN KEY([nhanvien_id])
REFERENCES [dbo].[nhanvien] ([nhanvien_id])
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD FOREIGN KEY([loaisanpham_id])
REFERENCES [dbo].[loaisanpham] ([loaisanpham_id])
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD FOREIGN KEY([trangthai_id])
REFERENCES [dbo].[trangthai] ([trangthai_id])
GO
