SELECT TOP(10)
	e.FirstName,
	e.LastName,
	e.DepartmentID
	FROM Employees AS e
JOIN
(
	SELECT DepartmentID,
			AVG(Salary) AS AverageSalaries
		FROM Employees
	GROUP BY DepartmentID
) AS AVGST
ON AVGST.DepartmentID = e.DepartmentID
WHERE e.Salary > AVGST.AverageSalaries
ORDER BY e.DepartmentID


--this solution looks greater but doesn't work on judge
SELECT DepartmentID,
		AVG(Salary) AS AverageSalary
	INTO AverageSalaries
	FROM Employees 
	GROUP BY DepartmentID


SELECT 
	e.FirstName, e.LastName, e.DepartmentID
FROM Employees  AS e
JOIN AverageSalaries AS [AVGS]
ON [AVGS].DepartmentID = e.DepartmentID
WHERE e.Salary > AVGS.AverageSalary
ORDER BY e.DepartmentID