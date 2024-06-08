CREATE OR ALTER PROCEDURE usp_SearchByTown(@townName VARCHAR(MAX))
AS
BEGIN
	SELECT 
		p.[Name] AS PassengerName,
		t.DateOfDeparture,
		ts.HourOfDeparture
	FROM Tickets AS t
	JOIN Passengers AS p
	ON p.Id = t.PassengerId
	JOIN Trains AS ts
	ON ts.Id = t.TrainId
	JOIN Towns AS c
	ON c.Id = ts.ArrivalTownId
	WHERE c.[Name] = @townName
	ORDER BY t.DateOfDeparture DESC, p.[Name]
END

EXEC usp_SearchByTown 'Berlin'


