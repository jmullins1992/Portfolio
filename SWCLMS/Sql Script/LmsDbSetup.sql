USE [master]
GO
/****** Object:  Database [SWC_LMS]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE DATABASE [SWC_LMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SWC_LMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\SWC_LMS.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SWC_LMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\SWC_LMS_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SWC_LMS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SWC_LMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SWC_LMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SWC_LMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SWC_LMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SWC_LMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SWC_LMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SWC_LMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SWC_LMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SWC_LMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SWC_LMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SWC_LMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SWC_LMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SWC_LMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SWC_LMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SWC_LMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SWC_LMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SWC_LMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SWC_LMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SWC_LMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SWC_LMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SWC_LMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SWC_LMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SWC_LMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SWC_LMS] SET RECOVERY FULL 
GO
ALTER DATABASE [SWC_LMS] SET  MULTI_USER 
GO
ALTER DATABASE [SWC_LMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SWC_LMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SWC_LMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SWC_LMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SWC_LMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SWC_LMS', N'ON'
GO
USE [SWC_LMS]
GO
/****** Object:  User [lmsapp]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE USER [lmsapp] FOR LOGIN [lmsapp] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assignment](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[AssignmentName] [varchar](50) NOT NULL,
	[PossiblePoints] [int] NOT NULL,
	[DueDate] [date] NOT NULL,
	[AssignmentDescription] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[CourseDescription] [varchar](255) NULL,
	[GradeLevelId] [tinyint] NOT NULL,
	[IsArchived] [bit] NOT NULL DEFAULT ((0)),
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradeLevel]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradeLevel](
	[GradeLevelId] [tinyint] IDENTITY(1,1) NOT NULL,
	[GradeLevelName] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GradeLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LmsUser]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LmsUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[AspId] [nvarchar](128) NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[SuggestedRole] [varchar](50) NULL,
	[GradeLevelId] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roster]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roster](
	[RosterId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CurrentGrade] [varchar](3) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[RosterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RosterAssignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RosterAssignment](
	[RosterAssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[RosterId] [int] NOT NULL,
	[AssignmentId] [int] NOT NULL,
	[PointsEarned] [decimal](18, 0) NULL,
	[Percentage] [decimal](5, 2) NULL,
	[Grade] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[RosterAssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentGuardian]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentGuardian](
	[GuardianId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentGuardian] PRIMARY KEY CLUSTERED 
(
	[GuardianId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebsiteSettings]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebsiteSettings](
	[WebsiteSettingsId] [int] IDENTITY(1,1) NOT NULL,
	[Setting] [nvarchar](50) NOT NULL,
	[SettingValue] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[WebsiteSettingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/1/2015 3:15:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Course]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_GradeLevel] FOREIGN KEY([GradeLevelId])
REFERENCES [dbo].[GradeLevel] ([GradeLevelId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_GradeLevel]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Subject]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[LmsUser] ([UserId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Teacher]
GO
ALTER TABLE [dbo].[LmsUser]  WITH CHECK ADD  CONSTRAINT [FK_LmsUser_GradeLevel] FOREIGN KEY([GradeLevelId])
REFERENCES [dbo].[GradeLevel] ([GradeLevelId])
GO
ALTER TABLE [dbo].[LmsUser] CHECK CONSTRAINT [FK_LmsUser_GradeLevel]
GO
ALTER TABLE [dbo].[Roster]  WITH CHECK ADD  CONSTRAINT [FK_Roster_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Roster] CHECK CONSTRAINT [FK_Roster_Course]
GO
ALTER TABLE [dbo].[Roster]  WITH CHECK ADD  CONSTRAINT [FK_Roster_Student] FOREIGN KEY([UserId])
REFERENCES [dbo].[LmsUser] ([UserId])
GO
ALTER TABLE [dbo].[Roster] CHECK CONSTRAINT [FK_Roster_Student]
GO
ALTER TABLE [dbo].[RosterAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RosterAssignment_Assignment] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignment] ([AssignmentId])
GO
ALTER TABLE [dbo].[RosterAssignment] CHECK CONSTRAINT [FK_RosterAssignment_Assignment]
GO
ALTER TABLE [dbo].[RosterAssignment]  WITH CHECK ADD  CONSTRAINT [FK_RosterAssignment_Roster] FOREIGN KEY([RosterId])
REFERENCES [dbo].[Roster] ([RosterId])
GO
ALTER TABLE [dbo].[RosterAssignment] CHECK CONSTRAINT [FK_RosterAssignment_Roster]
GO
ALTER TABLE [dbo].[StudentGuardian]  WITH CHECK ADD  CONSTRAINT [FK_StudentGuardian_Guardian] FOREIGN KEY([GuardianId])
REFERENCES [dbo].[LmsUser] ([UserId])
GO
ALTER TABLE [dbo].[StudentGuardian] CHECK CONSTRAINT [FK_StudentGuardian_Guardian]
GO
ALTER TABLE [dbo].[StudentGuardian]  WITH CHECK ADD  CONSTRAINT [FK_StudentGuardian_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[LmsUser] ([UserId])
GO
ALTER TABLE [dbo].[StudentGuardian] CHECK CONSTRAINT [FK_StudentGuardian_Student]
GO
/****** Object:  StoredProcedure [dbo].[spAddAssignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--------------------------------------------------------------
CREATE PROCEDURE [dbo].[spAddAssignment](
	@CourseId int,
	@AssignmentName varchar(30),
	@PossiblePoints int,
	@DueDate date,
	@AssignmentDescription varchar(255)
) AS

DECLARE @AssignmentId int

BEGIN TRANSACTION

INSERT INTO Assignment (CourseId, AssignmentName, PossiblePoints, DueDate, AssignmentDescription)
VALUES (@CourseId, @AssignmentName, @PossiblePoints, @DueDate, @AssignmentDescription)

SET @AssignmentId = SCOPE_IDENTITY()

INSERT INTO RosterAssignment (RosterId, AssignmentId)
SELECT RosterId, @AssignmentId
FROM Roster
WHERE CourseId = @CourseId AND IsDeleted = 0

COMMIT TRANSACTION

GO
/****** Object:  StoredProcedure [dbo].[spAddCourse]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	
--------------------------------------------------------------
--Course-related sprocs
--------------------------------------------------------------

create procedure [dbo].[spAddCourse](
	@TeacherId int,
	@SubjectId int,
	@CourseName varchar(50),
	@CourseDescription varchar(255) = null,
	@GradeLevelId tinyint,
	@StartDate date,
	@EndDate date
) AS

insert into Course (
	TeacherId, SubjectId, CourseName, CourseDescription, GradeLevelId,
	IsArchived, StartDate, EndDate
)
values (
	@TeacherId, @SubjectId, @CourseName, @CourseDescription, @GradeLevelId,
	0, @StartDate, @EndDate
)

GO
/****** Object:  StoredProcedure [dbo].[spAddRosterAssignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------

create procedure [dbo].[spAddRosterAssignment] (
	@UserId int,
	@CourseId int,
	@AssignmentId int,
	@PointsEarned decimal(5,2) = null,
	@Percentage decimal(5,2) = null,
	@Grade varchar(3) = null
) AS

declare @RosterId int
set @RosterId = (select TOP(1) RosterId from Roster where (UserId = @UserId and CourseId = @CourseId))

insert into RosterAssignment (RosterId, AssignmentId, PointsEarned, Percentage, Grade)
values (@RosterId, @AssignmentId, @PointsEarned, @Percentage, @Grade)

GO
/****** Object:  StoredProcedure [dbo].[spAddStudentGuardian]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------


create procedure [dbo].[spAddStudentGuardian](
	@StudentId int,
	@GuardianId int
) AS

INSERT INTO StudentGuardian (GuardianId, StudentId) VALUES (@GuardianId, @StudentId)

GO
/****** Object:  StoredProcedure [dbo].[spAddStudentToCourse]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddStudentToCourse] (
	@StudentId int,
	@CourseId int
) AS

DECLARE @RosterId int

BEGIN TRANSACTION

	IF EXISTS (SELECT RosterId FROM Roster
	WHERE UserId = @StudentId AND CourseId = @CourseId)
	BEGIN
		UPDATE Roster SET IsDeleted = 0
		WHERE UserId = @StudentId AND CourseId = @CourseId
	END
	ELSE
	BEGIN
		INSERT INTO Roster (CourseId, UserId) values (@CourseId, @StudentId)

		SET @RosterId = SCOPE_IDENTITY()

		INSERT INTO RosterAssignment (RosterId, AssignmentId)
		SELECT @RosterId, AssignmentId
		FROM Assignment
		WHERE CourseId = @CourseId
	END

COMMIT TRANSACTION

GO
/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------
--User-management-related sprocs
--------------------------------------------------------------

create procedure [dbo].[spAddUser](
	@AspId nvarchar(128) = null,
	@FirstName varchar(30),
	@LastName varchar(30),
	@Email varchar(50),
	@SuggestedRole varchar(50) = null,
	@GradeLevelId tinyint = null,
	@UserId int output
) as 

insert into LmsUser (AspId, FirstName, LastName, Email, SuggestedRole, GradeLevelId)
values (@AspId, @FirstName, @LastName, @Email, @SuggestedRole, @GradeLevelId)

set @UserId = SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[spCreateSubject]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

create procedure [dbo].[spCreateSubject](
	@SubjectName varchar(50)
) AS

insert into [Subject] (SubjectName) values (@SubjectName)

GO
/****** Object:  StoredProcedure [dbo].[spDeleteAllTableData]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spDeleteAllTableData] AS
	begin transaction
		delete RosterAssignment	
		delete Assignment
		delete Roster
		delete Course
		delete StudentGuardian
		delete LmsUser
		delete AspNetUserRoles	
		delete AspNetUsers
		delete AspNetRoles
		delete GradeLevel
		delete [Subject]
		 

		DBCC CHECKIDENT ('RosterAssignment', RESEED, 0)
		DBCC CHECKIDENT ('Assignment', RESEED, 0)
		DBCC CHECKIDENT ('Roster', RESEED, 0)
		DBCC CHECKIDENT ('Course', RESEED, 0)
		DBCC CHECKIDENT ('LmsUser', RESEED, 0)
		DBCC CHECKIDENT ('GradeLevel', RESEED, 0)
		DBCC CHECKIDENT ('[Subject]', RESEED, 0)

	commit transaction

GO
/****** Object:  StoredProcedure [dbo].[spDeleteAssignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spDeleteAssignment] (
	@AssignmentId int
)AS

DELETE FROM RosterAssignment WHERE AssignmentId = @AssignmentId
DELETE FROM Assignment WHERE AssignmentId = @AssignmentId


GO
/****** Object:  StoredProcedure [dbo].[spFindStudentsNotEnrolledInCourse]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------
CREATE PROCEDURE [dbo].[spFindStudentsNotEnrolledInCourse](
	@CourseId int
) AS

DECLARE @idsNotEnrolled TABLE (id int)
INSERT INTO @idsNotEnrolled
	SELECT st.UserId
		FROM LmsUser as st		
	EXCEPT
	SELECT st.UserId
		FROM LmsUser as st
			INNER JOIN Roster as r ON st.UserId = r.UserId
		WHERE r.CourseId = @CourseId
		AND r.IsDeleted = 0

SELECT u.UserId, u.FirstName, u.LastName, u.Email, u.SuggestedRole,
	u.GradeLevelId, g.GradeLevelName, u.AspId
	FROM @idsNotEnrolled
		INNER JOIN LmsUser u ON u.UserId = id
		LEFT JOIN GradeLevel g ON u.GradeLevelId = g.GradeLevelId
	WHERE u.GradeLevelId IS NOT NULL

GO
/****** Object:  StoredProcedure [dbo].[spGetAllGradeLevels]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


---------------------------------------------
--Subjects & Gradelevel CRUD
---------------------------------------------

CREATE PROCEDURE [dbo].[spGetAllGradeLevels]
AS
SELECT GradeLevelId, GradeLevelName
FROM GradeLevel

GO
/****** Object:  StoredProcedure [dbo].[spGetAllRoles]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


---------------------------------------------
-- These sprocs rely on AspNet Identity tables
---------------------------------------------

CREATE PROCEDURE [dbo].[spGetAllRoles] 
AS
SELECT Id, Name
FROM AspNetRoles


GO
/****** Object:  StoredProcedure [dbo].[spGetAllSubject]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

create procedure [dbo].[spGetAllSubject] as

select SubjectId, SubjectName from [Subject]

GO
/****** Object:  StoredProcedure [dbo].[spGetAllUnassignedUsers]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------

CREATE PROCEDURE [dbo].[spGetAllUnassignedUsers]
AS

SELECT LmsUser.FirstName, LmsUser.LastName, LmsUser.Email, LmsUser.SuggestedRole, 
	LmsUser.UserId, LmsUser.AspId, LmsUser.GradeLevelId
FROM LmsUser
	LEFT JOIN AspNetUsers ON AspNetUsers.Id = LmsUser.AspId
	LEFT JOIN AspNetUserRoles ON AspNetUserRoles.UserId = LmsUser.AspId
WHERE AspNetUserRoles.RoleId IS NULL


GO
/****** Object:  StoredProcedure [dbo].[spGetAssignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spGetAssignment] (
	@AssignmentId int
) AS

SELECT AssignmentId, AssignmentName, PossiblePoints, DueDate, AssignmentDescription
FROM Assignment
WHERE AssignmentId = @AssignmentId


GO
/****** Object:  StoredProcedure [dbo].[spGetCourseById]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------

create procedure [dbo].[spGetCourseById](
	@CourseId int
) AS

select CourseId, TeacherId, SubjectId, CourseName, CourseDescription, GradeLevelId, IsArchived, StartDate, EndDate from Course
where CourseId = @CourseId

GO
/****** Object:  StoredProcedure [dbo].[spGetCourseDetailsById]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------
CREATE PROCEDURE [dbo].[spGetCourseDetailsById](
	@CourseId int
) AS

SELECT c.CourseId, c.CourseName, 
	c.TeacherId, u.FirstName AS TeacherFirstName, u.LastName AS TeacherLastName, 
	c.SubjectId, s.SubjectName,
	c.StartDate, c.EndDate,
	c.IsArchived,
	c.CourseDescription, c.GradeLevelId, gl.GradeLevelName
FROM Course c
	INNER JOIN GradeLevel gl ON gl.GradeLevelId = c.GradeLevelId
	INNER JOIN [Subject] s ON s.SubjectId = c.SubjectId
	INNER JOIN LmsUser u ON u.UserId = c.TeacherId
	WHERE c.CourseId = @CourseId

GO
/****** Object:  StoredProcedure [dbo].[spGetCoursesByStudentId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

create procedure [dbo].[spGetCoursesByStudentId](
	@StudentId int
) AS

SELECT c.CourseId, CourseName, r.CurrentGrade
FROM Course AS c
	INNER JOIN Roster As r
	ON c.CourseId = r.CourseId
WHERE UserId = @StudentId
AND r.IsDeleted = 0


GO
/****** Object:  StoredProcedure [dbo].[spGetCoursesByTeacherId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spGetCoursesByTeacherId] (
	@TeacherId int
) AS
SELECT c.CourseId, CourseName, IsArchived, (SELECT Count(RosterId) FROM Roster r WHERE r.CourseId = c.CourseId AND r.IsDeleted = 0) AS NumOfStudents
FROM Course c 
WHERE c.TeacherId = @TeacherId
GROUP BY c.IsArchived, c.CourseId, c.CourseName

GO
/****** Object:  StoredProcedure [dbo].[spGetGradebookForCourseId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


---------------------------------------------
--Gradebook & Grade-related sprocs
---------------------------------------------
CREATE PROCEDURE [dbo].[spGetGradebookForCourseId] (
	@CourseId int
) AS

SELECT student.FirstName, student.LastName,
	r.CurrentGrade, a.AssignmentName, 
	ra.PointsEarned,  a.PossiblePoints, ra.Percentage,
	ra.RosterAssignmentId, a.DueDate, 
	a.AssignmentId, r.RosterId
FROM RosterAssignment ra
	INNER JOIN Roster AS r ON r.RosterId = ra.RosterId
	INNER JOIN Assignment AS a ON a.AssignmentId = ra.AssignmentId
	INNER JOIN LmsUser AS student ON student.UserId = r.UserId
WHERE r.CourseId = @CourseId

GO
/****** Object:  StoredProcedure [dbo].[spGetGradedAssignmentsByRosterId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------


CREATE PROCEDURE [dbo].[spGetGradedAssignmentsByRosterId](
	@RosterId int
) AS

DECLARE @StudentId int
DECLARE @CourseId int

SET @StudentId = (SELECT TOP(1) UserId FROM Roster r
	WHERE RosterId = @RosterId
)

SET @CourseId = (SELECT TOP(1) CourseId FROM Roster r
	WHERE RosterId = @RosterId
)

EXEC spGetGradedAssignmentsForStudentInCourse @StudentId, @CourseId


GO
/****** Object:  StoredProcedure [dbo].[spGetGradedAssignmentsForStudentInCourse]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------
--For Student View
--------------------------------------------------------------
CREATE PROCEDURE [dbo].[spGetGradedAssignmentsForStudentInCourse] (
	@StudentId int,
	@CourseId int
) AS

SELECT c.CourseId, c.CourseName,
	a.AssignmentName,
	ra.PointsEarned, ra.Percentage, ra.Grade, 
	StudentId = r.UserId, a.PossiblePoints
FROM Roster AS r
	INNER JOIN RosterAssignment AS ra ON ra.RosterId = r.RosterId
	INNER JOIN Assignment AS a ON a.AssignmentId = ra.AssignmentId
	INNER JOIN Course AS c ON c.CourseId = r.CourseId
WHERE r.UserId = @StudentId AND c.CourseId = @CourseId
AND ra.PointsEarned IS NOT NULL
ORDER BY a.DueDate


GO
/****** Object:  StoredProcedure [dbo].[spGetLmsUserByAspId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spGetLmsUserByAspId](
	@AspId nvarchar(128)
) AS

SELECT u.UserId, u.Email, u.FirstName, u.LastName, u.SuggestedRole, u.AspId, u.GradeLevelId
FROM LmsUser u	
WHERE u.AspId = @AspId

GO
/****** Object:  StoredProcedure [dbo].[spGetStudentsByCourseId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------
--Course Roster: Adding/Removing Students
---------------------------------------------

CREATE PROCEDURE [dbo].[spGetStudentsByCourseId] (
	@CourseId int
) AS

SELECT u.UserId, u.FirstName, u.LastName, u.Email, u.SuggestedRole,
	u.GradeLevelId, g.GradeLevelName, u.AspId
FROM LmsUser u
	LEFT JOIN GradeLevel g ON u.GradeLevelId = g.GradeLevelId
	INNER JOIN Roster as r ON u.UserId = r.UserId
WHERE r.CourseId = @CourseId
AND r.IsDeleted = 0

GO
/****** Object:  StoredProcedure [dbo].[spGetStudentsByGuardianId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------
--For Parent View
--------------------------------------------------------------

create procedure [dbo].[spGetStudentsByGuardianId](
	@GuardianId int
) AS

select UserId, FirstName, LastName from LmsUser
	inner join StudentGuardian on UserId = StudentId
where GuardianId = @GuardianId

GO
/****** Object:  StoredProcedure [dbo].[spGetUserDetailsById]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spGetUserDetailsById] (
	@UserId int
) AS

SELECT u.UserId, u.Email, u.FirstName, u.LastName, u.SuggestedRole, u.AspId, u.GradeLevelId
FROM LmsUser u	
WHERE u.UserId = @UserId

GO
/****** Object:  StoredProcedure [dbo].[spGetUserRolesById]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spGetUserRolesById](
	@UserId int
) AS

SELECT r.Name
FROM LmsUser u
	LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.AspId
	LEFT JOIN AspNetRoles r ON r.Id = ur.RoleId
WHERE u.UserId = @UserId

GO
/****** Object:  StoredProcedure [dbo].[spGetUserRolesByUserId]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------

CREATE PROCEDURE [dbo].[spGetUserRolesByUserId](
	@UserId int	
) AS

SELECT r.Name, r.Id
FROM AspNetUserRoles ur
	INNER JOIN AspNetRoles r ON ur.RoleId = r.Id
WHERE ur.UserId = @UserId

GO
/****** Object:  StoredProcedure [dbo].[spPopulateAspRoles]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPopulateAspRoles] AS
	INSERT INTO AspNetRoles(Id, Name)
	VALUES ('95638512-d7fd-4fe4-8c7b-e474c2b0db7d', 'Admin'),
		   ('6edd03d3-f7e7-456c-8d2d-763add266130', 'Parent'),
		   ('ef8ae5b0-e5af-4e6a-9d0f-88bd23f95d54', 'Student'),
		   ('a5a42f98-820f-4788-90a3-f6232d6d1acf', 'Teacher')

GO
/****** Object:  StoredProcedure [dbo].[spPopulateAssignments]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spPopulateAssignments] as
-- Algebra I
exec spAddAssignment 1, 'Quiz 1', 10, '20150803', 'A quiz'
exec spAddAssignment 1, 'Homework 1', 8, '20150810', 'Workbook p. 8'
exec spAddAssignment 1, 'Fundamentals Test', 50, '20150915', 'Open book, open notes'

-- Geometry
exec spAddAssignment 2, 'Quiz 1', 20, '20150806', 'A quiz'
exec spAddAssignment 2, 'The Big Test', 100, '20151012', 'No cheating.'

-- American History I
exec spAddAssignment 3, 'American Revolution Quiz', 20, '20150815', 'A quiz on the American Revolution'
exec spAddAssignment 3, 'Civil War Quiz', 8, '20150910', 'A quiz on the Civil War'
exec spAddAssignment 3, 'Final', 50, '20151201', 'Please turn it in no later than 2pm'

-- American History II
exec spAddAssignment 4, 'American Revolution Quiz', 20, '20150815', 'A quiz on the American Revolution'
exec spAddAssignment 4, 'Civil War Quiz', 8, '20150910', 'A quiz on the Civil War'
exec spAddAssignment 4, 'Quiz 3', 20, '20151006', 'A quiz'
exec spAddAssignment 4, 'Quiz 4', 20, '20151008', 'A quiz'
exec spAddAssignment 4, 'Final', 50, '20151201', 'Please turn it in no later than 2pm'


exec spUpdateRosterAssignment 1, 8.5, 85.00, 'B'
exec spUpdateRosterAssignment 2, 6, 75.00, 'C'
exec spUpdateStudentCourseGrade 1, 'B'

GO
/****** Object:  StoredProcedure [dbo].[spPopulateCourse]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spPopulateCourse] as
insert into Course (TeacherId, SubjectId, CourseName, CourseDescription, GradeLevelId, StartDate, EndDate, IsArchived)
values (5, 1, 'Algebra I', 'Learn the fundamentals of algebra', 9, '20150801', '20151220', 0),
	   (5, 1, 'Geometry', 'Learn the fundamentals of geometry', 10, '20150801', '20151220', 0),
	   (5, 3, 'American History I', 'American History from 1776 to 1865', 9, '20150801', '20151220', 0),
	   (5, 3, 'American History II', 'American History from 1866 to 2001', 10, '20150801', '20151220', 0),
	   (5, 3, 'American History III', 'American History from 2001 to 2012', 10, '20130801', '20131220', 1)
insert into Roster (CourseId, UserId)
values (1, 1), (3, 1), (2, 3), (4, 3), (5, 3)

GO
/****** Object:  StoredProcedure [dbo].[spPopulateGradeLevel]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spPopulateGradeLevel] as

insert into GradeLevel (GradeLevelName)
values ('Kindergart'), ('1st'), ('2nd'), ('3rd'), ('4th'), ('5th'), ('6th'), 
	                   ('7th'), ('8th'), ('9th'), ('10th'), ('11th'), ('12th')	

GO
/****** Object:  StoredProcedure [dbo].[spPopulateLmsUser]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spPopulateLmsUser] as

	INSERT INTO LmsUser (AspId, FirstName, LastName, Email, SuggestedRole, GradeLevelId)
	VALUES ('1a41c074-2b2a-4813-83d9-34f86269c179', 'Jim', 'Tucker', 'student2@gmail.com', 'Student', 9),
	       ('726e8f5f-9183-4135-bdaf-45ca01f12b5f', 'Michael', 'Scott', 'admin@gmail.com', 'Admin', null),
		   ('52513f8f-9fb8-43fd-ae03-3a93df035f40', 'Kim', 'Tucker', 'student@gmail.com', 'Student', 10),
		   ('5df6efcd-5b9d-45cd-8575-7157d2b187a8', 'Tim', 'Tucker', 'parent@gmail.com', 'Parent', null),
		   ('c2353ab2-4662-46b1-81fa-c4ed8cea8543', 'Charles', 'Minor', 'teacher@gmail.com', 'Teacher', null)

	INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
	VALUES ('1a41c074-2b2a-4813-83d9-34f86269c179', null, 0, 'AAAzPRtjdRUCOMS8FMtFcDBPDRLTwJZ/Y/Sa8fykEwvo2rzrIqeWyIvHZSbMhJ41GQ==', '525497de-adfb-431f-a43e-ec368efde82d', null, 0, 0, null, 0, 0, 'student2@gmail.com'),
	       ('726e8f5f-9183-4135-bdaf-45ca01f12b5f', null, 0, 'ACN9V1b9lmBgPsc9iDfzy2X09o3CK7ysNfF9uI8iFBevonM/BNZvYW+XDs0o21uQdQ==', '67504391-0de6-4e59-8742-b304b23b2602', null, 0, 0, null, 0, 0, 'admin@gmail.com'),
		   ('52513f8f-9fb8-43fd-ae03-3a93df035f40', null, 0, 'AMkDHujXD2GftstGH+dFUkFgmf8as7RGYiEYk2PO5rEdXj3je0KoaO7P3i3ps/xjcw==', '1ac21746-c46f-4ff4-8585-6e23897a5552', null, 0, 0, null, 0, 0, 'student@gmail.com'),
		   ('5df6efcd-5b9d-45cd-8575-7157d2b187a8', null, 0, 'AAtjUtX6jJZYvtsBMwcWXL1zs51lkKnNhKepBQ918wm70/UJ2etlBQtzhs47fCO69Q==', 'cbcd4549-17e0-4acd-af47-dfead48b2a64', null, 0, 0, null, 0, 0, 'parent@gmail.com'),
		   ('c2353ab2-4662-46b1-81fa-c4ed8cea8543', null, 0, 'ABl7DVOLceAUrU+IOkQVXSTR4tCU5VITRJXYnSPja+jEcV1AnyNSXk4wNWe7Ct+2fw==', 'e87168c6-3998-44b8-bb52-032b2d016cba', null, 0, 0, null, 0, 0, 'teacher@gmail.com')

	INSERT INTO AspNetUserRoles (UserId, RoleId)
	VALUES('1a41c074-2b2a-4813-83d9-34f86269c179', 'ef8ae5b0-e5af-4e6a-9d0f-88bd23f95d54'),
		  ('726e8f5f-9183-4135-bdaf-45ca01f12b5f', '95638512-d7fd-4fe4-8c7b-e474c2b0db7d'),
		  ('52513f8f-9fb8-43fd-ae03-3a93df035f40', 'ef8ae5b0-e5af-4e6a-9d0f-88bd23f95d54'),
		  ('5df6efcd-5b9d-45cd-8575-7157d2b187a8', '6edd03d3-f7e7-456c-8d2d-763add266130'),
		  ('c2353ab2-4662-46b1-81fa-c4ed8cea8543', 'a5a42f98-820f-4788-90a3-f6232d6d1acf')

	exec spAddStudentGuardian 1, 4
	exec spAddStudentGuardian 3, 4

GO
/****** Object:  StoredProcedure [dbo].[spPopulateSubject]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spPopulateSubject] as
insert into [Subject] (SubjectName)
values	('Math'), ('Science'), ('History'), ('Literature')

GO
/****** Object:  StoredProcedure [dbo].[spRebuildDataBase]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--run scripts

create PROCEDURE [dbo].[spRebuildDataBase] AS

	exec spDeleteAllTableData
	exec spPopulateGradeLevel
	exec spPopulateAspRoles
	exec spPopulateSubject
	exec spPopulateLmsUser
	exec spPopulateCourse
	exec spPopulateAssignments

GO
/****** Object:  StoredProcedure [dbo].[spRemoveGuardianRelationships]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------
create procedure [dbo].[spRemoveGuardianRelationships](
	@GuardianId int
) AS

DELETE StudentGuardian
WHERE GuardianId = @GuardianId

GO
/****** Object:  StoredProcedure [dbo].[spRemoveStudentFromCourse]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRemoveStudentFromCourse](
	@StudentId int,
	@CourseId int
)AS
BEGIN TRANSACTION

UPDATE Roster
	SET IsDeleted = 1
	WHERE UserId = @StudentId AND CourseId = @CourseId

COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[spUpdateCourseInformation]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------

CREATE PROCEDURE [dbo].[spUpdateCourseInformation] (
	@CourseId int,
	@SubjectId int,
	@TeacherId int,
	@CourseName varchar(50),
	@CourseDescription varchar(255) = null,
	@GradeLevelId tinyint,
	@IsArchived bit,
	@StartDate date,
	@EndDate date
)AS

UPDATE Course
	SET	SubjectId = @SubjectId,
		TeacherId = @TeacherId,
		CourseName = @CourseName,
		CourseDescription = @CourseDescription,
		GradeLevelId = @GradeLevelId,
		IsArchived = @IsArchived,
		StartDate = @StartDate,
		EndDate = @EndDate
	WHERE CourseId = @CourseId

GO
/****** Object:  StoredProcedure [dbo].[spUpdateRosterAssignment]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

create procedure [dbo].[spUpdateRosterAssignment](
	@RosterAssignmentId int,
	@PointsEarned decimal(5,2) = null,
	@Percentage decimal(5,2) = null,
	@Grade varchar(3) = null
) as

update RosterAssignment set
	PointsEarned = @PointsEarned,
	Percentage = @Percentage,
	Grade = @Grade
WHERE RosterAssignmentId = @RosterAssignmentId

GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudentCourseGrade]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------

CREATE PROCEDURE [dbo].[spUpdateStudentCourseGrade] (
	@RosterId int,
	@CurrentGrade varchar(3)
) AS

UPDATE Roster
	SET CurrentGrade = @CurrentGrade
	WHERE RosterId = @RosterId

GO
/****** Object:  StoredProcedure [dbo].[spUpdateSubject]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

create procedure [dbo].[spUpdateSubject](
	@SubjectId int,
	@SubjectName varchar(50)
) as

update dbo.[Subject]
	set SubjectName = @SubjectName
where 
	SubjectId = @SubjectId

GO
/****** Object:  StoredProcedure [dbo].[spUpdateUserDetails]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------
CREATE PROCEDURE [dbo].[spUpdateUserDetails](
	@UserId int,
	@LastName varchar(30),
	@FirstName varchar(30),
	@Email varchar(50),
	@SuggestedRole varchar(50) = null,
	@GradeLevelId tinyint = null
) AS

UPDATE LmsUser
	SET	LastName = @LastName,
		FirstName = @FirstName,
		Email = @Email,
		SuggestedRole = @SuggestedRole,
		GradeLevelId = @GradeLevelId
	WHERE UserId = @UserId


GO
/****** Object:  StoredProcedure [dbo].[spUpdateUserRoles]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateUserRoles](
	@UserId int,
	@IsStudent bit,
	@IsParent bit,
	@IsTeacher bit,
	@IsAdmin bit
)AS

DECLARE @AspId nvarchar(128)
SET @AspId = (select TOP(1) AspId from LmsUser where (LmsUser.UserId = @UserId))  

BEGIN TRANSACTION

DELETE x FROM AspNetUserRoles x
WHERE UserId = @AspId

if @IsStudent = 1 BEGIN
	INSERT INTO AspNetUserRoles (UserId, RoleId)
	SELECT @AspId AS UserId, Id AS RoleId
	FROM AspNetRoles
	Where Name = 'Student'
END

if @IsParent = 1 BEGIN
	INSERT INTO AspNetUserRoles (UserId, RoleId)
	SELECT @AspId AS UserId, Id AS RoleId
	FROM AspNetRoles
	Where Name = 'Parent'
END

if @IsTeacher = 1 BEGIN
	INSERT INTO AspNetUserRoles (UserId, RoleId)
	SELECT @AspId AS UserId, Id AS RoleId
	FROM AspNetRoles
	Where Name = 'Teacher' 
END

if (@IsAdmin = 1) BEGIN
	INSERT INTO AspNetUserRoles (UserId, RoleId)
	SELECT @AspId AS UserId, Id AS RoleId
	FROM AspNetRoles
	Where Name = 'Admin'
END
COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[spUserSearch]    Script Date: 7/1/2015 3:15:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------

CREATE PROCEDURE [dbo].[spUserSearch](
	@LastName varchar(30) = null,
	@FirstName varchar(30) = null,
	@Email varchar(50) = null,
	@RoleName nvarchar(256) = null
)
AS

SELECT u.LastName, u.FirstName, u.Email, u.UserId
FROM LmsUser as u
	LEFT JOIN AspNetUsers asp ON asp.Id = u.AspId
	LEFT JOIN AspNetUserRoles ur ON ur.UserId = asp.Id
	LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
WHERE 
	(@LastName IS NULL OR u.LastName LIKE @LastName+'%') AND
	(@FirstName IS NULL OR u.FirstName LIKE @FirstName+'%') AND
	(@Email IS NULL OR u.Email LIKE '%'+@Email+'%') AND
	(@RoleName IS NULL OR  r.Name = @RoleName)

GO
USE [master]
GO
ALTER DATABASE [SWC_LMS] SET  READ_WRITE 
GO
