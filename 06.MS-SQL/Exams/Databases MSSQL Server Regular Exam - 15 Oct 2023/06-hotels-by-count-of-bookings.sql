SELECT 
	d.Id,
	d.[Name]
FROM
(
SELECT h.Id, 
	h.[Name] 
	FROM Hotels AS h
JOIN Bookings AS b ON h.Id = b.HotelId
JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
JOIN Rooms AS r ON r.[Id] = hr.RoomId
	WHERE r.[Type] = 'VIP Apartment'
) AS d
GROUP BY d.Id, d.[Name]
ORDER BY COUNT(*) DESC


