SELECT TOP(5) d.CountryName, d.Elevation, d.[Length]
FROM
(
SELECT DISTINCT c.CountryName, p.Elevation, r.[Length],
	DENSE_RANK()
	OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeaksRanking,
	DENSE_RANK()
	OVER(PARTITION BY c.CountryName ORDER BY r.[Length] DESC) AS RiversRanking
	FROM Countries AS c
	JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	JOIN Peaks AS p
	ON p.MountainId = mc.MountainId
	JOIN CountriesRivers as cr
	ON cr.CountryCode = c.CountryCode
	JOIN Rivers AS r
	ON r.Id = cr.RiverId

) AS d
WHERE d.PeaksRanking = 1 AND d.RiversRanking = 1
ORDER BY d.Elevation DESC, d.[Length] DESC, d.CountryName
