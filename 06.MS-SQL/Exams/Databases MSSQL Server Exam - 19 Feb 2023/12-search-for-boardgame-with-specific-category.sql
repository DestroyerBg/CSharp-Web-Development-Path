CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(MAX)) 
AS
BEGIN
	SELECT 
		b.[Name],
		b.YearPublished,
		b.Rating,
		c.[Name],
		p.[Name],
		CONCAT_WS(' ',pr.PlayersMin, 'people') AS MinPlayers,
		CONCAT_WS(' ',pr.PlayersMax, 'people') AS MaxPlayers
		FROM Boardgames AS b
	JOIN Categories AS c ON c.Id = b.CategoryId
	JOIN Publishers AS p ON p.Id = b.PublisherId
	JOIN PlayersRanges as pr ON pr.Id = b.PlayersRangeId
	WHERE c.[Name] = @category
	ORDER BY p.[Name], b.YearPublished DESC
END

EXEC usp_SearchByCategory 'Wargames'