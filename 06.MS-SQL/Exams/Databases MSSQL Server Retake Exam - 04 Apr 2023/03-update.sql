UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE IssueDate >= '2022-11-01' AND IssueDate <= '2022-11-30'

UPDATE Clients
SET AddressId = 3
WHERE [Name] LIKE '%CO%'


