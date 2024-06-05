CREATE OR ALTER PROC usp_GetTownsStartingWith @SearchString NVARCHAR(50)
AS
BEGIN
	SELECT [Name] 
		FROM Towns
	WHERE SUBSTRING([Name], 1, LEN(@SearchString)) = @SearchString
END

EXEC usp_GetTownsStartingWith @SearchString = 'b'