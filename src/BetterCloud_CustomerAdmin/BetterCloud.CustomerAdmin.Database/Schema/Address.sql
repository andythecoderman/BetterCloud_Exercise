CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Street] NVARCHAR(100) NULL, 
    [City] NVARCHAR(100) NULL, 
    [State] CHAR(2) NULL, 
    [PostalCode] CHAR(10) NULL, 
    [Country] CHAR(3) NULL, 
    [Suite] NVARCHAR(20) NULL, 
    [Latitude] FLOAT NULL, 
    [Longitude] FLOAT NULL
)
