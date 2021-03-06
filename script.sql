USE [master]
GO
/****** Object:  Database [10190183]    Script Date: 02.06.2022 14:54:49 ******/
CREATE DATABASE [10190183]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'10190183', FILENAME = N'C:\databases\10190183.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'10190183_log', FILENAME = N'C:\databases\10190183_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [10190183] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [10190183].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [10190183] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [10190183] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [10190183] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [10190183] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [10190183] SET ARITHABORT OFF 
GO
ALTER DATABASE [10190183] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [10190183] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [10190183] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [10190183] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [10190183] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [10190183] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [10190183] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [10190183] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [10190183] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [10190183] SET  ENABLE_BROKER 
GO
ALTER DATABASE [10190183] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [10190183] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [10190183] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [10190183] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [10190183] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [10190183] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [10190183] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [10190183] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [10190183] SET  MULTI_USER 
GO
ALTER DATABASE [10190183] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [10190183] SET DB_CHAINING OFF 
GO
ALTER DATABASE [10190183] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [10190183] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [10190183] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [10190183] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [10190183] SET QUERY_STORE = OFF
GO
USE [10190183]
GO
/****** Object:  User [college\t.spiridonova]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\t.spiridonova] FOR LOGIN [college\t.spiridonova] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\o.kopets]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\o.kopets] FOR LOGIN [college\o.kopets] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\m.erina]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\m.erina] FOR LOGIN [college\m.erina] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\g.glebov]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\g.glebov] FOR LOGIN [college\g.glebov] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\g.fedorova]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\g.fedorova] FOR LOGIN [college\g.fedorova] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\a.vagin]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\a.vagin] FOR LOGIN [college\a.vagin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\a.r.popova]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\a.r.popova] FOR LOGIN [college\a.r.popova] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\a.berezhkov]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\a.berezhkov] FOR LOGIN [college\a.berezhkov] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [college\10190183]    Script Date: 02.06.2022 14:54:49 ******/
CREATE USER [college\10190183] FOR LOGIN [college\10190183] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\t.spiridonova]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\o.kopets]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\m.erina]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\g.glebov]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\g.fedorova]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\a.vagin]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\a.r.popova]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\a.berezhkov]
GO
ALTER ROLE [db_owner] ADD MEMBER [college\10190183]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id_category] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check](
	[id_check] [int] IDENTITY(1,1) NOT NULL,
	[check_materials] [nvarchar](50) NOT NULL,
	[check_count] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Check] PRIMARY KEY CLUSTERED 
(
	[id_check] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Makers]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makers](
	[id_makers] [int] IDENTITY(1,1) NOT NULL,
	[makers_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Makers] PRIMARY KEY CLUSTERED 
(
	[id_makers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[id_materials] [int] IDENTITY(1,1) NOT NULL,
	[materials_name] [nvarchar](50) NOT NULL,
	[materials_units] [nvarchar](50) NOT NULL,
	[materials_count] [int] NOT NULL,
	[materials_category] [int] NOT NULL,
	[materials_price] [float] NOT NULL,
	[materials_providers] [int] NOT NULL,
	[materials_makers] [int] NOT NULL,
	[materials_available] [int] NOT NULL,
	[materials_description] [nvarchar](150) NOT NULL,
	[materials_photo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id_materials] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id_orders] [int] IDENTITY(1,1) NOT NULL,
	[orders_pointup] [int] NOT NULL,
	[orders_users] [int] NOT NULL,
	[orders_check] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id_orders] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pointup]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pointup](
	[id_pointup] [int] IDENTITY(1,1) NOT NULL,
	[pointup_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Pointup] PRIMARY KEY CLUSTERED 
(
	[id_pointup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[id_providers] [int] IDENTITY(1,1) NOT NULL,
	[providers_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[id_providers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_roles] [int] IDENTITY(1,1) NOT NULL,
	[roles_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_roles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02.06.2022 14:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_users] [int] IDENTITY(1,1) NOT NULL,
	[users_role] [int] NOT NULL,
	[users_firstname] [nvarchar](50) NOT NULL,
	[users_lastname] [nvarchar](50) NOT NULL,
	[users_middlename] [nvarchar](50) NOT NULL,
	[users_phone] [nvarchar](50) NOT NULL,
	[users_datebirth] [date] NOT NULL,
	[users_mail] [nvarchar](50) NOT NULL,
	[users_login] [nvarchar](50) NOT NULL,
	[users_password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id_users] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Category] FOREIGN KEY([materials_category])
REFERENCES [dbo].[Category] ([id_category])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_Category]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Makers] FOREIGN KEY([materials_makers])
REFERENCES [dbo].[Makers] ([id_makers])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_Makers]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Providers] FOREIGN KEY([materials_providers])
REFERENCES [dbo].[Providers] ([id_providers])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_Providers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Check] FOREIGN KEY([orders_check])
REFERENCES [dbo].[Check] ([id_check])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Check]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Pointup] FOREIGN KEY([orders_pointup])
REFERENCES [dbo].[Pointup] ([id_pointup])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Pointup]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([orders_users])
REFERENCES [dbo].[Users] ([id_users])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([users_role])
REFERENCES [dbo].[Roles] ([id_roles])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [10190183] SET  READ_WRITE 
GO
