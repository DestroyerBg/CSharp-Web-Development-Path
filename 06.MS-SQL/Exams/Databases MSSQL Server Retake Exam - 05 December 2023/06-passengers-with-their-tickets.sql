SELECT 
		p.[Name],
		t.Price,
		t.DateOfDeparture,
		t.TrainId
	FROM Tickets AS t
JOIN Passengers AS p
ON p.Id = t.PassengerId
ORDER BY t.Price DESC, p.[Name]
