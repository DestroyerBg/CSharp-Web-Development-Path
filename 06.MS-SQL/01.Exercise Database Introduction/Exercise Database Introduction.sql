-- 01. Create Database

CREATE DATABASE Minions

-- 02. Create Tables

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

-- 03. Alter Minions Table

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REfERENCES Towns(Id)

-- 04. Insert Records in Both Tables



INSERT INTO Towns 
			VALUES (1, 'Sofia'),
					(2, 'Plovdiv'),
					(3, 'Varna')

INSERT INTO Minions 
			VALUES(1, 'Kevin', 22, 1),
					(2, 'Bob', 15, 3),
					(3, 'Steward', NULL, 2)


SELECT * FROM Towns
SELECT * FROM Minions


-- 05. Truncate Table Minions

TRUNCATE  TABLE Minions

SELECT * FROM Minions

--06 Drop All Tables

DROP TABLE Minions
DROP TABLE Towns

-- 07. Create Table People

CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1)
		CHECK(Gender IN ('m', 'f')) NOT NULL,
	Birthdate  DATETIME2 NOT NULL,
	Biography VARCHAR(MAX)
)


INSERT INTO People([Name], Gender, Birthdate)
			VALUES
			('Dinko Dinkov', 'm', '1999-05-05'),
			('Pencho Slavkov', 'm', '2000-08-12'),
			('Gosho Goshev', 'm', '2001-01-01'),
			('Joro Ignatov','m', '1992-05-12'),
			('Qmach Kochovala', 'm', '1990-06-03')


SELECT * FROM People


-- 08. Create Table Users

CREATE TABLE Users 
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture  VARBINARY(max),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)


INSERT INTO Users (Username, [Password])
			VALUES ('DestroyerBg', 'mnogoSumGotin'),
					('NitroBG', 'mnogoSumGotin!!!!!'),
					('Gabriel', 'gabi2002'),
					('BMWMafia', 'Mafiotite!!!!!'),
					('BMW760d', 'BMW760d')


-- 09. Change Primary key

ALTER TABLE Users 
DROP CONSTRAINT PK__Users__3214EC07E9E33F55

ALTER TABLE Users
ADD CONSTRAINT PK__Users_PKCombination
PRIMARY KEY (Id, Username)

-- 10. Add Check Constraint

ALTER TABLE Users
ADD CHECK (LEN(Password) >= 5)

-- test if check works -- throws an exception
INSERT INTO Users(Username, [Password])
					VALUES 
					('TEST', '123')

SELECT Username, [Password] FROM Users

-- 11. Set Default Value of a Field

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

-- check if new default value is working and it is

INSERT INTO Users (Username, [Password])
			VALUES ('Gabi2002', 'mnogoSumGotin')

-- 12. Set Unique Field

ALTER TABLE Users
DROP CONSTRAINT PK__Users_PKCombination

ALTER TABLE Users
ADD CONSTRAINT PK_Users_PKId
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT PK__Users_UniqueUsername
CHECK (LEN(Username) >= 3)

-- 13. Movies Database

CREATE DATABASE Movies
USE Movies


CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors (DirectorName)
		VALUES	('Baio Bakov'),
				('Pesho Peshev'),
				('Gosho Goshev'),
				('Gancho Ganchov'),
				('Canko Cankov')

SELECT * FROM Directors

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres (GenreName)
		VALUES	('Kriminalen'),
				('Komedia'),
				('Sapunka'),
				('Istoriq'),
				('Nauchna fantastika')

SELECT * FROM Genres


CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories (CategoryName)
		VALUES	('Serial'),
				('Igralev film'),
				('Durzost i krasota'),
				('Burzi i qrostni'),
				('Qmata')

SELECT * FROM Categories

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT,
	[Length] DECIMAL(5,2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating VARCHAR(MAX),
	Notes VARCHAR(MAX)
)


