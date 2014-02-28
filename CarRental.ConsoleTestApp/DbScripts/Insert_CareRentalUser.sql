USE CarRental
GO

Create PROCEDURE dbo.CarRental_InsertUser (
	 @UserId INT OUTPUT
	,@RoleId INT
	,@FirstName VARCHAR(50)
	,@LastName VARCHAR(50)
	,@EmailAddress VARCHAR(25)
	,@Password VARBINARY(500)
	,@IsActive BIT
	)
AS
BEGIN
	
	
	
	INSERT INTO [CarRental].[dbo].[CarRentalUser]
           ([RoleId]
           ,[EmailAddress]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[CreatedDtm]
           ,[UpdateDtm]
           ,[IsActive])
     VALUES
           (
               @RoleId,
               @EmailAddress,
               @FirstName,
               @LastName,
               @Password,
               GETDATE(),
               null,
               1           
           )
           
           set @UserId = SCOPE_IDENTITY();
           
           select @UserId
END
