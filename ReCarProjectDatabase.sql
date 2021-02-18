USE [master]
GO
/****** Object:  Database [ReCarProjectDatabase]    Script Date: 18.02.2021 21:51:06 ******/
CREATE DATABASE [ReCarProjectDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReCarProjectDatabase', FILENAME = N'C:\Users\Pc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ReCarProjectDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReCarProjectDatabase_log', FILENAME = N'C:\Users\Pc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ReCarProjectDatabase.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReCarProjectDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReCarProjectDatabase] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET ANSI_NULLS ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET ANSI_PADDING ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET ARITHABORT ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [ReCarProjectDatabase] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [ReCarProjectDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReCarProjectDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReCarProjectDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [ReCarProjectDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [ReCarProjectDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReCarProjectDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReCarProjectDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReCarProjectDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReCarProjectDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ReCarProjectDatabase]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 18.02.2021 21:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] NOT NULL,
	[BrandName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cars]    Script Date: 18.02.2021 21:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NULL,
	[DailyPrice] [decimal](18, 0) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Colors]    Script Date: 18.02.2021 21:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] NOT NULL,
	[ColorName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Costumers]    Script Date: 18.02.2021 21:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Costumers](
	[Id] [int] NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 18.02.2021 21:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[RentDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.02.2021 21:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [ReCarProjectDatabase] SET  READ_WRITE 
GO
