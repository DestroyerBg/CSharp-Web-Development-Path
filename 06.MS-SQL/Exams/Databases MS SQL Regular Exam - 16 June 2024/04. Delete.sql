BEGIN TRANSACTION
	DELETE lb
		FROM LibrariesBooks AS lb
	JOIN Books AS b ON b.Id = lb.BookId
	JOIN Authors AS a ON a.Id = b.AuthorId
	WHERE a.[Name] = 'Alex Michaelides'

	DELETE b
		FROM Books AS b
	JOIN Authors AS a ON a.Id = b.AuthorId
	WHERE a.[Name] = 'Alex Michaelides'


	DELETE Authors
	WHERE [Name] = 'Alex Michaelides'

	SELECT * FROM Authors WHERE [Name] = 'Alex Michaelides'

ROLLBACK TRANSACTION
