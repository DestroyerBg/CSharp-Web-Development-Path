SELECT 
	t.Id, t.[Name], t.PhoneNumber
	FROM Bookings AS b
RIGHT JOIN Tourists AS t ON t.Id = b.TouristId
WHERE b.HotelId IS NULL
ORDER BY t.[Name]