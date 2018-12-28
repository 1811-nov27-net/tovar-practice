-- DML
-- Database Manipulation Language
-- the subset of SWL which accesses and modifies individual rows.
-- SELECT, INSERT, UPDATE, and DELETE, TRUNCATE TABLE

-- SELECT is by far the more complicated

SELECT * 
FROM SalesLT.Address;

-- INSERT
--  simple insert with all columns or at least the first few.
INSERT INTO SalesLT.Address Values
('123 Dallas St', NULL, 'Dallas', 'Texas', 'United States', '12345', '268AF621-76D7-4C78-9441-144FD139821z', GETUTCDATE());

-- better insert, more readable - be explicit about columns
INSERT INTO SalesLT.Address(AddressLine1, City, StateProvince, CountryRegion, PostalCode)
VALUES 
(
'123 Dallas St', 'Dallas', 'Texas', 'United States', '12345'
);

-- there are ways to do bulk inserts from things like CSV Files
-- BULK INSERT SalesLT.Address FROM 'data.csv' WITH (FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');

INSERT INTO SalesLT.Address(AddressLine1, City, StateProvince, CountryRegion, PostalCode)
	SELECT AddressLine1, City, StateProvince, CountryRegion, REVERSE(PostalCode)
	FROM SalesLT.Address
	WHERE ModifiedDate > '2018' -- YEAR(ModifiedDate) >= 2018

SELECT AddressLine1, City, StateProvince, CountryRegion, PostalCode
INTO #my_table
FROM SalesLT.Address
WHERE ModifiedDate > '2018'

-- UPDATE
SELECT * FROM SalesLT.Address WHERE YEAR(ModifiedDate) >= 2018;

UPDATE SalesLT.Address
SET AddressLine2 = 'Apt 45'
WHERE YEAR(ModifiedDate) >= '2018'

UPDATE SalesLT.Address
SET AddressLine2 = 'Apt 45',
	PostalCode = (

	)

-- DELETE

-- delete every row in the table(slow way, one by one)
-- DELETE FROM SalesLT.Address;

DELETE FROM SalesLT.Address
WHERE ModifiedDate > '2018'

-- TRUNCATE TABLE deletes every row in the table all at once, fast way.
-- (table itselt still existst, but empty)
-- TRUNCATE TABLE SalesLT.Address