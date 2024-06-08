SELECT 
	t.Id AS TrainId,
	ts.[Name],
	m.Details
	FROM MaintenanceRecords AS m
JOIN Trains AS t
ON t.Id = m.TrainId
JOIN Towns AS ts
ON ts.Id = t.DepartureTownId
WHERE m.Details LIKE '%inspection%'
ORDER BY t.Id