INSERT INTO Movies(Title,DirectorId, GenreId, CategoryId)
		VALUES ('Burzi i qrostni', 1, 1, 1),
				('Vlastelina na prastenite', 2, 2, 2),
				('Div', 3, 3, 3),
				('Cukur', 4, 4, 4),
				('Ben 10', 5, 5, 5)


SELECT * FROM Movies

-- 14. Car Rental Database

CREATE DATABASE CarRental
USE CarRental
Go

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(5,2),
	WeeklyRate DECIMAL(5,2),
	MonthlyRate DECIMAL(5,2),
	WeekendRate DECIMAL(5,2)
)

INSERT INTO Categories(CategoryName)
		VALUES	('Sportni'),
				('Luksozni'),
				('Every-day')

SELECT * FROM Categories

CREATE TABLE Cars 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(20) NOT NULL,
	Manufacter VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear INT,
	CategoryId INT NOT NULL,
	Doors INT,
	Picture VARBINARY,
	Condition VARCHAR(MAX),
	Available BIT NOT NULL,
)

INSERT INTO Cars (PlateNumber, Manufacter, Model, CategoryId, Available)
			VALUES('Â3293ÂÍ', 'Mercedes', '0345G', 1, 0),
					('Â8698TX', 'Solaris', 'Urbino18', 2, 1),
					('Â0951KÐ', 'Mercedes', '0405G/N', 2, 1)

SELECT * FROM Cars

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(100),
	Notes VARCHAR(MAX),
)

INSERT INTO Employees(FirstName, LastName)
		VALUES	('Gosho', 'Goshev'),
				('Pencho', 'Penchev'),
				('Baio', 'Baev')

SELECT * FROM Employees

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenseNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(50),
	City VARCHAR(50),
	ZIPCode INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenseNumber, FullName)
		VALUES ('driver1License', 'Baio Baev'),
				('driver2License', 'Pesho Peshev'),
				('driver3License', 'Gosho Goshev')

SELECT * FROM Customers

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeID INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL(5,2),
	KilometrageStart DECIMAL(5,2),
	KilometrageEnd DECIMAL(5,2),
	TotalKilometrage DECIMAL(5,2),
	StartDate DATETIME2 DEFAULT GETDATE() NOT NULL,
	EndDate DATETIME2 DEFAULT (DATEADD(DAY, 5, GETDATE())) NOT NULL,
	TotalDays INT,
	RateApplied DECIMAL(5,2),
	TaxRate DECIMAL(5,2),
	OrderStatus BIT NOT NULL,
	Notes VARCHAR(MAX),
)

INSERT INTO RentalOrders(EmployeeID,CustomerId,CarId,OrderStatus)
		VALUES	(1,1,1,1),
				(2,2,2,0),
				(3,3,3,1)

SELECT * FROM RentalOrders

-- 15. Hotel Database

CREATE DATABASE Hotel
USE Hotel
GO

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(30),
	Notes VARCHAR(MAX),
)

INSERT INTO Employees(FirstName, LastName)
		VALUES	('Baio','Baev'),
				('Peshov','Peshev'),
				('Gosho','Goshev')

SELECT * FROM Employees

CREATE TABLE Customers
(
	AccountNumber VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(50),
	EmergencyName VARCHAR(50),
	EmergencyNumber VARCHAR(50),
	Notes VARCHAR(MAX),
)

INSERT INTO Customers(AccountNumber, FirstName, LastName)
		VALUES	('Account1Number','Baio','Baev'),
				('Account2Number','Peshov','Peshev'),
				('Account3Number','Gosho','Goshev')

SELECT * FROM Customers

CREATE TABLE RoomStatus
(
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX),
)

INSERT INTO RoomStatus(RoomStatus)
		VALUES	(1),
				(0),
				(1)

SELECT * FROM RoomStatus


CREATE TABLE RoomTypes 
(
	RoomType BIT NOT NULL,
	Notes VARCHAR(MAX),
)

INSERT INTO RoomTypes(RoomType)
		VALUES	(1),
				(0),
				(1)

SELECT * FROM RoomTypes


CREATE TABLE BedTypes  
(
	BedType  BIT NOT NULL,
	Notes VARCHAR(MAX),
)

