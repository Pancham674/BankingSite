CREATE TRIGGER T_AccountDeleted
ON [dbo].[Account]
INSTEAD OF DELETE
AS
	SET NOCOUNT ON
	DELETE FROM [dbo].[Transaction]
	WHERE AccountReceiver_ID IN (SELECT ID FROM deleted)
	OR AccountSender_ID IN (SELECT ID FROM deleted)

	DELETE FROM [dbo].[Account]
	WHERE ID IN (SELECT ID FROM deleted)