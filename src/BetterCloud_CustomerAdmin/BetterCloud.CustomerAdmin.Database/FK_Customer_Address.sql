ALTER TABLE [dbo].[Customer]
	ADD CONSTRAINT [FK_Customer_Address]
	FOREIGN KEY (Address)
	REFERENCES [Address] (Id)
