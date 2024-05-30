SELECT TOP(5)
	d.CountryName, 
	CASE
	WHEN d.PeakName IS NULL THEN '(no highest peak)'
	ELSE d.PeakName
	END AS 'Highest Peak Name', 
	CASE
	WHEN d.Elevation IS NULL THEN 0
	ELSE d.Elevation
	END AS 'Highest Peak Elevation',
	CASE
	WHEN d.MountainRange IS NULL THEN '(no mountain)'
	ELSE d.MountainRange
	END AS 'Mountain'
FROM
(
SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange,
	DENSE_RANK()
	OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeaksRanking
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m
	ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p
	ON p.MountainId = m.Id
) AS d
WHERE d.PeaksRanking = 1
ORDER BY d.CountryName, d.PeakName