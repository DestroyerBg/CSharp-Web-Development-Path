SELECT MIN(d.AverageSalary) 
FROM
(
SELECT e.DepartmentID,
		AVG(e.Salary) as AverageSalary
	FROM Employees as e
	GROUP BY e.DepartmentID
) AS d	