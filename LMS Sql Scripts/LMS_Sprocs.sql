use SWC_LMS
go
	
--------------------------------------------------------------
--Course-related sprocs
--------------------------------------------------------------

create procedure spAddCourse(
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
---------------------------------------------

create procedure spGetCourseById(
	@CourseId int
) AS

select CourseId, TeacherId, SubjectId, CourseName, CourseDescription, GradeLevelId, IsArchived, StartDate, EndDate from Course
where CourseId = @CourseId
GO

--------------------------------------------------------------
CREATE PROCEDURE spGetCourseDetailsById(
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

--------------------------------------------------------------

CREATE PROCEDURE spUpdateCourseInformation (
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


--------------------------------------------------------------
CREATE PROCEDURE spAddAssignment(
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
WHERE CourseId = @CourseId

COMMIT TRANSACTION
go

--------------------------------------------------------------

create procedure spAddRosterAssignment (
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
go

--------------------------------------------------------------
--User-management-related sprocs
--------------------------------------------------------------

create procedure spAddUser(
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

go

--------------------------------------------------------------
create procedure spRemoveGuardianRelationships(
	@GuardianId int
) AS

DELETE StudentGuardian
WHERE GuardianId = @GuardianId
GO

--------------------------------------------------------------


create procedure spAddStudentGuardian(
	@StudentId int,
	@GuardianId int
) AS

INSERT INTO StudentGuardian (GuardianId, StudentId) VALUES (@GuardianId, @StudentId)
GO

---------------------------------------------
CREATE PROCEDURE spUpdateUserDetails(
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

--------------------------------------------------------------
--For Parent View
--------------------------------------------------------------

create procedure spGetStudentsByGuardianId(
	@GuardianId int
) AS

select UserId, FirstName, LastName from LmsUser
	inner join StudentGuardian on UserId = StudentId
where GuardianId = @GuardianId
go

--------------------------------------------------------------
--For Student View
--------------------------------------------------------------
CREATE PROCEDURE spGetGradedAssignmentsForStudentInCourse (
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

---------------------------------------------

create procedure spGetCoursesByStudentId(
	@StudentId int
) AS

SELECT c.CourseId, CourseName, r.CurrentGrade
FROM Course AS c
	INNER JOIN Roster As r
	ON c.CourseId = r.CourseId
WHERE UserId = @StudentId
AND r.IsDeleted = 0

GO


---------------------------------------------
--Gradebook & Grade-related sprocs
---------------------------------------------
CREATE PROCEDURE spGetGradebookForCourseId (
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
WHERE r.CourseId = @CourseId AND r.IsDeleted = 0 
GO
---------------------------------------------

CREATE PROCEDURE spUpdateStudentCourseGrade (
	@RosterId int,
	@CurrentGrade varchar(3)
) AS

UPDATE Roster
	SET CurrentGrade = @CurrentGrade
	WHERE RosterId = @RosterId
GO

---------------------------------------------

create procedure spUpdateRosterAssignment(
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
Go

---------------------------------------------


CREATE PROCEDURE spGetGradedAssignmentsByRosterId(
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

---------------------------------------------
--Course Roster: Adding/Removing Students
---------------------------------------------

CREATE PROCEDURE spGetStudentsByCourseId (
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

---------------------------------------------
CREATE PROCEDURE spFindStudentsNotEnrolledInCourse(
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

---------------------------------------------

CREATE PROCEDURE spGetCoursesByTeacherId (
	@TeacherId int
) AS
SELECT c.CourseId, CourseName, IsArchived, (SELECT Count(RosterId) FROM Roster r WHERE r.CourseId = c.CourseId AND r.IsDeleted = 0) AS NumOfStudents
FROM Course c 
WHERE c.TeacherId = @TeacherId
GROUP BY c.IsArchived, c.CourseId, c.CourseName
GO

--------------------------------------------------------------

CREATE PROCEDURE spAddStudentToCourse (
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
---------------------------------------------

CREATE PROCEDURE spRemoveStudentFromCourse(
	@StudentId int,
	@CourseId int
)AS
BEGIN TRANSACTION

UPDATE Roster
	SET IsDeleted = 1
	WHERE UserId = @StudentId AND CourseId = @CourseId

COMMIT TRANSACTION

GO


---------------------------------------------
--Subjects & Gradelevel CRUD
---------------------------------------------

CREATE PROCEDURE spGetAllGradeLevels
AS
SELECT GradeLevelId, GradeLevelName
FROM GradeLevel
GO

---------------------------------------------

create procedure spCreateSubject(
	@SubjectName varchar(50)
) AS

insert into [Subject] (SubjectName) values (@SubjectName)
go

---------------------------------------------

create procedure spGetAllSubject as

select SubjectId, SubjectName from [Subject]
go

---------------------------------------------

create procedure spUpdateSubject(
	@SubjectId int,
	@SubjectName varchar(50)
) as

update dbo.[Subject]
	set SubjectName = @SubjectName
where 
	SubjectId = @SubjectId
go


---------------------------------------------
-- These sprocs rely on AspNet Identity tables
---------------------------------------------

CREATE PROCEDURE spGetAllRoles 
AS
SELECT Id, Name
FROM AspNetRoles

GO
---------------------------------------------

CREATE PROCEDURE spGetAllUnassignedUsers
AS

SELECT LmsUser.FirstName, LmsUser.LastName, LmsUser.Email, LmsUser.SuggestedRole, 
	LmsUser.UserId, LmsUser.AspId, LmsUser.GradeLevelId
FROM LmsUser
	LEFT JOIN AspNetUsers ON AspNetUsers.Id = LmsUser.AspId
	LEFT JOIN AspNetUserRoles ON AspNetUserRoles.UserId = LmsUser.AspId
WHERE AspNetUserRoles.RoleId IS NULL

GO

---------------------------------------------

CREATE PROCEDURE spGetUserDetailsById (
	@UserId int
) AS

SELECT u.UserId, u.Email, u.FirstName, u.LastName, u.SuggestedRole, u.AspId, u.GradeLevelId
FROM LmsUser u	
WHERE u.UserId = @UserId
GO
---------------------------------------------

CREATE PROCEDURE spGetUserRolesByUserId(
	@UserId int	
) AS

SELECT r.Name, r.Id
FROM AspNetUserRoles ur
	INNER JOIN AspNetRoles r ON ur.RoleId = r.Id
WHERE ur.UserId = @UserId
GO

---------------------------------------------

CREATE PROCEDURE spUserSearch(
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

---------------------------------------------

CREATE PROCEDURE spGetUserRolesById(
	@UserId int
) AS

SELECT r.Name
FROM LmsUser u
	LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.AspId
	LEFT JOIN AspNetRoles r ON r.Id = ur.RoleId
WHERE u.UserId = @UserId
GO

CREATE PROCEDURE spUpdateUserRoles(
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

---------------------------------------------

CREATE PROCEDURE spGetLmsUserByAspId(
	@AspId nvarchar(128)
) AS

SELECT u.UserId, u.Email, u.FirstName, u.LastName, u.SuggestedRole, u.AspId, u.GradeLevelId
FROM LmsUser u	
WHERE u.AspId = @AspId
GO

---------------------------------------------

CREATE PROCEDURE spDeleteAssignment (
	@AssignmentId int
)AS

DELETE FROM RosterAssignment WHERE AssignmentId = @AssignmentId
DELETE FROM Assignment WHERE AssignmentId = @AssignmentId

GO

---------------------------------------------

CREATE PROCEDURE spGetAssignment (
	@AssignmentId int
) AS

SELECT AssignmentId, AssignmentName, PossiblePoints, DueDate, AssignmentDescription
FROM Assignment
WHERE AssignmentId = @AssignmentId

GO
---------------------------------------------

