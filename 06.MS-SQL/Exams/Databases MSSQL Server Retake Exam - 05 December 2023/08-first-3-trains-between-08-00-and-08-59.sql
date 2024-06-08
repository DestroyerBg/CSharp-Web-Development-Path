SELECT TOP(3)
	tt.Id AS TrainId,
	tt.HourOfDeparture,
	ts.Price,
	tns.[Name]
		
	FROM Trains AS tt
JOIN Tickets AS ts
ON ts.TrainId = tt.Id
JOIN Towns AS tns
ON tns.Id = tt.ArrivalTownId
WHERE CAST(HourOfDeparture AS TIME) BETWEEN CAST('08:00' AS TIME) AND CAST('08:59' AS TIME)
									AND ts.Price > 50.00
ORDER BY ts.Price


