-- DDL
-- Data Definition Language
-- for defining columns and tables, altering the structure of our database
-- does not have access to individual rows on their contents

-- CREATE, ALTER, DROP


CREATE SCHEMA PS;
GO 

-- GO seperates "batches" of commands
-- the red squigglies will compain if you don't put it for some commands that want to be in their own batch.
-- even though you're only going to send that command by itself with highlighting anyway

-- columns are nullable by default (aka null)
-- but you should always be explicit

DROP TABLE PS.Pizza

CREATE TABLE PS.Pizza
(
	PizzaID INT IDENTITY(0,1) NOT NULL, -- an
	Name NVARCHAR(100) NOT NULL,
	CrustID INT NOT NULL,
	ModifiedDate DATETIME2 NOT NULL,
	CreatorName NVARCHAR(100)
);

-- we can add constraints within CREATE TABLE
-- or afterwards with ALTER TABLE

ALTER TABLE PS.Pizza
	ADD CONSTRAINT PK_Pizza_PizzaID PRIMARY KEY (PizzaID);

ALTER TABLE PS.Pizza
	ADD CONSTRAINT U_Pizza_Name UNIQUE (Name);

CREATE TABLE PS.Crust
(
	CrustID INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL UNIQUE
);

ALTER TABLE PS.Pizza
	ADD CONSTRAINT FK_Pizza_Crust_CrustID FOREIGN KEY (CrustID) REFERENCES PS.Crust (CrustID);

-- that only this that actually accomplishes is make the database throw an error
-- if you violate refential integrity
-- (either delete or update or referenced PK Value, or, insert or update an
-- FK Value that doesn't exist in the reference table)

ALTER TABLE PS.Pizza
	DROP CONSTRAINT FK_Pizza_Crust_CrustID


ALTER TABLE PS.Pizza
	ADD CONSTRAINT FK_Pizza_Crust_CrustID FOREIGN KEY (CrustID) REFERENCES PS.Crust (CrustID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;

-- constraints
--	PRIMARY KEY
-- UNIQUE
-- FOREIGN KEY
-- NOT NULL (and NULL, kind of fake constraint)
-- DEFAULT
-- CHECK

-- we can add columsn with ALTER TABLE also.
--	(these columns must be nullable or have defaults if there's already rows in the table)

-- add an "Active" boolean column to enable "deleting" a row without actually deleting it. 
ALTER TABLE PS.Crust
	ADD Active BIT NOT NULL DEFAULT(1)

-- CHECK constraint is for any condition you want on the value.
ALTER TABLE PS.Pizza
	ADD CONSTRAINT CK_Pizza_DateNotInFuture CHECK (ModifiedDate <= GETDATE())

INSERT INTO PS.Crust (CrustID, Name) VALUES 
	(1, 'Plain')
INSERT INTO PS.Pizza (PizzaID, Name, CrustID, ModifiedDate) VALUES
	(1, 'Standard', 1, '2018-01-01');

SELECT * FROM PS.Crust;

-- demo cascade on delete - also deletes the pizza using this crust

DELETE FROM PS.Crust

SELECT * FROM PS.Pizza

ALTER TABLE PS.Pizza
	ADD CONSTRAINT D_Pizza_ModifiedDate DEFAULT GETUTCDATE() FOR ModifiedDate;
INSERT INTO PS.Pizza (PizzaID, Name, CrustID) VALUES 
(
1, 'Standard',1
);

-- we have "computed columns" in SQL
ALTER TABLE PS.Crust
	ADD InternalName AS (CONVERT (VARCHAR(20), CrustID) + '_' + Name); 
-- that one is recaculated on every query

ALTER TABLE PS.Pizza
	ADD InternalName AS (CONVERT (VARCHAR(20), PizzaID) + '_' + Name) PERSISTED; 
-- that one (PERSISTED) is calculated once and then stored until
-- the row is updated

-- aggregate functions
--		COUNT
--		SUM
--		AVG(average)
--		MIN
--		MAX

-- Views
-- views are not tables, but they can be treated like read-only tables.
-- they are like "computed columns" but for a whole table.

GO

CREATE VIEW PS.ActivePizzas
AS
SELECT CrustID, Name, InternalName
FROM PS.Crust
WHERE Active = 1;

-- user defined functions
GO

CREATE FUNCTION PS.FirstPizzaName()
	RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @ret NVARCHAR(100);
	SELECT TOP(1) @ret = Name
	FROM PS.Pizza

	RETURN @ret
END


SELECT PS.FirstPizzaName();

CREATE FUNCTION PS.FirstCrustName(@status BIT)
	RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @ret NVARCHAR(100);

	SELECT TOP(1) @ret = Name
	FROM PS.Crust
	WHERE Active = @status

	RETURN @ret
END

-- user defined functions can be table-valued (return value is a whole table)
GO 
CREATE FUNCTION PS.AllNames()
RETURNS TABLE
AS
	RETURN SELECT NAME FROM PS.Pizza UNION SELECT Name FROM PS.Crust;

SELECT * FROM PS.AllNames();

-- functions are not allowed to modify the database / insert rows, etc.
-- they are read-only access

-- if we want to modify the database in this encapsulated kind of way,
-- we use "store procedures"

-- functions can be used in SELECT clause and things like that, but procedures can't

GO 
CREATE PROCEDURE PS.ChangePizzaNames(@newname NVARCHAR(100))
AS 
BEGIN
	IF (EXISTS (SELECT * FROM PS.Pizza))  -- if there are any rows in the table
	BEGIN
		UPDATE PS.Pizza
		SET Name = @newname
	END
	ELSE
	BEGIN
		RAISERROR('No pizzas found', 16, 1)
	END
END

EXECUTE PS.ChangePizzaNames 'Great Pizza';

-- force people to call procedures rather than directly modifying the database directly

-- you can use functions in select statement and where clauses etc.
-- but you can't do that with procedures

-- transaction
--	a transaction is a set of statements which follow ACID properties
--	 A atomic
--		a transaction must be all-or-nthong. must not be allowed to partially succeed and then fail.
--		if there is a failure, we must be returned to be original state.
--	C consistent
--		a transaction is not allowed to violate DB constraints or refential integrity
--	I isolated / isolation
--		the behavior of one transaction should not interfere with that of another transaction
--		each transaction should be able to think of itself as the only one currently running
--		we compromise on "isolated" part of ACID heavily in practice
--	D durable / durability
--		effects/result must not only be in "viotile memory" --> RAM, they must be persisted to disk
--		or some permanent storage

-- in SQL Server, we have four isolation levels to give us flexibility in isolation
-- why? because full isolation is lower performace (and higher possibility of deadlock). 
--		read_uncommitted, read_committed (default), repeatable, serializable
 
-- every SQL statemetn by default is already a transaction in itself.
-- an error part-way throughh will result in roling back anything changed up to that point

-- with explicit "BEGIN TRANSACTION" 

-- Triggers
--		you can have 'trigger' for a change / update that is being attempted to be implemented on to the table
GO

CREATE TRIGGER PS.TR_Pizza ON PS.Pizza
AFTER UPDATE
AS
BEGIN
	-- in a trigger, you have access to two special tables
	-- called inserted and deleted
	-- (like git, we think of updates as an insert and a delete.)
	UPDATE PS.Pizza
	SET ModifiedDate = GETDATE()
	WHERE PizzaID in (SELECT PizzaID FROM inserted);
END

-- the trigger is on the whole statement
UPDATE PS.Pizza
SET Name = 'New Pizza'

-- triggers also support INSTEAD OF and BEFORE where i put AFTER. you can have one more than one trigger
-- if you want to.