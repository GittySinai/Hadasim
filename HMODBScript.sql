USE [master]
GO
--1. Create the HMO DB
/****** Object:  Database [HMO]    Script Date: 28/03/2024 19:36:14 ******/
CREATE DATABASE [HMO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HMO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HMO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HMO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HMO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HMO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [HMO] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [HMO] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [HMO] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [HMO] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [HMO] SET ARITHABORT OFF 
GO

ALTER DATABASE [HMO] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [HMO] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [HMO] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [HMO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [HMO] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [HMO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [HMO] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [HMO] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [HMO] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [HMO] SET  DISABLE_BROKER 
GO

ALTER DATABASE [HMO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [HMO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [HMO] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [HMO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [HMO] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [HMO] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [HMO] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [HMO] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [HMO] SET  MULTI_USER 
GO

ALTER DATABASE [HMO] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [HMO] SET DB_CHAINING OFF 
GO

ALTER DATABASE [HMO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [HMO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [HMO] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [HMO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [HMO] SET QUERY_STORE = OFF
GO

ALTER DATABASE [HMO] SET  READ_WRITE 
GO

--2. Create the DB objects

USE [HMO]
GO
/****** Object:  Table [dbo].[EventTypes]    Script Date: 28/03/2024 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalEvents]    Script Date: 28/03/2024 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalEvents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeID] [int] NOT NULL,
	[MemberID] [bigint] NOT NULL,
	[EventDate] [date] NOT NULL,
	[Comments] [varchar](50) NULL,
	[EventExtensionID] [int] NULL,
 CONSTRAINT [PK_MedicalEvents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 28/03/2024 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TZ] [varchar](20) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[HouseNumber] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Mobile] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaccineTypes]    Script Date: 28/03/2024 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaccineTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VaccineName] [varchar](50) NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
 CONSTRAINT [PK_VaccineTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaccinEvents]    Script Date: 28/03/2024 19:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaccinEvents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VaccineID] [int] NOT NULL,
	[MemberID] [bigint] NOT NULL,
	[BodyLocation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Vaccine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--3. Generate meta data
SET IDENTITY_INSERT [dbo].[EventTypes] ON 
GO
INSERT [dbo].[EventTypes] ([ID], [EventTypeName]) VALUES (1, N'Disease diagnosis')
GO
INSERT [dbo].[EventTypes] ([ID], [EventTypeName]) VALUES (2, N'Recovery')
GO
INSERT [dbo].[EventTypes] ([ID], [EventTypeName]) VALUES (3, N'Receive a positive result')
GO
INSERT [dbo].[EventTypes] ([ID], [EventTypeName]) VALUES (4, N'Vaccination')
GO
SET IDENTITY_INSERT [dbo].[EventTypes] OFF

--4. Generate data for simulation and tests

GO
SET IDENTITY_INSERT [dbo].[MedicalEvents] ON 
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1, 1, 1, CAST(N'2023-03-24' AS Date), N'flu desease, high tempreature', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (2, 2, 1, CAST(N'2024-03-24' AS Date), N'geting better', 1)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1003, 1, 5, CAST(N'2024-03-27' AS Date), N'Covid diagnose', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1004, 4, 5, CAST(N'2024-03-27' AS Date), N'Vaccine given', 4)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1007, 2, 5, CAST(N'2024-03-22' AS Date), N'No improvemnet - DR was informed', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1011, 4, 5, CAST(N'2024-03-23' AS Date), N'aa', 5)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1012, 3, 1, CAST(N'2024-03-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1014, 4, 1, CAST(N'2024-03-22' AS Date), N'', 7)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1016, 4, 1, CAST(N'2024-03-21' AS Date), N'', 9)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1017, 2, 1, CAST(N'2024-03-07' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1018, 2, 1, CAST(N'2024-03-07' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1019, 2, 8, CAST(N'2024-03-12' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1020, 2, 8, CAST(N'2024-03-12' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1021, 2, 10010, CAST(N'2024-03-22' AS Date), N'nnnn', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1022, 2, 10010, CAST(N'2024-03-22' AS Date), N'nnnn', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1023, 3, 7, CAST(N'2024-03-15' AS Date), N'no', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1024, 3, 7, CAST(N'2024-03-15' AS Date), N'no', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1025, 4, 10015, CAST(N'2024-03-01' AS Date), N'ccccc', 10)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1026, 2, 10015, CAST(N'2024-03-08' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1027, 2, 10015, CAST(N'2024-03-08' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1028, 3, 8, CAST(N'2024-03-16' AS Date), N'nothing', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1029, 3, 8, CAST(N'2024-03-16' AS Date), N'nothing', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1030, 3, 10015, CAST(N'2024-03-22' AS Date), N'cccccccccccc', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1031, 3, 10015, CAST(N'2024-03-22' AS Date), N'cccccccccccc', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1032, 2, 10016, CAST(N'2024-03-01' AS Date), N'טטטטטטטטטטט', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1033, 1, 1, CAST(N'2023-03-24' AS Date), N'flu', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1034, 2, 1, CAST(N'2024-03-24' AS Date), N'geting better', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1035, 3, 1, CAST(N'2024-03-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1036, 4, 1, CAST(N'2024-03-22' AS Date), N'', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1039, 4, 1, CAST(N'2024-03-21' AS Date), N'', NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1040, 2, 1, CAST(N'2024-03-07' AS Date), NULL, NULL)
GO
INSERT [dbo].[MedicalEvents] ([ID], [EventTypeID], [MemberID], [EventDate], [Comments], [EventExtensionID]) VALUES (1041, 2, 1, CAST(N'2024-03-07' AS Date), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MedicalEvents] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (1, N'214787533', N'Gitty', N'Cohen', CAST(N'2004-10-19' AS Date), N'Telaviv', N'Henry', N'38', N'025453595', N'0527116807')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (5, N'213434566', N'Ari', N'Levi', CAST(N'2002-03-22' AS Date), N'Hadera', N'Azriel', N'2', N'025467778', N'05647543')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (7, N'219687533', N'Uri', N'Katz', CAST(N'2004-10-20' AS Date), N'Jerusalem', N'Henry', N'38', N'025453595', N'0527116807')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (8, N'219387533', N'Dovi', N'Smith', CAST(N'2004-10-20' AS Date), N'Jerusalem', N'Henry', N'38', N'025453595', N'0527116807')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (10010, N'043228692', N'Freydie', N'Sinai', CAST(N'1981-03-27' AS Date), N'Givat Shnuek', N'string', N'2', N'0765556788', N'768767878')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (10012, N'454454543', N'Gitel', N'Ransom', CAST(N'2024-03-07' AS Date), N'Jerusalem', N'Morgentau', N'38', N'0544371222', N'0768767878')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (10013, N'056456788', N'Lali', N'Sinai', CAST(N'2024-03-08' AS Date), N'Jerusalem', N'HenriM', N'38', N'0542216543', N'025453678')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (10015, N'222333232', N'Dan', N'Shapira', CAST(N'2024-03-16' AS Date), N'Hertzelia', N'Hakablan', N'2', N'06545568', N'05234566')
GO
INSERT [dbo].[Members] ([ID], [TZ], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [PhoneNumber], [Mobile]) VALUES (10016, N'564784644', N'Rivka', N'Cohen', CAST(N'2024-03-07' AS Date), N'Ranana', N'Horvits', N'33', N'0577371222', N'028565738')
GO
SET IDENTITY_INSERT [dbo].[Members] OFF

GO
SET IDENTITY_INSERT [dbo].[VaccinEvents] ON 
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (1, 1, 1, N'leg')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (4, 14, 5, N'ddd')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (5, 1, 5, N'nn')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (6, 5, 1, N'hand')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (7, 1, 1, N'hand')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (8, 13, 1, N'leg')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (9, 1, 1, N'leg')
GO
INSERT [dbo].[VaccinEvents] ([ID], [VaccineID], [MemberID], [BodyLocation]) VALUES (10, 5, 10015, N'hand')
GO
SET IDENTITY_INSERT [dbo].[VaccinEvents] OFF
GO
ALTER TABLE [dbo].[MedicalEvents]  WITH CHECK ADD  CONSTRAINT [FK_MedicalEvents_EventTypes] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventTypes] ([ID])
GO
ALTER TABLE [dbo].[MedicalEvents] CHECK CONSTRAINT [FK_MedicalEvents_EventTypes]
GO
ALTER TABLE [dbo].[MedicalEvents]  WITH CHECK ADD  CONSTRAINT [FK_MedicalEvents_Members] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([ID])
GO
ALTER TABLE [dbo].[MedicalEvents] CHECK CONSTRAINT [FK_MedicalEvents_Members]
GO
ALTER TABLE [dbo].[MedicalEvents]  WITH CHECK ADD  CONSTRAINT [FK_MedicalEvents_VaccinEvents] FOREIGN KEY([EventExtensionID])
REFERENCES [dbo].[VaccinEvents] ([ID])
GO
ALTER TABLE [dbo].[MedicalEvents] CHECK CONSTRAINT [FK_MedicalEvents_VaccinEvents]
GO
ALTER TABLE [dbo].[VaccinEvents]  WITH CHECK ADD  CONSTRAINT [FK_Vaccins_Members] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([ID])
GO
ALTER TABLE [dbo].[VaccinEvents] CHECK CONSTRAINT [FK_Vaccins_Members]
GO
ALTER TABLE [dbo].[VaccinEvents]  WITH CHECK ADD  CONSTRAINT [FK_Vaccins_VaccineTypes] FOREIGN KEY([VaccineID])
REFERENCES [dbo].[VaccineTypes] ([ID])
GO
ALTER TABLE [dbo].[VaccinEvents] CHECK CONSTRAINT [FK_Vaccins_VaccineTypes]
GO
