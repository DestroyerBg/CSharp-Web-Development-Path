USE Geography
GO

SELECT  MountainRange,PeakName, Elevation
	FROM Mountains as m
	JOIN Peaks as p
	ON p.MountainId = m.Id AND m.MountainRange = 'Rila'
	ORDER BY Elevation DESC