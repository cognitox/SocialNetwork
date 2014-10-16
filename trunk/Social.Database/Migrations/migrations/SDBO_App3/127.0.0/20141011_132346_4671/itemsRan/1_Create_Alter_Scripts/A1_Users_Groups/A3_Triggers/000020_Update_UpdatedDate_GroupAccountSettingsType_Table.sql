/*************************************************************
** File:    000020_Update_UpdatedDate_GroupAccountSettingsType_Table.sql
** Name:	[dbo].[GroupAccountSettingsType_Update_UpdatedDate]
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

/****** Object:  Trigger [dbo].[GroupAccountSettingsType_Update_UpdatedDate]    Script Date: 8/30/2014 12:08:40 AM ******/

CREATE TRIGGER [dbo].[GroupAccountSettingsType_Update_UpdatedDate]
ON [dbo].[GroupAccountSettingsType]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UpdatedDate) 
        UPDATE dbo.GroupAccountSettingsType SET UpdatedDate=GETUTCDATE() 
        WHERE GroupAccountSettingsTypeID IN (SELECT GroupAccountSettingsTypeID FROM INSERTED) 
END 
