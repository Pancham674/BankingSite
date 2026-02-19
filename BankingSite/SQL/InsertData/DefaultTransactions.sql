INSERT INTO [dbo].[Transaction]
           ([Date]
           ,[Amount]
           ,[IntendedUse]
           ,[Type]
           ,[AccountReceiver_ID]
           ,[AccountSender_ID])
     VALUES
           ('02.08.2024'
           ,1000
           ,'You still owe me a TON, don''t forget...'
           ,'Transfer'
           ,(SELECT TOP 1 ID
             FROM [dbo].[Account]
             WHERE IBAN = 'DE223564857234567891'
             ORDER BY ID DESC)
           ,(SELECT TOP 1 ID
             FROM [dbo].[Account]
             WHERE IBAN = 'DE223564857926649875'
             ORDER BY ID DESC))

INSERT INTO [dbo].[Transaction]
           ([Date]
           ,[Amount]
           ,[IntendedUse]
           ,[Type]
           ,[AccountReceiver_ID]
           ,[AccountSender_ID])
     VALUES
           ('24.03.2014'
           ,30340
           ,'Transferring into main account'
           ,'Transfer'
           ,(SELECT TOP 1 ID
             FROM [dbo].[Account]
             WHERE IBAN = 'DE84398943065064275'
             ORDER BY ID DESC)
           ,(SELECT TOP 1 ID
             FROM [dbo].[Account]
             WHERE IBAN = 'DE77394755926647212'
             ORDER BY ID DESC))

INSERT INTO [dbo].[Transaction]
           ([Date]
           ,[Amount]
           ,[IntendedUse]
           ,[Type]
           ,[AccountReceiver_ID]
           ,[AccountSender_ID])
     VALUES
           ('15.05.2025'
           ,50
           ,'Getting my cash money'
           ,'Withdrawal'
           ,(SELECT TOP 1 ID
             FROM [dbo].[Account]
             WHERE IBAN = 'DE223564857926647212'
             ORDER BY ID DESC)
           ,(SELECT TOP 1 ID
             FROM [dbo].[Account]
             WHERE IBAN = 'DE223564857926647212'
             ORDER BY ID DESC))
