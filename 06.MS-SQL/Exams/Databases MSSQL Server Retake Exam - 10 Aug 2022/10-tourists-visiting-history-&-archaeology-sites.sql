SELECT DISTINCT 
	RIGHT(t.[Name], LEN(t.[Name]) - CHARINDEX(' ', t.[Name])) AS LastName,
	t.Nationality,
	t.Age,
	t.PhoneNumber
	FROM Tourists AS t
JOIN SitesTourists AS st ON st.TouristId = t.Id
JOIN Sites AS s ON s.Id = st.SiteId
JOIN Categories AS c ON c.Id = s.CategoryId
WHERE c.[Name] = 'History and archaeology'
ORDER BY LastName
