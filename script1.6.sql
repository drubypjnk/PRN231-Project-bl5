USE [master]
GO
/****** Object:  Database [PRN231_BL5]    Script Date: 19/8/2023 8:48:12 AM ******/
CREATE DATABASE [PRN231_BL5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN231_BL5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRN231_BL5.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN231_BL5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRN231_BL5_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRN231_BL5] SET COMPATIBILITY_LEVEL = 150
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
ALTER DATABASE [PRN231_BL5] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [PRN231_BL5] SET RECOVERY FULL 
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
EXEC sys.sp_db_vardecimal_storage_format N'PRN231_BL5', N'ON'
GO
ALTER DATABASE [PRN231_BL5] SET QUERY_STORE = OFF
GO
USE [PRN231_BL5]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Notes]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Order_detail]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Order_Type]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Positions]    Script Date: 19/8/2023 8:48:12 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Positions_UN] UNIQUE NONCLUSTERED 
(
	[address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 19/8/2023 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NULL,
	[delete_flag] [bit] NULL,
	[product_name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_variants]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Product_variants_sub_position_relation]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Skus]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[Sub_position]    Script Date: 19/8/2023 8:48:12 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 19/8/2023 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [text] NULL,
	[password] [text] NULL,
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
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
ALTER TABLE [dbo].[Sub_position]  WITH CHECK ADD  CONSTRAINT [FK_Sub_position.position_id] FOREIGN KEY([position_id])
REFERENCES [dbo].[Positions] ([position_id])
GO
ALTER TABLE [dbo].[Sub_position] CHECK CONSTRAINT [FK_Sub_position.position_id]
GO
USE [master]
GO
ALTER DATABASE [PRN231_BL5] SET  READ_WRITE 
GO
