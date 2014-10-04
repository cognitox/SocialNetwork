/*************************************************************
** File:    000022_Update_UpdatedDate_GroupAccountGroupAccountSettingsLink_Table.sql
** Name:	[dbo].[GroupAccountGroupAccountSettingsLink_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountGroupAccountSettingsLink_Update_UpdatedDate]    Script Date: 8/30/2014 12:19:13 AM ******/

CREATE TRIGGER [dbo].[GroupAccountGroupAccountSettingsLink_Update_UpdatedDate]
ON [dbo].[GroupAccountGroupAccountSettingsLink]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountGroupAccountSettingsLink SET UpdatedDate=GETDATE() 
        WHERE GroupAccountGroupAccountSettingsLinkID IN (SELECT GroupAccountGroupAccountSettingsLinkID FROM INSERTED) 
END 
