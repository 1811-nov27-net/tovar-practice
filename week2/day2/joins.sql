-- joins combine data from two tables in one SELECT.
-- inner left, right, full outer, and across
-- (self for joining with same table)

SELECT * FROM SalesLT.Customer;
SELECT * FROM SalesLT.CustomerAddress;
SELECT * FROM SalesLT.Address;

-- get the name and address of all customers.
SELECT c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a on ca.AddressID = a.AddressID
WHERE a.City = 'Houston' AND a.StateProvince = 'Texas';

-- find all customers with multiple addresses
SELECT c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a on ca.AddressID = a.AddressID
WHERE a.AddressLine2 != 'NULL' AND a.AddressLine1 != 'NULL';

-- find any addresses with any names
-- addresses with no customer and customers with no address
SELECT c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince
FROM SalesLT.Customer AS c
	FULL OUTER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	FULL OUTER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID;

-- subqueries are an alternative way to accomplish that joins do.

-- we have operators like IN (checking membership in a list), NOT IN, EXISTS
-- ANY or ALL (checking for all true or any true in boolean list)
-- (in SQL, boolean is "BIT)

-- get the name and address fo all customers in Houston.
SELECT CustomerID
FROM SalesLT.CustomerAddress
WHERE AddressID IN
	(
	SELECT CustomerID
	FROM SalesLT.CustomerAddress
	WHERE AddressID IN
	(
		SELECT AddressID
		FROM SalesLT.Address
		WHERE City = 'Houston' AND StateProvince = 'Texas'
		)
		);

-- every first name that is also a last name with join

SELECT DISTINCT c.FirstName
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.Customer AS a ON c.FirstName = a.LastName;

-- every first name that is also a last name with subquery

SELECT DISTINCT FirstName
FROM SalesLT.Customer
WHERE FirstName IN (
	SELECT LastName
	FROM SalesLT.Customer
);

-- all the first names and last names starting with A
SELECT FirstName FROM SalesLT.Customer WHERE FirstName LIKE 'A%'	
UNION
SELECT FirstName FROM SalesLT.Customer WHERE LastName LIKE 'A%'	
	
-- all the set operaytors "by default" remove dublicates.
-- bu they all have "ALL" versions - UNION ALL, INTERSECT ALL, and EXCEPT ALL

-- with UNIOR ALL, we see the dublicates. the ALL versions are always faster.
-- (no loop to remove dublicates)
SELECT FirstName FROM SalesLT.Customer WHERE FirstName LIKE 'A%'	
UNION ALL
SELECT FirstName FROM SalesLT.Customer WHERE LastName LIKE 'A%'	

-- UNION gives all records in EITHER of the two results sets
-- INTERSECT gives all records in BOTH result sets
-- EXCEPT gives all records in the FIRST BUT NOT in the SECOND result set

-- every first name that is also a last name with set operators
SELECT FirstName FROM SalesLT.Customer	
INTERSECT
SELECT LastName FROM SalesLT.Customer

-- people with same first anme and last name
SELECT * FROM SalesLT.Customer WHERE FirstName = LastName

-- NULL represents a missing piece of data
-- all comparisons with NULL come out false, even = NULL
-- all things combine with null come out null.

-- use "IS NULL" to check for something being null

-- we have COALESCE function which takes in a list, returns a list
-- with all the NULLs coverted to something else