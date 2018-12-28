-- Show the first name and the email address of customer with CompanyName 'Bike World'

SELECT FirstName, LastName
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World'; -- returns two rows

-- Show the CompanyName for all customers with an address in City 'Dallas'

SELECT c.CompanyName
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID
WHERE a.City = 'Dallas';

-- How many items with ListPrice more than $1000 have been sold?
SELECT COUNT(ListPrice) as Count
FROM SalesLT.Product
WHERE ListPrice > 1000;

SELECT sum sod
FROM SalesLT. SalesOrderDetail
-- Give the CompanyName of those customers with orders over $100000. Include the subtotal plus tax plus freight.
SELECT c.CompanyName
FROM SalesLT.Customer as c
	INNER JOIN SalesLT.SalesOrderHeader AS so ON c.CustomerID = so.CustomerID
WHERE so.TotalDue > $100000;

-- Find the number of left racing socks ('Racing Socks, L') ordered by CompanyName 'Riding Cycles'.

SELECT Name
FROM SalesLT.Product;
SELECT *
FROM SalesLT.Customer;
SELECT *
FROM SalesLT.SalesOrderHeader;
SELECT *
FROM SalesLT.SalesOrderDetail;

SELECT COUNT(sd.OrderQty)
FROM SalesLT.Customer AS c
		INNER JOIN SalesLT.SalesOrderHeader AS so ON c.CustomerID = so.CustomerID
		INNER JOIN SalesLT.SalesOrderDetail AS sd ON so.CustomerID = sd.ProductID
		INNER JOIN SalesLT.Product AS p ON sd.ProductID = p.Name
WHERE p.Name = 'Racing Socks, L';

