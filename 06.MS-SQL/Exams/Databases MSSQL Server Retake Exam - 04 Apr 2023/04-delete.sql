BEGIN TRANSACTION

	Delete i
		FROM Invoices AS i
	JOIN Clients AS c ON c.Id = i.ClientId
	WHERE c.NumberVAT LIKE 'IT%'

	DELETE pc
		FROM ProductsClients AS pc
	JOIN Clients AS c ON c.Id = pc.ClientId
	WHERE c.NumberVAT LIKE 'IT%'

	DELETE Clients
	WHERE NumberVAT LIKE 'IT%'

ROLLBACK TRANSACTION

