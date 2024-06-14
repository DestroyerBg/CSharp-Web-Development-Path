BEGIN TRANSACTION
	DELETE tb
		FROM TouristsBonusPrizes AS tb
	JOIN BonusPrizes AS b ON b.Id = tb.BonusPrizeId
	WHERE b.[Name] = 'Sleeping bag'
	DELETE 
		FROM BonusPrizes 
	WHERE [Name] = 'Sleeping bag'
ROLLBACK TRANSACTION

