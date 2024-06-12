CREATE FUNCTION udf_ProductWithClients(@name VARCHAR(50))
RETURNS INT
BEGIN
DECLARE @result INT
	SELECT @result = COUNT(*) 
	FROM
	(
	SELECT 
		c.[Name]
		FROM Products AS p
	JOIN ProductsClients AS pc ON pc.ProductId = p.Id
	JOIN Clients AS c ON c.Id = pc.ClientId
	WHERE p.[Name] = @name
	GROUP BY c.[Name]
	) AS d
RETURN @result
END

SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')