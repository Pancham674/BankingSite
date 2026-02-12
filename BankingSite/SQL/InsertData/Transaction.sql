INSERT INTO [Transaction] (Date, Amount, IntendedUse, Type, AccountReceiver_ID, AccountSender_ID)
VALUES (@Date,@Amount,@IntendedUse,@Type,@AccountReceiver_ID,@AccountSender_ID); 

SELECT ID, Date, Amount, IntendedUse, Type, AccountReceiver_ID, AccountSender_ID FROM [Transaction] WHERE (ID = SCOPE_IDENTITY())