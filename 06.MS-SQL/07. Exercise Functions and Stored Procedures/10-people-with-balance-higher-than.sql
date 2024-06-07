CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan @number DECIMAL(18,4)
AS
BEGIN
SELECT ah.FirstName,
		ah.LastName
	FROM Accounts AS a
JOIN AccountHolders AS ah
ON  ah.Id = a.AccountHolderId
GROUP BY ah.FirstName,ah.LastName
HAVING SUM(Balance) >= @number
ORDER BY FirstName, LastName
END


EXEC usp_GetHoldersWithBalanceHigherThan 5

SELECT ah.FirstName,
		ah.LastName
	FROM Accounts AS a
JOIN AccountHolders AS ah
ON  ah.Id = a.AccountHolderId
GROUP BY ah.FirstName,
		ah.LastName
HAVING SUM(Balance) > 30000
ORDER BY FirstName, LastName
