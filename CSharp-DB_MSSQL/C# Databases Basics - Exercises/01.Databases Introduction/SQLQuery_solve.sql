--01.Create Database
CREATE DATABASE Minions

USE Minions
GO

--02.Create Tables
CREATE TABLE Minions 
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
	Age INT
)

CREATE TABLE Towns 
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
)

--03.Alter Minions Table
ALTER TABLE Minions
ADD TownId INT NOT NULL
FOREIGN KEY (TownId) REFERENCES Towns(Id)

--04.Insert Records in Both Tables
INSERT INTO Towns (Id, [Name])
VALUES	(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna');

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES	(1, 'Kevin', 22, 1),
		(2, 'Bob', 15, 3),
		(3, 'Steward', NULL, 2);

--
SELECT * FROM Towns
SELECT * FROM Minions

--05.Truncate Table Minions
TRUNCATE TABLE Minions

--06.Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

--07.Create Table People
CREATE TABLE People
(
	Id INT UNIQUE IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(2,2),
	[Weight] DECIMAL(2,2),
	Gender CHAR	CHECK (Gender IN ('m','f')) NOT NULL, 
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX),
)

ALTER TABLE People
ADD CONSTRAINT PK_People PRIMARY KEY (Id)

INSERT INTO People ([Name], Gender, Birthdate)
VALUES	('IVAN', 'm', '2000-01-01'),
('IVANKA', 'f', '2000-01-01'),
('IVAN', 'm', '2000-01-01'),
('IVANKA', 'f', '2000-01-01'),
('IVAN', 'm', '2000-01-01')

SELECT * FROM People
TRUNCATE TABLE People

--08.Create Table Users
CREATE TABLE Users
(
	Id BIGINT UNIQUE IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password]  VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id) 

INSERT INTO Users (Username, [Password])
VALUES	('IVAN', '123456'),
		('PETKAN', '123456'),
		('DRAGAN', '123456'),
		('USER', '123456'),
		('OPERATOR', '123456');

SELECT * FROM Users

--09.Change Primary Key
-- FIRST REMOVE PRIMARY KEY
ALTER TABLE Users
DROP CONSTRAINT PK_Users;

-- create a new primary key
ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)

--10.Add Check Constraint
ALTER TABLE Users
ADD CHECK (LEN([Password]) >= 5)

--11.Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_Users DEFAULT GETDATE() FOR LastLoginTime;

--
TRUNCATE TABLE Users

INSERT INTO Users (Username, [Password])
VALUES	('IVAN', '123456'),
		('PETKAN', '123456'),
		('DRAGAN', '123456'),
		('USER', '123456'),
		('OPERATOR', '123456');

SELECT * FROM Users
--

--12.Set Unique Field
-- FIRST REMOVE EXISTING PRIMARY KEY
ALTER TABLE Users
DROP CONSTRAINT PK_Users

-- CREATE NEW PRIMARY KEY
ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TABLE Users
ADD CHECK (LEN(Username) >= 3)

--13.Movies Database
CREATE DATABASE Movies

USE Movies
GO

-- Directors (Id, DirectorName, Notes)
CREATE TABLE Directors
(
	Id INT NOT NULL PRIMARY KEY, 
	DirectorName VARCHAR(50) NOT NULL, 
	Notes VARCHAR(200)
)

--Genres (Id, GenreName, Notes)
CREATE TABLE Genres
(
	Id INT NOT NULL PRIMARY KEY, 
	GenreName VARCHAR(100) NOT NULL, 
	Notes VARCHAR(200)
)
--Categories (Id, CategoryName, Notes)
CREATE TABLE Categories 
(
	Id INT NOT NULL PRIMARY KEY,
	CategoryName VARCHAR(100) NOT NULL, 
	Notes VARCHAR(200)
)
--Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
CREATE TABLE Movies 
(	Id INT NOT NULL PRIMARY KEY, 
	Title VARCHAR(200) NOT NULL, 
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id), 
	CopyrightYear DATETIME2, 
	[Length] TIME NOT NULL, 
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
	Rating NUMERIC(4,2), 
	Notes VARCHAR(200)
)

INSERT INTO Directors (Id, DirectorName)
VALUES	(1, 'DirectorName1'),
		(2, 'DirectorName2'),
		(3, 'DirectorName3'),
		(4, 'DirectorName4'),
		(5, 'DirectorName5');

