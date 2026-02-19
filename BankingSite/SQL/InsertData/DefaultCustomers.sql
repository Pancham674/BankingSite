INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[EmailAddress]
           ,[Address_ID])
     VALUES
           ('Anno'
           ,'Nhyme'
           ,012238864
           ,'anno.nhyme@yahoo.com'
           , (SELECT TOP 1 ID FROM [dbo].[Address]
           WHERE StreetName = 'Ventura Blvd'
           AND StreetNumber = 68
           AND ZipCode = 91604
           AND City = 'Studio City'
           ORDER BY ID DESC))

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[EmailAddress]
           ,[Address_ID])
     VALUES
           ('Annie'
           ,'Nhyme'
           ,012238559
           ,'annie.nhyme@yahoo.com'
           ,(SELECT TOP 1 ID FROM [dbo].[Address]
           WHERE StreetName = 'Ventura Blvd'
           AND StreetNumber = 68
           AND ZipCode = 91604
           AND City = 'Studio City'
           ORDER BY ID DESC))

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[EmailAddress]
           ,[Address_ID])
     VALUES
           ('André'
           ,'Nhyme'
           ,012232195
           ,'andré.nhyme@gmail.com'
           ,(SELECT TOP 1 ID FROM [dbo].[Address]
           WHERE StreetName = 'Sinthers Path'
           AND StreetNumber = 8
           AND ZipCode = 93280
           AND City = 'Hollow City'
           ORDER BY ID DESC))

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[EmailAddress]
           ,[Address_ID])
     VALUES
           ('Salliek'
           ,'Songh'
           ,03341128
           ,'salliek.songh@gmail.com'
           ,(SELECT TOP 1 ID FROM [dbo].[Address]
           WHERE StreetName = 'Sinthers Path'
           AND StreetNumber = 8
           AND ZipCode = 93280
           AND City = 'Hollow City'
           ORDER BY ID DESC))
           
INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[EmailAddress]
           ,[Address_ID])
     VALUES
           ('Nunya'
           ,'Busnhess'
           ,034229987
           ,'nunya.bus@outlook.com'
           ,(SELECT TOP 1 ID FROM [dbo].[Address]
           WHERE StreetName = 'Tailors Way'
           AND StreetNumber = 41
           AND ZipCode = 93342
           AND City = 'Hollow City'
           ORDER BY ID DESC))

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[EmailAddress]
           ,[Address_ID])
     VALUES
           ('Minou'
           ,'CinKing'
           ,034229987
           ,'cKing.minou@outlook.com'
           ,(SELECT TOP 1 ID FROM [dbo].[Address]
           WHERE StreetName = 'Tailors Way'
           AND StreetNumber = 2
           AND ZipCode = 93342
           AND City = 'Hollow City'
           ORDER BY ID DESC))