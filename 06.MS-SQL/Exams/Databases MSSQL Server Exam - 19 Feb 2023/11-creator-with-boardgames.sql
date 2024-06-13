CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(MAX))
RETURNS INT 
BEGIN
DECLARE @result INT
	SELECT  @result = COUNT(*) 
		FROM Boardgames AS b
	JOIN CreatorsBoardgames AS cb ON cb.BoardgameId = b.Id
	JOIN Creators AS c ON c.Id = cb.CreatorId
	WHERE c.FirstName = @name
	RETURN @result
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')