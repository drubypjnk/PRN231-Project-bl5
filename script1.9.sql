USE [master]
GO
/****** Object:  Database [PRN231_BL5]    Script Date: 8/24/2023 8:52:13 PM ******/
CREATE DATABASE [PRN231_BL5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN231_BL5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PRN231_BL5.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN231_BL5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PRN231_BL5_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PRN231_BL5] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN231_BL5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN231_BL5] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN231_BL5] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN231_BL5] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN231_BL5] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN231_BL5] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN231_BL5] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PRN231_BL5] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN231_BL5] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN231_BL5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN231_BL5] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN231_BL5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN231_BL5] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN231_BL5] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN231_BL5] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN231_BL5] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRN231_BL5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN231_BL5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN231_BL5] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN231_BL5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN231_BL5] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN231_BL5] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN231_BL5] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN231_BL5] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN231_BL5] SET  MULTI_USER 
GO
ALTER DATABASE [PRN231_BL5] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN231_BL5] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN231_BL5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN231_BL5] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN231_BL5] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN231_BL5] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PRN231_BL5] SET QUERY_STORE = ON
GO
ALTER DATABASE [PRN231_BL5] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PRN231_BL5]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[history_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[create_date] [datetime] NULL,
	[desc] [text] NULL,
	[delete_flag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[history_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [text] NULL,
	[desc] [text] NULL,
	[delete_flag] [bit] NULL,
	[position_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[note_id] [int] NOT NULL,
	[create_by] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[create_date] [datetime] NULL,
	[content] [text] NULL,
	[delete_flag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[note_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[order_type_id] [int] NOT NULL,
	[create_date] [datetime] NULL,
	[total_price] [float] NULL,
	[update_date] [datetime] NULL,
	[delete_flag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_detail]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_detail](
	[order_id] [int] NULL,
	[product_variant_id] [int] NULL,
	[quantity] [int] NULL,
	[price] [float] NULL,
	[is_delete] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Type]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Type](
	[order_type_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [text] NULL,
	[desc] [text] NULL,
	[create_date] [datetime] NULL,
	[delete_flag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[position_id] [int] NOT NULL,
	[address] [varchar](16) NULL,
	[desc] [text] NULL,
	[delete_flag] [bit] NULL,
	[seat] [int] NULL,
	[avail_seat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[position_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NULL,
	[delete_flag] [bit] NULL,
	[product_name] [nvarchar](255) NULL,
	[img] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_variants]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_variants](
	[product_variant_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[unit_price] [int] NULL,
	[quality] [int] NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[create_by] [text] NULL,
	[unit_in_stock] [int] NULL,
	[unit_in_order] [int] NULL,
	[delete_flag] [bit] NULL,
	[sku_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_variant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_variants_sub_position_relation]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_variants_sub_position_relation](
	[sub_position_id] [int] NOT NULL,
	[product_variant_id] [int] NOT NULL,
	[delete_flag] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesUsers]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesUsers](
	[RolesID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_RolesUsers] PRIMARY KEY CLUSTERED 
(
	[RolesID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skus]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skus](
	[sku_id] [int] IDENTITY(1,1) NOT NULL,
	[desc] [text] NULL,
	[total_price] [float] NULL,
	[approve_date] [datetime] NULL,
	[create_date] [datetime] NULL,
	[create_by] [text] NULL,
	[update_date] [datetime] NULL,
	[delete_flag] [bit] NULL,
	[name] [nvarchar](256) NULL,
 CONSTRAINT [PK__Skus__EAC95375DD258534] PRIMARY KEY CLUSTERED 
(
	[sku_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sub_position]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sub_position](
	[sub_position_id] [int] NOT NULL,
	[address] [text] NULL,
	[desc] [text] NULL,
	[position_id] [int] NOT NULL,
	[delete_flag] [bit] NULL,
	[seat] [int] NULL,
	[avail_seat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sub_position_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/24/2023 8:52:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[full_name] [text] NULL,
	[description] [text] NULL,
	[age] [int] NULL,
	[gender] [int] NULL,
	[location] [text] NULL,
	[email] [text] NULL,
	[status] [int] NULL,
	[avatar] [text] NULL,
	[is_private] [bit] NULL,
	[delete_flag] [bit] NULL,
	[Token] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([category_id], [name], [desc], [delete_flag], [position_id]) VALUES (1, N'Laptop', N'Laptop', 0, 1)
INSERT [dbo].[Category] ([category_id], [name], [desc], [delete_flag], [position_id]) VALUES (2, N'Phone', N'Phone', 0, 2)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (1, N'A', N'A', 0, 10000, 4000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (2, N'B', N'B', 0, 10000, 8000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (3, N'C', N'C', 0, 10000, 10000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (4, N'D', N'D', 0, 10000, 10000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (5, N'E', N'E', 0, 10000, 10000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (6, N'F', N'F', 0, 10000, 10000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (7, N'G', N'G', 0, 10000, 10000)
INSERT [dbo].[Positions] ([position_id], [address], [desc], [delete_flag], [seat], [avail_seat]) VALUES (8, N'H', N'H', 0, 10000, 10000)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [category_id], [delete_flag], [product_name], [img]) VALUES (3, 1, NULL, N'Laptop Asus ULTRA S1', NULL)
INSERT [dbo].[Product] ([product_id], [category_id], [delete_flag], [product_name], [img]) VALUES (4, 1, NULL, N'Laptop Dell XPS 9570', NULL)
INSERT [dbo].[Product] ([product_id], [category_id], [delete_flag], [product_name], [img]) VALUES (5, 1, NULL, N'Laptop Asus ULTRA S2', NULL)
INSERT [dbo].[Product] ([product_id], [category_id], [delete_flag], [product_name], [img]) VALUES (6, 1, NULL, N'Laptop Dell XPS 9560', NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_variants] ON 

INSERT [dbo].[Product_variants] ([product_variant_id], [product_id], [unit_price], [quality], [create_date], [update_date], [create_by], [unit_in_stock], [unit_in_order], [delete_flag], [sku_id]) VALUES (8, 3, 10000000, 50, CAST(N'2023-08-15T20:06:49.573' AS DateTime), CAST(N'2023-08-15T20:06:51.567' AS DateTime), N'Admin', 100, 0, 0, 1)
INSERT [dbo].[Product_variants] ([product_variant_id], [product_id], [unit_price], [quality], [create_date], [update_date], [create_by], [unit_in_stock], [unit_in_order], [delete_flag], [sku_id]) VALUES (9, 3, 20000000, 25, CAST(N'2023-08-15T20:06:49.573' AS DateTime), CAST(N'2023-08-15T20:06:51.567' AS DateTime), N'Admin', 100, 0, 1, 2)
INSERT [dbo].[Product_variants] ([product_variant_id], [product_id], [unit_price], [quality], [create_date], [update_date], [create_by], [unit_in_stock], [unit_in_order], [delete_flag], [sku_id]) VALUES (10, 3, 10000000, 50, CAST(N'2023-08-15T20:06:49.573' AS DateTime), CAST(N'2023-08-15T20:06:51.567' AS DateTime), N'Admin', 100, 0, 1, 2)
INSERT [dbo].[Product_variants] ([product_variant_id], [product_id], [unit_price], [quality], [create_date], [update_date], [create_by], [unit_in_stock], [unit_in_order], [delete_flag], [sku_id]) VALUES (11, 4, 30000000, 50, CAST(N'2023-08-15T20:06:49.573' AS DateTime), CAST(N'2023-08-15T20:06:51.567' AS DateTime), N'Admin', 100, 0, 1, 2)
SET IDENTITY_INSERT [dbo].[Product_variants] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[RolesUsers] ([RolesID], [UserID]) VALUES (1, 1)
INSERT [dbo].[RolesUsers] ([RolesID], [UserID]) VALUES (2, 2)
INSERT [dbo].[RolesUsers] ([RolesID], [UserID]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[Skus] ON 

INSERT [dbo].[Skus] ([sku_id], [desc], [total_price], [approve_date], [create_date], [create_by], [update_date], [delete_flag], [name]) VALUES (1, N'Lô Hàng 1', 1000000000, CAST(N'2023-08-15T20:01:34.313' AS DateTime), CAST(N'2023-08-15T20:01:34.313' AS DateTime), N'ADMIN', CAST(N'2023-08-15T20:01:34.313' AS DateTime), 1, N'Lô Hàng 1')
INSERT [dbo].[Skus] ([sku_id], [desc], [total_price], [approve_date], [create_date], [create_by], [update_date], [delete_flag], [name]) VALUES (2, N'Lô Hàng 2', 2000000000, CAST(N'2023-08-15T20:01:34.313' AS DateTime), CAST(N'2023-08-15T20:01:34.313' AS DateTime), N'ADMIN', CAST(N'2023-08-15T20:01:34.313' AS DateTime), 1, N'Lô Hàng 1')
SET IDENTITY_INSERT [dbo].[Skus] OFF
GO
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (1, N'A_1', N'A_1', 1, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (2, N'A_2', N'A_2', 1, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (3, N'A_3', N'A_3', 1, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (4, N'B_1', N'B_1', 2, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (5, N'A_4', N'A_4', 1, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (6, N'A_5', N'A_5', 1, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (7, N'A_6', N'A_6', 1, 0, 1000, 900)
INSERT [dbo].[Sub_position] ([sub_position_id], [address], [desc], [position_id], [delete_flag], [seat], [avail_seat]) VALUES (8, N'B_5', N'B_5', 2, 0, 1000, 900)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [username], [password], [full_name], [description], [age], [gender], [location], [email], [status], [avatar], [is_private], [delete_flag], [Token]) VALUES (1, N'hduong', N'123456', N'hoang duong ', N'nhan vien', 18, 1, N'ha noi', N'hduong@gm.com', 1, NULL, 1, 0, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiaGR1b25nIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjkyODg0ODk0LCJleHAiOjE2OTI4ODg0OTQsImlhdCI6MTY5Mjg4NDg5NCwiaXNzIjoiSXNzdWVyS2V5IiwiYXVkIjoiQXVkaWVuY2VLZXkifQ.25joLNlVivfookLlswkBROoSkvK8F02DHPUVlqPM3EM')
INSERT [dbo].[User] ([user_id], [username], [password], [full_name], [description], [age], [gender], [location], [email], [status], [avatar], [is_private], [delete_flag], [Token]) VALUES (2, N'david', N'123', N'david beckham', N'sep', 28, 1, N'london', N'beck@gmail.com', 0, NULL, 1, 1, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiZGF2aWQiLCJuYmYiOjE2OTI4NzE1NzAsImV4cCI6MTY5Mjg3NTE2OSwiaWF0IjoxNjkyODcxNTcwLCJpc3MiOiJJc3N1ZXJLZXkiLCJhdWQiOiJBdWRpZW5jZUtleSJ9.mNbAEgTe5MlrhBsABpCNe1TjjJh0GU6YaXj5ULJ3TmQ')
INSERT [dbo].[User] ([user_id], [username], [password], [full_name], [description], [age], [gender], [location], [email], [status], [avatar], [is_private], [delete_flag], [Token]) VALUES (3, N'rooney ', N'123', N'roney wayne', N'nhan vien', 21, 1, N'manchester', N'fadffc2', 1, NULL, 1, 1, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoicm9vbmV5ICIsInJvbGUiOiJTdGFmZiIsIm5iZiI6MTY5Mjg4MTUyNCwiZXhwIjoxNjkyODg1MTI0LCJpYXQiOjE2OTI4ODE1MjQsImlzcyI6Iklzc3VlcktleSIsImF1ZCI6IkF1ZGllbmNlS2V5In0.kW6WP91J7AevVK7FMj_YS-bwtxyxbNSe-cOqLztB9rE')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Positions_UN]    Script Date: 8/24/2023 8:52:14 PM ******/
ALTER TABLE [dbo].[Positions] ADD  CONSTRAINT [Positions_UN] UNIQUE NONCLUSTERED 
(
	[address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Positions] ADD  DEFAULT ((0)) FOR [delete_flag]
GO
ALTER TABLE [dbo].[Skus] ADD  DEFAULT ((0)) FOR [delete_flag]
GO
ALTER TABLE [dbo].[Sub_position] ADD  DEFAULT ((0)) FOR [delete_flag]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity.user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity.user_id]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD FOREIGN KEY([position_id])
REFERENCES [dbo].[Positions] ([position_id])
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes.create_by] FOREIGN KEY([create_by])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes.create_by]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes.order_id] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([order_id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes.order_id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order.order_type_id] FOREIGN KEY([order_type_id])
REFERENCES [dbo].[Order_Type] ([order_type_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order.order_type_id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order.user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order.user_id]
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_detail.order_id] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([order_id])
GO
ALTER TABLE [dbo].[Order_detail] CHECK CONSTRAINT [FK_Order_detail.order_id]
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_detail.product_variant_id] FOREIGN KEY([product_variant_id])
REFERENCES [dbo].[Product_variants] ([product_variant_id])
GO
ALTER TABLE [dbo].[Order_detail] CHECK CONSTRAINT [FK_Order_detail.product_variant_id]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product.category_id] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([category_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product.category_id]
GO
ALTER TABLE [dbo].[Product_variants]  WITH CHECK ADD FOREIGN KEY([sku_id])
REFERENCES [dbo].[Skus] ([sku_id])
GO
ALTER TABLE [dbo].[Product_variants]  WITH CHECK ADD  CONSTRAINT [FK_Product_variants.product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Product_variants] CHECK CONSTRAINT [FK_Product_variants.product_id]
GO
ALTER TABLE [dbo].[Product_variants_sub_position_relation]  WITH CHECK ADD  CONSTRAINT [FK_Product_variants_sub_position_relation.product_variant_id] FOREIGN KEY([product_variant_id])
REFERENCES [dbo].[Product_variants] ([product_variant_id])
GO
ALTER TABLE [dbo].[Product_variants_sub_position_relation] CHECK CONSTRAINT [FK_Product_variants_sub_position_relation.product_variant_id]
GO
ALTER TABLE [dbo].[Product_variants_sub_position_relation]  WITH CHECK ADD  CONSTRAINT [FK_Product_variants_sub_position_relation.sub_position_id] FOREIGN KEY([sub_position_id])
REFERENCES [dbo].[Sub_position] ([sub_position_id])
GO
ALTER TABLE [dbo].[Product_variants_sub_position_relation] CHECK CONSTRAINT [FK_Product_variants_sub_position_relation.sub_position_id]
GO
ALTER TABLE [dbo].[RolesUsers]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsers_Roles] FOREIGN KEY([RolesID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[RolesUsers] CHECK CONSTRAINT [FK_RolesUsers_Roles]
GO
ALTER TABLE [dbo].[RolesUsers]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[RolesUsers] CHECK CONSTRAINT [FK_RolesUsers_Users]
GO
ALTER TABLE [dbo].[Sub_position]  WITH CHECK ADD  CONSTRAINT [FK_Sub_position.position_id] FOREIGN KEY([position_id])
REFERENCES [dbo].[Positions] ([position_id])
GO
ALTER TABLE [dbo].[Sub_position] CHECK CONSTRAINT [FK_Sub_position.position_id]
GO
USE [master]
GO
ALTER DATABASE [PRN231_BL5] SET  READ_WRITE 
GO
