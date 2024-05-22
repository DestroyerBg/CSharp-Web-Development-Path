CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
)

INSERT INTO Students([Name])
			VALUES	('Mila'),
					('Toni'),
					('Ron')



CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL,
)

INSERT INTO Exams([Name])
			VALUES	('SpringMVC'),
					('Neo4j'),
					('Oracle 11g')





CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(StudentID) NOT NULL,
	ExamID INT REFERENCES Exams(ExamID) NOT NULL,
	PRIMARY KEY (StudentID,ExamID)
)

INSERT INTO StudentsExams(StudentID,ExamID)
			VALUES	(1,101),
					(1,102),
					(2,101)


