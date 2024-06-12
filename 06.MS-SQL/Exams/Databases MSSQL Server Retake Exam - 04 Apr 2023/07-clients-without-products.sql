SELECT 
	c.Id,
	c.[Name],
	CONCAT_WS(', ', CONCAT_WS(' ', a.StreetName, a.StreetNumber),a.City, a.PostCode, cs.[Name]) AS [Address]
	FROM Clients AS c
LEFT JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN Countries AS cs ON cs.Id = a.CountryId
WHERE pc.ProductId IS NULL
ORDER BY c.[Name]

