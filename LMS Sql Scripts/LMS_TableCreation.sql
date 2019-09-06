-----------------------------------------------------------
-- DB Creation
-----------------------------------------------------------
USE master
GO

IF EXISTS (select * from master.dbo.syslogins WHERE name = 'lmsapp')
DROP LOGIN lmsapp
GO

CREATE LOGIN lmsapp
	WITH PASSWORD = '12345';
GO

if exists (select * from sysdatabases where name='SWC_LMS')
	drop database SWC_LMS
GO

CREATE DATABASE SWC_LMS
GO

USE SWC_LMS
GO

CREATE USER lmsapp FOR LOGIN lmsapp;
GO

GRANT EXECUTE TO lmsapp
GO

-----------------------------------------------------------
-- Table Creation
-----------------------------------------------------------

CREATE TABLE GradeLevel(
	GradeLevelId tinyint identity(1,1) primary key not null,
	GradeLevelName varchar(10) not null
)
GO

CREATE TABLE [Subject] (
	SubjectId int identity(1,1) primary key not null,
	SubjectName varchar(50) not null
)
GO

CREATE TABLE LmsUser (
	UserId int identity(1,1) primary key not null,
	AspId nvarchar(128) null,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	Email varchar(50) not null,
	SuggestedRole varchar(50) null,
	GradeLevelId tinyint null
)
GO

ALTER TABLE LmsUser 
	ADD CONSTRAINT FK_LmsUser_GradeLevel FOREIGN KEY (GradeLevelId)
	REFERENCES dbo.GradeLevel(GradeLevelId)
--TODO add AspId fk constraint
GO

CREATE TABLE Course (
	CourseId int identity(1,1) primary key not null,
	TeacherId int not null,
	SubjectId int not null,
	CourseName varchar(50) not null,
	CourseDescription varchar(255) null,
	GradeLevelId tinyint not null,
	IsArchived bit default 0 not null,
	StartDate date not null,
	EndDate date not null
)
GO

ALTER TABLE Course
	ADD CONSTRAINT FK_Course_Teacher FOREIGN KEY (TeacherId)
		REFERENCES dbo.LmsUser(UserId),
	CONSTRAINT FK_Course_Subject FOREIGN KEY (SubjectId)
		REFERENCES [Subject](SubjectId),
	CONSTRAINT FK_Course_GradeLevel FOREIGN KEY (GradeLevelId)
		REFERENCES GradeLevel(GradeLevelId)
GO

CREATE TABLE StudentGuardian(
	GuardianId int not null,
	StudentId int not null,
	Constraint PK_StudentGuardian PRIMARY KEY (GuardianId, StudentId)
)
GO

ALTER TABLE StudentGuardian
	ADD CONSTRAINT FK_StudentGuardian_Student FOREIGN KEY (StudentId)
		REFERENCES dbo.LmsUser(UserId),
	CONSTRAINT FK_StudentGuardian_Guardian FOREIGN KEY (GuardianId)
		REFERENCES dbo.LmsUser(UserId)
GO

CREATE TABLE Assignment(
    "AssignmentId" int identity(1,1) primary key not null,
    "CourseId" int not null,
    "AssignmentName" varchar(50) not null,
    "PossiblePoints" int not null,
    "DueDate" date not null,
    "AssignmentDescription" varchar(255) not null
)
GO

ALTER TABLE Assignment
	ADD CONSTRAINT FK_Assignment_Course FOREIGN KEY (CourseId)
		REFERENCES dbo.Course(CourseId)
GO

CREATE TABLE Roster (
    "RosterId" int identity(1,1) primary key not null,
    "CourseId" int not null,
    "UserId" int not null,
    "CurrentGrade" varchar(3) null,
    "IsDeleted" bit default 0 not null
)
GO

ALTER TABLE Roster
	ADD CONSTRAINT FK_Roster_Course FOREIGN KEY (CourseId)
		REFERENCES dbo.Course(CourseId),
	CONSTRAINT FK_Roster_Student FOREIGN KEY (UserId)
		REFERENCES dbo.LmsUser(UserId)
GO

CREATE TABLE RosterAssignment(
    "RosterAssignmentId" int identity(1,1) primary key not null,
    "RosterId" int not null,
    "AssignmentId" int not null,
    "PointsEarned" decimal(5,2) null,
    "Percentage" decimal(5,2) null,
    "Grade" varchar(3) null
)
GO

ALTER TABLE RosterAssignment
	ADD CONSTRAINT FK_RosterAssignment_Roster FOREIGN KEY (RosterId)
		REFERENCES dbo.Roster(RosterId),
	CONSTRAINT FK_RosterAssignment_Assignment FOREIGN KEY (AssignmentId)
		REFERENCES dbo.Assignment(AssignmentId)
GO
