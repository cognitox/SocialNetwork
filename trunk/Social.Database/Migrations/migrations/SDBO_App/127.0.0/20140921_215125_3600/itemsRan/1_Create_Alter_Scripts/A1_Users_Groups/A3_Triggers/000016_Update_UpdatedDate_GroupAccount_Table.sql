/*************************************************************
** File:    000016_Update_UpdatedDate_GroupAccount_Table.sql
** Name:	[dbo].[GroupAccount_Update_UpdatedDate]
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
USE {{DatabaseName}}
GO

/****** Object:  Trigger [dbo].[GroupAccount_Update_UpdatedDate]    Script Date: 8/30/2014 12:05:04 AM ******/

CREATE TRIGGER [dbo].[GroupAccount_Update_UpdatedDate]
ON [dbo].[GroupAccount]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccount SET UpdatedDate=GETDATE() 
        WHERE GroupAccountID IN (SELECT GroupAccountID FROM INSERTED) 
END 


