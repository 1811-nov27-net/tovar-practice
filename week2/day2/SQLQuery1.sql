-- a comment
 -- first step: make sure the dropdown is set to the right DB, not "master"
-- ("USE adventureworks;" is usually how you switch DBs, but Azure SQL DB doesn't support it)
 -- basic SELECT query - all columns and all rows from a given table.
-- SalesLT is the schema name, Customer is the table name.
SELECT *
FROM SalesLT.Customer;
 -- highlight a command and press F5 (execute / play button) to run that command.

 SELECT 1+1;

 -- two clauses in the SELECT statement so far - SELECT clause and FROM clause.
 -- FROM clause specifies what table or tables we are looking inside
 -- and SELECT clause specifies the columns of our "result set"

 -- we can do calculations from the table's columns
 -- and name our result columns with "AS", even with hspaces, using "" or []

 SELECT CustomerID, Title, FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name],  Suffix
 FROM SalesLT.Customer;

 SELECT *
 FROM SalesLT.Product;

 SELECT Name, ProductNumber, ProductID, ListPrice * 1.08 AS [Price with Tax], ListPrice - StandardCost AS PROFIT
 FROM SalesLT.Product;

 SELECT Color, Size
 FROM SalesLT.Product; -- returns 295 rows

 SELECT DISTINCT Color, Size
 FROM SalesLT.Product; -- returns 295 rows

 SELECT DISTINCT p.ProductID, p.Color, p.Size
 FROM SalesLT.Product AS p; -- returns 295 rows

 -- WHERE clause
 -- allows filtering of rows basd on a condition (before any calculated columns in the SELECT Clause)

 SELECT *
 FROM SalesLT.Customer
 WHERE FirstName = 'Brian';

 -- we have boolen operators AND, OR
 -- we an group them with parentheses
 -- we have comparison's like = for equals
 SELECT *
 FROM SalesLT.Customer
 WHERE FirstName = 'Brian' AND LastName = 'Goldstein';

 -- not-equals is <> is !=
 SELECT *
 FROM SalesLT.Customer
 WHERE FirstName = 'Brian' AND LastName != 'Goldstein';

 -- we have ordered comparison with < <= > >=
 -- of numbers, dates, and also strings ("dictionary"/lexicographic ordering)

 -- excersice: all customers with first names that start with B

 SELECT *
 FROM SalesLT.Customer
 WHERE FirstName > 'B' AND FirstName < 'C';

 -- SQL supports, not regex, but some amount of its own pattern matching with LIKE operator.
 --		%	any number of characters
 --		[abc] either a, , or c
 --		
 SELECT *
 FROM SalesLT.Customer
 WHERE FirstName Like 'B[ar]%';

SELECT LEFT ('123456789',4);

-- data types 
--	numberic
--		tinyint, smallint, int, bigint
--			(1)	    (2)	   (4)	  (8)
--		float, real, decimal,
--			use decimal for basically all floating-point stuff
--				decimal as a type acceps parameters
--					decimal(10, 3) means 10 digits, with 3 of them after the decimal place.
--					i.e. 00000000.00
--		for currency values, we have money type

-- string
--		char(10) (fixed length length character array)
--		varchar(10)	(variable length up to 10 characters array)
--		nchar(10)	("national" aka unicode char array)
--		nvarchar(1)	(unicode variable length)
--	for the vrchars we can also pass "MAX" as parameter e.g. NVARCHAR(MAX)
--		no reason to not use NVARCHAR all the time

-- string literals are technically VARCHAR ('HELLO')
-- we can make Unicode string literals (NVARCHAR) like: N'HELLO;

-- we also have BINARY type and VARBINARY for storing binary data directly in the DB

-- date and time data types\
-- date, time, datetime
-- don't use datetime, use datetime2 because it hs more range
-- datetimeoffset (for intervals of time like "5 minutes")

-- we've seen SELECT, FROM, and WHERE
-- the other clauses are GROUP BY, HAVING, and ORDER BY.

-- group all rows by first name, and count the number of dublicates per name
SELECT FirstName, COUNT(FirstName) AS COUNT
FROM SalesLT.Customer
GROUP BY FirstName;

-- WHERE clause runs *before* the GROUP BY clause.
-- so we can't filter on any conditions that depend on the grouping.

-- e.g. if i wan tonly the FirstName that *have* dublicates, i can't use WHERE,
-- because the grouping hasn't happened yet, there's nothing to compare

SELECT FirstName, COUNT(FirstName) AS COUNT
FROM SalesLT.Customer
WHERE COUNT(FirstName) > 1
GROUP BY FirstName;

-- COUNT as an aggregate function, this means it operates on many values and returns just one value.
-- (unlike LENj for example, takes one string and returns a number)
-- you use COUNT with GROUP BY.

-- HAVING is for conditions that run AFTER the GROUP BY.
-- all first names besides Andrew that have any dublicates, and how many there are 
SELECT FirstName, COUNT(FirstName) AS COUNT
FROM SalesLT.Customer
WHERE FirstName != 'Andrew'
GROUP BY FirstName
HAVING COUNT(FirstName) > 1;

-- ORDER BY sorts the result set and it's the last thing that runs
SELECT *
FROM SalesLT.Product
ORDER BY StandardCost ASC;

-- execution order of a select statement
--	FROM
--	WHERE
--	GROUP BY
--	HAVING
--	ORDER BY
--	SELECT
--	(in order of writing it, except for SELECT.)
