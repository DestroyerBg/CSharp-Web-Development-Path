SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects as ep
	ON ep.EmployeeID = e.EmployeeID
	WHERE ep.ProjectID is NULL
	ORDER BY e.EmployeeID