INSERT INTO BedTypes(BedType)
		VALUES	(1),
				(0),
				(1)

SELECT * FROM BedTypes

CREATE TABLE Rooms
(
	RoomNumber VARCHAR(50) NOT NULL, 
	RoomType VARCHAR(50) NOT NULL, 
	BedType VARCHAR(50), 
	Rate DECIMAL(5,2), 
	RoomStatus BIT NOT NULL, 
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, RoomStatus)
		VALUES	('RoomNumber1', 'Business', 1),
				('RoomNumber2', 'President', 1),
				('RoomNumber3', 'Regular', 0)

SELECT * FROM Rooms

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentRate DECIMAL(5,2),
	AccountNumber VARCHAR(50),
	FirstDateOccupied DATETIME2 DEFAULT GETDATE() NOT NULL,
	LastDateOccupied DATETIME2 DEFAULT (DATEADD(DAY, 10, GETDATE())) NOT NULL,
	TotalDays INT,
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(5,2),
	TaxAmount DECIMAL(5,2),
	PaymentTotal DECIMAL(5,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId)
		VALUES	(1),
				(3),
				(2)

SELECT * FROM Payments

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME2 DEFAULT GETDATE() NOT NULL,
	AccountNumber VARCHAR(50), 
	RoomNumber INT, 
	RateApplied DECIMAL(5,2), 
	PhoneCharge DECIMAL(5,2), 
	Notes VARCHAR(MAX)
) 

INSERT INTO Occupancies(EmployeeId)
		VALUES	(1),
				(3),
				(2)

SELECT * FROM Occupancies


-- 16. Create SoftUni Database

CREATE DATABASE Softuni
USE Softuni
GO

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
)


CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText VARCHAR(50),
	TownId INT REFERENCES Towns(Id) NOT NULL,
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50), 
	DepartmentId INT REFERENCES Departments(Id), 
	HireDate DATETIME2 DEFAULT GETDATE(), 
	Salary DECIMAL(6,2), 
	AddressId INT REFERENCES Addresses(Id)
)

-- 17. Backup Database - done
-- 18. Basic Insert

INSERT INTO Towns([Name])
		VALUES	('Sofia'),
				('Plovdiv'),
				('Varna'),
				('Burgas')



INSERT INTO Departments([Name])
		VALUES	('Engineering'),
				('Sales'),
				('Marketing'),
				('Software Development'),
				('Quality Assurance')


INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
		VALUES	('Ivan','Ivanov','Ivanov','.NET Developer', 4, '2013-02-01', 3500),
				('Petar','Petrov','Petrov','Senior Engineer', 1, '2004-03-02', 4000),
				('Maria','Petrov','Ivanova','Intern', 5, '2016-08-28', 525.25),
				('Georgi','Teziev','Ivanov','CEO', 2, '2007-12-09', 3000),
				('Peter','Pan','Pan','Intern', 3, '2016-08-28', 599.88)



SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

-- 20. Basic Select All Fields and Order Them

Select *
	FROM TOWNS
	ORDER BY [Name]


Select *
	FROM Departments
	ORDER BY [Name]

Select *
	FROM Employees
	ORDER BY Salary DESC


-- 21. Basic Select Some Fields
	
Select [Name]
	FROM TOWNS
	ORDER BY [Name]


Select [Name]
	FROM Departments
	ORDER BY [Name]

Select FirstName, LastName, JobTitle, Salary
	FROM Employees
	ORDER BY Salary DESC

-- 22.Increase Employees Salary

UPDATE Employees
	SET Salary = Salary + Salary * 0.1

Select  Salary
	FROM Employees

-- 23. Decrease Tax Rate

USE Hotel
GO
UPDATE Payments
	SET TaxRate = 100
	WHERE TaxRate = NULL

UPDATE Payments
	SET TaxRate = TaxRate - TaxRate*0.03

SELECT TaxRate FROM Payments

-- 24. Delete all records
	
	TRUNCATE TABLE Occupancies 
