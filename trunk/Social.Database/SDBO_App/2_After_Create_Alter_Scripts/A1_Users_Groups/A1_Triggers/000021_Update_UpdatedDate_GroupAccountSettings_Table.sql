/*************************************************************
** File:    000021_Update_UpdatedDate_GroupAccountSettings_Table.sql
** Name:	[dbo].[GroupAccountSettings_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountSettings_Update_UpdatedDate]    Script Date: 8/30/2014 12:11:41 AM ******/

CREATE TRIGGER [dbo].[GroupAccountSettings_Update_UpdatedDate]
ON [dbo].[GroupAccountSettings]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountSettings SET UpdatedDate=GETDATE() 
        WHERE GroupAccountSettingsID IN (SELECT GroupAccountSettingsID FROM INSERTED) 
END 

