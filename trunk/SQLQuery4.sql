


-- milestone
-- review

--CREATE TABLE [CommitmentDocument]
--(
--	CommitmentDocumentID INT IDENTITY(1,1) PRIMARY KEY,
--	CommitmentMetaDataID INT NOT NULL,
--	Content VARBINARY NOT NULL,
--	Name VARCHAR(255) NOT NULL
--)



-- TODO
--CREATE TABLE [CommitmentDocument]
--(
--	CommitmentDocumentID INT IDENTITY(1,1) PRIMARY KEY,
--	CommitmentMetaDataID INT NOT NULL,
--	Content VARBINARY NOT NULL,
--	Name VARCHAR(255) NOT NULL
--)

/*
TODO, Change all of the account ID's to uniqueidentifier...
TODO, add in forign key constraints,
TODO, add in schema bindings
*/

----- diff metadata tables for each type of commitment...

---- Hold the meta data of an individual commitment
--CREATE TABLE [CommitmentMetaData]
--(
--	CommitmentMetaDataID INT IDENTITY(1,1) PRIMARY KEY,
--	-- b/c a commitment should be extensible and able to contain multiple types of sub commitments
--	CommitmentTypeID INT NOT NULL,
--	CommitmentStatusTypeID INT NOT NULL, -- individual status of commitments

--	-- alll common fields

--)

