USE Bank

CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
SELECT CONCAT_WS(' ', FirstName, LastName) AS FullName
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName 