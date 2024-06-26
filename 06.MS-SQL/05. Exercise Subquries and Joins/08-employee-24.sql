SELECT e.EmployeeID, e.FirstName, 
	CASE
	WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name]
	END AS ProjectName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects as ep
	ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p
	ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24