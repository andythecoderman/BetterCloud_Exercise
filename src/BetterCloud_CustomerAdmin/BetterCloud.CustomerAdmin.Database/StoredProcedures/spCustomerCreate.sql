CREATE PROCEDURE [dbo].[spCustomerCreate]
	@CustomerId uniqueidentifier OUTPUT,
	@Email nvarchar(100) NULL,
	@Phone nvarchar(20) NULL,
	@FirstName nvarchar(100) NULL,
	@LastName nvarchar(100) NULL,
	@DOB datetime NULL,
	@Gender char NULL,
	@Street nvarchar(100) NULL,
	@City nvarchar(100) NULL,
	@State char(2) NULL,
	@PostalCode char(10) NULL,
	@Country char(3) NULL,
	@Suite nvarchar(20) NULL,
	@Latitude float NULL,
	@Longitude float NULL	
AS

IF @CustomerId IS NULL SELECT @CustomerId = NEWID() 

DECLARE @AddrId int

BEGIN TRANSACTION "Create_Customer"
BEGIN TRY
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

	INSERT INTO Customer (
		CustomerId,
		Email,
		Phone,
		FirstName,
		LastName,
		DOB,
		Gender,
		AddressId
	)
	VALUES (
		@CustomerId,
		@Email,
		@Phone,
		@FirstName,
		@LastName,
		@DOB,
		@Gender,
		@AddrId
	)
COMMIT TRANSACTION;

END TRY
BEGIN CATCH
	-- TODO Add better error messageing 
	ROLLBACK TRANSACTION;
END CATCH
