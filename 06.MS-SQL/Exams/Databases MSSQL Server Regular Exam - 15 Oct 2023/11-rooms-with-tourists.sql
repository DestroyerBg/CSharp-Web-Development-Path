CREATE OR ALTER FUNCTION udf_RoomsWithTourists(@name VARCHAR(MAX))

RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = SUM(AdultsCount + ChildrenCount)
	FROM
	(
	SELECT 
		b.AdultsCount,
		b.ChildrenCount,
		r.[Type]
		FROM Bookings AS b
	JOIN Rooms AS r ON r.Id = b.RoomId
	WHERE r.[Type] = @name
	) d
	GROUP BY d.[Type]
	RETURN @result
END

SELECT dbo.udf_RoomsWithTourists('Double Room')
