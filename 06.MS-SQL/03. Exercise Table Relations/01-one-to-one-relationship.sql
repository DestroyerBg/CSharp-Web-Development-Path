CREATE DATABASE Exercise
USE Exercise
GO

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(50) UNIQUE
)

INSERT INTO Passports 
		VALUES  (101,'N34FG21B'),
				(102,'K65LO4R7'),
				(103,'ZE657QP2')

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT UNIQUE REFERENCES Passports(PassportID)

)

INSERT INTO Persons(FirstName,Salary,PassportID)
			VALUES	('Roberto', 43300,102),
					('Tom', 56100,103),
					('Yana', 60200,101)

SELECT * FROM Persons