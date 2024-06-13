SELECT 
	d.LastName,
	CEILING(AVG(d.Rating)) AS AverageRating,
	d.[Name]
FROM
(
SELECT 
	c.LastName,
	b.Rating,
	p.[Name]
	FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] = 'Stonemaier Games'
) AS d
GROUP BY d.LastName, d.[Name]
ORDER BY AVG(d.Rating) DESC