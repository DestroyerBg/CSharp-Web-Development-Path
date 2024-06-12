SELECT
	d.[Name] AS Client,
	FLOOR(AVG(d.Price)) 'Average Price'
FROM 
(
SELECT 
	c.[Name],
	p.Price
	FROM Clients AS c
JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Products AS p ON p.Id = pc.ProductId
JOIN Vendors AS v ON v.Id = p.VendorId
WHERE v.NumberVAT LIKE '%FR%'
) AS d
GROUP BY d.[Name]
ORDER BY 'Average Price', d.[Name] DESC
