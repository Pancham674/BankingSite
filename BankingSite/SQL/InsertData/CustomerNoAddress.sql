INSERT INTO Customer (FirstName, LastName, PhoneNumber, EmailAddress, Address_ID)
VALUES (@FirstName,@LastName,@PhoneNumber,@EmailAddress,NULL);

SELECT ID, FirstName, LastName, PhoneNumber, EmailAddress, Address_ID
FROM Customer
WHERE (ID = SCOPE_IDENTITY())