SELECT 
	d.[Name],
	COUNT(d.PassengerName)
FROM
(
	SELECT 
		tns.[Name],
		p.[Name] AS PassengerName
		FROM Tickets AS ts
	JOIN Trains AS tt
	ON tt.Id = ts.TrainId
	JOIN Towns AS tns
	ON tns.Id = tt.ArrivalTownId
	JOIN Passengers AS p
	ON p.Id = ts.PassengerId
	WHERE ts.Price > 76.99
) AS d
GROUP BY d.[Name]
ORDER BY d.[Name]




