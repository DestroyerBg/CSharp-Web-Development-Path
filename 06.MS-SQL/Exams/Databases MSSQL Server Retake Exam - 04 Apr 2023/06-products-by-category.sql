SELECT 
	p.Id,
	p.[Name],
	p.Price,
	c.[Name]
	FROM Products AS p
JOIN Categories AS c ON c.Id = p.CategoryId
WHERE c.[Name] = 'ADR' OR c.[Name] = 'Others'
ORDER BY p.Price DESC
