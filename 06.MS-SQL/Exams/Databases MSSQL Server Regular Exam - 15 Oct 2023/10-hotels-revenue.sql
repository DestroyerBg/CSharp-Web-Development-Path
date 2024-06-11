SELECT 
	d.HotelName AS HotelName,
	SUM(d.Price * NightsCount) AS HotelRevenue
FROM
(
SELECT 
	DATEDIFF(DAY,b.ArrivalDate, b.DepartureDate) AS NightsCount,
	r.Price,
	h.[Name] AS HotelName
	FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
) AS d
GROUP BY d.HotelName
ORDER BY HotelRevenue DESC