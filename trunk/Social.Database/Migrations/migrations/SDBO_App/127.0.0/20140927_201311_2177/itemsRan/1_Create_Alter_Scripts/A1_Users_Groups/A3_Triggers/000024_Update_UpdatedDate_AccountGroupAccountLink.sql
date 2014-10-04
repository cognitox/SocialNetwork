/*************************************************************
** File:    000024_Update_UpdatedDate_AccountGroupAccountLink.sql
** Name:	[dbo].[AccountGroupAccountLink_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountGroupAccountLink_Update_UpdatedDate]    Script Date: 8/30/2014 12:21:09 AM ******/

CREATE TRIGGER [dbo].[AccountGroupAccountLink_Update_UpdatedDate]
ON [dbo].[AccountGroupAccountLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountGroupAccountLink SET UpdatedDate=GETDATE() 
        WHERE AccountGroupAccountLinkID IN (SELECT AccountGroupAccountLinkID FROM INSERTED) 
END 
