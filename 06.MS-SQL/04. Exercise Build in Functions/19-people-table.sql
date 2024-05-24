USE Exercise

CREATE TABLE People
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
)

INSERT INTO People([Name],Birthdate)
		VALUES	('Gabriel', '2002-08-12'),
				('Baio', '2012-12-05'),
				('Bako', '1900-05-12')

SELECT [Name],
	DATEDIFF(YEAR, Birthdate,  GETDATE()) AS 'Age in Years',
	DATEDIFF(MONTH, Birthdate,  GETDATE()) AS 'Age in Months',
	DATEDIFF(DAY, Birthdate,  GETDATE()) AS 'Age in Days',
	DATEDIFF(MINUTE, Birthdate,  GETDATE()) AS 'Age in Minutes'
	FROM People