CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(MAX))
AS
BEGIN
	SELECT 
		t.[Name],
		CASE
		WHEN COUNT(T.[Name]) >= 100 THEN 'Gold badge'
		WHEN COUNT(T.[Name]) >= 50 THEN 'Silver badge'
		WHEN COUNT(T.[Name]) >= 25 THEN 'Bronze badge'
		ELSE NULL
		END AS Reward
		FROM Tourists AS t
	JOIN SitesTourists AS st ON st.TouristId = t.Id
	JOIN Sites AS s ON s.Id = st.SiteId
	WHERE t.[Name] = @TouristName
	GROUP BY t.[Name]
END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Zac Walsh'