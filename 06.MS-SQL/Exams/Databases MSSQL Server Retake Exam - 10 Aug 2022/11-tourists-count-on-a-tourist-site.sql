CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(MAX))
RETURNS INT
BEGIN
DECLARE @result INT

	SELECT 
		@result = COUNT(*) 
		FROM SitesTourists AS st
	JOIN Sites AS s ON s.Id = st.SiteId
	WHERE s.[Name] = @Site
	RETURN @result
END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')