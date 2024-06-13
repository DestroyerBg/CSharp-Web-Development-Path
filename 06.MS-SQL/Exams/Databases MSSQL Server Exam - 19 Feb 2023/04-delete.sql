BEGIN TRANSACTION
	DELETE cb  
		FROM CreatorsBoardgames AS cb
	JOIN Boardgames AS b ON b.Id = cb.BoardgameId
	JOIN Publishers AS p ON p.Id = b.PublisherId
	JOIN Addresses AS a ON a.Id = p.AddressId
	WHERE a.Town LIKE 'L%'


	DELETE b
		FROM Boardgames AS b
	JOIN Publishers AS p ON p.Id = b.PublisherId
	JOIN Addresses AS a ON a.Id = p.AddressId
	WHERE a.Town LIKE 'L%'

	DELETE p
		FROM Publishers AS p
	JOIN Addresses AS a ON a.Id = p.AddressId
	WHERE a.Town LIKE 'L%'


	DELETE a
		FROM Addresses AS a
	WHERE a.Town LIKE 'L%'

ROLLBACK TRANSACTION



