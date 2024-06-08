DELETE mr
FROM MaintenanceRecords AS mr
JOIN Trains AS t
ON t.Id = mr.TrainId
WHERE DepartureTownId = 3

DELETE ts
	FROM Tickets AS ts
JOIN Trains AS t
ON t.Id = ts.TrainId
WHERE t.DepartureTownId = 3

DELETE trs
FROM TrainsRailwayStations AS trs
JOIN Trains AS t
ON t.Id = trs.TrainId
WHERE DepartureTownId = 3

DELETE Trains
WHERE DepartureTownId = 3

SELECT COUNT(*) FROM Tickets
SELECT COUNT(*) FROM MaintenanceRecords
SELECT COUNT(*) FROM TrainsRailwayStations
SELECT COUNT(*) FROM Trains






