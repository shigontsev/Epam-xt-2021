USE [master]
GO
/****** Object:  Database [UserAwardBD]    Script Date: 04.07.2021 11:04:35 ******/
CREATE DATABASE [UserAwardBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserAwardBD', FILENAME = N'C:\Users\Yurii_S\UserAwardBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserAwardBD_log', FILENAME = N'C:\Users\Yurii_S\UserAwardBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UserAwardBD] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserAwardBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserAwardBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserAwardBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserAwardBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserAwardBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserAwardBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserAwardBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserAwardBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserAwardBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserAwardBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserAwardBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserAwardBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserAwardBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserAwardBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserAwardBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserAwardBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserAwardBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserAwardBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserAwardBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserAwardBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserAwardBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserAwardBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserAwardBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserAwardBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UserAwardBD] SET  MULTI_USER 
GO
ALTER DATABASE [UserAwardBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserAwardBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserAwardBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserAwardBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserAwardBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UserAwardBD] SET QUERY_STORE = OFF
GO
USE [UserAwardBD]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [UserAwardBD]
GO
/****** Object:  Table [dbo].[AuthData]    Script Date: 04.07.2021 11:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthData](
	[IdUser] [uniqueidentifier] NOT NULL,
	[HashPass] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 04.07.2021 11:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04.07.2021 11:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04.07.2021 11:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndAwards]    Script Date: 04.07.2021 11:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndAwards](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[IdAward] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UsersAndAwards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndRoles]    Script Date: 04.07.2021 11:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndRoles](
	[IdUser] [uniqueidentifier] NOT NULL,
	[IdRole] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[AuthData] ([IdUser], [HashPass]) VALUES (N'634b2a7e-e1b2-45a5-9195-1bca6f500f64', N'ABYUOHcUmIVTmGF/mrpzRIzUT76ygHVy5iLTOjN8NukhYc/OkV9jDpP/0ru7WS3I6Q==')
GO
INSERT [dbo].[AuthData] ([IdUser], [HashPass]) VALUES (N'17d86959-8f03-4fdc-a87b-b7e03cf93fba', N'AAGczHvNygXEqnpX8glI7LotKExAh5RHrobvoKE65YfFebmT+6dIGvyIPN2brBs+jA==')
GO
INSERT [dbo].[Award] ([Id], [Title]) VALUES (N'457b74ea-bb04-4798-8c69-30e452504492', N'Ceasar')
GO
INSERT [dbo].[Award] ([Id], [Title]) VALUES (N'1845320b-33c2-4492-9e6b-5f0a7a67c35a', N'Human')
GO
INSERT [dbo].[Award] ([Id], [Title]) VALUES (N'8f19392c-0872-4c41-8c81-afb180ae1b24', N'Fish')
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (0, N'admin')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'user')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[User] ([Id], [Name], [DateOfBirth]) VALUES (N'634b2a7e-e1b2-45a5-9195-1bca6f500f64', N'admin', CAST(N'1996-11-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([Id], [Name], [DateOfBirth]) VALUES (N'17d86959-8f03-4fdc-a87b-b7e03cf93fba', N'user', CAST(N'1990-06-11T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UsersAndAwards] ON 
GO
INSERT [dbo].[UsersAndAwards] ([Id], [IdUser], [IdAward]) VALUES (2, N'17d86959-8f03-4fdc-a87b-b7e03cf93fba', N'8f19392c-0872-4c41-8c81-afb180ae1b24')
GO
INSERT [dbo].[UsersAndAwards] ([Id], [IdUser], [IdAward]) VALUES (3, N'634b2a7e-e1b2-45a5-9195-1bca6f500f64', N'457b74ea-bb04-4798-8c69-30e452504492')
GO
SET IDENTITY_INSERT [dbo].[UsersAndAwards] OFF
GO
INSERT [dbo].[UsersAndRoles] ([IdUser], [IdRole]) VALUES (N'634b2a7e-e1b2-45a5-9195-1bca6f500f64', 0)
GO
INSERT [dbo].[UsersAndRoles] ([IdUser], [IdRole]) VALUES (N'634b2a7e-e1b2-45a5-9195-1bca6f500f64', 1)
GO
INSERT [dbo].[UsersAndRoles] ([IdUser], [IdRole]) VALUES (N'17d86959-8f03-4fdc-a87b-b7e03cf93fba', 1)
GO
ALTER TABLE [dbo].[AuthData]  WITH CHECK ADD  CONSTRAINT [FK_AuthData_ToUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuthData] CHECK CONSTRAINT [FK_AuthData_ToUser]
GO
ALTER TABLE [dbo].[UsersAndAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndAwards_ToAward] FOREIGN KEY([IdAward])
REFERENCES [dbo].[Award] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndAwards] CHECK CONSTRAINT [FK_UsersAndAwards_ToAward]
GO
ALTER TABLE [dbo].[UsersAndAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndAwards_ToUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndAwards] CHECK CONSTRAINT [FK_UsersAndAwards_ToUser]
GO
ALTER TABLE [dbo].[UsersAndRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndRoles_ToRole] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndRoles] CHECK CONSTRAINT [FK_UsersAndRoles_ToRole]
GO
ALTER TABLE [dbo].[UsersAndRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndRoles_ToUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndRoles] CHECK CONSTRAINT [FK_UsersAndRoles_ToUser]
GO
USE [master]
GO
ALTER DATABASE [UserAwardBD] SET  READ_WRITE 
GO
