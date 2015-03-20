CREATE PROCEDURE [dbo].[spCustomerCreate]
	@CustomerId uniqueidentifier OUTPUT,
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
	@Longitude float,
	@AddrId int
AS

IF @CustomerId IS NULL SELECT @CustomerId = NEWID() 

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
