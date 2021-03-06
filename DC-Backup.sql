USE [master]
GO
/****** Object:  Database [ZambeziProject]    Script Date: 21-Sep-21 21:37:46 ******/
CREATE DATABASE [ZambeziProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZambeziProject', FILENAME = N'D:\Program Files (x86)\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZambeziProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZambeziProject_log', FILENAME = N'D:\Program Files (x86)\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZambeziProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ZambeziProject] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZambeziProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZambeziProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZambeziProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZambeziProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZambeziProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZambeziProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZambeziProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZambeziProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZambeziProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZambeziProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZambeziProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZambeziProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZambeziProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZambeziProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZambeziProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZambeziProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ZambeziProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZambeziProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZambeziProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZambeziProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZambeziProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZambeziProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZambeziProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZambeziProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ZambeziProject] SET  MULTI_USER 
GO
ALTER DATABASE [ZambeziProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZambeziProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZambeziProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZambeziProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZambeziProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZambeziProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ZambeziProject', N'ON'
GO
ALTER DATABASE [ZambeziProject] SET QUERY_STORE = OFF
GO
USE [ZambeziProject]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Timestamp] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserRole]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserRole]
AS
SELECT        dbo.Roles.Id, dbo.Roles.Title, dbo.Users.Id AS UserId
FROM            dbo.Roles INNER JOIN
                         dbo.Users ON dbo.Roles.Id = dbo.Users.RoleId
