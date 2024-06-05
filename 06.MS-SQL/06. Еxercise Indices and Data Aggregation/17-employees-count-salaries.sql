SELECT COUNT(d.EmployeeID)
FROM
(
SELECT EmployeeID 
	FROM Employees
WHERE ManagerID IS NULL
) AS d