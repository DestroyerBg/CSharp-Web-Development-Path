CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(MAX))
AS
BEGIN
	DECLARE @countryId INT
	SELECT @countryId = id FROM Countries WHERE [Name] = @country
	SELECT 
		t.[Name],
		t.PhoneNumber,
		t.Email,
		COUNT(*) AS CountOfBookings
		FROM Bookings AS b
	JOIN Tourists AS t ON t.Id = b.TouristId
	JOIN Hotels AS h ON h.Id = b.HotelId
	JOIN Destinations AS d ON d.Id = h.DestinationId
	JOIN Countries AS c ON c.Id = d.CountryId
	WHERE t.CountryId = @countryId
	GROUP BY t.[Name], t.PhoneNumber, t.Email, t.CountryId
	ORDER BY COUNT(*) DESC
END

EXEC usp_SearchByCountry 'Greece'



