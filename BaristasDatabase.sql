USE [master]
GO
/****** Object:  Database [Baristas]    Script Date: 6/23/2020 1:27:10 PM ******/
CREATE DATABASE [Baristas]
GO

ALTER DATABASE [Baristas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Baristas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Baristas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Baristas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Baristas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Baristas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Baristas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Baristas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Baristas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Baristas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Baristas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Baristas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Baristas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Baristas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Baristas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Baristas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Baristas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Baristas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Baristas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Baristas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Baristas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Baristas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Baristas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Baristas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Baristas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Baristas] SET  MULTI_USER 
GO
ALTER DATABASE [Baristas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Baristas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Baristas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Baristas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Baristas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Baristas]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutUs](
	[AboutUsID] [int] IDENTITY(1,1) NOT NULL,
	[OurStory] [nvarchar](250) NULL,
	[OurStoryImage] [nvarchar](max) NULL,
	[OurVision1] [nvarchar](250) NULL,
	[OurVision2] [nvarchar](250) NULL,
	[OurVision3] [nvarchar](250) NULL,
	[OurVision4] [nvarchar](250) NULL,
	[OurMenu] [nvarchar](250) NULL,
	[OurMenuImage1] [nvarchar](max) NULL,
	[OurMenuImage2] [nvarchar](max) NULL,
	[OurMenuImage3] [nvarchar](max) NULL,
	[OurMenuImage4] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AboutUsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeID] [int] NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[CustomerName] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeName] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[CreatedDate] [date] NULL DEFAULT (getdate()),
	[Total] [decimal](18, 0) NULL,
	[Discount] [float] NULL,
	[TotalDiscount] [decimal](18, 0) NULL,
	[Noted] [nvarchar](max) NULL,
	[CustomerName] [nvarchar](250) NULL,
	[CustomerPhoneNumber] [nvarchar](250) NULL,
	[ShippingAddress] [nvarchar](250) NULL,
	[IsPaid] [bit] NULL,
	[PaymentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillDetails]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetails](
	[BillDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[BillID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookingTable]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingTable](
	[BookingTableID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
	[NumberCustomer] [int] NULL,
	[BookingDate] [date] NULL,
	[BookingTime] [time](7) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[ProductID] [int] NULL,
	[NewsID] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[PostDate] [date] NULL,
	[RootCommentID] [int] NULL,
	[ReplyCommentToID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Discount]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountCode] [nvarchar](250) NULL,
	[DiscountPercent] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[FeedBackID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Age] [nvarchar](250) NULL,
	[Job] [nvarchar](250) NULL,
	[Another] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedBackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Footer]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[FooterID] [int] IDENTITY(1,1) NOT NULL,
	[OpenTime1] [nvarchar](250) NULL,
	[OpenTime2] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[FacebookLink] [nvarchar](max) NULL,
	[InstaLink] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[FooterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HaveSize]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HaveSize](
	[HaveSizeID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[ProductSizeID] [int] NULL,
	[Prices] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[HaveSizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HomePageContent]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePageContent](
	[HomePageContentID] [int] IDENTITY(1,1) NOT NULL,
	[StoreContent] [nvarchar](max) NULL,
	[StoreImage] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[HomePageContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HomePageSilder]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePageSilder](
	[SilderID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[DisplayOrder] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SilderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[NewsCateID] [int] NULL,
	[NewsName] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[CreatedDate] [date] NULL DEFAULT (getdate()),
	[CreatedBy] [nvarchar](250) NULL,
	[ModifyDate] [date] NULL,
	[ModifyBy] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsCategory]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsCategory](
	[NewsCateID] [int] IDENTITY(1,1) NOT NULL,
	[NewsCateName] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL DEFAULT (getdate()),
	[CreatedBy] [nvarchar](250) NULL,
	[ModifyDate] [date] NULL,
	[ModifyBy] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentStatus] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductCateID] [int] NULL,
	[ProductName] [nvarchar](250) NULL,
	[Discount] [float] NULL,
	[Description] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[CreatedDate] [date] NULL DEFAULT (getdate()),
	[CreatedBy] [nvarchar](250) NULL,
	[ModifyDate] [date] NULL,
	[ModifyBy] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCateID] [int] IDENTITY(1,1) NOT NULL,
	[CateName] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL DEFAULT (getdate()),
	[CreatedBy] [nvarchar](250) NULL,
	[ModifyDate] [date] NULL,
	[ModifyBy] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSize]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSize](
	[ProductSizeID] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL DEFAULT (getdate()),
	[CreatedBy] [nvarchar](250) NULL,
	[ModifyDate] [date] NULL,
	[ModifyBy] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductSizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rating]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[ProductID] [int] NULL,
	[NumberStar] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagsID] [int] IDENTITY(1,1) NOT NULL,
	[TagsName] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[TagsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagsNews]    Script Date: 6/23/2020 1:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsNews](
	[TagsID] [int] NULL,
	[NewsID] [int] NULL,
	[TagsNewsID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TagsNewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [AccountTypeID], [UserName], [Password], [Email], [CustomerName], [Address], [Phone]) VALUES (1, 1, N'admin', N'123456', NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([AccountID], [AccountTypeID], [UserName], [Password], [Email], [CustomerName], [Address], [Phone]) VALUES (2, 2, N'thaihoa', N'123456', N'thaihoa@gmail.com', N'Nguyễn Thái Hoà', N'1 Lê Duẩn, Q.1, TP.HCM', N'012345678')
INSERT [dbo].[Account] ([AccountID], [AccountTypeID], [UserName], [Password], [Email], [CustomerName], [Address], [Phone]) VALUES (3, 2, N'duythien', N'098765', N'duythien@gmail.com', N'Đỗ Duy Thiện', N'10 Phan Văn Trị, Quận Bình Thạnh, TP Hồ Chí Minh', N'023456789')
INSERT [dbo].[Account] ([AccountID], [AccountTypeID], [UserName], [Password], [Email], [CustomerName], [Address], [Phone]) VALUES (4, 2, N'ngoclong', N'ngoclong123', N'ngoclong@gmail.com', N'Nguyễn Ngọc Long', N'45 Phạm Văn Đồng, Quận Gò Vấp, TP.HCM', N'034567891')
INSERT [dbo].[Account] ([AccountID], [AccountTypeID], [UserName], [Password], [Email], [CustomerName], [Address], [Phone]) VALUES (5, 2, N'khaihoan123', N'hoan234', N'khaihoan@gmail.com', N'Trần Khải Hoàn', N'10 Nơ Trang Long, Quận Bình Thạnh, Tp.HCM', N'056789123')
INSERT [dbo].[Account] ([AccountID], [AccountTypeID], [UserName], [Password], [Email], [CustomerName], [Address], [Phone]) VALUES (6, 2, N'lanvy99', N'@Vy12', N'lanvy@gmail.com', N'Đỗ Huỳnh Lan Vy', N'20 Đinh Tiên Hoàng, Quận 1, TP.HCM', N'078912345')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName]) VALUES (1, N'Admin')
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillID], [AccountID], [CreatedDate], [Total], [Discount], [TotalDiscount], [Noted], [CustomerName], [CustomerPhoneNumber], [ShippingAddress], [IsPaid], [PaymentID]) VALUES (1, 2, CAST(N'2020-06-15' AS Date), CAST(90000 AS Decimal(18, 0)), 1, CAST(90000 AS Decimal(18, 0)), NULL, N'asd', N'123123', N'123123123123', 0, 2)
INSERT [dbo].[Bill] ([BillID], [AccountID], [CreatedDate], [Total], [Discount], [TotalDiscount], [Noted], [CustomerName], [CustomerPhoneNumber], [ShippingAddress], [IsPaid], [PaymentID]) VALUES (2, 2, CAST(N'2020-06-19' AS Date), CAST(23200 AS Decimal(18, 0)), NULL, CAST(23200 AS Decimal(18, 0)), N'gbjjnyjmujgyfgg', N'Nguyễn Văn A', N'11', N'123123 asdasd', 0, 2)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillDetails] ON 

