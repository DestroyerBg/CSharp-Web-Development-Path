SELECT SUM(d.[Difference]) 
FROM
(SELECT 
	FirstName AS MainWizardName,
	DepositAmount AS MainWizardDeposit,
	LEAD(FirstName) OVER(ORDER BY Id) AS GuestWizardName,
	LEAD(DepositAmount) OVER(ORDER BY Id) AS GuestWizardDeposit,
	(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)) AS [Difference]
	FROM WizzardDeposits
) AS d