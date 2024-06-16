BEGIN TRANSACTION

UPDATE c
SET c.Website = (CONCAT_WS('.', 'www',(LOWER(a.[Name])),'com'))
	FROM Contacts AS c
JOIN Authors AS a ON a.ContactId = c.Id
WHERE c.Website IS NULL

UPDATE Contacts
	SET Website = REPLACE(Website, ' ', '')

SELECT * FROM Authors AS a 
JOIN Contacts AS c ON c.Id = a.ContactId

ROLLBACK TRANSACTION




