BEGIN TRANSACTION
	DELETE b
		FROM Bookings AS b
	JOIN Tourists AS t
	ON b.TouristId = t.Id
	WHERE t.[Name] LIKE '%Smith%'
	DELETE 
		FROM Tourists
	WHERE [Name] LIKE '%Smith%'

	
ROLLBACK TRANSACTION

