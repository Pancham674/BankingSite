UPDATE Customer
SET 
FirstName = @FirstName,
LastName = @LastName,
PhoneNumber = @PhoneNumber,
EmailAddress = @EmailAddress,
Address_ID = NULL
WHERE ID = @ID