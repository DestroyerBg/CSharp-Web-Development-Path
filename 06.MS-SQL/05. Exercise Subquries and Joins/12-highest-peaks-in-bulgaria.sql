USE Geography

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	RIGHT JOIN Mountains AS m
	ON p.MountainId = m.Id
	RIGHT JOIN MountainsCountries AS mc
	ON m.Id = mc.MountainId
	RIGHT JOIN Countries AS C
	ON c.CountryCode = mc.CountryCode
	WHERE mc.CountryCode = 'BG' AND Elevation > 2835
	ORDER BY p.Elevation DESC
	

