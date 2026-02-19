UPDATE [dbo].[Address]
SET 
StreetName = @StreetName,
StreetNumber = @StreetNumber,
ZipCode = @ZipCode,
City = @City
WHERE ID = @ID