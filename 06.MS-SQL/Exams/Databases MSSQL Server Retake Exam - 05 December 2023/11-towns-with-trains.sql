CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @result INT 
	SELECT @result = COUNT(*)
	FROM Trains AS t
	JOIN Towns AS ts
	ON ts.Id = t.ArrivalTownId OR ts.Id = t.DepartureTownId
	WHERE ts.[Name] = @name
	RETURN @result
END

SELECT dbo.udf_TownsWithTrains('Paris')





