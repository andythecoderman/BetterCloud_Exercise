CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CustomerId] UNIQUEIDENTIFIER NOT NULL  DEFAULT newid(), 
    [Email] NVARCHAR(100) NULL, 
    [Phone] NVARCHAR(20) NULL, 
    [FirstName] NVARCHAR(100) NULL, 
    [LastName] NVARCHAR(100) NULL, 
    [DOB] DATETIME NULL, 
    [Gender] CHAR NULL, 
    [AddressId] INT NULL, 
    CONSTRAINT [CK_Customer_CustomerId] UNIQUE (CustomerId)
)

GO

CREATE INDEX [IX_Customer_CustomerId] ON [dbo].[Customer] (CustomerId)
