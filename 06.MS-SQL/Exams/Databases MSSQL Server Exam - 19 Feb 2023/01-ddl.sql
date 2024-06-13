CREATE DATABASE Boardgames
USE Boardgames

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName VARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL,
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL,
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(10,2) NOT NULL,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	PublisherId INT REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT REFERENCES PlayersRanges(Id) NOT NULL,
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT REFERENCES Creators(Id) NOT NULL,
	BoardgameId INT REFERENCES Boardgames(Id) NOT NULL,
	CONSTRAINT pk_CreatorBoardGames PRIMARY KEY(CreatorId, BoardgameId)
)


