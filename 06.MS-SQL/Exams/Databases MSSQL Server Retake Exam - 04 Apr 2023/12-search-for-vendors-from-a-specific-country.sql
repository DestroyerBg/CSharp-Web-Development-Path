CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(50)) 
AS
BEGIN
	SELECT 
		v.[Name],
		v.NumberVAT,
		CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info],
		CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
		FROM Countries AS c
	JOIN Addresses AS a ON a.CountryId = c.Id
	JOIN Vendors AS v ON v.AddressId = a.Id
	WHERE c.[Name] = @country
	ORDER BY v.[Name], c.[Name]
END

EXEC usp_SearchByCountry 'France'

