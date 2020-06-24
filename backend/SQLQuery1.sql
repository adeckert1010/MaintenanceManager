
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
--IF EXISTS(select * from sys.databases where name='DemoDB')
DROP DATABASE IF EXISTS MaintenanceManager;
GO

-- Create a new DemoDB Database
CREATE DATABASE MaintenanceManager;
GO

-- Switch to the DemoDB Database
USE MaintenanceManager;
GO

BEGIN TRANSACTION;

CREATE TABLE vehiclesByYear
(
	id			int	   identity(1,1),
	year_made	int			not null,
	make		varchar(MAX)		not null
)
COMMIT

ALTER TABLE dbo.vehicles
ADD CONSTRAINT DF_year_made
DEFAULT 2020 FOR year_made;

DECLARE @JSON_TABLE VARCHAR(MAX)

SELECT @JSON_TABLE = BulkColumn
FROM OPENROWSET(BULK 'E:\AllenDeckert\Documents\GitHub\MaintenanceManager\apiResponses\Makes\2020.json', SINGLE_CLOB)T


INSERT INTO dbo.vehicles (make) SELECT value
FROM OPENJSON(@JSON_TABLE, '$.data')

