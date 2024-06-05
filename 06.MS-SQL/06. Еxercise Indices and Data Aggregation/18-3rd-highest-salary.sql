SELECT DISTINCT d.DepartmentID,
		d.Salary AS ThirdHighestSalary
FROM
(
SELECT
	DepartmentID,
	Salary,
	DENSE_RANK()
	OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRanking
	FROM Employees
) AS d
WHERE d.SalaryRanking = 3