SELECT d.[Name],
		MAX(d.Price) AS Price,
		d.NumberVAT
FROM 
(
SELECT 
	c.[Name],
	p.Price,
	c.NumberVAT
	FROM Clients AS c
JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Products AS p ON p.Id = pc.ProductId
WHERE c.[Name] NOT LIKE '%KG'
) AS d
GROUP BY d.[Name],
	d.NumberVAT
ORDER BY Price DESC
