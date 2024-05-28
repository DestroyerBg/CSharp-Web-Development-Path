SELECT e.EmployeeID,e.FirstName, e.ManagerID, em.FirstName
	FROM Employees AS e
	RIGHT JOIN Employees em
	ON em.EmployeeID = e.ManagerID
	WHERE e.ManagerID IN (3,7) AND e.ManagerID IS NOT NULL
	ORDER BY e.EmployeeID

