CREATE SCHEMA EM;
GO

CREATE TABLE EM.Employee
(
	ID INT NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	SSN NVARCHAR(100) NOT NULL,
	DeptID INT NOT NULL
);


CREATE TABLE EM.EmptDetails
(
	ID INT NOT NULL,
	EmployeeID INT NOT NULL,
	Salary FLOAT NOT NULL,
	Address1 NVARCHAR(100) NOT NULL,
	Address2 NVARCHAR(100) NOT NULL,
	City NVARCHAR(100) NOT NULL,
	STATE NVARCHAR(100) NOT NULL,
	Country NVARCHAR(100) NOT NULL,
);

CREATE TABLE EM.Department
(
	ID INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Location NVARCHAR(100) NOT NULL,
);

INSERT INTO EM.Employee (ID ,FirstName, LastName, SSN, DeptID) VALUES
	(1, 'Tina', 'Smith', '123-545-4456',1);

INSERT INTO EM.Employee (ID ,FirstName, LastName, SSN, DeptID) VALUES
	(2, 'Axel', 'Tovar', '211-545-4456',1);

INSERT INTO EM.Employee (ID ,FirstName, LastName, SSN, DeptID) VALUES
	(3, 'Joel', 'Tovar', '111-545-4456',2);

INSERT INTO EM.Employee (ID ,FirstName, LastName, SSN, DeptID) VALUES
	(4, 'John', 'Sno', '111-545-4456',3);

SELECT *
FROM EM.Employee;

INSERT INTO EM.Department (ID, Name, Location) VALUES
	(1, 'Marketing', 'Arlington TX');
INSERT INTO EM.Department (ID, Name, Location) VALUES
	(2, 'Sales', 'Houston TX');
INSERT INTO EM.Department (ID, Name, Location) VALUES
	(3, 'Production', 'Austin TX');

SELECT *
FROM EM.Department;

INSERT INTO EM.EmptDetails(ID, EmployeeID, Salary, Address1, Address2, City, STATE, Country) VALUES
	(1, 12, 50000.00, '123 south', ' ', 'Dallas', 'Texas', 'US');
INSERT INTO EM.EmptDetails(ID, EmployeeID, Salary, Address1, Address2, City, STATE, Country) VALUES
	(2, 123, 60000.00, '123 north', ' ', 'Austin', 'Texas', 'US');
INSERT INTO EM.EmptDetails(ID, EmployeeID, Salary, Address1, Address2, City, STATE, Country) VALUES
	(3, 124, 650000.00, '123 west', ' ', 'Houston', 'Texas', 'US');
INSERT INTO EM.EmptDetails(ID, EmployeeID, Salary, Address1, Address2, City, STATE, Country) VALUES
	(4, 125, 77000.00, '123 east', ' ', 'Lufkin', 'Texas', 'US');

SELECT (FirstName + ' ' + LastName) AS FullName, d.Name
FROM EM.Department AS d
	INNER JOIN EM.Employee AS emp ON d.ID = emp.DeptID
WHERE emp.DeptID = 1;

SELECT SUM(ed.Salary)
FROM EM.EmptDetails AS ed
	INNER JOIN EM.Employee AS emp ON ed.ID = emp.DeptID
	INNER JOIN EM.Department AS d on emp.DeptID = d.ID
WHERE d.ID >= 1;