INSERT INTO Categories (Id, CategoryName)
VALUES	(1, 'UNDER 18'),
		(2, 'FORBIDEN'),
		(3, 'TEST'),
		(4, 'TEST TEST'),
		(5, 'TEST 2 TEST');

INSERT INTO Genres (Id, GenreName)
VALUES	(1, 'ACTION'),
		(2, 'COMEDY'),
		(3, 'NONE'),
		(4, 'CRIMI'),
		(5, 'MISTERY');

INSERT INTO Movies (Id, Title, [Length], DirectorId, GenreId, CategoryId)
VALUES	(1, 'PARVI', '01:01:00', 1, 1, 1),
		(2, 'VTORI', '02:01:00', 2, 2, 2),
		(3, 'TRETI', '03:01:00', 3, 3, 3),
		(4, '4ETVARTI', '04:01:00', 4, 4, 4),
		(5, 'PETI', '05:01:00', 5, 5, 5);

SELECT * FROM Movies
TRUNCATE TABLE Movies

--14.Car Rental Database
CREATE DATABASE CarRental

USE CarRental
GO

--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories 
(
	Id INT PRIMARY KEY IDENTITY, 
	CategoryName VARCHAR(100) NOT NULL, 
	DailyRate NUMERIC(4,2), 
	WeeklyRate NUMERIC(4,2), 
	MonthlyRate NUMERIC(4,2), 
	WeekendRate NUMERIC(4,2)
)
--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars 
(
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber VARCHAR(10) NOT NULL, 
	Manufacturer VARCHAR(10) NOT NULL, 
	Model VARCHAR(10) NOT NULL, 
	CarYear INT, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
	Doors INT, 
	Picture VARBINARY(MAX), 
	Condition VARCHAR(100), 
	Available BIT
)
--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	Title VARCHAR(50), 
	Notes VARCHAR(200)
)
--Customers (Id, DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
CREATE TABLE Customers 
(
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber INT NOT NULL, 
	FullName VARCHAR(150) NOT NULL, 
	[Address] VARCHAR(100), 
	City VARCHAR(50), 
	ZIPCode INT, 
	Notes VARCHAR(200)
)
--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
	TankLevel NUMERIC(4,2), 
	KilometrageStart INT, 
	KilometrageEnd INT, 
	TotalKilometrage INT, 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied NUMERIC(4,2), 
	TaxRate DECIMAL(10,2), 
	OrderStatus BIT, 
	Notes VARCHAR(200)
)

INSERT INTO Categories (CategoryName)
VALUES	('VAN'),
		('SUV'),
		('WAGON');

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CategoryId)
VALUES	('A1234AA', 'AUDI', 'A3', 1),
		('B1234BB', 'MERCEDES', 'C220', 2),
		('C1234CC', 'TOYOTA', 'COROLLA', 3);

INSERT INTO Employees (FirstName, LastName)
VALUES	('IVAN', 'IVANOV'),
		('PETAR', 'PETROV'),
		('PETKAN', 'PETKANOV');

INSERT INTO Customers (DriverLicenceNumber, FullName)
VALUES	(12345678, 'FULL NAME1'),
		(123456789, 'FULL NAME2'),
		(1234567890, 'FULL NAME3');

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, OrderStatus)
VALUES	(1,1,1,1),
		(2,2,2,0),
		(3,3,3,1);

SELECT * FROM RentalOrders

--15.Hotel Database
CREATE DATABASE Hotel

USE Hotel
GO

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	Title VARCHAR(50), 
	Notes VARCHAR(200)
)
--Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers 
(
	AccountNumber VARCHAR(30),
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	PhoneNumber VARCHAR(20), 
	EmergencyName VARCHAR(150), 
	EmergencyNumber VARCHAR(20), 
	Notes VARCHAR(200),
	CONSTRAINT PK_Customer PRIMARY KEY (AccountNumber, FirstName, LastName)
)
--RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus 
(
	RoomStatus VARCHAR(50) PRIMARY KEY, 
	Notes VARCHAR(200)
)
--RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(50) PRIMARY KEY, 
	Notes VARCHAR(200)
)
--BedTypes (BedType, Notes)
CREATE TABLE BedTypes 
(
	BedType VARCHAR(50) PRIMARY KEY, 
	Notes VARCHAR(200)
)
--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY, 
	RoomType VARCHAR(50), 
	BedType VARCHAR(50), 
	Rate INT, 
	RoomStatus VARCHAR(50), 
	Notes VARCHAR(200)
)
--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	PaymentDate DATETIME2, 
	AccountNumber VARCHAR(30), 
	FirstDateOccupied DATETIME2, 
	LastDateOccupied DATETIME2, 
	TotalDays INT, 
	AmountCharged DECIMAL(10,2), 
	TaxRate DECIMAL(10,2), 
	TaxAmount DECIMAL(10,2), 
	PaymentTotal DECIMAL(10,2), 
	Notes VARCHAR(200)
)
--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	DateOccupied DATETIME2, 
	AccountNumber VARCHAR(30), 
	RoomNumber INT, 
	RateApplied NUMERIC(4,2), 
	PhoneCharge DECIMAL(10,2), 
	Notes VARCHAR(200)
)

