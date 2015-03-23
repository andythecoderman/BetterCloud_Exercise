CREATE PROCEDURE [dbo].[spCustomerUpdate]
	@CustomerId uniqueidentifier,
	@Email nvarchar(100),
	@Phone nvarchar(20),
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@DOB datetime,
	@Gender char,
	@Street nvarchar(100),
	@City nvarchar(100),
	@State char(2),
	@PostalCode char(10),
	@Country char(3),
	@Suite nvarchar(20),
	@Latitude float,
	@Longitude float	
AS
DECLARE @AddrId int
BEGIN TRANSACTION "Create_Customer"
BEGIN TRY
	SELECT @AddrId = AddressId 
	FROM Customer
	WHERE CustomerId = @CustomerId
	IF @AddrId IS NULL 
	BEGIN 
		-- Create Address Record for Customer
		INSERT INTO Address (
			Street,
			City,
			State,
			PostalCode,
			Country,
			Suite,
			Latitude,
			Longitude	
		)
		Values (
			@Street,
			@City,
			@State,
			@PostalCode,
			@Country,
			@Suite,
			@Latitude,
			@Longitude
		)
		SELECT @AddrId = SCOPE_IDENTITY();
	END
	ELSE 
		-- Update existing Address record
	BEGIN	
		UPDATE Address SET 
			Street = @Street,
			City = @City,
			State = @State,
			PostalCode = @PostalCode,
			Country = @Country,
			Suite = @Suite,
			Latitude = @Latitude,
			Longitude = @Longitude	
		WHERE Id = @AddrId
	END

	UPDATE Customer SET
		Email = @Email,
		Phone = @Phone,
		FirstName = @FirstName,
		LastName = @LastName,
		DOB = @DOB,
		Gender = @Gender,
		AddressId = @AddrId
	WHERE CustomerID = @CustomerId

COMMIT TRANSACTION;

END TRY
BEGIN CATCH
	-- TODO Add better error messageing 
	ROLLBACK TRANSACTION;
END CATCH

