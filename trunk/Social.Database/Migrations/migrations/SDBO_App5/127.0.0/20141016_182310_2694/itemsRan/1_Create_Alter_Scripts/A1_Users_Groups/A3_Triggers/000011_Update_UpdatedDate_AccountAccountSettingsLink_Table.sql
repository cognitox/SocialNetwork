/*************************************************************
** File:    000011_Update_UpdatedDate_AccountAccountSettingsLink_Table.sql
** Name:	[dbo].[AccountAccountSettingsLink_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[AccountAccountSettingsLink_Update_UpdatedDate]    Script Date: 8/30/2014 12:00:00 AM ******/

CREATE TRIGGER [dbo].[AccountAccountSettingsLink_Update_UpdatedDate]
ON [dbo].[AccountAccountSettingsLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.AccountAccountSettingsLink SET UpdatedDate=GETUTCDATE() 
        WHERE AccountAccountSettingsLinkID IN (SELECT AccountAccountSettingsLinkID FROM INSERTED) 
END 
