CREATE PROCEDURE [dbo].[spCustomerGetByCustomerId]
	@CustomerID uniqueidentifier
AS
	SELECT *
	FROM Customer INNER JOIN Address 
	ON Customer.AddressId = Address.Id
	WHERE CustomerId = @CustomerID