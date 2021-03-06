USE [master]
GO
/****** Object:  Database [IndividualProjectBrief_Part_B]    Script Date: 30/04/2021 12:01:06 ******/
CREATE DATABASE [IndividualProjectBrief_Part_B]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IndividualProjectBrief_Part_B', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\IndividualProjectBrief_Part_B.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IndividualProjectBrief_Part_B_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\IndividualProjectBrief_Part_B_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IndividualProjectBrief_Part_B].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ARITHABORT OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET  MULTI_USER 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET QUERY_STORE = OFF
GO
USE [IndividualProjectBrief_Part_B]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[TuitionFees] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllStudents]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllStudents]
AS
SELECT *
FROM dbo.Students

GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[TrainerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllTrainers]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllTrainers]
AS
SELECT *
FROM dbo.Trainers

GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SubDateTime] [datetime] NOT NULL,
	[OralMark] [int] NULL,
	[TotalMark] [int] NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllAssignments]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AllAssignments]
AS
SELECT Ass.Title FROM (SELECT Title, COUNT(*) [Count] FROM Assignments GROUP BY Title) AS Ass

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Stream] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Start_Date] [date] NULL,
	[End_Date] [date] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[AllCourses]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AllCourses]
AS
SELECT *
FROM Courses
GO
/****** Object:  Table [dbo].[CoursesStudents]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesStudents](
	[CoursesStudentsId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_CoursesStudents_1] PRIMARY KEY CLUSTERED 
(
	[CoursesStudentsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Students_per_Course]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Students_per_Course]
AS
SELECT c.CourseId, c.Title AS Course_Title, s.StudentId, s.FirstName AS Student_FirstName, s.LastName AS Student_LastName 
FROM CoursesStudents cs
INNER JOIN Courses c ON c.CourseId = cs.CourseId
INNER JOIN Students s ON s.StudentId = cs.StudentId

GO
/****** Object:  Table [dbo].[CoursesTrainers]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesTrainers](
	[CoursesTrainersId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[TrainerId] [int] NOT NULL,
 CONSTRAINT [PK_CoursesTrainers] PRIMARY KEY CLUSTERED 
(
	[CoursesTrainersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Trainers_per_Course]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Trainers_per_Course]
AS
SELECT t.TrainerId
,t.FirstName AS Trainer_FirstName
,t.LastName AS Trainer_LastName
,c.CourseId
,c.Title AS Course_Title
FROM CoursesTrainers cs
INNER JOIN Trainers t ON cs.TrainerId = t.TrainerId
INNER JOIN Courses c ON cs.CourseId = c.CourseId


GO
/****** Object:  View [dbo].[Assignment_per_Course]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Assignment_per_Course]
AS
SELECT DISTINCT(a.Title) AS Assignment_Title, c.CourseId, c.Title AS Course_Title
FROM Assignments a
INNER JOIN Courses c ON a.CourseId = c.CourseId

GO
/****** Object:  View [dbo].[Assignments_per_Course_per_Student]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Assignments_per_Course_per_Student]
AS
SELECT DISTINCT(a.Title) AS Assignment_Title, c.CourseId, c.Title AS Course_Title, s.StudentId, s.Firstname AS Student_FirstName, s.LastName AS Student_LastName
FROM Assignments a
INNER JOIN Courses c ON a.CourseId = c.CourseId
INNER JOIN Students s ON a.StudentId = s.StudentId

GO
/****** Object:  View [dbo].[Students_In_More_Than_One_Course]    Script Date: 30/04/2021 12:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Students_In_More_Than_One_Course]
AS
SELECT s.StudentId, s.FirstName, s.LastName, COUNT(*) AS NumberOfCourses
FROM CoursesStudents cs
INNER JOIN Students s ON cs.StudentId = s.StudentId
GROUP BY s.StudentId, s.FirstName, s.LastName
HAVING COUNT(*) > 1

GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (19, N'Budget Analysis', N'Financial analysis of project', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 70, 30, 2, 1)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (20, N'Class Diagram', N'Programs class diagram', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 10, 90, 3, 2)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (21, N'ERD Diagram', N'Database diagram', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 10, 90, 4, 3)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (22, N'Systems Analysis', N'Systems analysis', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 40, 60, 5, 4)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (23, N'Business Plan', N'Presentation of the business plan', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 70, 30, 6, 5)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (24, N'Bug Analysis', N'Work item management - git', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 7, 1)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (25, N'Software Development A', N'Software Implementation Part A', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 8, 2)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (26, N'Software Development B', N'Software Implementation', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 9, 3)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (27, N'QA Testing Methods', N'Testing methodologies', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 10, 4)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (28, N'Systems Analysis', N'Systems analysis', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 40, 60, 1, 5)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (29, N'Business Plan', N'Presentation of the business plan', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 70, 30, 2, 1)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (30, N'Bug Analysis', N'Work item management - git', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 3, 3)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (31, N'Software Development A', N'Software Implementation Part A', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 4, 4)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (32, N'Software Development B', N'Software Implementation', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 5, 5)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (33, N'QA Testing Methods', N'Testing methodologies', CAST(N'2021-05-26T21:00:00.000' AS DateTime), 0, 100, 6, 6)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (51, N'Django', N'Web dev', CAST(N'2021-05-30T00:00:00.000' AS DateTime), 10, 10, 14, 11)
INSERT [dbo].[Assignments] ([AssignmentId], [Title], [Description], [SubDateTime], [OralMark], [TotalMark], [CourseId], [StudentId]) VALUES (52, N'Django', N'Web dev', CAST(N'2021-05-30T00:00:00.000' AS DateTime), 10, 10, 14, 12)
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (1, N'Adobe illustrator', N'Graphics & Engineering Designing', N'Design', CAST(N'2021-03-26' AS Date), CAST(N'2021-03-26' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (2, N'Advanced Administration for Citrix', N'Systems Engineering', N'Virtual Machines', CAST(N'2021-04-23' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (3, N'Fundamentals of Unix', N'Systems Engineering', N'Operation Systems', CAST(N'2021-04-25' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (4, N'Microsoft Azure', N'MS Engineering', N'Cloud Technologies', CAST(N'2021-04-29' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (5, N'Oracle E-Business Suite', N'Informatics', N'CRM', CAST(N'2021-04-30' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (6, N'Dynamics of Information Security', N'Security Engineering', N'Security Technologies', CAST(N'2021-04-30' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (7, N'Systems Analysis', N'Systems Analysis', N'Systems Analytics', CAST(N'2021-05-01' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (8, N'Digital Marketing', N'Marketing', N'Digital Marketing Engineering', CAST(N'2021-06-01' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (9, N'Office 365', N'Infrastructure', N'IT Infrastructure', CAST(N'2021-07-01' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (10, N'Advanced Geographic Information Systems', N'Information Systems', N'Geographic Systems', CAST(N'2021-08-01' AS Date), CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (11, N'Unity 101', N'Game dev', N'Gaming', CAST(N'2021-04-24' AS Date), CAST(N'2021-04-30' AS Date))
INSERT [dbo].[Courses] ([CourseId], [Title], [Stream], [Type], [Start_Date], [End_Date]) VALUES (14, N'Python 101', N'Software dev', N'Software', CAST(N'2021-04-30' AS Date), CAST(N'2030-05-21' AS Date))
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[CoursesStudents] ON 

INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (1, 1, 1)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (2, 1, 2)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (3, 1, 3)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (4, 1, 4)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (5, 1, 5)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (6, 2, 6)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (7, 2, 7)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (8, 2, 8)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (10, 2, 9)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (11, 2, 10)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (12, 3, 1)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (13, 4, 2)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (14, 5, 3)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (15, 6, 4)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (16, 7, 5)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (17, 8, 6)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (19, 9, 10)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (20, 10, 1)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (38, 14, 11)
INSERT [dbo].[CoursesStudents] ([CoursesStudentsId], [CourseId], [StudentId]) VALUES (39, 11, 12)
SET IDENTITY_INSERT [dbo].[CoursesStudents] OFF
GO
SET IDENTITY_INSERT [dbo].[CoursesTrainers] ON 

INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (1, 1, 1)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (2, 2, 2)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (3, 3, 3)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (4, 4, 4)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (5, 5, 5)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (6, 6, 6)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (7, 7, 7)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (8, 8, 8)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (9, 9, 9)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (10, 10, 10)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (11, 5, 1)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (12, 6, 2)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (13, 7, 3)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (14, 8, 4)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (15, 9, 5)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (16, 10, 6)
INSERT [dbo].[CoursesTrainers] ([CoursesTrainersId], [CourseId], [TrainerId]) VALUES (25, 11, 7)
SET IDENTITY_INSERT [dbo].[CoursesTrainers] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (1, N'George', N'Kal', CAST(N'1994-10-19' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (2, N'Giannis', N'Pan', CAST(N'1988-06-10' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (3, N'Olia', N'Mour', CAST(N'1995-08-07' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (4, N'Antonis', N'Kat', CAST(N'1994-11-04' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (5, N'Nikos', N'Xen', CAST(N'1994-04-18' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (6, N'Alex', N'Kav', CAST(N'1993-03-16' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (7, N'Antreas', N'Plev', CAST(N'1992-09-01' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (8, N'Anastasia', N'Kalok', CAST(N'1986-08-24' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (9, N'Agapi', N'Kalok', CAST(N'1996-02-16' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (10, N'Ilias', N'Diam', CAST(N'1990-10-30' AS Date), 2000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (11, N'James', N'Bond', CAST(N'2010-10-10' AS Date), 1000)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [DateOfBirth], [TuitionFees]) VALUES (12, N'Bruno', N'Goet', CAST(N'1994-10-19' AS Date), 1000)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (1, N'Michael', N'Scott', N'Project Management')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (2, N'Dwight', N'Schrute', N'Sales Management')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (3, N'Jim', N'Halpert', N'Object Oriented Programming')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (4, N'Creed', N'Bratton', N'Electronics and TeleCommunication Systems')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (5, N'Pam', N'Beesly', N'Computer Graphics')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (6, N'Darryl', N'Philbin', N'DBMS Systems')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (7, N'Stanley', N'Hudson', N'Operating Systems')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (8, N'Andy', N'Bernard', N'Computer Organisation & Architecture')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (9, N'Kevin', N'Malone', N'Systems Programming')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (10, N'Kelly', N'Kapoor', N'Logic, Discrete Mathematical Structures')
INSERT [dbo].[Trainers] ([TrainerId], [FirstName], [LastName], [Subject]) VALUES (11, N'James', N'Bond', N'MI6')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Courses]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Students]
GO
ALTER TABLE [dbo].[CoursesStudents]  WITH CHECK ADD  CONSTRAINT [FK_CoursesStudents_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CoursesStudents] CHECK CONSTRAINT [FK_CoursesStudents_Courses]
GO
ALTER TABLE [dbo].[CoursesStudents]  WITH CHECK ADD  CONSTRAINT [FK_CoursesStudents_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[CoursesStudents] CHECK CONSTRAINT [FK_CoursesStudents_Students]
GO
ALTER TABLE [dbo].[CoursesTrainers]  WITH CHECK ADD  CONSTRAINT [FK_CoursesTrainers_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CoursesTrainers] CHECK CONSTRAINT [FK_CoursesTrainers_Courses]
GO
ALTER TABLE [dbo].[CoursesTrainers]  WITH CHECK ADD  CONSTRAINT [FK_CoursesTrainers_Trainers] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([TrainerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoursesTrainers] CHECK CONSTRAINT [FK_CoursesTrainers_Trainers]
GO
USE [master]
GO
ALTER DATABASE [IndividualProjectBrief_Part_B] SET  READ_WRITE 
GO
