SELECT d.ContinentCode, d.CurrencyCode, d.CurrencyUsage	
FROM
(
SELECT  c.ContinentCode, c.CurrencyCode,
	COUNT(c.CountryCode) as CurrencyUsage,
	DENSE_RANK()
	OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) Currency
	FROM Countries as c
	GROUP BY c.ContinentCode, c.CurrencyCode
	HAVING COUNT(C.CurrencyCode) > 1
) AS d
WHERE Currency = 1
ORDER BY d.ContinentCode