INSERT INTO Employees (FirstName, LastName)
VALUES	('IVAN1', 'IVANOV1'),
		('IVAN2', 'IVANOV2'),
		('IVAN3', 'IVANOV3');

INSERT INTO Customers (AccountNumber, FirstName, LastName)
VALUES	('123', 'IVANA1', 'IVANOVA1'),
		('1234', 'IVANA2', 'IVANOVA2'),
		('12345', 'IVANA3', 'IVANOVA3');

INSERT INTO RoomStatus (RoomStatus)
VALUES	('FREE'),
		('CLOSE'),
		('NONE');

INSERT INTO RoomTypes (RoomType)
VALUES	('SINGLE'),
		('DOUBLE'),
		('APARTMENT');

INSERT INTO BedTypes (BedType)
VALUES	('SINGLE'),
		('DOUBLE'),
		('CHILDREN');

INSERT INTO Rooms (RoomNumber)
VALUES	(1),
		(2),
		(3);

INSERT INTO Payments (EmployeeId)
VALUES	(1),
		(2),
		(3);

INSERT INTO Occupancies (EmployeeId)
VALUES	(1),
		(2),
		(3);

--16.Create SoftUni Database
CREATE DATABASE SoftUni

USE SoftUni
GO

--Towns (Id, [Name])
CREATE TABLE Towns 
(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(100)
)
--Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(100),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)
--Departments (Id, [Name])
CREATE TABLE Departments 
(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(100)
)
--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50), 
	LastName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50), 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
	HireDate DATETIME2, 
	Salary DECIMAL(10,2), 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--17.Backup Database
--BackUp database use GUI -- SoftUni -> Tasks -> Back Up...
-- Delete (Drop) DATABASE SoftUni
DROP DATABASE SoftUni
-- Restore DATABASE SoftUni use GUI -- Databases - Restore Database...

--18.Basic Insert
SELECT * FROM Employees

--•	Towns: Sofia, Plovdiv, Varna, Burgas
INSERT INTO Towns (Name)
VALUES	('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas');
SELECT * FROM Towns

--•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO Departments(Name)
VALUES	('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Developmen'),
		('Quality Assurance');
SELECT * FROM Departments

--•	Employees:
--Name						Job Title		Department				Hire Date	Salary
--Ivan Ivanov Ivanov		.NET Developer	Software Development	01/02/2013	3500.00
--Petar Petrov Petrov		Senior Engineer	Engineering				02/03/2004	4000.00
--Maria Petrova Ivanova		Intern			Quality Assurance		28/08/2016	525.25
--Georgi Teziev Ivanov		CEO				Sales					09/12/2007	3000.00
--Peter Pan Pan				Intern			Marketing				28/08/2016	599.88

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES	('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-01-02',3500.00),
		('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
		('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
		('Georgi','Teziev','Ivanov','CEO',2,'2007-12-09',3000.00),
		('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88);
SELECT * FROM Employees

--19.Basic Select All Fields
-- first select all records from the Towns, then from Departments and finally from Employees table
SELECT * FROM Towns, Departments, Employees

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20.Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name] ASC;
SELECT * FROM Departments
ORDER BY [Name] ASC;
SELECT * FROM Employees
ORDER BY Salary DESC;

--21.Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name] ASC;
SELECT [Name] FROM Departments
ORDER BY [Name] ASC;
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

--22.Increase Employees Salary
UPDATE Employees
SET Salary = Salary * 1.1;

SELECT Salary FROM Employees

--23.Decrease Tax Rate
INSERT INTO Payments (TaxRate)
VALUES	(1.00),
		(100.00),
		(10.00);

UPDATE Payments
SET TaxRate = TaxRate - TaxRate * 0.03;

SELECT TaxRate FROM Payments

--24.Delete All Records
SELECT * FROM Occupancies

TRUNCATE TABLE Occupancies 