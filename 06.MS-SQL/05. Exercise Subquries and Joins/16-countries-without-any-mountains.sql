SELECT COUNT(d.[Count]) as [Count]
FROM
(
SELECT COUNT(mc.MountainId) as [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId is NULL
	GROUP BY c.CountryName, mc.MountainId
) AS d	