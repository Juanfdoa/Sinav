/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2022 (16.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2022
    Target Database Engine Edition : Microsoft SQL Server Express Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Sinav]    Script Date: 29/09/2023 2:01:05 p. m. ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Sinav')
BEGIN
CREATE DATABASE [Sinav]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sinav', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Sinav.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sinav_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Sinav_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Modern_Spanish_CI_AS
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
END
GO
ALTER DATABASE [Sinav] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sinav].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sinav] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sinav] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sinav] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sinav] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sinav] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sinav] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Sinav] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sinav] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sinav] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sinav] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sinav] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sinav] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sinav] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sinav] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sinav] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Sinav] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sinav] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sinav] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sinav] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sinav] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sinav] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Sinav] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sinav] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sinav] SET  MULTI_USER 
GO
ALTER DATABASE [Sinav] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sinav] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sinav] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sinav] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sinav] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sinav] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Sinav] SET QUERY_STORE = ON
GO
ALTER DATABASE [Sinav] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Sinav]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/09/2023 2:01:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoleClaims]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[ClaimType] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[ClaimValue] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Name] [nvarchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[NormalizedName] [nvarchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[ConcurrencyStamp] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[ClaimType] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[ClaimValue] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[ProviderKey] [nvarchar](128) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[ProviderDisplayName] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[UserId] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[RoleId] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[UserName] [nvarchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[NormalizedUserName] [nvarchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[Email] [nvarchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[NormalizedEmail] [nvarchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[SecurityStamp] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[ConcurrencyStamp] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[PhoneNumber] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserTokens]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[LoginProvider] [nvarchar](128) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Name] [nvarchar](128) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Value] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblAllergy]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblAllergy]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblAllergy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Description] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TblAllergy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblAllergyUser]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblAllergyUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblAllergyUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AllergyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Observations] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TblAllergyUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblDisease]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblDisease]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblDisease](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Description] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TblDisease] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblDiseaseUser]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblDiseaseUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblDiseaseUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseId] [int] NOT NULL,
	[UserId] [int] NULL,
	[Observations] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TblDiseaseUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblNews]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblNews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Description] [varchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[ImageUrl] [varchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[Status] [bit] NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblPQRS]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPQRS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblPQRS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Email] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Category] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Message] [varchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[IsRead] [bit] NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TblPQRS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblSlider]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblSlider]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblSlider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Status] [bit] NULL,
	[ImageUrl] [varchar](max) COLLATE Modern_Spanish_CI_AS NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TblSlider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblSupplier]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblSupplier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblSupplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Nit] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Phone] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Address] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Email] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TblSupplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Surname] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[DocumentType] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[DocumentNumber] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Gender] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Address] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Phone] [nvarchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Birthdate] [datetime2](7) NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblVaccine]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblVaccine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblVaccine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Description] [nvarchar](max) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_TblVaccine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TblVaccineUser]    Script Date: 29/09/2023 2:01:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblVaccineUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblVaccineUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VaccineId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Dose] [int] NOT NULL,
	[Rate] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Active] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TblVaccineUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoleClaims]') AND name = N'IX_AspNetRoleClaims_RoleId')
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND name = N'RoleNameIndex')
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND name = N'IX_AspNetUserClaims_UserId')
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND name = N'IX_AspNetUserLogins_UserId')
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND name = N'IX_AspNetUserRoles_RoleId')
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND name = N'EmailIndex')
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND name = N'UserNameIndex')
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblVaccine_SupplierId]    Script Date: 29/09/2023 2:01:06 p. m. ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TblVaccine]') AND name = N'IX_TblVaccine_SupplierId')
CREATE NONCLUSTERED INDEX [IX_TblVaccine_SupplierId] ON [dbo].[TblVaccine]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetRoleClaims_AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetRoleClaims]'))
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetRoleClaims_AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetRoleClaims]'))
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserClaims_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserClaims_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserLogins_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserLogins_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserTokens_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserTokens]'))
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AspNetUserTokens_AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserTokens]'))
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblAllergyUser_TblAllergy1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblAllergyUser]'))
ALTER TABLE [dbo].[TblAllergyUser]  WITH CHECK ADD  CONSTRAINT [FK_TblAllergyUser_TblAllergy1] FOREIGN KEY([AllergyId])
REFERENCES [dbo].[TblAllergy] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblAllergyUser_TblAllergy1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblAllergyUser]'))
ALTER TABLE [dbo].[TblAllergyUser] CHECK CONSTRAINT [FK_TblAllergyUser_TblAllergy1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblAllergyUser_TblUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblAllergyUser]'))
ALTER TABLE [dbo].[TblAllergyUser]  WITH CHECK ADD  CONSTRAINT [FK_TblAllergyUser_TblUser1] FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblAllergyUser_TblUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblAllergyUser]'))
ALTER TABLE [dbo].[TblAllergyUser] CHECK CONSTRAINT [FK_TblAllergyUser_TblUser1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblDiseaseUser_TblDisease1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblDiseaseUser]'))
ALTER TABLE [dbo].[TblDiseaseUser]  WITH CHECK ADD  CONSTRAINT [FK_TblDiseaseUser_TblDisease1] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[TblDisease] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblDiseaseUser_TblDisease1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblDiseaseUser]'))
ALTER TABLE [dbo].[TblDiseaseUser] CHECK CONSTRAINT [FK_TblDiseaseUser_TblDisease1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblDiseaseUser_TblUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblDiseaseUser]'))
ALTER TABLE [dbo].[TblDiseaseUser]  WITH CHECK ADD  CONSTRAINT [FK_TblDiseaseUser_TblUser1] FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblDiseaseUser_TblUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblDiseaseUser]'))
ALTER TABLE [dbo].[TblDiseaseUser] CHECK CONSTRAINT [FK_TblDiseaseUser_TblUser1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblVaccine_TblSupplier_SupplierId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblVaccine]'))
ALTER TABLE [dbo].[TblVaccine]  WITH CHECK ADD  CONSTRAINT [FK_TblVaccine_TblSupplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[TblSupplier] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblVaccine_TblSupplier_SupplierId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblVaccine]'))
ALTER TABLE [dbo].[TblVaccine] CHECK CONSTRAINT [FK_TblVaccine_TblSupplier_SupplierId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblVaccineUser_TblUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblVaccineUser]'))
ALTER TABLE [dbo].[TblVaccineUser]  WITH CHECK ADD  CONSTRAINT [FK_TblVaccineUser_TblUser1] FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblVaccineUser_TblUser1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblVaccineUser]'))
ALTER TABLE [dbo].[TblVaccineUser] CHECK CONSTRAINT [FK_TblVaccineUser_TblUser1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblVaccineUser_TblVaccine1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblVaccineUser]'))
ALTER TABLE [dbo].[TblVaccineUser]  WITH CHECK ADD  CONSTRAINT [FK_TblVaccineUser_TblVaccine1] FOREIGN KEY([VaccineId])
REFERENCES [dbo].[TblVaccine] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblVaccineUser_TblVaccine1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblVaccineUser]'))
ALTER TABLE [dbo].[TblVaccineUser] CHECK CONSTRAINT [FK_TblVaccineUser_TblVaccine1]
GO
USE [master]
GO
ALTER DATABASE [Sinav] SET  READ_WRITE 
GO
