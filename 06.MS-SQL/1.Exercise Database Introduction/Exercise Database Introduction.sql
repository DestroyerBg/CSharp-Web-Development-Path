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
DROP CONSTRAINT PK__Users__3214EC07A51C2314

ALTER TABLE Users
ADD PRIMARY KEY (Id, Username)

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

SELECT LastLoginTime FROM Users
