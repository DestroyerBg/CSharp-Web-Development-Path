CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	ALTER TABLE Employees
	ALTER COLUMN DepartmentID INT NULL


	DELETE ep
		FROM EmployeesProjects AS ep
	JOIN Employees AS e
	ON ep.EmployeeID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId

	UPDATE d 
	SET ManagerID = NULL
	FROM Departments AS d
	JOIN Employees AS e
	ON e.DepartmentID = d.DepartmentID
	WHERE e.DepartmentID = @departmentId


	UPDATE Employees
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	UPDATE Employees
	SET DepartmentID = NULL
	WHERE DepartmentID = @departmentId

	DELETE 
		FROM Departments
	WHERE DepartmentID = @departmentId

	DELETE 
		FROM Employees
	WHERE DepartmentID = @departmentId

	

	SELECT COUNT(*) 
		FROM Employees
	WHERE DepartmentID = @departmentId

END

EXEC usp_DeleteEmployeesFromDepartment @departmentId = 5

