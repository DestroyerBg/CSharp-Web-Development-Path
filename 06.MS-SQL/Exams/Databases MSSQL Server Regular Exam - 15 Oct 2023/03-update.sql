UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE CONCAT_WS(' ', DATEPART(MONTH, ArrivalDate), DATEPART(YEAR, ArrivalDate)) = '12 2023'


UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

