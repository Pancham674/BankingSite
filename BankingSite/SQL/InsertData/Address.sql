INSERT INTO [dbo].[Address] ([StreetName], [StreetNumber], [ZipCode], [City])
VALUES (@StreetName, @StreetNumber, @ZipCode, @City);

SELECT * FROM [Address]
WHERE (ID = SCOPE_IDENTITY())