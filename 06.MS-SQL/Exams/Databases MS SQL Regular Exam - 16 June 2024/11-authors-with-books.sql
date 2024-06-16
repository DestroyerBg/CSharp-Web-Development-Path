CREATE OR ALTER FUNCTION udf_AuthorsWithBooks(@name VARCHAR(MAX))
RETURNS INT
BEGIN
DECLARE @result INT;
	SELECT
		@result = COUNT(*)
	FROM
	(
	SELECT 
		a.[Name]
		FROM Books AS b
	JOIN Authors AS a ON b.AuthorId = a.Id
	WHERE a.[Name] = @name
	) AS d
	GROUP BY d.[Name]
RETURN @result
END

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling')