CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(50)
BEGIN
	DECLARE @Result NVARCHAR(50);
	IF @Salary < 30000
	BEGIN
		SET @Result = 'Low'
	END

	ELSE IF @Salary BETWEEN 30000 AND 50000
	BEGIN
		SET @Result = 'Average'
	END

	ELSE IF @Salary > 50000
	BEGIN
		SET @Result = 'High'
	END
	RETURN @Result
END

SELECT Salary,
	dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees