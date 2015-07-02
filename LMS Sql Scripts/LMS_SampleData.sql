use SWC_LMS
go

create procedure spPopulateGradeLevel as

insert into GradeLevel (GradeLevelName)
values ('Kindergart'), ('1st'), ('2nd'), ('3rd'), ('4th'), ('5th'), ('6th'), 
	                   ('7th'), ('8th'), ('9th'), ('10th'), ('11th'), ('12th')	
go

CREATE PROCEDURE spPopulateAspRoles AS
	INSERT INTO AspNetRoles(Id, Name)
	VALUES ('95638512-d7fd-4fe4-8c7b-e474c2b0db7d', 'Admin'),
		   ('6edd03d3-f7e7-456c-8d2d-763add266130', 'Parent'),
		   ('ef8ae5b0-e5af-4e6a-9d0f-88bd23f95d54', 'Student'),
		   ('a5a42f98-820f-4788-90a3-f6232d6d1acf', 'Teacher')
GO

CREATE procedure spPopulateLmsUser as

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
go

create procedure spPopulateSubject as
insert into [Subject] (SubjectName)
values	('Math'), ('Science'), ('History'), ('Literature')
go

CREATE procedure spPopulateCourse as
insert into Course (TeacherId, SubjectId, CourseName, CourseDescription, GradeLevelId, StartDate, EndDate, IsArchived)
values (5, 1, 'Algebra I', 'Learn the fundamentals of algebra', 9, '20150801', '20151220', 0),
	   (5, 1, 'Geometry', 'Learn the fundamentals of geometry', 10, '20150801', '20151220', 0),
	   (5, 3, 'American History I', 'American History from 1776 to 1865', 9, '20150801', '20151220', 0),
	   (5, 3, 'American History II', 'American History from 1866 to 2001', 10, '20150801', '20151220', 0),
	   (5, 3, 'American History III', 'American History from 2001 to 2012', 10, '20130801', '20131220', 1)
insert into Roster (CourseId, UserId)
values (1, 1), (3, 1), (2, 3), (4, 3), (5, 3)
go

CREATE procedure spPopulateAssignments as
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

create procedure spDeleteAllTableData AS
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

--run scripts

create PROCEDURE spRebuildDataBase AS

	exec spDeleteAllTableData
	exec spPopulateGradeLevel
	exec spPopulateAspRoles
	exec spPopulateSubject
	exec spPopulateLmsUser
	exec spPopulateCourse
	exec spPopulateAssignments
GO

exec spRebuildDataBase
