CREATE PROCEDURE [dbo].[spCustomerGetAll]
AS
	SELECT *
	FROM Customer INNER JOIN Address 
	ON Customer.AddressId = Address.Id
