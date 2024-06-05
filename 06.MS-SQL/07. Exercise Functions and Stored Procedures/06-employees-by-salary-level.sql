CREATE PROCEDURE usp_EmployeesBySalaryLevel @LevelOfSalary NVARCHAR(50)
AS
BEGIN
	SELECT FirstName,
			LastName
		FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
END

EXEC usp_EmployeesBySalaryLevel @LevelOfSalary = 'High'