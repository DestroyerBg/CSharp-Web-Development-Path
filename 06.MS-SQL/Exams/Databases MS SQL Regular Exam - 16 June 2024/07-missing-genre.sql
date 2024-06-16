SELECT 
	DISTINCT
	l.[Name],
	c.Email
	FROM Libraries AS l
JOIN LibrariesBooks AS lb ON lb.LibraryId = l.Id
JOIN Books AS b ON b.Id = lb.BookId
JOIN Genres AS g ON g.Id = b.GenreId
JOIN Contacts AS c ON c.Id = l.ContactId
WHERE NOT EXISTS
(
	SELECT 1
    FROM LibrariesBooks AS lb2
    JOIN Books AS b2 ON b2.Id = lb2.BookId
    JOIN Genres AS g2 ON g2.Id = b2.GenreId
    WHERE lb2.LibraryId = l.Id
      AND g2.[Name] = 'mystery'
)
ORDER BY l.[Name]