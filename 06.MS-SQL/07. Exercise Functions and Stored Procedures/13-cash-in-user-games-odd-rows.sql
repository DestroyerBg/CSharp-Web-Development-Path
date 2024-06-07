USE Diablo

CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS
RETURN

SELECT SUM(d.Cash) AS SumCash
FROM
(
SELECT
	ug.Cash, 
	ROW_NUMBER()
	OVER(ORDER BY ug.Cash DESC) AS RowRanking
	FROM UsersGames AS ug
	JOIN  Games AS g
	ON g.Id = ug.GameId
	WHERE g.[Name] = @gameName
	GROUP BY ug.GameId, ug.Cash, [Name]
) AS d
WHERE d.RowRanking % 2 = 1


SELECT * FROM dbo.ufn_CashInUsersGames('Aithusa')


