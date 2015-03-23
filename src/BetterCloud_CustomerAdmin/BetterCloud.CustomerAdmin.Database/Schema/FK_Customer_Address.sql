ALTER TABLE [dbo].[Customer]
	ADD CONSTRAINT [FK_Customer_Address]
	FOREIGN KEY ([AddressId])
	REFERENCES [Address] (Id)
