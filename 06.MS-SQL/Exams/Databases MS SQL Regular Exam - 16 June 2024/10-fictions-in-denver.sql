SELECT 
	a.[Name] AS Author,
	b.Title,
	l.[Name] AS [Library],
	c.PostAddress AS [Library Address]
	FROM Books AS b
JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
JOIN Authors AS a ON a.Id = b.AuthorId
JOIN Libraries AS l ON l.Id = lb.LibraryId
JOIN Genres AS g ON g.Id = b.GenreId
JOIN Contacts AS c ON c.Id = l.ContactId
WHERE g.[Name] = 'Fiction' AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title

