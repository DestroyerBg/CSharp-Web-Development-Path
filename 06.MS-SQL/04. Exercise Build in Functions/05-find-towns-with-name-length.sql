SELECT [Name]
	FROM Towns
	WHERE LEN([NAME]) IN (5,6)
	ORDER BY [NAME]