CREATE DATABASE TableRelations

USE TableRelations
GO

--01.One-To-One Relationship
CREATE TABLE Persons (PersonID INT IDENTITY, FirstName VARCHAR(50), Salary DECIMAL(10, 2), PassportID INT)

CREATE TABLE Passports (PassportID INT IDENTITY(101, 1) PRIMARY KEY, PassportNumber VARCHAR(20))

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES ('Roberto', 43300.00, 102), ('Tom', 56100.00, 103), ('Yana', 60200.00, 101)

--SELECT * FROM Persons
INSERT INTO Passports (PassportNumber)
VALUES ('N34FG21B'), ('K65LO4R7'), ('ZE657QP2')

--SELECT * FROM Passports
--DROP TABLE Passports

--DROP TABLE Persons
ALTER TABLE Persons ADD PRIMARY KEY (PersonID)

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

--02.One-To-Many Relationship
CREATE TABLE Models(
	ModelID INT IDENTITY(101,1),
	[Name] VARCHAR(50),
	ManufacturerID INT
)

CREATE TABLE Manufacturers(
	ManufacturerID INT IDENTITY,
	[Name] VARCHAR(50),
	EstablishedOn DATE
)

--DROP TABLE Manufacturers
--SELECT * FROM Models
--SELECT * FROM Manufacturers

INSERT INTO Models([Name], [ManufacturerID])
	 VALUES ('X1',	1),
			('i6',1),
			('Model S',2),
			('Model X',2),
			('Model 3',2),
			('Nova',3)


INSERT INTO Manufacturers ([Name], EstablishedOn)
	 VALUES ('BMW', '07/03/1916'),
			('Tesla', '01/01/2003'),
			('Lada', '01/05/1966')

ALTER TABLE Models
ADD PRIMARY KEY (ModelID)

ALTER TABLE Manufacturers
ADD PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)


--03. Many-To-Many Relationship

CREATE TABLE Students(
	StudentID INT IDENTITY,
	[Name] VARCHAR(20)
)

INSERT INTO Students([Name])
	 VALUES ('Mila'),
			('Toni'),
			('Ron')

SELECT * FROM Students

ALTER TABLE Students
ADD PRIMARY KEY (StudentID)

CREATE TABLE Exams(
	ExamID INT IDENTITY(101,1),
	[Name] VARCHAR(20)
)

INSERT INTO Exams([Name])
	 VALUES ('SpringMVC'),
			('Neo4j'),
			('Oracle 11g')

SELECT * FROM Exams

ALTER TABLE Exams
ADD PRIMARY KEY (ExamID)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

INSERT INTO StudentsExams([StudentID], [ExamID])
	 VALUES (1,101),
			(1,102),
			(2,101),
			(3,103),
			(2,102),
			(2,103)

SELECT * FROM StudentsExams

ALTER TABLE StudentsExams
ADD PRIMARY KEY ([StudentID], [ExamID])

ALTER TABLE StudentsExams
ADD FOREIGN KEY ([StudentID]) REFERENCES Students([StudentID])

ALTER TABLE StudentsExams
ADD FOREIGN KEY ([ExamID]) REFERENCES Exams([ExamID])

--DROP TABLE StudentsExams

--04. Self-Referencing 

CREATE TABLE Teachers(
	[TeacherID] INT IDENTITY(101,1) NOT NULL,
	[Name] VARCHAR(20),
	[ManagerID] INT 
)

INSERT INTO [dbo].[Teachers]([Name],[ManagerID])
	 VALUES ('John',NULL),
			('Maya',106),
			('Silvia',106),
			('Ted',105),
			('Mark',101),
			('Greta',101)

SELECT * FROM [dbo].[Teachers]

ALTER TABLE [dbo].[Teachers]
ADD PRIMARY KEY ([TeacherID])

ALTER TABLE [dbo].[Teachers]
ADD FOREIGN KEY ([ManagerID]) REFERENCES [dbo].[Teachers]([TeacherID])

--05. Online Store Database
--CREATE DATABASE TableRelations_05
CREATE TABLE Cities(
	[CityID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Customers(
	[CustomerID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50),
	[Birthday] DATE,
	[CityID] INT
)

CREATE TABLE Orders(
	[OrderID] INT IDENTITY PRIMARY KEY,
	[CustomerID] INT
)

CREATE TABLE ItemTypes(
	[ItemTypeID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items(
	[ItemID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50),
	[ItemTypeID] INT 
)

CREATE TABLE OrderItems(
	[OrderID] INT NOT NULL,
	[ItemID] INT NOT NULL
)

ALTER TABLE [dbo].[Customers]
ADD FOREIGN KEY ([CityID]) REFERENCES [dbo].[Cities]([CityID])

ALTER TABLE [dbo].[Orders]
ADD FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers]([CustomerID])

ALTER TABLE [dbo].[Items]
ADD FOREIGN KEY ([ItemTypeID]) REFERENCES [dbo].[ItemTypes]([ItemTypeID])

ALTER TABLE [dbo].[OrderItems]
ADD FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders]([OrderID])

ALTER TABLE [dbo].[OrderItems]
ADD FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ItemID])

ALTER TABLE [dbo].[OrderItems]
ADD PRIMARY KEY ([OrderID],[ItemID])

--ALTER TABLE [OrderItems]
--ALTER COLUMN [OrderID] INT NOT NULL

--ALTER TABLE [OrderItems]
--ALTER COLUMN [ItemID] INT NOT NULL


--06. University Database

CREATE DATABASE TableRelations_06

USE TableRelations_06
GO

CREATE TABLE Majors(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Payments(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount DECIMAL(10,2),
	StudentID INT
)

CREATE TABLE Students(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber INT,
	StudentName VARCHAR(50),
	MajorID INT
)

CREATE TABLE Subjects(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Agenda(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,
	PRIMARY KEY (StudentID, SubjectID)
)

ALTER TABLE [dbo].[Students]
ADD FOREIGN KEY ([MajorID]) REFERENCES [dbo].[Majors]([MajorID])

ALTER TABLE [dbo].[Agenda]
ADD FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students]([StudentID])

ALTER TABLE [dbo].[Agenda]
ADD FOREIGN KEY ([SubjectID]) REFERENCES [dbo].[Subjects]([SubjectID])

ALTER TABLE [dbo].[Payments]
ADD FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students]([StudentID])


--09. *Peaks in Rila
USE Geography
GO

SELECT 
	  m.MountainRange,
	  p.PeakName,
	  p.Elevation
FROM Peaks AS p
INNER JOIN Mountains AS m ON p.MountainId=m.Id
WHERE m.MountainRange='Rila'
ORDER BY p.Elevation DESC