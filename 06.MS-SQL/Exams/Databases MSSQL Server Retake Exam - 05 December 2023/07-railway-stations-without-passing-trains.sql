SELECT t.[Name],
		rs.[Name]
	FROM TrainsRailwayStations AS trs
RIGHT JOIN RailwayStations AS rs
ON rs.Id = trs.RailwayStationId
RIGHT JOIN Towns AS t
ON t.Id = rs.TownId
WHERE trs.TrainId IS NULL
ORDER BY t.[Name], rs.[Name]