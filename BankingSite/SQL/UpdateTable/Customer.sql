UPDATE Customer
SET 
FirstName = @FirstName,
LastName = @LastName,
PhoneNumber = @PhoneNumber,
EmailAddress = @EmailAddress,
Address_ID =   (SELECT ID FROM Address
				WHERE ID = @AddressID)
WHERE ID = @ID