/*************************************************************
** File:    000004_Update_UpdatedDate_AccountType_Table.sql
** Name:	[dbo].[AccountType_Update_UpdatedDate]
** Desc:	Database Trigger, Updates the UpdatedDate Column On Update
**
** Auth:	Justin Jarczyk
** Date:	8/29/2014
**************************
** Change History
**************************
** PR		Date			Author				Description	
** --		--------		-------				------------------------------------
** 1		8/29/2014		Justin Jarczyk		Created Script
**
**
**************************************************************/

/****** Object:  Trigger [dbo].[GroupAccountType_Update_UpdatedDate]    Script Date: 8/29/2014 11:51:35 PM ******/

CREATE TRIGGER [dbo].[AccountType_Update_UpdatedDate]
ON [dbo].[AccountType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountType SET UpdatedDate=GETDATE() 
        WHERE AccountTypeID IN (SELECT AccountTypeID FROM INSERTED) 
END 
