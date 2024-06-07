CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount @accountId INT, @interestRate DECIMAL(10,4)
AS
BEGIN
	SELECT	a.Id, 
			ah.FirstName, 
			ah.LastName, 
			a.Balance AS [Current Balance],
			dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
		FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON ah.Id = a.Id
	WHERE ah.Id = @accountId
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1