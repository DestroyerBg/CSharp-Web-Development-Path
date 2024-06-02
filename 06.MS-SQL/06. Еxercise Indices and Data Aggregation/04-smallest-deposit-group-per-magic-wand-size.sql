SELECT TOP(2) d.DepositGroup ,MIN(d.Average)
FROM
(SELECT DepositGroup,
	AVG(MagicWandSize) AS Average
FROM WizzardDeposits
GROUP BY DepositGroup) AS d
GROUP BY d.Average, d.DepositGroup
ORDER BY MIN(d.Average)