SELECT TOP(50) e.EmployeeID,
	CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName, 
	CONCAT_WS(' ', em.FirstName, em.LastName) AS ManagerName, 
	d.Name AS DepartmentName
	FROM Employees AS e
	RIGHT JOIN Employees em
	ON em.EmployeeID = e.ManagerID
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID
