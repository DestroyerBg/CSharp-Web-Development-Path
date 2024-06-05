CREATE OR ALTER FUNCTION ufn_IsWordComprised (@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
BEGIN
	DECLARE @Counter INT
	SET @Counter = 1
	WHILE @Counter <= LEN(@word)
		BEGIN
			IF CHARINDEX(SUBSTRING(@word, @Counter, 1), @setOfLetters) = 0
			BEGIN
				RETURN 0
			END
			ELSE
			SET @Counter+=1
		END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS Result

