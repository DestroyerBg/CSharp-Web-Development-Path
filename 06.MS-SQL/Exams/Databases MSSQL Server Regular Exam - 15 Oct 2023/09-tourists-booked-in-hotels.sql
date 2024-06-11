SELECT 
	h.[Name],
	r.Price
	FROM Bookings AS b
JOIN Tourists AS t ON t.Id = b.TouristId
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC


