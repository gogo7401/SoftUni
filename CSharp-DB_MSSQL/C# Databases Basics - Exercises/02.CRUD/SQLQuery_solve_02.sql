--01.Examine the Databases
--Part I – Queries for SoftUni Database
USE SoftUni
GO

--02.Find All the Information About Departments
SELECT *
FROM Departments

--03.Find all Department Names
SELECT [Name]
FROM Departments

--04.Find Salary of Each Employee
SELECT [FirstName],
	[LastName],
	[Salary]
FROM [dbo].[Employees]

--05.Find Full Name of Each Employee
SELECT [FirstName],
	[MiddleName],
	[LastName]
FROM [dbo].[Employees]

--06.Find Email Address of Each Employee
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS 'Full Email Address'
FROM [dbo].[Employees]

--07.Find All Different Employees' Salaries
SELECT DISTINCT [Salary]
FROM [dbo].[Employees]

--08.Find All Information About Employees
SELECT *
FROM [dbo].[Employees]
WHERE [JobTitle] = 'Sales Representative'

--09.Find Names of All Employees by Salary in Range
SELECT [FirstName],
	[LastName],
	[JobTitle]
FROM [dbo].[Employees]
WHERE [Salary] BETWEEN 20000
		AND 30000

--10.Find Names of All Employees
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [Full Name]
FROM [dbo].[Employees]
WHERE [Salary] IN (
		25000,
		14000,
		12500,
		23600
		)

--11.Find All Employees Without a Manager
SELECT [FirstName],
	[LastName]
FROM [dbo].[Employees]
WHERE [ManagerID] IS NULL

--12.Find All Employees with a Salary More Than 50000
SELECT [FirstName],
	[LastName],
	[Salary]
FROM [dbo].[Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

--13.Find 5 Best Paid Employees.
SELECT TOP (5) [FirstName],
	[LastName]
FROM [dbo].[Employees]
ORDER BY [Salary] DESC

--14.Find All Employees Except Marketing
SELECT [FirstName],
	[LastName]
FROM [dbo].[Employees]
WHERE [DepartmentID] <> 4

--15.Sort Employees Table
SELECT *
FROM [dbo].[Employees]
ORDER BY [Salary] DESC,
	[FirstName] ASC,
	[LastName] DESC,
	[MiddleName] ASC
	--16.Create View Employees with Salaries
GO

CREATE VIEW V_EmployeesSalaries
AS
SELECT [FirstName],
	[LastName],
	[Salary]
FROM [dbo].[Employees]
	--17.Create View Employees with Job Titles
GO

CREATE VIEW V_EmployeeNameJobTitle
AS
SELECT [FirstName] + ' ' + ISNULL([MiddleName], '') + ' ' + [LastName] AS [Full Name],
	[JobTitle]
FROM [dbo].[Employees]
GO

SELECT *
FROM [V_EmployeeNameJobTitle]

--18.Distinct Job Titles
SELECT DISTINCT [JobTitle]
FROM [dbo].[Employees]

--19.Find First 10 Started Projects
SELECT TOP (10) *
FROM [dbo].[Projects]
ORDER BY [StartDate],
	[Name]

--20.Last 7 Hired Employees
SELECT TOP (7) [FirstName],
	[LastName],
	[HireDate]
FROM [dbo].[Employees]
ORDER BY [HireDate] DESC

--21.Increase Salaries
BEGIN TRANSACTION
UPDATE [dbo].[Employees]
SET [Salary] = [Salary] * 1.12
WHERE [DepartmentID] IN (
		SELECT [DepartmentID]
		FROM [dbo].[Departments]
		WHERE [Name] IN (
				'Engineering',
				'Tool Design',
				'Marketing',
				'Information Services'
				)
		)

SELECT [Salary]
FROM [dbo].[Employees]

--After this, you should restore the database to the original data
ROLLBACK TRANSACTION --This returns the database to the previous state

SELECT [Salary]
FROM [dbo].[Employees]

--Part II – Queries for Geography Database
USE GEOGRAPHY
GO

--22.All Mountain Peaks
SELECT [PeakName]
FROM [dbo].[Peaks]
ORDER BY [PeakName] ASC

--23.Biggest Countries by Population
SELECT TOP (30) [CountryName],
	[Population]
FROM [dbo].[Countries]
WHERE [ContinentCode] IN (
		SELECT [ContinentCode]
		FROM [dbo].[Continents]
		WHERE [ContinentName] = 'Europe'
		)
ORDER BY [Population] DESC,
	[CountryName] ASC

--countries by population, located in Europe
SELECT *
FROM [dbo].[Continents]

--24.*Countries and Currency (Euro / Not Euro)
SELECT *
FROM [dbo].[Countries]

SELECT [CountryName],
	[CountryCode],
	CASE 
		WHEN [CurrencyCode] = 'EUR'
			THEN 'Euro'
		ELSE 'Not Euro'
		END AS [Currency]
FROM [dbo].[Countries]
ORDER BY [CountryName] ASC

--Part III – Queries for Diablo Database
USE Diablo
GO
--25.All Diablo Characters
SELECT [Name]
FROM [dbo].[Characters]
ORDER BY [Name]