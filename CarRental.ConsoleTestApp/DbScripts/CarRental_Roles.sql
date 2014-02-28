INSERT INTO [CarRental].[dbo].[CarRentalRole]
           ([Name]
           ,[IsActive]
           ,[IsDeleted]
           ,[CreatedDtm]
           ,[UpdatedDtm])
     VALUES
           (
              'Admin',
              1,0,GETDATE(),null
           
           ),
           (
              'Guest User',
              1,0,GETDATE(),null
           
           ),
           (
              'Normal User',
              1,0,GETDATE(),null
           
           )