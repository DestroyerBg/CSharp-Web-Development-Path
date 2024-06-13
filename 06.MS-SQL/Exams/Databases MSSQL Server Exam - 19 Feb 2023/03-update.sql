UPDATE PlayersRanges
SET PlayersMax+=1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name]+='V2'
WHERE CAST(YearPublished AS INT) >= 2020