GO
/****** Object:  Table [dbo].[GaugeRecords]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GaugeRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UploaderId] [int] NOT NULL,
	[ImagePath] [nvarchar](350) NOT NULL,
	[GPSLocation] [nvarchar](350) NOT NULL,
	[WaterLevel] [float] NOT NULL,
	[Temperature] [float] NOT NULL,
	[RiverFlow] [float] NOT NULL,
	[GaugeId] [int] NOT NULL,
	[Approval] [bit] NOT NULL,
	[ApproverId] [int] NULL,
	[Timestamp] [date] NOT NULL,
 CONSTRAINT [PK_GaugeRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GaugeStation]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GaugeStation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[StationId] [int] NOT NULL,
 CONSTRAINT [PK_GaugeStation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [text] NOT NULL,
	[Message] [text] NOT NULL,
	[ImagePath] [text] NOT NULL,
	[UserId] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [money] NOT NULL,
	[UserId] [int] NULL,
	[StationId] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stations]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[ImagePath] [text] NULL,
 CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StationStatistics]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StationStatistics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StationId] [int] NOT NULL,
	[Coordinates] [nvarchar](150) NOT NULL,
	[Location] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_StationStatistics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GaugeRecords] ON 

INSERT [dbo].[GaugeRecords] ([Id], [UploaderId], [ImagePath], [GPSLocation], [WaterLevel], [Temperature], [RiverFlow], [GaugeId], [Approval], [ApproverId], [Timestamp]) VALUES (11, 1, N'3d6ee961-4c15-4.png', N'0000', 1234, 35, 1234, 4, 1, 1, CAST(N'2021-09-19' AS Date))
INSERT [dbo].[GaugeRecords] ([Id], [UploaderId], [ImagePath], [GPSLocation], [WaterLevel], [Temperature], [RiverFlow], [GaugeId], [Approval], [ApproverId], [Timestamp]) VALUES (15, 1, N'338516ba-6c27-4.png', N'Updated', 0, 0, 0, 4, 0, 1, CAST(N'2021-09-19' AS Date))
SET IDENTITY_INSERT [dbo].[GaugeRecords] OFF
GO
SET IDENTITY_INSERT [dbo].[GaugeStation] ON 

INSERT [dbo].[GaugeStation] ([Id], [Title], [StationId]) VALUES (4, N'Zambezi SE 1', 16)
INSERT [dbo].[GaugeStation] ([Id], [Title], [StationId]) VALUES (7, N'Comesa SE 5', 18)
SET IDENTITY_INSERT [dbo].[GaugeStation] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Heading], [Message], [ImagePath], [UserId], [Timestamp]) VALUES (3, N'Sample News', N'Saple BLuh', N'cbf5f41f-72e6-4.jpg', 1, CAST(N'2021-09-21T21:02:57.400' AS DateTime))
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Title]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (3, N'Ordinary Users')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (5, N'Staff')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([Id], [Salary], [UserId], [StationId]) VALUES (5, 1000.0000, 13, 18)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Stations] ON 

INSERT [dbo].[Stations] ([Id], [Title], [ImagePath]) VALUES (16, N'Zambezi Station', N'ce5aa540-9c17-4.jpg')
INSERT [dbo].[Stations] ([Id], [Title], [ImagePath]) VALUES (18, N'Comesa Station', N'f8fd5db9-6a9e-4.jpg')
INSERT [dbo].[Stations] ([Id], [Title], [ImagePath]) VALUES (19, N'Amaterasu Station', N'a95bad67-d1e9-4.jpg')
SET IDENTITY_INSERT [dbo].[Stations] OFF
GO
SET IDENTITY_INSERT [dbo].[StationStatistics] ON 

INSERT [dbo].[StationStatistics] ([Id], [StationId], [Coordinates], [Location]) VALUES (27, 16, N'111111,555555', N'Kabwe')
INSERT [dbo].[StationStatistics] ([Id], [StationId], [Coordinates], [Location]) VALUES (29, 18, N'452622,1235', N'Kitwe')
INSERT [dbo].[StationStatistics] ([Id], [StationId], [Coordinates], [Location]) VALUES (30, 19, N'156254,25698', N'Nirobie')
SET IDENTITY_INSERT [dbo].[StationStatistics] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [RoleId], [Timestamp]) VALUES (1, N'michael nawa', N'nawa', N'michaelnawa@gmail.com', N'michaelnawa1998@gmail.com', 1, CAST(N'2021-09-13' AS Date))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [RoleId], [Timestamp]) VALUES (6, N'admin', N'daddy', N'admin@admin.com', N'admin@admin.com', 1, CAST(N'2021-09-13' AS Date))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [RoleId], [Timestamp]) VALUES (11, N'michael', N'nawa', N'michaelnawa1998@gmail.comt', N'michaelnawa1998@gmail.comt', 1, CAST(N'2021-09-18' AS Date))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [RoleId], [Timestamp]) VALUES (12, N'michael', N'nawa', N'michaelnawa1998@gmail.comgege', N'michaelnawa1998@gmail.comt', 1, CAST(N'2021-09-18' AS Date))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [RoleId], [Timestamp]) VALUES (13, N'Staff meber', N'LastName', N'staff@staff.com', N'staff@staff.com', 5, CAST(N'2021-09-18' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[GaugeRecords] ADD  CONSTRAINT [DF_GaugeRecords_Approval]  DEFAULT ((0)) FOR [Approval]
GO
ALTER TABLE [dbo].[GaugeRecords] ADD  CONSTRAINT [DF_GaugeRecords_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[GaugeRecords]  WITH CHECK ADD  CONSTRAINT [FK_GaugeRecords_GaugeStation] FOREIGN KEY([GaugeId])
REFERENCES [dbo].[GaugeStation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GaugeRecords] CHECK CONSTRAINT [FK_GaugeRecords_GaugeStation]
GO
ALTER TABLE [dbo].[GaugeRecords]  WITH CHECK ADD  CONSTRAINT [FK_GaugeRecords_Users] FOREIGN KEY([UploaderId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GaugeRecords] CHECK CONSTRAINT [FK_GaugeRecords_Users]
GO
ALTER TABLE [dbo].[GaugeRecords]  WITH CHECK ADD  CONSTRAINT [FK_GaugeRecords_Users_Approver] FOREIGN KEY([ApproverId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GaugeRecords] CHECK CONSTRAINT [FK_GaugeRecords_Users_Approver]
GO
ALTER TABLE [dbo].[GaugeStation]  WITH CHECK ADD  CONSTRAINT [FK_GaugeStation_Stations] FOREIGN KEY([StationId])
REFERENCES [dbo].[Stations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GaugeStation] CHECK CONSTRAINT [FK_GaugeStation_Stations]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Users]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Stations] FOREIGN KEY([StationId])
REFERENCES [dbo].[Stations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Stations]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Users]
GO
ALTER TABLE [dbo].[StationStatistics]  WITH CHECK ADD  CONSTRAINT [FK_Stations] FOREIGN KEY([StationId])
REFERENCES [dbo].[Stations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StationStatistics] CHECK CONSTRAINT [FK_Stations]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [RolesID_FK] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [RolesID_FK]
GO
/****** Object:  StoredProcedure [dbo].[GaugeRecordsApprove]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GaugeRecordsApprove] 
	@Approval bit,
	@ApproverId int,
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Update GaugeRecords
	Set Approval=@Approval,ApproverId=@ApproverId
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeRecordsCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[GaugeRecordsCreate]
	@UploaderId int,
	@ImagePath text,
	@GPSLocation text,
	@WaterLevel float,
	@Temperature float,
	@RiverFlow float,
	@GaugeId int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into GaugeRecords (UploaderId,ImagePath,GPSLocation,WaterLevel,Temperature,RiverFlow,GaugeId)
	Values (@UploaderId,@ImagePath,@GPSLocation,@WaterLevel,@Temperature,@RiverFlow,@GaugeId)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeRecordsDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[GaugeRecordsDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from GaugeRecords
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeRecordsGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[GaugeRecordsGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from GaugeRecords 
	where GaugeId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeRecordsGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[GaugeRecordsGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from GaugeRecords
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeRecordsUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[GaugeRecordsUpdate]
	@ImagePath text,
	@WaterLevel float,
	@Temperature float,
	@RiverFlow float,
	@Approval bit,
	@ApproverId int,
	@GaugeId int,
	@GPSLocation text,
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update GaugeRecords
	Set ImagePath=@ImagePath,WaterLevel=@WaterLevel,Temperature=@Temperature,RiverFlow=@RiverFlow,GPSLocation = @GPSLocation,GaugeId=@GaugeId
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeStationCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[GaugeStationCreate]
	@Title nvarchar(50), 
	@StationId int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into GaugeStation (Title,StationId)
	Values (@Title,@StationId)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeStationDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[GaugeStationDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from GaugeStation
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeStationGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[GaugeStationGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from GaugeStation 
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeStationGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[GaugeStationGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from GaugeStation
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeStationGetRecords]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
Create PROCEDURE [dbo].[GaugeStationGetRecords]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from GaugeRecords 
	where GaugeId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GaugeStationUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[GaugeStationUpdate]
	@Title nvarchar(50), 
	@StationId int,
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update GaugeStation
	Set Title=@Title,StationId=@StationId
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[NewsCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[NewsCreate]
	@Heading nvarchar(850),
	@Message text,
	@ImagePath nvarchar(850), 
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into News (Heading,Message,ImagePath,UserId)
	Values (@Heading,@Message,@ImagePath,@UserId)
END
GO
/****** Object:  StoredProcedure [dbo].[NewsDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[NewsDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from News
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[NewsGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[NewsGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from News 
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[NewsGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[NewsGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from News
END
GO
/****** Object:  StoredProcedure [dbo].[NewsUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[NewsUpdate]
	@Heading nvarchar(850),
	@Message text,
	@ImagePath nvarchar(850), 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update News
	Set Heading=@Heading,Message=@Message,ImagePath=@ImagePath
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[RolesCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create
CREATE PROCEDURE [dbo].[RolesCreate]
	@Title nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into Roles (Title)
	Values (@Title)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[RolesDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[RolesDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from Roles
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[RolesGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[RolesGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Roles 
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[RolesGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[RolesGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Roles
END
GO
/****** Object:  StoredProcedure [dbo].[RolesUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[RolesUpdate]
	@Title nvarchar(50),
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update Roles
	Set Title=@Title
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[StaffCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[StaffCreate]
	@Salary money,
	@UserId int, 
	@StationId int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into Staff (Salary,UserId,StationId)
	Values (@Salary,@UserId,@StationId)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[StaffDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[StaffDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from Staff
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StaffGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[StaffGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Staff 
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StaffGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[StaffGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Staff
END
GO
/****** Object:  StoredProcedure [dbo].[StaffUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[StaffUpdate]
	@Salary money,
	@StationId int,
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update Staff
	Set Salary=@Salary,StationId=@StationId
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationsCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[StationsCreate]
	@Title nvarchar(150),
	@ImagePath text
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into Stations (Title,ImagePath)
	Values (@Title,@ImagePath)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[StationsDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[StationsDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from Stations
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationsGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[StationsGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Stations 
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationsGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[StationsGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Stations
END
GO
/****** Object:  StoredProcedure [dbo].[StationsGetGauge]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StationsGetGauge]
	@Id int
AS
BEGIN
	SET NOCOUNT ON; 
	Select * from GaugeStation
	Where StationId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationsGetStats]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StationsGetStats]
	@Id int
AS
BEGIN
	SET NOCOUNT ON; 
	Select * from StationStatistics
	Where StationId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationStatisticsCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[StationStatisticsCreate]
	@Location nvarchar(150),
	@StationId int,
	@Coordinates nvarchar(150)
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into StationStatistics (Location,StationId,Coordinates)
	Values (@Location,@StationId,@Coordinates)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[StationStatisticsDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[StationStatisticsDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from StationStatistics
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationStatisticsGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[StationStatisticsGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from StationStatistics 
	where StationId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationStatisticsGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[StationStatisticsGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from StationStatistics
END
GO
/****** Object:  StoredProcedure [dbo].[StationStatisticsUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[StationStatisticsUpdate]
	@Location nvarchar(150),
	@StationId int,
	@Coordinates nvarchar(150),
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update StationStatistics
	Set Location=@Location,StationId=@StationId,Coordinates=@Coordinates
	Where StationId=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[StationsUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[StationsUpdate]
	@Title nvarchar(150),
	@Id int,
	@ImagePath text
AS
BEGIN
	SET NOCOUNT ON;

	Update Stations
	Set Title = @Title,ImagePath = @ImagePath
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersChangePassword]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersChangePassword]
	@Id int,
	@Password text
AS
BEGIN
	SET NOCOUNT ON;

	Update Users set Password = @Password
	Where Id = @Id
	 
END
GO
/****** Object:  StoredProcedure [dbo].[UsersCreate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------Create
CREATE PROCEDURE [dbo].[UsersCreate]
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Email nvarchar(150),
	@Password nvarchar(350),
	@RoleId int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into Users (FirstName,LastName,Email,Password,RoleId)
	Values (@FirstName,@LastName,@Email,@Password,@RoleId)

	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[UsersDelete] 
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Delete from Users
	Where id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersGet]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get
CREATE PROCEDURE [dbo].[UsersGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Users 
	where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersGetAll]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GET ALL
CREATE PROCEDURE [dbo].[UsersGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Users
END
GO
/****** Object:  StoredProcedure [dbo].[UsersGetRole]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UsersGetRole]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Select * from dbo.UserRole
	where UserId = @Id
	 
END
GO
/****** Object:  StoredProcedure [dbo].[UsersLogin]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UsersLogin]
	@Email nvarchar(150),
	@Password nvarchar(150)
AS
BEGIN
	SET NOCOUNT ON;

	Select * from Users
	Where Email= @Email and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[UsersUpdate]    Script Date: 21-Sep-21 21:37:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[UsersUpdate]
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Email nvarchar(150),
	@Password nvarchar(350),
	@RoleId int,
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	Update Users
	Set FirstName=@FirstName,LastName=@LastName,Email=@Email,RoleId=@RoleId
	Where Id=@Id
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Roles"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserRole'
GO
USE [master]
GO
ALTER DATABASE [ZambeziProject] SET  READ_WRITE 
GO