INSERT [dbo].[BillDetails] ([BillDetailID], [ProductID], [BillID], [Quantity]) VALUES (1, 4, 1, 2)
INSERT [dbo].[BillDetails] ([BillDetailID], [ProductID], [BillID], [Quantity]) VALUES (2, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[BillDetails] OFF
SET IDENTITY_INSERT [dbo].[BookingTable] ON 

INSERT [dbo].[BookingTable] ([BookingTableID], [CustomerName], [Phone], [NumberCustomer], [BookingDate], [BookingTime], [IsActive]) VALUES (1, N'Nguyễn Văn A', N'11', 1, CAST(N'2020-06-20' AS Date), CAST(N'06:17:00' AS Time), 0)
INSERT [dbo].[BookingTable] ([BookingTableID], [CustomerName], [Phone], [NumberCustomer], [BookingDate], [BookingTime], [IsActive]) VALUES (2, N'Nguyễn Thái Hoà', N'12312313', 12, CAST(N'2020-06-25' AS Date), CAST(N'17:43:00' AS Time), 0)
INSERT [dbo].[BookingTable] ([BookingTableID], [CustomerName], [Phone], [NumberCustomer], [BookingDate], [BookingTime], [IsActive]) VALUES (3, N'Nguyễn Thái Hoà', N'12312312', 12, CAST(N'2020-06-22' AS Date), CAST(N'20:59:00' AS Time), 0)
SET IDENTITY_INSERT [dbo].[BookingTable] OFF
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([DiscountID], [DiscountCode], [DiscountPercent]) VALUES (1, N'GIAMGIA10', 0.1)
INSERT [dbo].[Discount] ([DiscountID], [DiscountCode], [DiscountPercent]) VALUES (2, N'GIAMGIA20', 0.2)
INSERT [dbo].[Discount] ([DiscountID], [DiscountCode], [DiscountPercent]) VALUES (3, N'GIAMGIA15', 0.3)
SET IDENTITY_INSERT [dbo].[Discount] OFF
SET IDENTITY_INSERT [dbo].[HaveSize] ON 

INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (6, 1, 1, CAST(29000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (7, 1, 2, CAST(35000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (8, 1, 3, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (9, 2, 1, CAST(35000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (10, 2, 2, CAST(42000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (11, 2, 3, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (12, 3, 1, CAST(29000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (13, 3, 2, CAST(35000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (14, 3, 3, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (15, 4, 1, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (16, 4, 2, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (17, 4, 3, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (18, 5, 1, CAST(37000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (19, 5, 2, CAST(44000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (20, 5, 3, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (21, 6, 1, CAST(52000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (22, 6, 2, CAST(57000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (23, 6, 3, CAST(65000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (24, 7, 1, CAST(52000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (25, 7, 2, CAST(58000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (26, 7, 3, CAST(65000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (27, 8, 1, CAST(52000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (28, 8, 2, CAST(59000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (29, 8, 3, CAST(65000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (30, 9, 1, CAST(35000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (31, 9, 2, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (32, 9, 3, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (33, 10, 1, CAST(35000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (34, 10, 2, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (35, 10, 3, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (36, 11, 1, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (37, 11, 2, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (38, 11, 3, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (39, 12, 1, CAST(39000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (40, 12, 2, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (41, 12, 3, CAST(52000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (42, 13, 1, CAST(39000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (43, 13, 2, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (44, 13, 3, CAST(52000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (45, 14, 1, CAST(39000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (46, 14, 2, CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[HaveSize] ([HaveSizeID], [ProductID], [ProductSizeID], [Prices]) VALUES (47, 14, 3, CAST(52000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[HaveSize] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsID], [NewsCateID], [NewsName], [Content], [Image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (1, 1, N'Khai Trương Quán, Khuyến mãi tưng bừng', N'Ngày 23/12 này, Seoul Garden tại 33 Trần Hưng Đạo, Hà Nội sẽ khai trương với không gian ẩm thực sang trọng và chất lượng dịch vụ đẳng cấp mới.

Nếu như thực khách đã quen thuộc với phong cách tươi sáng, đơn giản và trang nhã tại các nhà hàng của Seoul Garden (Vincom center, The Garden, Nam Kỳ Khởi Nghĩa), thì nhà hàng mới sẽ là làn gió thổi sức sống mới cho thương hiệu nhờ vẻ tinh tế, hiện đại. Không gian bắt mắt với sắc đỏ, nâu làm chủ đạo và các hoa văn tinh tế tại mỗi góc nhà hàng sẽ làm bữa ăn của thực khách thêm ngon miệng. Thêm vào đó, nhà hàng có riêng một khu vực quầy bar phong cách và cá tính, phục vụ các loại rượu và các loại bia tươi, tạo ra không gian đẳng cấp cho thực khách, đặc biệt là các doanh nhân và các bạn trẻ ưa khám phá. Tại đây, thực khách có thể tìm thấy hàng trăm món ăn hảo hạng thay đổi theo ngày, theo mùa của nhiều quốc gia trong khu vực. Nhà hàng có rất nhiều món ăn như ba chỉ bò Mỹ sốt tiêu đen, thịt heo sốt Teriyaki (Nhật Bản); gà sốt Tomyum (Thái Lan), gà sốt Bulgogi (Hàn Quốc), gà Curry (Malaysia), cá hồi, đà điểu, hải sâm… được chế biến từ nguyên liệu nhập khẩu tươi và sạch. Ngoài các món nướng, thực khách có thể chọn một trong số các loại lẩu như: lẩu Thái chua cay, lẩu kim chi cay nhẹ, lẩu Tomyum không cay… để bữa ăn được trọn vị, thêm ngon.

Bên cạnh đó, thực khách còn được thưởng thức các món ăn quen thuộc của Việt Nam như: bún riêu, bánh cuốn, bánh đúc… và một số món đặc trưng như pizza của Italy, sushi và sashimi của Nhật. Nhân dịp nhà hàng 33 Trần Hưng Đạo khai trương, nhóm từ 3 người trở lên sẽ được tặng thăn lưng bò Mỹ nướng tảng. Với mô hình mới, thực khách có thể ngồi tại bàn chọn món, nhân viên sẽ mang và phục vụ tại bàn ăn cho thực khách.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[News] ([NewsID], [NewsCateID], [NewsName], [Content], [Image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (2, 2, N'Khuyến mãi toàn bộ menu', N'Nằm ở vị trí đắc địa, có không gian rộng rãi lên đến 750 m2 và được thiết kế theo phong cách sân vườn hiện đại, quán cà phê kết hợp giữa anh Nguyễn Ngọc Sang và thương hiệu Ông Bầu chính là địa điểm lý tưởng để thực khách đến thưởng thức cà phê, check-in, giải trí… Chị Lan Anh, một vị khách có mặt trong ngày khai trương cà phê Ông Bầu tại Bình Dương cho hay: “Chúng tôi nghe nói về cà phê Ông Bầu từ mấy tháng trước nhưng chưa có dịp thưởng thức do các quán ở xa quá. Nhưng nay cà phê Ông Bầu lại bất ngờ xuất hiện ở Bình Dương, tôi đưa cả nhà đến đây để uống thử xem cà phê có thật như quảng cáo hay không. Không ngờ, cà phê của các ông bầu rất thật, rất chất mà quán lại quá đẹp…”. Nhập mã GIAMGIA10 để được giảm giá 10', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[NewsCategory] ON 

INSERT [dbo].[NewsCategory] ([NewsCateID], [NewsCateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (1, N'Tin tức', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[NewsCategory] ([NewsCateID], [NewsCateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (2, N'Khuyến mãi', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[NewsCategory] ([NewsCateID], [NewsCateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (3, N'Chia sẻ', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[NewsCategory] ([NewsCateID], [NewsCateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (4, N'Cộng đồng', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[NewsCategory] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentID], [PaymentStatus]) VALUES (1, N'Offline')
INSERT [dbo].[Payment] ([PaymentID], [PaymentStatus]) VALUES (2, N'Online')
INSERT [dbo].[Payment] ([PaymentID], [PaymentStatus]) VALUES (3, N'MoMo')
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (1, 1, N'Cà phê đen', 0.2, N'Cà phê (bắt nguồn từ từ tiếng Pháp café /kafe/)[2] là một loại thức uống được ủ từ hạt cà phê rang, lấy từ quả của cây cà phê. Các giống cây cà phê được bắt nguồn từ vùng nhiệt đới châu Phi và các vùng Madagascar, Comoros, Mauritius và Réunion trên Ấn Độ Dương.[3] Giống cây này được xuất khẩu từ châu Phi tới các nước trên thế giới và hiện nay đã được trồng tại tổng cộng hơn 70 quốc gia, chủ yếu là các khu vực nằm gần đường xích đạo thuộc châu Mỹ, Đông Nam Á, Ấn Độ và châu Phi. Hai giống cà phê được trồng phổ biến nhất là cà phê chè, và cà phê vối. Sau khi chín, quả cà phê sẽ được hái, chế biến và phơi khô. Hạt cà phê khô sẽ được rang trong nhiều điều kiện nhiệt độ khác nhau, tùy thuộc vào nhu cầu thị hiếu. Hạt cà phê sau khi rang sẽ được đem đi xay và ủ với nước sôi để tạo ra cà phê dưới dạng thức uống.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (2, 1, N'Cà phê sữa', 0.15, N'Cà phê sữa đá pha theo phong cách Việt Nam gồm cà phê rang xay được pha phin hay pha sẵn, sữa đặc có đường (thông dụng là sữa Ông Thọ) theo tỷ lệ một phần nước cà phê, 1 hoặc hai phần sữa tùy theo khẩu vị của người uống. Cà phê sữa này được uống chung với nhiều nước đá. Món cà phê sữa đá cùng với cà phê đen đá là hai loại thức uống từ cà phê phổ biến tại các quán cà phê cũng như tại gia đình ở Việt Nam.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (3, 1, N'Bạc xỉu', 0.25, N'​Chữ “bạc xỉu” là gọi tắt của cụm từ “bạc tẩy xỉu phé”, đây là tiếng người Tàu khá phổ thông sống ở Sài Gòn. Bạc là màu trắng, tẩy là ly không, xỉu là một tí, phé là cà phê. Nói một cách rõ ràng và sát nghĩa hơn thì đó là: Sữa nóng thêm chút cà phê.
​
Sữa đặc pha với nước sôi hơi béo quá và có mùi hơi khó uống nên những người Hoa đó đã thêm một chút cà phê vào cho cốc sữa dậy mùi cà phê và át đi mùi của sữa đặc. Dần dà những người khách Việt quen dần với món ăn và cách gọi đó, từ đó dùng luôn cách gọi đó đặt tên cho món ăn trở thành một trào lưu sau này', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (4, 1, N'Cappuccino
', 0.1, N'Cappuccino là một cách pha chế cà phê của Ý. Một cà phê cappuccino bao gồm ba phần đều nhau: cà phê espresso pha với một lượng nước gấp đôi, sữa nóng và sữa sủi bọt. Để hoàn thiện khẩu vị, người ta thường rải lên trên tách cà phê cappuccino là bột ca cao và/hay bột quế.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (5, 1, N'Espresso', 0.1, N'Espresso, là một phương pháp pha cà phê có nguồn gốc từ Ý, trong đó một lượng nhỏ nước sôi gần như bị đè dưới áp lực qua hạt cà phê nghiền. Espresso cũng là nền tảng cho nhiều loại đồ uống từ cà phê khác như cà phê latte, cappuccino, macchiato, cà phê mocha, flat white và Americano.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (6, 2, N'Đá Xay Oreo', 0, N'Đá xay oreo là một trong các loại thức uống đá xay được giới trẻ yêu thích hiện nay. ', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (7, 2, N'Đá Xay Việt Quốc', 0.4, N'Việt quất là loại quả có vị chua nhẹ nhưng mang đến nhiều công dụng tuyệt vời cho sức khỏe như chống lão hóa da, bổ sung vitamin cần thiết cho cơ thể. Món đá xay việt quất là một trong các loại nước uống đá xay giúp giải nhiệt cơn khát mùa hè, là sự kết hợp giữa vị chua cùng sữa tươi béo ngậy.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (8, 2, N'Bạc Hà Đá Xay', 0.35, N'Bạc hà với hương vị the mát sảng khoái là nguyên liệu không thể thiếu trong các món đồ uống bán chạy nhất mùa hè và bạc hà đá xay cũng vậy, luôn là món đồ uống giải khát giải nóng trong các loại nước uống đá xay cực kỳ được ưa chuộng.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (9, 3, N'Yogurt Việt Quất', 0, N'Yogurt (sữa chua) là loại thực phẩm rất tốt cho hệ tiêu hóa và có tác dụng làm đẹp da, được rất nhiều chị em phụ nữ yêu thích. Với cách kết hợp cùng cocktail trái cây nhiệt đới và sốt việt quất lần này, ly sữa chua đá nhà bạn sẽ không những ngon miệng mà còn ngon mắt, hấp dẫn hơn rất nhiều.

', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (10, 3, N'Yogurt Thạch Hoa quả', 0.1, N'Yogurt (sữa chua) là loại thực phẩm rất tốt cho hệ tiêu hóa và có tác dụng làm đẹp da, được rất nhiều chị em phụ nữ yêu thích. Với cách kết hợp cùng cocktail trái cây nhiệt đới và sốt việt quất lần này, ly sữa chua đá nhà bạn sẽ không những ngon miệng mà còn ngon mắt, hấp dẫn hơn rất nhiều.

', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (11, 3, N'Yougurt Cam Tươi', 0.2, N'Yogurt Cam tươi là sự kết hợp hài hoà giữa sưa chua và cam tươi, là một sản phẩm giải khát cũng như bổ sung rất nhei62u  vitamin C không thể bỏ qua trong những ngày hè oi bức', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (12, 4, N'Nước ép Táo', 0, N'Nước táo là một loại đồ uống hình thành do ép trái táo tây. Từ 1,5 kg táo tây có thể vắt được một lít nước táo. Bên Đức ngoài nước táo tinh chất người ta còn hay uống nước táo pha với nước suối. Vào năm 2011 trung bình tại Đức mỗi người uống 8,0 lít nước táo nguyên chất và 9,4 lít nước táo pha với nước suối.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (13, 4, N'Nước ép Thơm', 0.15, N'Mùa hè nắng nóng, có một ly nước ép dứa mát lạnh để thưởng thức thì không còn gì tuyệt vời bằng, vừa giải khát lại đẹp da, vừa giảm cân hiệu quả lại cực kỳ tốt cho sức khỏe. Làm nước ép dứa không quá cầu kỳ như các loại nước khác, chỉ cần bỏ ra chút ít thời gian là bạn đã có được những ly thức uống thơm ngon, bổ dưỡng rồi.', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [ProductCateID], [ProductName], [Discount], [Description], [image], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (14, 4, N'Nước ép dưa hấu', 0, N'Nước ép dưa hấu là sự lựa chọn tuyệt vời cho những ai cần giải khát vào những ngày hè oi bức. Nước ép dưa hấu ngoài lợi ích giải khát còn cung cấp cho cơ thể nhiều vitamin và các dưỡng chất cần thiết.
', NULL, CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProductCateID], [CateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (1, N'Cà phê', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[ProductCategory] ([ProductCateID], [CateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (2, N'Đá xay', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[ProductCategory] ([ProductCateID], [CateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (3, N'Yogurt', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[ProductCategory] ([ProductCateID], [CateName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (4, N'Juice', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[ProductSize] ON 

INSERT [dbo].[ProductSize] ([ProductSizeID], [SizeName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (1, N'S', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[ProductSize] ([ProductSizeID], [SizeName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (2, N'M', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
INSERT [dbo].[ProductSize] ([ProductSizeID], [SizeName], [CreatedDate], [CreatedBy], [ModifyDate], [ModifyBy], [IsActive]) VALUES (3, N'L', CAST(N'2020-06-07' AS Date), N'admin', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[ProductSize] OFF
SET IDENTITY_INSERT [dbo].[Rating] ON 

INSERT [dbo].[Rating] ([RatingID], [AccountID], [ProductID], [NumberStar]) VALUES (1, 2, 1, 3)
INSERT [dbo].[Rating] ([RatingID], [AccountID], [ProductID], [NumberStar]) VALUES (2, 2, 2, 5)
INSERT [dbo].[Rating] ([RatingID], [AccountID], [ProductID], [NumberStar]) VALUES (3, 2, 1, 5)
SET IDENTITY_INSERT [dbo].[Rating] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([TagsID], [TagsName]) VALUES (1, N'KHUYENMAI')
INSERT [dbo].[Tags] ([TagsID], [TagsName]) VALUES (2, N'CAFENGON')
INSERT [dbo].[Tags] ([TagsID], [TagsName]) VALUES (3, N'DONGHANHCUNGBARISTA')
INSERT [dbo].[Tags] ([TagsID], [TagsName]) VALUES (4, N'BARISTA')
INSERT [dbo].[Tags] ([TagsID], [TagsName]) VALUES (5, N'KHUYENMAITUNGBUNG')
INSERT [dbo].[Tags] ([TagsID], [TagsName]) VALUES (6, N'KHUYENMAI10')
SET IDENTITY_INSERT [dbo].[Tags] OFF
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (getdate()) FOR [PostDate]
GO
ALTER TABLE [dbo].[HomePageSilder] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_PayMent] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_PayMent]
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([BillID])
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([NewsID])
REFERENCES [dbo].[News] ([NewsID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([ReplyCommentToID])
REFERENCES [dbo].[Comment] ([CommentID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([RootCommentID])
REFERENCES [dbo].[Comment] ([CommentID])
GO
ALTER TABLE [dbo].[HaveSize]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[HaveSize]  WITH CHECK ADD FOREIGN KEY([ProductSizeID])
REFERENCES [dbo].[ProductSize] ([ProductSizeID])
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD FOREIGN KEY([NewsCateID])
REFERENCES [dbo].[NewsCategory] ([NewsCateID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([ProductCateID])
REFERENCES [dbo].[ProductCategory] ([ProductCateID])
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[TagsNews]  WITH CHECK ADD FOREIGN KEY([NewsID])
REFERENCES [dbo].[News] ([NewsID])
GO
ALTER TABLE [dbo].[TagsNews]  WITH CHECK ADD FOREIGN KEY([TagsID])
REFERENCES [dbo].[Tags] ([TagsID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [chk_bill_discount] CHECK  (([Discount]>=(0.1) AND [Discount]<=(1)))
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [chk_bill_discount]
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD  CONSTRAINT [chk_discount] CHECK  (([DiscountPercent]>=(0.1) AND [DiscountPercent]<=(1)))
GO
ALTER TABLE [dbo].[Discount] CHECK CONSTRAINT [chk_discount]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [chk_rating] CHECK  (([NumberStar]>=(0) AND [NumberStar]<=(5)))
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [chk_rating]
GO
USE [master]
GO
ALTER DATABASE [Baristas] SET  READ_WRITE 
GO
