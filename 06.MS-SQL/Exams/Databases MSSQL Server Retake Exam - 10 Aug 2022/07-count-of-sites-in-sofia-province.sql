SELECT 
	l.Province,
	l.Municipality,
	l.[Name],
	COUNT(l.[Name]) 
	FROM Sites AS s
JOIN Locations AS l ON l.Id = s.LocationId
WHERE l.Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.[Name]
ORDER BY COUNT(l.[Name]) DESC, l.[Name]
