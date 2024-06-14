SELECT * 
	FROM TouristsBonusPrizes AS tb
LEFT JOIN Tourists AS t ON t.Id = tb.TouristId

SELECT 
	t.[Name],
	t.Age,
	t.PhoneNumber,
	t.Nationality,
	CASE
	WHEN tb.BonusPrizeId IS NULL THEN '(no bonus prize)'
	ELSE b.[Name]
	END AS [Reward]
	FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tb ON t.Id = tb.TouristId
LEFT JOIN BonusPrizes AS b ON b.Id = tb.BonusPrizeId
ORDER BY t.[Name]
