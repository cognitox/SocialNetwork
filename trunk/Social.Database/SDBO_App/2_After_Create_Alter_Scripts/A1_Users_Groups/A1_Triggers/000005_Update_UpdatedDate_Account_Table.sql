/*************************************************************
** File:    000005_Update_UpdatedDate_Account_Table.sql
** Name:	[dbo].[Account_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[Account_Update_UpdatedDate]    Script Date: 8/29/2014 11:52:01 PM ******/

CREATE TRIGGER [dbo].[Account_Update_UpdatedDate]
ON [dbo].[Account]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.Account SET UpdatedDate=GETDATE() 
        WHERE AccountID IN (SELECT AccountID FROM INSERTED) 
END 
