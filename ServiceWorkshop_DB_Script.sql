--USE [master]
--GO
--/****** Object:  Database [ServiceWorkshop]    Script Date: 2/6/2022 5:12:58 PM ******/
--CREATE DATABASE [ServiceWorkshop]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'ServiceWorkshop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ServiceWorkshop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'ServiceWorkshop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ServiceWorkshop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
--GO

USE [ServiceWorkshop]
GO
ALTER DATABASE [ServiceWorkshop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServiceWorkshop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServiceWorkshop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServiceWorkshop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServiceWorkshop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ServiceWorkshop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServiceWorkshop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET RECOVERY FULL 
GO
ALTER DATABASE [ServiceWorkshop] SET  MULTI_USER 
GO
ALTER DATABASE [ServiceWorkshop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServiceWorkshop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServiceWorkshop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServiceWorkshop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ServiceWorkshop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ServiceWorkshop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ServiceWorkshop', N'ON'
GO
ALTER DATABASE [ServiceWorkshop] SET QUERY_STORE = OFF
GO
USE [ServiceWorkshop]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 2/6/2022 5:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingID] [uniqueidentifier] NOT NULL,
	[CustomerID] [uniqueidentifier] NOT NULL,
	[VehicleID] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/6/2022 5:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[DateAdded] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 2/6/2022 5:12:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [uniqueidentifier] NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[RegNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bookings] ([BookingID], [CustomerID], [VehicleID], [Date], [Notes]) VALUES (N'38c8a5dd-d614-40b0-2cb0-08d9e9812132', N'eb17f8af-2566-4702-8111-66ad9fd3166f', N'69270688-3606-4d5a-216b-08d9e97c4606', CAST(N'2022-03-03T16:57:39.0000000' AS DateTime2), N'Booking for Mark on the 3rd of March')
INSERT [dbo].[Bookings] ([BookingID], [CustomerID], [VehicleID], [Date], [Notes]) VALUES (N'4726dd8e-6b6a-4dff-bab4-2835638f4cf6', N'2c0f4195-9f6c-4742-aa99-4c5f4c1d12ab', N'902936af-8906-448a-a5e8-32f968ddc3e7', CAST(N'2022-02-03T17:55:50.8500000' AS DateTime2), N'Ford Booking')
INSERT [dbo].[Bookings] ([BookingID], [CustomerID], [VehicleID], [Date], [Notes]) VALUES (N'e2b98530-df96-49c1-99c7-3cdf975f7998', N'2c0f4195-9f6c-4742-aa99-4c5f4c1d12ab', N'0e7fb085-780d-4145-9a4e-a56ec0a069a6', CAST(N'2022-02-03T17:55:50.8500000' AS DateTime2), N'Toyota Booking')
INSERT [dbo].[Bookings] ([BookingID], [CustomerID], [VehicleID], [Date], [Notes]) VALUES (N'dd995c43-106e-4fe5-9002-5df597186916', N'd304b0ec-6414-4591-a9da-6389091dc2e9', N'dd83ba55-e391-4ff7-9f04-b995e45e5993', CAST(N'2022-02-24T17:55:50.0000000' AS DateTime2), N'BMW booking updated booking date')
INSERT [dbo].[Bookings] ([BookingID], [CustomerID], [VehicleID], [Date], [Notes]) VALUES (N'46ba3422-1437-4e92-ac2e-a268acbe4d0f', N'4fbb183f-0f15-496d-f3ae-08d9e7db6b36', N'5c978777-b865-46e2-872e-f2f936ed5fd0', CAST(N'2022-02-03T17:57:41.0000000' AS DateTime2), N'Toyota Booking1 updates')
INSERT [dbo].[Bookings] ([BookingID], [CustomerID], [VehicleID], [Date], [Notes]) VALUES (N'ff6e0222-3a3a-496f-91e8-f56b730f6280', N'4fbb183f-0f15-496d-f3ae-08d9e7db6b36', N'5c978777-b865-46e2-872e-f2f936ed5fd0', CAST(N'2022-02-03T17:57:41.0000000' AS DateTime2), N'Toyota Booking2 updating again')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'4fbb183f-0f15-496d-f3ae-08d9e7db6b36', N'Michael', N'Lubbe', N'9999999999', CAST(N'2022-02-04T14:39:38.3436370' AS DateTime2), NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'd0d7a28c-ef7c-4c85-c335-08d9e7fedd75', N'test', N'test', N'2332222', CAST(N'2022-02-04T18:57:22.1482165' AS DateTime2), NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'2c0f4195-9f6c-4742-aa99-4c5f4c1d12ab', N'Estra', N'Crouse', N'0732754345', CAST(N'2022-02-03T14:01:30.7200000' AS DateTime2), NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'd304b0ec-6414-4591-a9da-6389091dc2e9', N'Mandie', N'Campher', N'7898787799', CAST(N'2022-02-03T14:01:54.2500000' AS DateTime2), CAST(N'2022-02-04T18:54:28.1781536' AS DateTime2))
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'eb17f8af-2566-4702-8111-66ad9fd3166f', N'Mark', N'Potgieter', N'0728452342', CAST(N'2022-02-03T14:01:30.7200000' AS DateTime2), NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'800280f5-1b4c-4b6b-8c05-9a3f91fd9de7', N'Andrew', N'Small', N'0843243453', CAST(N'2022-02-03T14:01:30.7133333' AS DateTime2), NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Surname], [ContactNumber], [DateAdded], [DateUpdated]) VALUES (N'692973b9-82bd-4366-ac6e-ade5ed31b40c', N'Jane', N'Woodburn', N'083254323', CAST(N'2022-02-03T14:01:30.7200000' AS DateTime2), NULL)
GO
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'd8726757-dfbe-40b2-ee3f-08d9e872724f', N'A4', N'Audi', N'CA 234565')
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'69270688-3606-4d5a-216b-08d9e97c4606', N'Escort', N'Ford', N'JHT234GP')
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'902936af-8906-448a-a5e8-32f968ddc3e7', N'Eco Sport', N'Ford', N'NP 5432323')
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'0e7fb085-780d-4145-9a4e-a56ec0a069a6', N'Conquest', N'Toyota', N'HTY 555 GP')
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'dd83ba55-e391-4ff7-9f04-b995e45e5993', N'3 Series', N'BMW', N'CA 234432')
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'6fc36d5e-1f16-464d-8e8f-c69efc6479ad', N'5 Series', N'BMW', N'CAA 123456')
INSERT [dbo].[Vehicles] ([VehicleID], [Model], [Make], [RegNumber]) VALUES (N'5c978777-b865-46e2-872e-f2f936ed5fd0', N'RAV4', N'Toyota', N'MNT 234 GP')
GO
USE [master]
GO
ALTER DATABASE [ServiceWorkshop] SET  READ_WRITE 
GO
