CREATE TRIGGER T_CustomerDeleted
ON [dbo].[Customer]
INSTEAD OF DELETE
AS
	SET NOCOUNT ON
	DELETE FROM [dbo].[Account]
	WHERE Customer_ID IN (SELECT ID FROM deleted)

	DELETE FROM [dbo].[Customer]
	WHERE ID IN (SELECT ID FROM deleted)